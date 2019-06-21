using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sonic_06_Mod_Manager
{
    public partial class ModManager : Form
    {
        public static string versionNumber = "Version 1.0";
        public static bool isCreatorDisposed;
        string[] modArray;
        string modsPath;
        string s06Path;
        string xeniaPath;
        string arcPath;
        string origArcPath;
        string targetArcPath;

        public ModManager()
        {
            InitializeComponent();

            modsPath = Properties.Settings.Default.modsPath;
            modsBox.Text = Properties.Settings.Default.modsPath;
            s06Path = Properties.Settings.Default.s06Path;
            s06PathBox.Text = Properties.Settings.Default.s06Path;
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
            CleanUpMods();
            if (File.Exists($"{modsPath}\\mods.ini")) GetChecks();

            tm_CreatorDisposal.Start();
        }

        private void GetChecks()
        {
            int totalMods = modList.Items.Count;
            string getSeek = File.ReadAllLines($"{modsPath}\\mods.ini")[1];
            string getOrigTotal = File.ReadAllLines($"{modsPath}\\mods.ini")[2];
            int.TryParse(getSeek.Substring(5, getSeek.Length - 5), out int seek);
            int.TryParse(getOrigTotal.Substring(6, getOrigTotal.Length - 6), out int origTotal);

            if (totalMods == origTotal)
            {
                foreach (int i in Enumerable.Range(3, seek))
                {
                    try
                    {
                        string currentSeek = File.ReadAllLines($"{modsPath}\\mods.ini")[i];
                        int.TryParse(currentSeek.Substring(currentSeek.Length - totalMods.ToString().Length), out int index);
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

        private void MergeARCs(string arc1, string arc2, string output)
        {
            string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}"; Directory.CreateDirectory(tempPath);
            var tempData = new DirectoryInfo(tempPath);
            File.Copy(arc1, Path.Combine(tempPath, Path.GetFileName(arc1)));
            File.Move(origArcPath, targetArcPath);
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

            arctool = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc2))}\" -c \"{output}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack1 = Process.Start(arctool);
            Repack1.WaitForExit();
            Repack1.Close();

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
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshMods();
        }

        private void S06PathBox_TextChanged(object sender, EventArgs e)
        {
            s06Path = s06PathBox.Text;
            Properties.Settings.Default.s06Path = s06Path;
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
            if (modsBox.Text != string.Empty && s06PathBox.Text != string.Empty && xeniaBox.Text != string.Empty)
            {
                SaveChecks();
                CleanUpMods();

                try { CopyMods(); }
                catch (Exception ex)
                {
                    MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanUpMods();
                    return;
                }

                LaunchXenia();
            }
            else { MessageBox.Show("Please specify the required paths.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                    sw.WriteLine($"Index{item++}={check}");
                }
            }
        }

        private void CleanUpMods()
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

        private void CopyMods()
        {
            int[] indexes = modList.CheckedIndices.Cast<int>().ToArray();
            foreach (var item in indexes)
            {
                var mods = Directory.GetFiles(modArray[item], "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".arc") || s.EndsWith(".wmv") || s.EndsWith(".xma") || s.EndsWith(".xex"));

                foreach (var mod in mods)
                {
                    arcPath = mod.Remove(0, modArray[item].Length);
                    var arcName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                    arcName = arcName.Replace("\\", "");
                    origArcPath = s06Path + arcPath;
                    targetArcPath = origArcPath + "_back";

                    if (File.Exists(modArray[item] + "\\mod.ini"))
                    {
                        if (File.ReadAllLines(modArray[item] + "\\mod.ini").Contains("Merge=\"True\""))
                        {
                            if (mod.EndsWith(".arc"))
                            {
                                Console.WriteLine("Merging " + mod);
                                MergeARCs(origArcPath, mod, origArcPath);
                            }
                            else
                            {
                                Console.WriteLine("Copying " + mod);
                                File.Move(origArcPath, targetArcPath);
                                File.Copy(mod, origArcPath);
                            }
                        }
                        else
                        {
                            if (!File.Exists(targetArcPath))
                            {
                                Console.WriteLine("Copying " + mod);
                                File.Move(origArcPath, targetArcPath);
                                File.Copy(mod, origArcPath);
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
                            File.Move(origArcPath, targetArcPath);
                            File.Copy(mod, origArcPath);
                        }
                        else
                        {
                            Console.WriteLine("Skipped " + mod);
                        }
                    }
                }
            }
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
            //MessageBox.Show("Sonic '06 Mod Manager\n\n" +
            //                "" +
            //                $"{versionNumber}\n\n" +
            //                "" +
            //                "Knuxfan24 - Lead Developer\n" +
            //                "Hyper - Co-developer\n" +
            //                "xose - ARC Unpacker\n" +
            //                "g0ldenlink - ARC Repacker",
            //                "Credits",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);

            new About().ShowDialog();
        }

        private void Tm_CreatorDisposal_Tick(object sender, EventArgs e)
        {
            if (isCreatorDisposed == true)
            {
                RefreshMods();
                isCreatorDisposed = false;
            }
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
    }
}
