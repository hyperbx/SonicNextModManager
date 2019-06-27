using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

// Welcome to Sonic '06 Mod Manager!

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2019 Knuxfan24 & HyperPolygon64

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Sonic_06_Mod_Manager
{
    public partial class ModManager : Form
    {
        public static string versionNumber = "Version 1.04";
        public static string updateState;
        public static string serverStatus;
        public static string installState;
        public static bool isCreatorDisposed;
        public static string username;
        public static string password;
        string[] modArray;
        string modsPath;
        string s06Path;
        string xeniaPath;
        string arcPath;
        string ftpPath;
        string origArcPath;
        string targetArcPath;
        List<string> checkedModsList = new List<string>() { };
        List<string> skippedMods = new List<string>() { };

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

        public static void CheckForUpdates(string currentVersion, string newVersionDownloadLink, string versionInfoLink)
        {
            try
            {
                var latestVersion = new Tools.TimedWebClient { Timeout = 100000 }.DownloadString(versionInfoLink);
                var changeLogs = new Tools.TimedWebClient { Timeout = 100000 }.DownloadString("https://segacarnival.com/hyper/updates/sonic-06-mod-manager/changelogs.txt");
                if (latestVersion.Contains("Version"))
                {
                    if (latestVersion != currentVersion)
                    {
                        DialogResult confirmUpdate = MessageBox.Show("Sonic '06 Mod Manager - " + latestVersion + " is now available!\n\nChangelogs:\n" + changeLogs + "\n\nDo you wish to download it?", "New update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (confirmUpdate)
                        {
                            case DialogResult.Yes:
                                try
                                {
                                    if (File.Exists(Application.ExecutablePath))
                                    {
                                        var clientApplication = new WebClient();
                                        clientApplication.DownloadFileAsync(new Uri(newVersionDownloadLink), Application.ExecutablePath + ".pak");
                                        clientApplication.DownloadFileCompleted += (s, e) =>
                                        {
                                            File.Replace(Application.ExecutablePath + ".pak", Application.ExecutablePath, Application.ExecutablePath + ".bak");
                                            Process.Start(Application.ExecutablePath);
                                            Application.Exit();
                                        };
                                    }
                                    else { MessageBox.Show("Sonic '06 Mod Manager doesn't exist... What?!", "Stupid Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                                catch
                                {
                                    MessageBox.Show("An error occurred when updating Sonic '06 Mod Manager.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                        }
                    }
                    else if (updateState == "user") MessageBox.Show("There are currently no updates available.", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    serverStatus = "down";
                }
            }
            catch
            {
                serverStatus = "offline";
            }

            updateState = null;
        }

        private void ModManager_Load(object sender, EventArgs e)
        {
            CheckForUpdates(versionNumber, "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe", "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt");

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool");
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php", Properties.Resources.arctoolphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php", Properties.Resources.unarcphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php", Properties.Resources.arccphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", Properties.Resources.arctool);

            RefreshMods();
            if (Directory.Exists(s06Path) && Properties.Settings.Default.manUninstall == false) CleanUpMods();

            tm_CreatorDisposal.Start();

            if (Properties.Settings.Default.ftp == true)
            {
                Height = 529;
                check_manUninstall.Visible = false;
                check_FTP.Checked = true;
                playButton.Left = 10;
                playButton.Width = 186;
                playButton.Text = "Test Connection";
            }
            else
            {
                if (Properties.Settings.Default.manUninstall == true)
                {
                    Height = 503;
                    check_FTP.Checked = false;
                    check_manUninstall.Checked = true;
                    playButton.Text = "Install Mods";
                    playButton.Left = 106;
                    playButton.Width = 90;
                    stopButton.Visible = true;
                    launchXeniaButton.Visible = true;
                }
                else
                {
                    Height = 503;
                    check_FTP.Checked = false;
                    check_manUninstall.Checked = false;
                    stopButton.Visible = false;
                    launchXeniaButton.Visible = false;
                    playButton.Left = 10;
                    playButton.Width = 282;
                    playButton.Text = "Save and Play";
                }
            }

            if (Properties.Settings.Default.ftpSystem == 0) combo_System.SelectedIndex = 0;
            else if (Properties.Settings.Default.ftpSystem == 1) combo_System.SelectedIndex = 1;

            if (Properties.Settings.Default.priority == 0) combo_Priority.SelectedIndex = 0;
            else if (Properties.Settings.Default.priority == 1) combo_Priority.SelectedIndex = 1;

            if (Properties.Settings.Default.filter == 0)
            {
                radio_All.Checked = true;
                radio_Xbox.Checked = false;
                radio_PlayStation.Checked = false;
            }
            else if (Properties.Settings.Default.filter == 1)
            {
                radio_All.Checked = false;
                radio_Xbox.Checked = true;
                radio_PlayStation.Checked = false;
            }
            else if (Properties.Settings.Default.filter == 2)
            {
                radio_All.Checked = false;
                radio_Xbox.Checked = false;
                radio_PlayStation.Checked = true;
            }

            userField.Text = Properties.Settings.Default.username;
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

            Properties.Settings.Default.modsPath = modsPath;
            Properties.Settings.Default.Save();

            if (File.Exists($"{modsPath}\\mods.ini")) GetChecks();
            else
            {
                modArray = Directory.GetDirectories(modsPath);
                modList.Items.Clear();
                foreach (string mod in modArray)
                {
                    var modName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                    modName = modName.Replace("\\", "");
                    if (Properties.Settings.Default.filter == 0)
                    {
                        modList.Items.Add(modName);
                    }
                    else if (Properties.Settings.Default.filter == 1)
                    {
                        if (File.Exists($"{Path.Combine(modsPath, modName)}\\mod.ini"))
                        {
                            var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, modName)}\\mod.ini");
                            if (getPlatform.Contains("Platform=\"Xbox 360\""))
                            {
                                modList.Items.Add(modName);
                            }
                        }
                    }
                    else if (Properties.Settings.Default.filter == 2)
                    {
                        if (File.Exists($"{Path.Combine(modsPath, modName)}\\mod.ini"))
                        {
                            var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, modName)}\\mod.ini");
                            if (getPlatform.Contains("Platform=\"PlayStation 3\""))
                            {
                                modList.Items.Add(modName);
                            }
                        }
                    }
                }
            }
        }

        private void GetChecks()
        {
            string line;
            modArray = Directory.GetDirectories(modsPath);
            using (StreamReader sr = new StreamReader($"{modsPath}\\mods.ini"))
            {
                sr.ReadLine();
                modList.Items.Clear();
                while ((line = sr.ReadLine()) != null)
                {
                    bool modExists = false;
                    foreach (var item in modArray)
                    {
                        if (Path.GetFileName(item) == line) modExists = true;
                    }
                    if (modExists)
                    {
                        if (Properties.Settings.Default.filter == 0)
                        {
                            modList.Items.Add(line);
                        }
                        else if (Properties.Settings.Default.filter == 1)
                        {
                            if (File.Exists($"{Path.Combine(modsPath, line)}\\mod.ini"))
                            {
                                var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, line)}\\mod.ini");
                                if (getPlatform.Contains("Platform=\"Xbox 360\""))
                                {
                                    modList.Items.Add(line);
                                }
                            }
                        }
                        else if (Properties.Settings.Default.filter == 2)
                        {
                            if (File.Exists($"{Path.Combine(modsPath, line)}\\mod.ini"))
                            {
                                var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, line)}\\mod.ini");
                                if (getPlatform.Contains("Platform=\"PlayStation 3\""))
                                {
                                    modList.Items.Add(line);
                                }
                            }
                        }
                        for (int i = 0; i < modList.Items.Count; i++) modList.SetItemChecked(i, true);
                    }
                }
            }

            foreach (string mod in modArray)
            {
                var modName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                modName = modName.Replace("\\", "");
                bool isInList = false;
                for (int i = 0; i < modList.Items.Count; i++)
                {
                    if (modName == modList.Items[i].ToString())
                    {
                        isInList = true;
                    }
                }
                if (!isInList)
                {
                    if (Properties.Settings.Default.filter == 0)
                    {
                        modList.Items.Add(modName);
                    }
                    else if (Properties.Settings.Default.filter == 1)
                    {
                        if (File.Exists($"{Path.Combine(modsPath, modName)}\\mod.ini"))
                        {
                            var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, modName)}\\mod.ini");
                            if (getPlatform.Contains("Platform=\"Xbox 360\""))
                            {
                                modList.Items.Add(modName);
                            }
                        }
                    }
                    else if (Properties.Settings.Default.filter == 2)
                    {
                        if (File.Exists($"{Path.Combine(modsPath, modName)}\\mod.ini"))
                        {
                            var getPlatform = File.ReadAllText($"{Path.Combine(modsPath, modName)}\\mod.ini");
                            if (getPlatform.Contains("Platform=\"PlayStation 3\""))
                            {
                                modList.Items.Add(modName);
                            }
                        }
                    }
                }
            }
        }

        private void SaveChecks()
        {
            string checkList = $"{modsPath}\\mods.ini";
            int checkTotal = 0;

            foreach (string items in modList.CheckedItems) { checkTotal++; }

            using (StreamWriter sw = File.CreateText(checkList))
            {
                sw.WriteLine("[Main]");
            }

            foreach (var item in checkedModsList)
            {
                using (StreamWriter sw = File.AppendText(checkList))
                {
                    sw.WriteLine($"{item}");
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshMods();
            btn_UpperPriority.Enabled = false;
            btn_DownerPriority.Enabled = false;
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
            if (combo_Priority.SelectedIndex == 0)
            {
                for (int i = modList.Items.Count - 1; i >= 0; i--)
                {
                    if (modList.GetItemChecked(i))
                    {
                        checkedModsList.Add(modList.Items[i].ToString());
                    }
                }
            }
            else if (combo_Priority.SelectedIndex == 1)
            {
                for (int i = 0; i < modList.Items.Count; i++)
                {
                    if (modList.GetItemChecked(i))
                    {
                        checkedModsList.Add(modList.Items[i].ToString());
                    }
                }
            }
            checkedModsList.ForEach(i => Console.Write("{0}\n", i));
            if (modList.CheckedItems.Count != 0)
            {
                if (!check_FTP.Checked)
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

                        if (!check_FTP.Checked && !check_manUninstall.Checked) LaunchXenia();
                    }
                    else { MessageBox.Show("Please specify the required paths.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    if (modsBox.Text != string.Empty && s06PathBox.Text != string.Empty)
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

                        if (!check_FTP.Checked && !check_manUninstall.Checked) LaunchXenia();
                    }
                    else { MessageBox.Show("Please specify the required paths.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
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
                    if (!check_FTP.Checked && !check_manUninstall.Checked) LaunchXenia();
                }
            }
        }

        private void InstallMods()
        {
            try { CleanUpMods(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tools.Notification.Dispose();
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
                    Tools.Notification.Dispose();
                    return;
                }

                Tools.Notification.Dispose();
                return;
            }
        }

        private void LaunchXenia()
        {
            if (xeniaBox.Text != string.Empty)
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
                if (!check_manUninstall.Checked) CleanUpMods();
            }
            else
            {
                MessageBox.Show("Please specify your executable file for Xenia.", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        }

        private void CleanUpMods()
        {
            skippedMods.Clear();
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
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.xex");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.xex");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create(Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString())));
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xex";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonArchivesArray = Tools.List.xenonarchives().ToArray();

                    foreach (var item in xenonArchivesArray)
                    {
                        if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/archives/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonSoundXMAArray = Tools.List.xenonsound().ToArray();

                    foreach (var item in xenonSoundXMAArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonSoundWMVArray = Tools.List.xenonsound().ToArray();

                    foreach (var item in xenonSoundWMVArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bwmv_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.wmv");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.wmv");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.wmv";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonSoundEventArray = Tools.List.xenonsoundevent().ToArray();

                    foreach (var item in xenonSoundEventArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/event/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonSoundVoiceEArray = Tools.List.xenonsoundvoicee().ToArray();

                    foreach (var item in xenonSoundVoiceEArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/e/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] xenonSoundVoiceJArray = Tools.List.xenonsoundvoicej().ToArray();

                    foreach (var item in xenonSoundVoiceJArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bxma_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}xenon/sound/voice/j/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.xma";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
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
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.BIN");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.BIN");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create(Path.Combine(s06PathBox.Text, Path.GetFileNameWithoutExtension(item.ToString())));
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.BIN";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3ArchivesArray = Tools.List.ps3archives().ToArray();

                    foreach (var item in ps3ArchivesArray)
                    {
                        if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/archives/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3SoundAT3Array = Tools.List.ps3sound().ToArray();

                    foreach (var item in ps3SoundAT3Array)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3SoundPAMArray = Tools.List.ps3sound().ToArray();

                    foreach (var item in ps3SoundPAMArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bpam_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.pam");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.pam");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.pam";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3SoundEventArray = Tools.List.ps3soundevent().ToArray();

                    foreach (var item in ps3SoundEventArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/event/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3SoundVoiceEArray = Tools.List.ps3soundvoicee().ToArray();

                    foreach (var item in ps3SoundVoiceEArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/e/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }

                    string[] ps3SoundVoiceJArray = Tools.List.ps3soundvoicej().ToArray();

                    foreach (var item in ps3SoundVoiceJArray)
                    {
                        if (Regex.Match(item.ToString(), @"\bat3_back\b", RegexOptions.IgnoreCase).Success)
                        {
                            bool fileExists = false;
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                            try
                            {
                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                fileExists = true;
                            }
                            catch (WebException ex)
                            {
                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                            }

                            if (fileExists)
                            {
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}ps3/sound/voice/j/{item.ToString()}");
                            ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                            ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.at3";
                            ps3cleanupStep2.UseBinary = false;
                            ps3cleanupStep2.UsePassive = true;
                            FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                        }
                    }
                    #endregion
                }

                string[] win32ArchivesArray = Tools.List.win32archives().ToArray();

                foreach (var item in win32ArchivesArray)
                {
                    if (Regex.Match(item.ToString(), @"\barc_back\b", RegexOptions.IgnoreCase).Success)
                    {
                        bool fileExists = false;
                        FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}win32/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                        getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                        getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                        try
                        {
                            FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                            fileExists = true;
                        }
                        catch (WebException ex)
                        {
                            FtpWebResponse response = (FtpWebResponse)ex.Response;
                            if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                        }

                        if (fileExists)
                        {
                            FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}win32/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                            ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, userField.Text);
                            FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                        }

                        FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}win32/archives/{item.ToString()}");
                        ps3cleanupStep2.Method = WebRequestMethods.Ftp.Rename;
                        ps3cleanupStep2.RenameTo = $"{Path.GetFileNameWithoutExtension(item.ToString())}.arc";
                        ps3cleanupStep2.UseBinary = false;
                        ps3cleanupStep2.UsePassive = true;
                        FtpWebResponse ps3RenameResponse = (FtpWebResponse)ps3cleanupStep2.GetResponse();
                    }
                }
            }
            convertDialog.Close();
        }

        private void CopyMods()
        {
            skippedMods.Clear();
            string[] names = checkedModsList.ToArray(); //modList.CheckedItems.Cast<string>().ToArray();

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
                            if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Platform=\"Xbox 360\""))
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
                                        skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                skippedMods.Add($"\n► {item} (failed because the mod was not targeted for the Xbox 360)");
                                break;
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
                                skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (combo_System.SelectedIndex == 0)
                        {
                            if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                            {
                                if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Platform=\"Xbox 360\""))
                                {
                                    if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                                    {
                                        string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
                                        var tempData = new DirectoryInfo(tempPath);

                                        using (WebClient client = new WebClient())
                                        {
                                            client.UseDefaultCredentials = true;
                                            client.Credentials = new NetworkCredential(userField.Text, userField.Text);

                                            if (Path.GetFileName(mod).Contains(".arc"))
                                            {
                                                byte[] arcBytes = null;
                                                if (mod.Contains(@"\xenon\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                else break;

                                                Directory.CreateDirectory(tempPath);

                                                using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                                {
                                                    file.Write(arcBytes, 0, arcBytes.Length);
                                                    file.Close();
                                                }

                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                                try
                                                {
                                                    FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                    fileExists = true;
                                                }
                                                catch (WebException ex)
                                                {
                                                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                                }

                                                if (!fileExists)
                                                {
                                                    FtpWebRequest win32cleanup = null;
                                                    if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);

                                                if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                else break;
                                            }
                                            else
                                            {
                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                                try
                                                {
                                                    FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                    fileExists = true;
                                                }
                                                catch (WebException ex)
                                                {
                                                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                                }

                                                if (!fileExists)
                                                {
                                                    FtpWebRequest win32cleanup = null;
                                                    if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else break;
                                            }
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
                                        catch { Tools.Notification.Dispose(); return; }
                                    }
                                    else
                                    {
                                        using (WebClient client = new WebClient())
                                        {
                                            bool fileExists = false;
                                            FtpWebRequest getFile = null;
                                            if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                            try
                                            {
                                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                fileExists = true;
                                            }
                                            catch (WebException ex)
                                            {
                                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                            }

                                            if (fileExists)
                                            {
                                                skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                break;
                                            }
                                            else
                                            {
                                                FtpWebRequest win32cleanup = null;
                                                if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                Console.WriteLine(win32cleanup.RequestUri);
                                                win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                win32cleanup.UseBinary = false;
                                                win32cleanup.UsePassive = true;
                                                FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    skippedMods.Add($"\n► {item} (failed because the mod was not targeted for the {combo_System.Text})");
                                    break;
                                }
                            }
                            else
                            {
                                using (WebClient client = new WebClient())
                                {
                                    bool fileExists = false;
                                    FtpWebRequest getFile = null;
                                    if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                    getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                    getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                    try
                                    {
                                        FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                        fileExists = true;
                                    }
                                    catch (WebException ex)
                                    {
                                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                    }

                                    if (fileExists)
                                    {
                                        skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                        break;
                                    }
                                    else
                                    {
                                        FtpWebRequest win32cleanup = null;
                                        if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{s06PathBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    }
                                }
                            }
                        }
                        else if (combo_System.SelectedIndex == 1)
                        {
                            if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                            {
                                if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Platform=\"PlayStation 3\""))
                                {
                                    if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                                    {
                                        string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
                                        var tempData = new DirectoryInfo(tempPath);

                                        using (WebClient client = new WebClient())
                                        {
                                            client.UseDefaultCredentials = true;
                                            client.Credentials = new NetworkCredential(userField.Text, userField.Text);

                                            if (Path.GetFileName(mod).Contains(".arc"))
                                            {
                                                byte[] arcBytes = null;
                                                if (mod.Contains(@"\ps3\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                else break;

                                                Directory.CreateDirectory(tempPath);

                                                using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                                {
                                                    file.Write(arcBytes, 0, arcBytes.Length);
                                                    file.Close();
                                                }

                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                                try
                                                {
                                                    FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                    fileExists = true;
                                                }
                                                catch (WebException ex)
                                                {
                                                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                                }

                                                if (!fileExists)
                                                {
                                                    FtpWebRequest win32cleanup = null;
                                                    if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);

                                                if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                else break;
                                            }
                                            else
                                            {
                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                                try
                                                {
                                                    FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                    fileExists = true;
                                                }
                                                catch (WebException ex)
                                                {
                                                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                                }

                                                if (!fileExists)
                                                {
                                                    FtpWebRequest win32cleanup = null;
                                                    if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else break;
                                            }
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
                                        catch { Tools.Notification.Dispose(); return; }
                                    }
                                    else
                                    {
                                        using (WebClient client = new WebClient())
                                        {
                                            bool fileExists = false;
                                            FtpWebRequest getFile = null;
                                            if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                            getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                            getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                            try
                                            {
                                                FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                                fileExists = true;
                                            }
                                            catch (WebException ex)
                                            {
                                                FtpWebResponse response = (FtpWebResponse)ex.Response;
                                                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                            }

                                            if (fileExists)
                                            {
                                                skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                break;
                                            }
                                            else
                                            {
                                                FtpWebRequest win32cleanup = null;
                                                if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                Console.WriteLine(win32cleanup.RequestUri);
                                                win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                                win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                win32cleanup.UseBinary = false;
                                                win32cleanup.UsePassive = true;
                                                FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    skippedMods.Add($"\n► {item} (failed because the mod was not targeted for the {combo_System.Text})");
                                    break;
                                }
                            }
                            else
                            {
                                using (WebClient client = new WebClient())
                                {
                                    bool fileExists = false;
                                    FtpWebRequest getFile = null;
                                    if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                    getFile.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                    getFile.Method = WebRequestMethods.Ftp.GetFileSize;

                                    try
                                    {
                                        FtpWebResponse fileResponse = (FtpWebResponse)getFile.GetResponse();
                                        fileExists = true;
                                    }
                                    catch (WebException ex)
                                    {
                                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) fileExists = false;
                                    }

                                    if (fileExists)
                                    {
                                        skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                        break;
                                    }
                                    else
                                    {
                                        FtpWebRequest win32cleanup = null;
                                        if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, userField.Text);
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{s06PathBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{s06PathBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{s06PathBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            convertDialog.Close();
            if (check_FTP.Checked && skippedMods.ToString() != string.Empty || check_manUninstall.Checked && skippedMods.ToString() != string.Empty) MessageBox.Show("Mod installation complete! You can now launch the game.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (skippedMods.ToString() != string.Empty)
            {
                var getString = new StringBuilder();
                foreach (var modName in skippedMods)
                {
                    getString.Append(modName);
                }
                if (getString.ToString() != string.Empty) MessageBox.Show($"Mod installation completed, but the following mods were skipped:\n{getString.ToString()}", "Success, but errors occurred...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] names = checkedModsList.ToArray();

            if (modList.SelectedIndex == -1) return;
            else
            {
                string getItem = modList.GetItemText(modList.SelectedItem);
                if (File.Exists($"{Path.Combine(modsPath, getItem)}\\mod.ini"))
                {
                    var modDetails = "";
                    using (StreamReader configFile = new StreamReader($"{Path.Combine(modsPath, getItem)}\\mod.ini"))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.Contains("Title=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Title: " + entryValue + "\n";
                            }
                            if (line.Contains("Version=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Version: " + entryValue + "\n";
                            }
                            if (line.Contains("Date=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Date: " + entryValue + "\n";
                            }
                            if (line.Contains("Author=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Author: " + entryValue + "\n";
                            }
                            if (line.Contains("Platform=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Platform: " + entryValue + "\n";
                            }
                            if (line.Contains("Merge=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails += "Merge: " + entryValue + "\n";
                            }
                        }
                    }
                    MessageBox.Show(modDetails, modList.Items[modList.SelectedIndex].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("No configuration file found for the selected mod.", "None", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            else if (check_FTP.Checked || check_manUninstall.Checked) { playButton.Text = "Install Mods"; }
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
                playButton.Text = "Test Connection";
                lbl_GameDirectory.Left += 9;

                if (check_manUninstall.Checked == true)
                {
                    playButton.Left = 10;
                    playButton.Width = 186;
                    Height = 529;
                }
                else
                {
                    playButton.Width = 186;
                    Height = 529;
                }

                check_manUninstall.Visible = false;
                launchXeniaButton.Visible = false;
                stopButton.Visible = true;
                s06PathButton.Enabled = false;
                lbl_XeniaExecutable.Enabled = false;
                xeniaBox.Enabled = false;
                xeniaButton.Enabled = false;
                lbl_System.Visible = true;
                combo_System.Visible = true;
                lbl_Username.Visible = true;
                lbl_Password.Visible = true;
                userField.Visible = true;
                passField.Visible = true;

                if (ftpPath == string.Empty) { s06PathBox.Text = "ftp://"; }
                else { s06PathBox.Text = ftpPath; }

                Properties.Settings.Default.ftp = true;
            }
            else
            {
                lbl_GameDirectory.Text = "Game Directory:";
                playButton.Text = "Save and Play";
                lbl_GameDirectory.Left -= 9;

                if (check_manUninstall.Checked == true)
                {
                    playButton.Left = 106;
                    playButton.Width = 90;
                    Height = 503;
                    stopButton.Visible = true;
                    launchXeniaButton.Visible = true;
                }
                else
                {
                    playButton.Left = 10;
                    playButton.Width = 282;
                    Height = 503;
                    stopButton.Visible = false;
                    launchXeniaButton.Visible = false;
                }

                check_manUninstall.Visible = true;
                s06PathButton.Enabled = true;
                lbl_XeniaExecutable.Enabled = true;
                xeniaBox.Enabled = true;
                xeniaButton.Enabled = true;
                lbl_System.Visible = false;
                combo_System.Visible = false;
                lbl_Username.Visible = false;
                lbl_Password.Visible = false;
                userField.Visible = false;
                passField.Visible = false;

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
                if (check_FTP.Checked)
                {
                    if (s06PathBox.Text.StartsWith("ftp://"))
                    {
                        if (s06PathBox.Text.EndsWith("/"))
                        {
                            CleanUpMods();
                        }
                        else
                        {
                            s06PathBox.AppendText("/");
                            CleanUpMods();
                        }
                    }
                }
                else
                {
                    CleanUpMods();
                }
                MessageBox.Show("Mod uninstall complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tools.Notification.Dispose();
                return;
            }
        }

        private void Btn_UpperPriority_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.modList.SelectedIndex;
            object selectedItem = this.modList.SelectedItem;

            if (modList.GetItemCheckState(selectedIndex) == CheckState.Checked)
            {
                this.modList.Items.RemoveAt(selectedIndex);
                selectedIndex -= 1;
                this.modList.Items.Insert(selectedIndex, selectedItem);
                this.modList.SelectedIndex = selectedIndex;
                modList.SetItemChecked(selectedIndex, true);
            }
            else
            {
                this.modList.Items.RemoveAt(selectedIndex);
                selectedIndex -= 1;
                this.modList.Items.Insert(selectedIndex, selectedItem);
                this.modList.SelectedIndex = selectedIndex;
                modList.SetItemChecked(selectedIndex, false);
            }
        }

        private void Btn_DownerPriority_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.modList.SelectedIndex;
            object selectedItem = this.modList.SelectedItem;

            if (modList.GetItemCheckState(selectedIndex) == CheckState.Checked)
            {
                this.modList.Items.RemoveAt(selectedIndex);
                selectedIndex += 1;
                this.modList.Items.Insert(selectedIndex, selectedItem);
                this.modList.SelectedIndex = selectedIndex;
                modList.SetItemChecked(selectedIndex, true);
            }
            else
            {
                this.modList.Items.RemoveAt(selectedIndex);
                selectedIndex += 1;
                this.modList.Items.Insert(selectedIndex, selectedItem);
                this.modList.SelectedIndex = selectedIndex;
                modList.SetItemChecked(selectedIndex, false);
            }
        }

        private void ModList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = this.modList.SelectedIndex >= 0;
            this.btn_UpperPriority.Enabled = this.modList.SelectedIndex > 0;
            this.btn_DownerPriority.Enabled = this.modList.SelectedIndex >= 0 && this.modList.SelectedIndex < this.modList.Items.Count - 1;
        }

        private void Btn_SelectAll_Click(object sender, EventArgs e)
        {
            //Checks all available checkboxes.
            for (int i = 0; i < modList.Items.Count; i++) modList.SetItemChecked(i, true);
        }

        private void Btn_DeselectAll_Click(object sender, EventArgs e)
        {
            //Unchecks all available checkboxes.
            for (int i = 0; i < modList.Items.Count; i++) modList.SetItemChecked(i, false);
        }

        private void Combo_Priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Priority.SelectedIndex == 0) { Properties.Settings.Default.priority = 0; }
            else { Properties.Settings.Default.priority = 1; }
            Properties.Settings.Default.Save();
        }

        private void UserField_TextChanged(object sender, EventArgs e)
        {
            username = userField.Text;
            Properties.Settings.Default.username = username;
            Properties.Settings.Default.Save();
        }

        private void PassField_TextChanged(object sender, EventArgs e)
        {
            password = passField.Text;
        }

        private void Check_manUninstall_CheckedChanged(object sender, EventArgs e)
        {
            if (check_manUninstall.Checked == true)
            {
                playButton.Text = "Install Mods";
                playButton.Left = 106;
                playButton.Width = 90;
                stopButton.Visible = true;
                launchXeniaButton.Visible = true;

                Properties.Settings.Default.manUninstall = true;
            }
            else
            {
                playButton.Text = "Save and Play";
                playButton.Left = 10;
                playButton.Width = 282;
                stopButton.Visible = false;
                launchXeniaButton.Visible = false;

                Properties.Settings.Default.manUninstall = false;
            }
            Properties.Settings.Default.Save();
        }

        private void LaunchXeniaButton_Click(object sender, EventArgs e)
        {
            LaunchXenia();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_All.Checked == true)
            {
                Properties.Settings.Default.filter = 0;
                btn_UpperPriority.Enabled = false;
                btn_DownerPriority.Enabled = false;
                RefreshMods();
            }

            Properties.Settings.Default.Save();
        }

        private void Radio_Xbox_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Xbox.Checked == true)
            {
                Properties.Settings.Default.filter = 1;
                btn_UpperPriority.Enabled = false;
                btn_DownerPriority.Enabled = false;
                RefreshMods();
            }

            Properties.Settings.Default.Save();
        }

        private void Radio_PlayStation_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_PlayStation.Checked == true)
            {
                Properties.Settings.Default.filter = 2;
                btn_UpperPriority.Enabled = false;
                btn_DownerPriority.Enabled = false;
                RefreshMods();
            }

            Properties.Settings.Default.Save();
        }
    }
}
