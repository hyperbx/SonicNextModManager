using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Sonic_06_Mod_Manager
{
    public partial class ModManager : Form
    {
        public static string versionNumber = "Version 1.0";
        public static string installState = "";
        public static bool isCreatorDisposed;
        string[] modArray;
        string modsPath;
        string s06Path;
        string xeniaPath;
        string arcPath;
        string ftpPath;
        string origArcPath;
        string targetArcPath;
        List<string> checkedModsList = new List<string>() { };

        public ModManager()
        {
            InitializeComponent();

            modsPath = Properties.Settings.Default.modsPath;
            modsBox.Text = Properties.Settings.Default.modsPath;
            s06Path = Properties.Settings.Default.s06Path;
            ftpPath = Properties.Settings.Default.ftpPath;
            if (check_FTP.Checked == true) s06PathBox.Text = Properties.Settings.Default.ftpPath;
            else s06PathBox.Text = Properties.Settings.Default.s06Path;
            xeniaPath = Properties.Settings.Default.xeniaPath;
            xeniaBox.Text = Properties.Settings.Default.xeniaPath;
        }

        public string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private void ModManager_Load(object sender, EventArgs e)
        {
            Text = $"Sonic '06 Mod Manager ({versionNumber})";

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool");
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php", Properties.Resources.arctoolphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php", Properties.Resources.unarcphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php", Properties.Resources.arccphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", Properties.Resources.arctool);

            RefreshMods();
            if (Directory.Exists(s06Path)) CleanUpMods();
            if (File.Exists($"{modsPath}\\mods.ini")) GetChecks();

            tm_CreatorDisposal.Start();

            if (Properties.Settings.Default.ftp == true)
            {
                check_FTP.Checked = true;
                playButton.Width = 186;
                playButton.Text = "Copy Mods";
            }
            else
            {
                check_FTP.Checked = false;
                playButton.Width = 282;
                playButton.Text = "Save and Play";
            }

            if (Properties.Settings.Default.ftpSystem == 0) combo_System.SelectedIndex = 0;
            else if (Properties.Settings.Default.ftpSystem == 1) combo_System.SelectedIndex = 1;
        }

        private void MergeARCs(string arc1, string arc2, string output, bool ftp, string ftpPath)
        {
            string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
            var tempData = new DirectoryInfo(tempPath);
            if (!ftp) Directory.CreateDirectory(tempPath);
            if (ftp) { tempPath = ftpPath; }
            if (!ftp)
            {
                File.Copy(arc1, Path.Combine(tempPath, Path.GetFileName(arc1)));
                if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
            }

            ProcessStartInfo arctool;

            arctool = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc1))}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack1 = Process.Start(arctool);
            Unpack1.WaitForExit();
            Unpack1.Close();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc1)));

            //if (arc1 != arc2) { Directory.Move(Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc1)), Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc2))); }

            File.Copy(arc2, Path.Combine(tempPath, Path.GetFileName(arc2)));

            arctool = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc2))}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack2 = Process.Start(arctool);
            Unpack2.WaitForExit();
            Unpack2.Close();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc2)));

            arctool = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc2))}\" -c \"{output}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack1 = Process.Start(arctool);
            Repack1.WaitForExit();
            Repack1.Close();

            if (!ftp)
            {
                try
                {
                    if (Directory.Exists(tempPath))
                    {
                        foreach (FileInfo file in tempData.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo directory in tempData.GetDirectories())
                        {
                            directory.Delete(true);
                        }
                    }
                }
                catch { return; }
            }
        }

        private void RefreshMods()
        {
            if (modArray != null)
            {
                Array.Clear(modArray, 0, modArray.Length);
            }
            if (modsPath == "")
            {
                MessageBox.Show("No Mods folder specified, select your SONIC THE HEDGEHOG (2006) Mods directory...",
                                "Sonic '06 Mod Manager",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                FolderBrowserDialog modPathBrowser = new FolderBrowserDialog();
                modPathBrowser.Description = "Select your SONIC THE HEDGEHOG (2006) Mods directory...";
                if (modPathBrowser.ShowDialog() == DialogResult.OK)
                {
                    modsPath = modPathBrowser.SelectedPath;
                    modsBox.Text = modsPath;
                }
                else{ Application.Exit(); }
            }

            if (!Directory.Exists(modsPath))
            {
                modList.Items.Clear();
                return;
            }
            modArray = Directory.GetDirectories(modsPath);
            modList.Items.Clear();
            foreach (string mod in modArray)
            {
                var modName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                modName = modName.Replace("\\", "");
                modList.Items.Add(modName);
            }
            Properties.Settings.Default.modsPath = modsPath;
            Properties.Settings.Default.Save();

            if (File.Exists($"{modsPath}\\mods.ini")) GetChecks();
        }

        private void GetChecks()
        {
            int totalMods = modList.Items.Count;
            string getSeek = File.ReadAllLines($"{modsPath}\\mods.ini")[1];
            string getOrigTotal = File.ReadAllLines($"{modsPath}\\mods.ini")[2];
            int.TryParse(getSeek.Substring(5, getSeek.Length - 5), out int seek);
            int.TryParse(getOrigTotal.Substring(6, getOrigTotal.Length - 6), out int origTotal);

            if (origTotal == totalMods)
            {
                foreach (int i in Enumerable.Range(3, seek))
                {
                    try
                    {
                        string currentSeek = File.ReadAllLines($"{modsPath}\\mods.ini")[i];
                        int.TryParse(currentSeek.Substring(currentSeek.LastIndexOf('=') + 1), out int index);
                        modList.SetItemChecked(index, true);
                    }
                    catch { return; }
                }
            }
            else
            {
                try { File.Delete($"{modsPath}\\mods.ini"); }
                catch { return; }
            }
        }

        private void SaveChecks()
        {
            string checkList = $"{modsPath}\\mods.ini";
            int checkTotal = 0;
            int item = 0;

            foreach (string items in modList.CheckedItems) { checkTotal++; }

            using (StreamWriter sw = File.CreateText(checkList))
            {
                sw.WriteLine("[Main]");
                sw.WriteLine($"Seek={checkTotal}");
                sw.WriteLine($"Total={modList.Items.Count}");
            }

            foreach (int check in modList.CheckedIndices)
            {
                using (StreamWriter sw = File.AppendText(checkList))
                {
                    sw.WriteLine($"\"{modList.Items[check]}\"={check}");
                }
            }

            using (StreamWriter sw = File.AppendText(checkList))
            {
                sw.WriteLine("\n[Mods]");
            }

            for (int i = 0; i < modList.Items.Count; i++)
            {
                using (StreamWriter sw = File.AppendText(checkList))
                {
                    sw.WriteLine($"Mod{i}=\"{modList.Items[i]}\"");
                }
            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshMods();
        }

        private void S06PathBox_TextChanged(object sender, EventArgs e)
        {
            if (!check_FTP.Checked)
            {
                s06Path = s06PathBox.Text;
                Properties.Settings.Default.s06Path = s06Path;
            }
            else
            {
                ftpPath = s06PathBox.Text;
                if (s06PathBox.Text == string.Empty) { s06PathBox.Text = "ftp://"; }
                Properties.Settings.Default.ftpPath = ftpPath;
            }
            Properties.Settings.Default.Save();
        }

        private void XeniaBox_TextChanged(object sender, EventArgs e)
        {
            xeniaPath = xeniaBox.Text;
            Properties.Settings.Default.xeniaPath = xeniaPath;
            Properties.Settings.Default.Save();
        }

        private void XeniaButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog xeniaBrowser = new OpenFileDialog();
            xeniaBrowser.Title = "Select a Xenia executable...";
            xeniaBrowser.Filter = "Programs (*.exe)|*.exe";
            xeniaBrowser.FilterIndex = 1;
            xeniaBrowser.RestoreDirectory = true;
            if (xeniaBrowser.ShowDialog() == DialogResult.OK)
            {
                xeniaPath = xeniaBrowser.FileName;
                xeniaBox.Text = xeniaPath;
                Properties.Settings.Default.xeniaPath = xeniaPath;
                Properties.Settings.Default.Save();
            }
        }

        private void S06PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s06PathBrowser = new FolderBrowserDialog();
            s06PathBrowser.Description = "Select your SONIC THE HEDGEHOG (2006) Game directory...";
            if (s06PathBrowser.ShowDialog() == DialogResult.OK)
            {
                s06Path = s06PathBrowser.SelectedPath;
                s06PathBox.Text = s06Path;
                Properties.Settings.Default.s06Path = s06Path;
                Properties.Settings.Default.Save();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ModCreate ModCreateWindow = new ModCreate(modsPath);
            ModCreateWindow.ShowDialog();

            RefreshMods();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            checkedModsList.Clear();
            for (int i = 0; i < modList.Items.Count; i++)
            {
                if (modList.GetItemChecked(i))
                {
                    checkedModsList.Add(modList.Items[i].ToString());
                }

            }
            checkedModsList.ForEach(i => Console.Write("{0}\n", i));
            if (modList.CheckedItems.Count != 0)
            {
                if (modsBox.Text != string.Empty && s06PathBox.Text != string.Empty && xeniaBox.Text != string.Empty)
                {
                    SaveChecks();

                    if (check_FTP.Checked)
                    {
                        if (s06PathBox.Text.StartsWith("ftp://"))
                        {
                            if (s06PathBox.Text.EndsWith("/"))
                            {
                                InstallMods();
                            }
                            else
                            {
                                s06PathBox.AppendText("/");
                                InstallMods();
                            }
                        }
                        else
                        {
                            if (s06PathBox.Text.StartsWith("/")) { s06PathBox.Text = s06PathBox.Text.Substring(1); }
                            s06PathBox.Text = $"ftp://{s06PathBox.Text}";

                            if (s06PathBox.Text.EndsWith("/"))
                            {
                                InstallMods();
                            }
                            else
                            {
                                s06PathBox.AppendText("/");
                                InstallMods();
                            }
                        }
                    }
                    else { InstallMods(); }

                    if (!check_FTP.Checked) LaunchXenia();
                }
                else { MessageBox.Show("Please specify the required paths.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                if (check_FTP.Checked)
                {
                    FtpWebRequest testConnection = (FtpWebRequest)WebRequest.Create(s06PathBox.Text);
                    testConnection.Method = WebRequestMethods.Ftp.ListDirectory;

                    if (s06PathBox.Text.StartsWith("ftp://"))
                    {
                        if (s06PathBox.Text.EndsWith("/"))
                        {
                            try
                            {
                                WebResponse getResponse = testConnection.GetResponse();
                                MessageBox.Show("Successfully established a connection to the FTP server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                MessageBox.Show("Unable to establish a connection to the FTP server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            s06PathBox.AppendText("/");
                            try
                            {
                                WebResponse getResponse = testConnection.GetResponse();
                                MessageBox.Show("Successfully established a connection to the FTP server.", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                MessageBox.Show("Unable to establish a connection to the FTP server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        if (s06PathBox.Text.StartsWith("/")) { s06PathBox.Text = s06PathBox.Text.Substring(1); }
                        s06PathBox.Text = $"ftp://{s06PathBox.Text}";

                        if (s06PathBox.Text.EndsWith("/"))
                        {
                            try
                            {
                                WebResponse getResponse = testConnection.GetResponse();
                                MessageBox.Show("Successfully established a connection to the FTP server.", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                MessageBox.Show("Unable to establish a connection to the FTP server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            s06PathBox.AppendText("/");
                            try
                            {
                                WebResponse getResponse = testConnection.GetResponse();
                                MessageBox.Show("Successfully established a connection to the FTP server.", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                MessageBox.Show("Unable to establish a connection to the FTP server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    SaveChecks();
                    LaunchXenia();
                }
            }
        }

        private void InstallMods()
        {
            try { CleanUpMods(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try { CopyMods(); }
            catch (Exception ex1)
            {
                MessageBox.Show($"Please refer to the following error for more information:\n\n{ex1}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { CleanUpMods(); }
                catch (Exception ex2)
                {
                    MessageBox.Show($"Please refer to the following error for more information:\n\n{ex2}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                return;
            }
        }

        private void LaunchXenia()
        {
            string args;
            if (File.Exists($"{s06Path}\\default.xex")) { args = $"\"{s06Path}\\default.xex\""; }
            else { args = string.Empty; }

            Console.WriteLine("\nStarting Xenia.\n");
            ProcessStartInfo xeniaExec;
            xeniaExec = new ProcessStartInfo(xeniaPath)
            {
                WorkingDirectory = Path.GetDirectoryName(xeniaPath),
                Arguments = args
            };
            var xenia = Process.Start(xeniaExec);
            xenia.WaitForExit();
            CleanUpMods();
        }

        private void CleanUpMods()
        {
            installState = "cleanup";
            var convertDialog = new ModStatus();
            var parentLeft = Left + ((Width - convertDialog.Width) / 2);
            var parentTop = Top + ((Height - convertDialog.Height) / 2);
            convertDialog.Location = new System.Drawing.Point(parentLeft, parentTop);
            convertDialog.Show();
            if (!check_FTP.Checked)
            {
                if (s06Path != string.Empty)
                {
                    var mods = Directory.GetFiles(s06Path, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".arc_back") || s.EndsWith(".wmv_back") || s.EndsWith(".xma_back") || s.EndsWith(".xex_back"));

                    foreach (var mod in mods)
                    {
                        if (File.Exists(mod.ToString().Remove(mod.Length - 5)))
                        {
                            File.Delete(mod.ToString().Remove(mod.Length - 5));
                        }
                        File.Move(mod.ToString(), mod.ToString().Remove(mod.Length - 5));
                        Console.WriteLine("Removing: " + mod.ToString().Remove(mod.Length - 5));
                    }
                }
            }
            else
            {
                if (combo_System.SelectedIndex == 0)
                {
                    #region Xbox 360
                    string[] rootXEXArray = Tools.List.root().ToArray();

                    foreach (var item in rootXEXArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxex_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{Path.GetFileNameWithoutExtension(item.ToString())}.xex");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xex";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonArchivesArray = Tools.List.xenonarchives().ToArray();

                    foreach (var item in xenonArchivesArray)
                    {
                        if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/archives/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonSoundXMAArray = Tools.List.xenonsound().ToArray();

                    foreach (var item in xenonSoundXMAArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonSoundWMVArray = Tools.List.xenonsound().ToArray();

                    foreach (var item in xenonSoundWMVArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bwmv_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.wmv");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.wmv";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonSoundEventArray = Tools.List.xenonsoundevent().ToArray();

                    foreach (var item in xenonSoundEventArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/event/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonSoundVoiceEArray = Tools.List.xenonsoundvoicee().ToArray();

                    foreach (var item in xenonSoundVoiceEArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/e/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] xenonSoundVoiceJArray = Tools.List.xenonsoundvoicej().ToArray();

                    foreach (var item in xenonSoundVoiceJArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                xenoncleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                                xenoncleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/j/{item.ToString()}");
                                xenoncleanup.Method = WebRequestMethods.Ftp.Rename;
                                xenoncleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                                xenoncleanup.UseBinary = false;
                                xenoncleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)xenoncleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }
                    #endregion
                }
                else if (combo_System.SelectedIndex == 1)
                {
                    #region PlayStation 3
                    string[] rootEBOOTArray = Tools.List.root().ToArray();

                    foreach (var item in rootEBOOTArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bBIN_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{Path.GetFileNameWithoutExtension(item.ToString())}.BIN");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.BIN";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3ArchivesArray = Tools.List.ps3archives().ToArray();

                    foreach (var item in ps3ArchivesArray)
                    {
                        if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/archives/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3SoundAT3Array = Tools.List.ps3sound().ToArray();

                    foreach (var item in ps3SoundAT3Array)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3SoundPAMArray = Tools.List.ps3sound().ToArray();

                    foreach (var item in ps3SoundPAMArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bpam_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.pam");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.pam";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3SoundEventArray = Tools.List.ps3soundevent().ToArray();

                    foreach (var item in ps3SoundEventArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/event/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3SoundVoiceEArray = Tools.List.ps3soundvoicee().ToArray();

                    foreach (var item in ps3SoundVoiceEArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/e/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }

                    string[] ps3SoundVoiceJArray = Tools.List.ps3soundvoicej().ToArray();

                    foreach (var item in ps3SoundVoiceJArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            try
                            {
                                FtpWebRequest ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                                ps3cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/j/{item.ToString()}");
                                ps3cleanup.Method = WebRequestMethods.Ftp.Rename;
                                ps3cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                                ps3cleanup.UseBinary = false;
                                ps3cleanup.UsePassive = true;
                                FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanup.GetResponse();
                            }
                            catch { return; }
                        }
                    }
                    #endregion
                }

                string[] win32ArchivesArray = Tools.List.win32archives().ToArray();

                foreach (var item in win32ArchivesArray)
                {
                    if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                    {
                        try
                        {
                            FtpWebRequest win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}win32/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            win32cleanup.Method = WebRequestMethods.Ftp.DeleteFile;
                            FtpWebResponse win32DeleteResponse = (FtpWebResponse)win32cleanup.GetResponse();
                            win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}win32/archives/{item.ToString()}");
                            win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                            win32cleanup.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                            win32cleanup.UseBinary = false;
                            win32cleanup.UsePassive = true;
                            FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                        }
                        catch { return; }
                    }
                }
            }
            convertDialog.Close();
        }

        private void CopyMods()
        {
            string[] names = modList.CheckedItems.Cast<string>().ToArray();

            installState = "install";
            var convertDialog = new ModStatus();
            var parentLeft = Left + ((Width - convertDialog.Width) / 2);
            var parentTop = Top + ((Height - convertDialog.Height) / 2);
            convertDialog.Location = new System.Drawing.Point(parentLeft, parentTop);
            convertDialog.Show();
            foreach (var item in names)
            {
                var mods = Directory.GetFiles($"{modsPath}\\{item}", "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".arc") || s.EndsWith(".wmv") || s.EndsWith(".xma") || s.EndsWith(".xex"));

                foreach (var mod in mods)
                {
                    arcPath = mod.Remove(0, $"{modsPath}\\{item}".Length);
                    origArcPath = s06Path + arcPath;
                    targetArcPath = origArcPath + "_back";

                    if (!check_FTP.Checked)
                    {
                        if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                        {
                            if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                            {
                                if (mod.EndsWith(".arc"))
                                {
                                    Console.WriteLine("Merging " + mod);
                                    MergeARCs(origArcPath, mod, origArcPath, false, string.Empty);
                                }
                                else
                                {
                                    Console.WriteLine("Copying " + mod);
                                    if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                    File.Copy(mod, origArcPath, true);
                                }
                            }
                            else
                            {
                                if (!File.Exists(targetArcPath))
                                {
                                    Console.WriteLine("Copying " + mod);
                                    if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                    File.Copy(mod, origArcPath, true);
                                }
                                else
                                {
                                    Console.WriteLine("Skipped " + mod);
                                }
                            }
                        }
                        else
                        {
                            if (!File.Exists(targetArcPath))
                            {
                                Console.WriteLine("Copying " + mod);
                                if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                File.Copy(mod, origArcPath, true);
                            }
                            else
                            {
                                Console.WriteLine("Skipped " + mod);
                            }
                        }
                    }
                    else
                    {
                        if (combo_System.SelectedIndex == 0)
                        {
                            if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                            {
                                if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                                {
                                    string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
                                    var tempData = new DirectoryInfo(tempPath);

                                    using (WebClient client = new WebClient())
                                    {
                                        byte[] arcBytes = null;
                                        if (mod.Contains(@"\xenon\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");

                                        Directory.CreateDirectory(tempPath);

                                        using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                        {
                                            file.Write(arcBytes, 0, arcBytes.Length);
                                            file.Close();
                                        }

                                        FtpWebRequest win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                        if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);
                                    }

                                    using (WebClient client = new WebClient())
                                    {
                                        if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                    }

                                    try
                                    {
                                        if (Directory.Exists(tempPath))
                                        {
                                            foreach (FileInfo file in tempData.GetFiles())
                                            {
                                                file.Delete();
                                            }
                                            foreach (DirectoryInfo directory in tempData.GetDirectories())
                                            {
                                                directory.Delete(true);
                                            }
                                        }
                                    }
                                    catch { return; }
                                }
                                else
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    }
                                }
                            }
                            else
                            {
                                using (WebClient client = new WebClient())
                                {
                                    if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                }
                            }
                        }
                        else if (combo_System.SelectedIndex == 1)
                        {
                            if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                            {
                                if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                                {
                                    string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
                                    var tempData = new DirectoryInfo(tempPath);

                                    using (WebClient client = new WebClient())
                                    {
                                        byte[] arcBytes = null;
                                        if (mod.Contains(@"\ps3\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");

                                        Directory.CreateDirectory(tempPath);

                                        using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                        {
                                            file.Write(arcBytes, 0, arcBytes.Length);
                                            file.Close();
                                        }

                                        FtpWebRequest win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                        if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);
                                    }

                                    using (WebClient client = new WebClient())
                                    {
                                        if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                    }

                                    try
                                    {
                                        if (Directory.Exists(tempPath))
                                        {
                                            foreach (FileInfo file in tempData.GetFiles())
                                            {
                                                file.Delete();
                                            }
                                            foreach (DirectoryInfo directory in tempData.GetDirectories())
                                            {
                                                directory.Delete(true);
                                            }
                                        }
                                    }
                                    catch { return; }
                                }
                                else
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    }
                                }
                            }
                            else
                            {
                                using (WebClient client = new WebClient())
                                {
                                    if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                }
                            }
                        }

                        MessageBox.Show("Mod installation complete! You can now launch the game.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            convertDialog.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (modList.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (File.Exists(modArray[modList.SelectedIndex] + "\\mod.ini"))
                {
                    var modDetails = "";
                    using (StreamReader configFile = new StreamReader(modArray[modList.SelectedIndex] + "\\mod.ini"))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.Contains("Title=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Title: " + entryValue + "\n";
                            }
                            if (line.Contains("Version=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Version: " + entryValue + "\n";
                            }
                            if (line.Contains("Date=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Date: " + entryValue + "\n";
                            }
                            if (line.Contains("Author=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Author: " + entryValue + "\n";
                            }
                            if (line.Contains("Merge=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Merge: " + entryValue + "\n";
                            }
                        }
                    }
                    MessageBox.Show(modDetails, modList.Items[modList.SelectedIndex].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("No configuration file found for selected mod.", "None", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void ModsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog modPathBrowser = new FolderBrowserDialog();
            modPathBrowser.Description = "Select your SONIC THE HEDGEHOG (2006) Mods directory...";
            if (modPathBrowser.ShowDialog() == DialogResult.OK)
            {
                modsPath = modPathBrowser.SelectedPath;
                modsBox.Text = modsPath;
                RefreshMods();
            }
        }

        private void ModsBox_TextChanged(object sender, EventArgs e)
        {
            modsPath = modsBox.Text;
            RefreshMods();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void Tm_CreatorDisposal_Tick(object sender, EventArgs e)
        {
            if (isCreatorDisposed == true)
            {
                RefreshMods();
                isCreatorDisposed = false;
            }

            if (modList.CheckedItems.Count == 0 && check_FTP.Checked) { playButton.Text = "Test Connection"; }
            else if (check_FTP.Checked) { playButton.Text = "Copy Mods"; }
            else { playButton.Text = "Save and Play"; }
        }

        private void Lbl_ModsDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(modsPath);
        }

        private void Lbl_GameDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(s06Path);
        }

        private void Lbl_XeniaExecutable_Click(object sender, EventArgs e)
        {
            LaunchXenia();
        }

        private void Check_FTP_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FTP.Checked == true)
            {
                lbl_GameDirectory.Text = "FTP Location:";
                lbl_GameDirectory.Left += 9;
                playButton.Text = "Test Connection";
                playButton.Width = 186;

                stopButton.Visible = true;
                s06PathButton.Enabled = false;
                lbl_XeniaExecutable.Enabled = false;
                xeniaBox.Enabled = false;
                xeniaButton.Enabled = false;
                lbl_System.Visible = true;
                combo_System.Visible = true;

                if (ftpPath == string.Empty) { s06PathBox.Text = "ftp://"; }
                else { s06PathBox.Text = ftpPath; }

                Properties.Settings.Default.ftp = true;
            }
            else
            {
                lbl_GameDirectory.Text = "Game Directory:";
                lbl_GameDirectory.Left -= 9;
                playButton.Text = "Save and Play";
                playButton.Width = 282;

                stopButton.Visible = false;
                s06PathButton.Enabled = true;
                lbl_XeniaExecutable.Enabled = true;
                xeniaBox.Enabled = true;
                xeniaButton.Enabled = true;
                lbl_System.Visible = false;
                combo_System.Visible = false;

                s06PathBox.Text = s06Path;

                Properties.Settings.Default.ftp = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Combo_System_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_System.SelectedIndex == 0) { Properties.Settings.Default.ftpSystem = 0; }
            else { Properties.Settings.Default.ftpSystem = 1; }
            Properties.Settings.Default.Save();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                CleanUpMods();
                MessageBox.Show("Mod clean-up complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Btn_UpperPriority_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.modList.SelectedIndex;
            object selectedItem = this.modList.SelectedItem;

            this.modList.Items.RemoveAt(selectedIndex);
            selectedIndex -= 1;
            this.modList.Items.Insert(selectedIndex, selectedItem);
            this.modList.SelectedIndex = selectedIndex;
        }

        private void Btn_DownerPriority_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.modList.SelectedIndex;
            object selectedItem = this.modList.SelectedItem;

            this.modList.Items.RemoveAt(selectedIndex);
            selectedIndex += 1;
            this.modList.Items.Insert(selectedIndex, selectedItem);
            this.modList.SelectedIndex = selectedIndex;
        }

        private void ModList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_UpperPriority.Enabled = this.modList.SelectedIndex > 0;
            this.btn_DownerPriority.Enabled = this.modList.SelectedIndex >= 0 && this.modList.SelectedIndex < this.modList.Items.Count - 1;
        }
    }
}
