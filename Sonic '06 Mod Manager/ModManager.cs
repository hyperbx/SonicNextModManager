using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;

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

// MainForm code is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2017 thesupersonic16

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
        public static string versionNumber = "Version 1.09";
        public static string updateState;
        public static string serverStatus;
        public static string installState;
        public static bool isCreatorDisposed;
        public static string username;
        public static string password;
        string[] modArray;
        string modsPath;
        string s06Path;
        string vkXeniaPath;
        string dx12XeniaPath;
        string arcPath;
        string ftpPath;
        string origArcPath;
        string targetArcPath;
        string patchArcPath;
        List<string> checkedModsList = new List<string>() { };
        List<string> checkedPatchesList = new List<string>() { };
        List<string> skippedMods = new List<string>() { };

        public ModManager(string[] args)
        {
            InitializeComponent();

            modsPath = Properties.Settings.Default.modsPath;
            modsBox.Text = Properties.Settings.Default.modsPath;
            s06Path = Properties.Settings.Default.s06Path;
            ftpPath = Properties.Settings.Default.ftpPath;
            ftpLocationBox.Text = Properties.Settings.Default.ftpPath;
            s06PathBox.Text = Properties.Settings.Default.s06Path;
            vkXeniaPath = Properties.Settings.Default.vkXeniaPath;
            dx12XeniaPath = Properties.Settings.Default.dx12XeniaPath;
            xeniaBox.Text = Properties.Settings.Default.dx12XeniaPath;
        }

        public static string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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
                                var exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
                                if (exists) { MessageBox.Show("Please close any other instances of Sonic '06 Mod Manager and try again.", "Stupid Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                else
                                {
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
            try
            {
                var Protocol = "sonic06mm";
                var key = Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command");

                if (key == null)
                {
                    if (!Program.RunningAsAdmin())
                    {
                        DialogResult registry = MessageBox.Show("The registry key for GameBanana 1-Click Mod Install is missing. Do you want to run Sonic '06 Mod Manager as an administrator to install it?", "Missing Registry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        switch (registry)
                        {
                            case DialogResult.Yes:
                                var runAsAdmin = new ProcessStartInfo(Application.ExecutablePath);
                                runAsAdmin.Verb = "runas";
                                if (Process.Start(runAsAdmin) != null) { Application.Exit(); }
                                break;
                        }
                    }
                }

                key = Registry.ClassesRoot.OpenSubKey(Protocol, true);
                if (key == null)
                    key = Registry.ClassesRoot.CreateSubKey(Protocol);
                key.SetValue("", "URL:Sonic '06 Mod Manager");
                key.SetValue("URL Protocol", "");
                var prevkey = key;
                key = key.OpenSubKey("shell", true);
                if (key == null)
                    key = prevkey.CreateSubKey("shell");
                prevkey = key;
                key = key.OpenSubKey("open", true);
                if (key == null)
                    key = prevkey.CreateSubKey("open");
                prevkey = key;
                key = key.OpenSubKey("command", true);
                if (key == null)
                    key = prevkey.CreateSubKey("command");

                key.SetValue("", $"\"{Application.ExecutablePath}\" \"-banana\" \"%1\"");
                key.Close();
            }
            catch { }

            if (!versionNumber.Contains("-indev")) CheckForUpdates(versionNumber, "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe", "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt");

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool");
            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub");
            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs");
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php", Properties.Resources.arctoolphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php", Properties.Resources.unarcphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php", Properties.Resources.arccphp);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", Properties.Resources.arctool);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar", Properties.Resources.unlub);

            RefreshMods();
            if (Directory.Exists(s06Path) && Properties.Settings.Default.manUninstall == false) CleanUpMods();

            tm_CreatorDisposal.Start();

            if (Properties.Settings.Default.ftp == true)
            {
                check_manUninstall.Enabled = false;
                check_FTP.Checked = true;
                playButton.Width = 101;
                playButton.Text = "Test Connection";
            }
            else
            {
                if (Properties.Settings.Default.manUninstall == true)
                {
                    check_FTP.Checked = false;
                    check_manUninstall.Checked = true;
                    playButton.Text = "Install Mods";
                    playButton.Width = 101;
                }
                else
                {
                    check_FTP.Checked = false;
                    check_manUninstall.Checked = false;
                    playButton.Width = 207;
                    playButton.Text = "Save and Play";
                }
            }

            combo_System.SelectedIndex = Properties.Settings.Default.ftpSystem;
            combo_API.SelectedIndex = Properties.Settings.Default.api;
            combo_Priority.SelectedIndex = Properties.Settings.Default.priority;
            combo_MSAA.SelectedIndex = Properties.Settings.Default.msaaLevel;
            combo_Reflections.SelectedIndex = Properties.Settings.Default.reflectionLevel;
            check_VulkanOnDX12.Checked = Properties.Settings.Default.vulkanOnDX12;
            check_VSync.Checked = Properties.Settings.Default.vsync;
            check_ProtectZero.Checked = Properties.Settings.Default.protectZero;
            check_RTV.Checked = Properties.Settings.Default.rtv;
            check_2xRes.Checked = Properties.Settings.Default.doubleIntRes;
            check_Gamma.Checked = Properties.Settings.Default.gamma;
            HardTextureRAM.Value = Properties.Settings.Default.hardTextureCache;
            SoftTextureRAM.Value = Properties.Settings.Default.softTextureCache;
            SoftCacheLifetime.Value = Properties.Settings.Default.softCacheLifetime;
            check_Debug.Checked = Properties.Settings.Default.debug;
            viewportX.Value = Properties.Settings.Default.viewportX;
            viewportY.Value = Properties.Settings.Default.viewportY;

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
            btn_UpperPriority.Enabled = false;
            btn_DownerPriority.Enabled = false;
            button1.Enabled = false;

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

            if (File.Exists($"{modsPath}\\patches.ini")) GetPatchChecks();

            if (File.Exists($"{modsPath}\\mods.ini")) GetModChecks();
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

        private void GetModChecks()
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

        private void GetPatchChecks()
        {
            string line;
            using (StreamReader sr = new StreamReader($"{modsPath}\\patches.ini"))
            {
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    int.TryParse(line, out int index);
                    patchesList.SetItemChecked(index, true);
                }
            }
        }

        private void SaveChecks()
        {
            string modCheckList = $"{modsPath}\\mods.ini";
            string patchCheckList = $"{modsPath}\\patches.ini";
            int modCheckTotal = 0;
            int patchCheckTotal = 0;

            foreach (string items in modList.CheckedItems) { modCheckTotal++; }
            foreach (string items in patchesList.CheckedItems) { patchCheckTotal++; }

            using (StreamWriter sw = File.CreateText(modCheckList))
            {
                sw.WriteLine("[Main]");
            }

            foreach (var item in checkedModsList)
            {
                using (StreamWriter sw = File.AppendText(modCheckList))
                {
                    sw.WriteLine($"{item}");
                }
            }

            using (StreamWriter sw = File.CreateText(patchCheckList))
            {
                sw.WriteLine("[Main]");
            }

            foreach (var item in patchesList.CheckedItems)
            {
                using (StreamWriter sw = File.AppendText(patchCheckList))
                {
                    sw.WriteLine(patchesList.Items.IndexOf(item));
                }
            }
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
            if (combo_API.SelectedIndex == 0)
            {
                Properties.Settings.Default.vkXeniaPath = xeniaBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.dx12XeniaPath = xeniaBox.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void XeniaButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog xeniaBrowser = new System.Windows.Forms.OpenFileDialog();
            xeniaBrowser.Title = "Select a Xenia executable...";
            xeniaBrowser.Filter = "Programs (*.exe)|*.exe";
            xeniaBrowser.FilterIndex = 1;
            xeniaBrowser.RestoreDirectory = true;
            if (xeniaBrowser.ShowDialog() == DialogResult.OK)
            {
                if (combo_API.SelectedIndex == 0)
                {
                    xeniaBox.Text = xeniaBrowser.FileName;
                    Properties.Settings.Default.vkXeniaPath = xeniaBrowser.FileName;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    xeniaBox.Text = xeniaBrowser.FileName;
                    Properties.Settings.Default.dx12XeniaPath = xeniaBrowser.FileName;
                    Properties.Settings.Default.Save();
                }
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
            if (playButton.Text == "Save and Play" || playButton.Text == "Install Mods")
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
                            RefreshMods();

                            if (check_FTP.Checked)
                            {
                                if (ftpLocationBox.Text.StartsWith("ftp://"))
                                {
                                    if (ftpLocationBox.Text.EndsWith("/"))
                                    {
                                        InstallMods();
                                    }
                                    else
                                    {
                                        ftpLocationBox.AppendText("/");
                                        InstallMods();
                                    }
                                }
                                else
                                {
                                    if (ftpLocationBox.Text.StartsWith("/")) { ftpLocationBox.Text = ftpLocationBox.Text.Substring(1); }
                                    ftpLocationBox.Text = $"ftp://{ftpLocationBox.Text}";

                                    if (ftpLocationBox.Text.EndsWith("/"))
                                    {
                                        InstallMods();
                                    }
                                    else
                                    {
                                        ftpLocationBox.AppendText("/");
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
                        if (modsBox.Text != string.Empty && ftpLocationBox.Text != string.Empty)
                        {
                            SaveChecks();
                            RefreshMods();

                            if (check_FTP.Checked)
                            {
                                if (ftpLocationBox.Text.StartsWith("ftp://"))
                                {
                                    if (ftpLocationBox.Text.EndsWith("/"))
                                    {
                                        InstallMods();
                                    }
                                    else
                                    {
                                        ftpLocationBox.AppendText("/");
                                        InstallMods();
                                    }
                                }
                                else
                                {
                                    if (ftpLocationBox.Text.StartsWith("/")) { ftpLocationBox.Text = ftpLocationBox.Text.Substring(1); }
                                    ftpLocationBox.Text = $"ftp://{ftpLocationBox.Text}";

                                    if (ftpLocationBox.Text.EndsWith("/"))
                                    {
                                        InstallMods();
                                    }
                                    else
                                    {
                                        ftpLocationBox.AppendText("/");
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
                        try
                        {
                            FtpWebRequest testConnection = (FtpWebRequest)WebRequest.Create(ftpLocationBox.Text);
                            testConnection.Credentials = new NetworkCredential(userField.Text, passField.Text);
                            testConnection.Method = WebRequestMethods.Ftp.ListDirectory;
                            if (ftpLocationBox.Text.StartsWith("ftp://"))
                            {
                                if (ftpLocationBox.Text.EndsWith("/"))
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
                                    ftpLocationBox.AppendText("/");
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
                                if (ftpLocationBox.Text.StartsWith("/")) { ftpLocationBox.Text = ftpLocationBox.Text.Substring(1); }
                                ftpLocationBox.Text = $"ftp://{ftpLocationBox.Text}";

                                if (ftpLocationBox.Text.EndsWith("/"))
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
                                    ftpLocationBox.AppendText("/");
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
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Tools.Notification.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        SaveChecks();
                        RefreshMods();

                        try
                        {
                            if (patchesList.CheckedItems.Count != 0 || combo_MSAA.SelectedIndex != 1 || combo_Reflections.SelectedIndex != 1) InstallPatches();
                        }
                        catch (Exception ex3)
                        {
                            MessageBox.Show($"Please refer to the following error for more information:\n\n{ex3}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Tools.Notification.Dispose();
                            return;
                        }

                        if (!check_FTP.Checked && !check_manUninstall.Checked) LaunchXenia();
                    }
                }
            }
            else
            {
                checkedPatchesList.Clear();
                for (int i = patchesList.Items.Count - 1; i >= 0; i--)
                {
                    if (patchesList.GetItemChecked(i))
                    {
                        checkedPatchesList.Add(patchesList.Items[i].ToString());
                    }
                }
                checkedPatchesList.ForEach(i => Console.Write("{0}\n", i));

                try { CleanUpMods(); }
                catch (Exception ex)
                {
                    MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tools.Notification.Dispose();
                    return;
                }

                if (!check_FTP.Checked)
                {
                    if (modsBox.Text != string.Empty && s06PathBox.Text != string.Empty && xeniaBox.Text != string.Empty)
                    {
                        SaveChecks();
                        RefreshMods();
                    }
                }
                SaveChecks();
                RefreshMods();

                if (check_FTP.Checked)
                {
                    if (ftpLocationBox.Text.StartsWith("ftp://"))
                    {
                        if (ftpLocationBox.Text.EndsWith("/"))
                        {
                            InstallPatches();
                        }
                        else
                        {
                            ftpLocationBox.AppendText("/");
                            InstallPatches();
                        }
                    }
                    else
                    {
                        if (ftpLocationBox.Text.StartsWith("/")) { ftpLocationBox.Text = ftpLocationBox.Text.Substring(1); }
                        ftpLocationBox.Text = $"ftp://{ftpLocationBox.Text}";

                        if (ftpLocationBox.Text.EndsWith("/"))
                        {
                            InstallPatches();
                        }
                        else
                        {
                            ftpLocationBox.AppendText("/");
                            InstallPatches();
                        }
                    }
                }
                else { InstallPatches(); }
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
                string[] launchArgs;
                List<string> xeniaParameters = new List<string>() { };
                if (File.Exists($"{s06Path}\\default.xex")) { args = $"\"{s06Path}\\default.xex\""; xeniaParameters.Add(args); }
                else { args = string.Empty; }

                if (check_RTV.Enabled && check_RTV.Checked) { xeniaParameters.Add("--d3d12_edram_rov=false"); }
                if (check_2xRes.Enabled && check_2xRes.Checked) { xeniaParameters.Add("--d3d12_resolution_scale=2"); }
                if (check_VSync.Enabled && !check_VSync.Checked) { xeniaParameters.Add("--vsync=false"); }
                if (check_VulkanOnDX12.Enabled && check_VulkanOnDX12.Checked) { xeniaParameters.Add("--gpu=vulkan"); }
                if (check_ProtectZero.Enabled && !check_ProtectZero.Checked) { xeniaParameters.Add("--protect_zero=false"); }
                if (check_Gamma.Enabled && check_Gamma.Checked) { xeniaParameters.Add("--kernel_display_gamma_type=2"); }
                if (HardTextureRAM.Enabled && HardTextureRAM.Value != 0) { xeniaParameters.Add($"--d3d12_texture_cache_limit_hard={HardTextureRAM.Value}"); }
                if (SoftTextureRAM.Enabled && SoftTextureRAM.Value != 0) { xeniaParameters.Add($"--d3d12_texture_cache_limit_soft={SoftTextureRAM.Value}"); }
                if (SoftCacheLifetime.Enabled && SoftCacheLifetime.Value != 0) { xeniaParameters.Add($"--d3d12_texture_cache_limit_soft_lifetime={SoftCacheLifetime.Value}"); }
                if (check_Debug.Enabled && check_Debug.Checked) { xeniaParameters.Add("--debug"); }

                launchArgs = xeniaParameters.ToArray();

                Console.WriteLine($"\nStarting Xenia <{combo_API.Text}>\n");
                Console.WriteLine($"Parameters:\n");
                //xeniaParameters.ForEach(i => Console.Write("{0}\n", i));
                Console.WriteLine(string.Join(" ", xeniaParameters.ToArray()));
                ProcessStartInfo xeniaExec;
                if (combo_API.SelectedIndex == 0)
                {
                    xeniaExec = new ProcessStartInfo(vkXeniaPath)
                    {
                        WorkingDirectory = Path.GetDirectoryName(vkXeniaPath),
                        Arguments = string.Join(" ", xeniaParameters.ToArray())
                    };
                }
                else
                {
                    xeniaExec = new ProcessStartInfo(dx12XeniaPath)
                    {
                        WorkingDirectory = Path.GetDirectoryName(dx12XeniaPath),
                        Arguments = string.Join(" ", xeniaParameters.ToArray())
                    };
                }
                var xenia = Process.Start(xeniaExec);
                xenia.WaitForExit();

                if (!check_manUninstall.Checked) CleanUpMods();

                if (check_Debug.Checked)
                {
                    Tools.XeniaException.GetErrors();
                    Tools.XeniaException.GetWarnings();
                }
            }
            else
            {
                MessageBox.Show("Please specify your executable file for Xenia.", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Windows.Forms.OpenFileDialog xeniaBrowser = new System.Windows.Forms.OpenFileDialog();
                xeniaBrowser.Title = "Select a Xenia executable...";
                xeniaBrowser.Filter = "Programs (*.exe)|*.exe";
                xeniaBrowser.FilterIndex = 1;
                xeniaBrowser.RestoreDirectory = true;
                if (xeniaBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (combo_API.SelectedIndex == 0)
                    {
                        xeniaBox.Text = xeniaBrowser.FileName;
                        Properties.Settings.Default.vkXeniaPath = xeniaBrowser.FileName;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        xeniaBox.Text = xeniaBrowser.FileName;
                        Properties.Settings.Default.dx12XeniaPath = xeniaBrowser.FileName;
                        Properties.Settings.Default.Save();
                    }

                    tab_Section.SelectedIndex = 1;
                }
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.xex");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.xex");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create(Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString())));
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/archives/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.wmv");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.wmv");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/event/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/e/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.xma");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}xenon/sound/voice/j/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.BIN");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString()))}.BIN");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create(Path.Combine(ftpLocationBox.Text, Path.GetFileNameWithoutExtension(item.ToString())));
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/archives/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.pam");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{Path.GetFileNameWithoutExtension(item.ToString())}.pam");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/event/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/event/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/e/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/e/{item.ToString()}");
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
                            FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/j/{Path.GetFileNameWithoutExtension(item.ToString())}.at3");
                                ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                                ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                            }

                            FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}ps3/sound/voice/j/{item.ToString()}");
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
                        FtpWebRequest getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}win32/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                        getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                            FtpWebRequest ps3cleanupStep1 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}win32/archives/{Path.GetFileNameWithoutExtension(item.ToString())}.arc");
                            ps3cleanupStep1.Method = WebRequestMethods.Ftp.DeleteFile;
                            ps3cleanupStep1.Credentials = new NetworkCredential(userField.Text, passField.Text);
                            FtpWebResponse ps3DeleteResponse = (FtpWebResponse)ps3cleanupStep1.GetResponse();
                        }

                        FtpWebRequest ps3cleanupStep2 = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}win32/archives/{item.ToString()}");
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
            string[] filesToCopy;
            List<string> filesToCopyList = new List<string>();
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
                if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                {
                    using (StreamReader configFile = new StreamReader($"{Path.Combine(modsPath, item)}\\mod.ini"))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.Contains("Read-only=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                string[] filesToCopyBroken = entryValue.Split(',');
                                filesToCopy = filesToCopyBroken.Select(x => x.Replace("\"", string.Empty)).ToArray();
                                foreach (string file in filesToCopy)
                                {
                                    filesToCopyList.Add(file);
                                }
                            }
                        }
                    }
                }

                var mods = Directory.GetFiles($"{modsPath}\\{item}", "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".arc") || s.EndsWith(".wmv") || s.EndsWith(".xma") || s.EndsWith(".xex"));

                foreach (var mod in mods)
                {
                    arcPath = mod.Remove(0, $"{modsPath}\\{item}".Length);
                    origArcPath = s06Path + arcPath;
                    targetArcPath = origArcPath + "_back";
                    patchArcPath = origArcPath + "_orig";

                    if (!check_FTP.Checked)
                    {
                        if (File.Exists($"{modsPath}\\{item}\\mod.ini"))
                        {
                            if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Platform=\"Xbox 360\""))
                            {
                                if (File.ReadAllLines($"{modsPath}\\{item}\\mod.ini").Contains("Merge=\"True\""))
                                {
                                    if (Path.GetExtension(mod) == ".arc")
                                    {
                                        if (!File.Exists(patchArcPath))
                                        {
                                            if (string.Join(" ", filesToCopyList.ToArray()).Contains(Path.GetFileName(mod)))
                                            {
                                                Console.WriteLine("Copying " + mod);
                                                if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                                File.Copy(mod, origArcPath, true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Merging " + mod);
                                                MergeARCs(origArcPath, mod, origArcPath, false, string.Empty);
                                            }
                                        }
                                        else
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a patch was already installed on file: {Path.GetFileName(mod)})");
                                        }
                                    }
                                    else
                                    {
                                        if ((!File.Exists(targetArcPath) || !File.Exists(patchArcPath)) == false)
                                        {
                                            Console.WriteLine("Copying " + mod);
                                            if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                            File.Copy(mod, origArcPath, true);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Skipped " + mod);
                                            if (Path.GetExtension(mod).Contains(".arc"))
                                            {
                                                if (File.Exists(targetArcPath))
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                }
                                                else if (File.Exists(patchArcPath))
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a patch was already installed on file: {Path.GetFileName(mod)})");
                                                }
                                                else
                                                {
                                                    skippedMods.Add($"\n► {item} (failed for literally no reason whatsoever)");
                                                }
                                            }
                                            else
                                            {
                                                skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                            }
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if ((!File.Exists(targetArcPath) || !File.Exists(patchArcPath)) == false)
                                    {
                                        Console.WriteLine("Copying " + mod);
                                        if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                        File.Copy(mod, origArcPath, true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Skipped " + mod);
                                        if (Path.GetExtension(mod).Contains(".arc"))
                                        {
                                            if (File.Exists(targetArcPath))
                                            {
                                                skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                            }
                                            else if (File.Exists(patchArcPath))
                                            {
                                                skippedMods.Add($"\n► {item} (failed because a patch was already installed on file: {Path.GetFileName(mod)})");
                                            }
                                            else
                                            {
                                                skippedMods.Add($"\n► {item} (failed for literally no reason whatsoever)");
                                            }
                                        }
                                        else
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                        }
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
                            if ((!File.Exists(targetArcPath) || !File.Exists(patchArcPath)) == false)
                            {
                                Console.WriteLine("Copying " + mod);
                                if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
                                File.Copy(mod, origArcPath, true);
                            }
                            else
                            {
                                Console.WriteLine("Skipped " + mod);
                                if (Path.GetExtension(mod).Contains(".arc"))
                                {
                                    if (File.Exists(targetArcPath))
                                    {
                                        skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                    }
                                    else if (File.Exists(patchArcPath))
                                    {
                                        skippedMods.Add($"\n► {item} (failed because a patch was already installed on file: {Path.GetFileName(mod)})");
                                    }
                                    else
                                    {
                                        skippedMods.Add($"\n► {item} (failed for literally no reason whatsoever)");
                                    }
                                }
                                else
                                {
                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                }
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
                                            client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                            if (Path.GetExtension(mod) == ".arc")
                                            {
                                                if (string.Join(" ", filesToCopyList.ToArray()).Contains(Path.GetFileName(mod)))
                                                {
                                                    client.UseDefaultCredentials = true;
                                                    client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                                    bool fileExists = false;
                                                    FtpWebRequest getFile = null;
                                                    if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                        if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                        Console.WriteLine(win32cleanup.RequestUri);
                                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                        win32cleanup.UseBinary = false;
                                                        win32cleanup.UsePassive = true;
                                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                        if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                    }
                                                }
                                                else
                                                {
                                                    byte[] arcBytes = null;
                                                    if (mod.Contains(@"\xenon\archives\")) arcBytes = client.DownloadData($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                    else break;

                                                    Directory.CreateDirectory(tempPath);

                                                    using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                                    {
                                                        file.Write(arcBytes, 0, arcBytes.Length);
                                                        file.Close();
                                                    }

                                                    bool fileExists = false;
                                                    FtpWebRequest getFile = null;
                                                    if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                    else break;
                                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                        if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                        else break;
                                                        Console.WriteLine(win32cleanup.RequestUri);
                                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                        win32cleanup.UseBinary = false;
                                                        win32cleanup.UsePassive = true;
                                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                    }

                                                    MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);

                                                    if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                    else break;
                                                }
                                            }
                                            else
                                            {
                                                client.UseDefaultCredentials = true;
                                                client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                    if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
                                            client.UseDefaultCredentials = true;
                                            client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                            bool fileExists = false;
                                            FtpWebRequest getFile = null;
                                            if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                if (Path.GetExtension(mod) == ".arc")
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                }
                                                else
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                FtpWebRequest win32cleanup = null;
                                                if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                Console.WriteLine(win32cleanup.RequestUri);
                                                win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                win32cleanup.UseBinary = false;
                                                win32cleanup.UsePassive = true;
                                                FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
                                    client.UseDefaultCredentials = true;
                                    client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                    bool fileExists = false;
                                    FtpWebRequest getFile = null;
                                    if (mod.Contains(@"\xenon\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\xenon\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                        if (Path.GetExtension(mod) == ".arc")
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                        }
                                        else
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        FtpWebRequest win32cleanup = null;
                                        if (mod.Contains(@"\xenon\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        if (mod.Contains(@"\xenon\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\xenon\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"xenon/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
                                            client.Credentials = new NetworkCredential(userField.Text, passField.Text);

                                            if (Path.GetExtension(mod) == ".arc")
                                            {
                                                if (string.Join(" ", filesToCopyList.ToArray()).Contains(Path.GetFileName(mod)))
                                                {
                                                    bool fileExists = false;
                                                    FtpWebRequest getFile = null;
                                                    if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                        if (Path.GetExtension(mod) == ".arc")
                                                        {
                                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                        }
                                                        else
                                                        {
                                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FtpWebRequest win32cleanup = null;
                                                        if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                        Console.WriteLine(win32cleanup.RequestUri);
                                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                        win32cleanup.UseBinary = false;
                                                        win32cleanup.UsePassive = true;
                                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                        if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                    }
                                                }
                                                else
                                                {
                                                    byte[] arcBytes = null;
                                                    if (mod.Contains(@"\ps3\archives\")) arcBytes = client.DownloadData($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) arcBytes = client.DownloadData($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                    else break;

                                                    Directory.CreateDirectory(tempPath);

                                                    using (FileStream file = File.Create($"{tempPath}\\{Path.GetFileName(mod)}"))
                                                    {
                                                        file.Write(arcBytes, 0, arcBytes.Length);
                                                        file.Close();
                                                    }

                                                    bool fileExists = false;
                                                    FtpWebRequest getFile = null;
                                                    if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                                    else break;
                                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                        if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                        else break;
                                                        Console.WriteLine(win32cleanup.RequestUri);
                                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                        win32cleanup.UseBinary = false;
                                                        win32cleanup.UsePassive = true;
                                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                    }

                                                    MergeARCs($"{tempPath}\\{Path.GetFileName(mod)}", mod, $"{tempPath}\\{Path.GetFileName(mod)}", true, tempPath);

                                                    if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, $"{tempPath}\\{Path.GetFileName(mod)}");
                                                    else break;
                                                }
                                            }
                                            else
                                            {
                                                bool fileExists = false;
                                                FtpWebRequest getFile = null;
                                                if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                                else break;
                                                getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                    if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                    else break;
                                                    Console.WriteLine(win32cleanup.RequestUri);
                                                    win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                    win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                    win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                    win32cleanup.UseBinary = false;
                                                    win32cleanup.UsePassive = true;
                                                    FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();
                                                }

                                                if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
                                            if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                            else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                            getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                                if (Path.GetExtension(mod) == ".arc")
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                                }
                                                else
                                                {
                                                    skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                FtpWebRequest win32cleanup = null;
                                                if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                                else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                                Console.WriteLine(win32cleanup.RequestUri);
                                                win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                                win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                                win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                                win32cleanup.UseBinary = false;
                                                win32cleanup.UsePassive = true;
                                                FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                                if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                                else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
                                    if (mod.Contains(@"\ps3\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\event\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\voice\e\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\ps3\sound\voice\j\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}_back");
                                    else if (mod.Contains(@"\win32\archives\")) getFile = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}_back");
                                    getFile.Credentials = new NetworkCredential(userField.Text, passField.Text);
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
                                        if (Path.GetExtension(mod) == ".arc")
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)} - try merging instead)");
                                        }
                                        else
                                        {
                                            skippedMods.Add($"\n► {item} (failed because a mod was already installed on file: {Path.GetFileName(mod)})");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        FtpWebRequest win32cleanup = null;
                                        if (mod.Contains(@"\ps3\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\event\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}");
                                        else if (mod.Contains(@"\win32\archives\")) win32cleanup = (FtpWebRequest)WebRequest.Create($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}");
                                        Console.WriteLine(win32cleanup.RequestUri);
                                        win32cleanup.Method = WebRequestMethods.Ftp.Rename;
                                        win32cleanup.Credentials = new NetworkCredential(userField.Text, passField.Text);
                                        win32cleanup.RenameTo = $"{Path.GetFileName(mod)}_back";
                                        win32cleanup.UseBinary = false;
                                        win32cleanup.UsePassive = true;
                                        FtpWebResponse win32RenameResponse = (FtpWebResponse)win32cleanup.GetResponse();

                                        if (mod.Contains(@"\ps3\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\event\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/event/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\e\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/e/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\ps3\sound\voice\j\")) client.UploadFile($"{ftpLocationBox.Text}{"ps3/sound/voice/j/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
                                        else if (mod.Contains(@"\win32\archives\")) client.UploadFile($"{ftpLocationBox.Text}{"win32/archives/"}{Path.GetFileName(mod)}", WebRequestMethods.Ftp.UploadFile, mod);
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
            if (tab_Section.SelectedIndex == 2)
            {
                if (patchesList.SelectedIndex == -1) return;
                else
                {
                    if (patchesList.Items[patchesList.SelectedIndex].ToString() == "Disable Shadows")
                    {
                        MessageBox.Show("This patch will disable all real-time shadows. This can provide a minor performance boost and will make the game render darkness by vertex colouring.", patchesList.Items[patchesList.SelectedIndex].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (patchesList.Items[patchesList.SelectedIndex].ToString() == "Omega Blur Fix")
                    {
                        MessageBox.Show("This patch will replace Omega's shaders to prevent the sprites from becoming blurry on Xenia.", patchesList.Items[patchesList.SelectedIndex].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (patchesList.Items[patchesList.SelectedIndex].ToString() == "Vulkan API Compatibility")
                    {
                        MessageBox.Show("This patch will enable the fixes so the game renders correctly with the Vulkan API on Xenia.", patchesList.Items[patchesList.SelectedIndex].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
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
            else if (check_FTP.Checked && tab_Section.SelectedIndex != 2 || check_manUninstall.Checked && tab_Section.SelectedIndex != 2) { playButton.Text = "Install Mods"; stopButton.Text = "Uninstall Mods"; }
            else if (!check_FTP.Checked && tab_Section.SelectedIndex != 2 || !check_manUninstall.Checked && tab_Section.SelectedIndex != 2) { playButton.Text = "Save and Play"; }
            else { playButton.Text = "Apply Patches"; stopButton.Text = "Restore Defaults"; }
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
                playButton.Text = "Test Connection";

                playButton.Width = 101;

                check_manUninstall.Enabled = false;
                stopButton.Visible = true;
                lbl_GameDirectory.Enabled = false;
                s06PathBox.Enabled = false;
                s06PathButton.Enabled = false;
                launchXeniaButton.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                patchesList.Enabled = false;
                label1.Enabled = false;
                label3.Enabled = false;
                combo_MSAA.Enabled = false;
                combo_Reflections.Enabled = false;
                lbl_MSAAdef.Enabled = false;
                lbl_Reflectionsdef.Enabled = false;

                if (ftpPath == string.Empty) { ftpLocationBox.Text = "ftp://"; }
                else { ftpLocationBox.Text = ftpPath; }

                Properties.Settings.Default.ftp = true;
            }
            else
            {
                playButton.Text = "Save and Play";

                if (check_manUninstall.Checked == true)
                {
                    playButton.Width = 101;
                    stopButton.Visible = true;
                }
                else
                {
                    playButton.Width = 207;
                    stopButton.Visible = false;
                }

                check_manUninstall.Enabled = true;
                lbl_GameDirectory.Enabled = true;
                s06PathBox.Enabled = true;
                s06PathButton.Enabled = true;
                launchXeniaButton.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                patchesList.Enabled = true;
                label1.Enabled = true;
                label3.Enabled = true;
                combo_MSAA.Enabled = true;
                combo_Reflections.Enabled = true;
                lbl_MSAAdef.Enabled = true;
                lbl_Reflectionsdef.Enabled = true;

                Properties.Settings.Default.ftp = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Combo_System_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ftpSystem = combo_System.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (stopButton.Text == "Uninstall Mods")
            {
                try
                {
                    if (check_FTP.Checked)
                    {
                        if (ftpLocationBox.Text.StartsWith("ftp://"))
                        {
                            if (ftpLocationBox.Text.EndsWith("/"))
                            {
                                CleanUpMods();
                            }
                            else
                            {
                                ftpLocationBox.AppendText("/");
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
            else
            {
                try
                {
                    combo_MSAA.SelectedIndex = 1;
                    combo_Reflections.SelectedIndex = 1;
                    viewportX.Value = 1280;
                    viewportY.Value = 720;

                    //Unchecks all available checkboxes.
                    for (int i = 0; i < patchesList.Items.Count; i++) patchesList.SetItemChecked(i, false);

                    if (s06Path != string.Empty)
                    {
                        var mods = Directory.GetFiles(s06Path, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".arc_orig"));

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
                    File.Delete($"{modsPath}\\patches.ini");
                    MessageBox.Show("Patch uninstall complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Please refer to the following error for more information:\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tools.Notification.Dispose();
                    return;
                }
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
            Properties.Settings.Default.priority = combo_Priority.SelectedIndex;
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
                playButton.Width = 101;
                stopButton.Visible = true;
                check_FTP.Enabled = false;

                Properties.Settings.Default.manUninstall = true;
            }
            else
            {
                playButton.Text = "Save and Play";
                playButton.Width = 207;
                stopButton.Visible = false;
                check_FTP.Enabled = true;

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

        private void Btn_SaveMods_Click(object sender, EventArgs e)
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

            SaveChecks();
            RefreshMods();
        }

        private void FtpLocationBox_TextChanged(object sender, EventArgs e)
        {
            ftpPath = ftpLocationBox.Text;
            if (ftpLocationBox.Text == string.Empty) { ftpLocationBox.Text = "ftp://"; }
            Properties.Settings.Default.ftpPath = ftpPath;
            Properties.Settings.Default.Save();
        }

        private void Combo_MSAA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_MSAA.SelectedIndex == 1)
            //{
            //    lbl_MSAAdef.Visible = true;
            //}
            //else if (combo_MSAA.SelectedIndex == 2)
            //{
            //    lbl_MSAAdef.Visible = false;
            //    if (Properties.Settings.Default.msaaLevel != 2) MessageBox.Show("4x MSAA can cause issues in certain sections of the game. Use this at your own risk.", "MSAA Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    lbl_MSAAdef.Visible = false;
            //}
            //Properties.Settings.Default.msaaLevel = combo_MSAA.SelectedIndex;
            //Properties.Settings.Default.Save();
        }

        private void Combo_Reflections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Reflections.SelectedIndex != 1)
            {
                lbl_Reflectionsdef.Visible = false;
                Properties.Settings.Default.reflectionLevel = combo_Reflections.SelectedIndex;
            }
            else
            {
                lbl_Reflectionsdef.Visible = true;
                Properties.Settings.Default.reflectionLevel = combo_Reflections.SelectedIndex;
            }
            Properties.Settings.Default.Save();
        }

        private void Tab_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_Section.SelectedIndex == 2)
            {
                button1.Text = "Patch Info";
                playButton.Text = "Apply Patches";
                playButton.Width = 101;
                stopButton.Text = "Restore Defaults";
                stopButton.Visible = true;
            }
            else
            {
                button1.Text = "Mod Info";
                if (check_manUninstall.Checked) playButton.Text = "Install Mods";
                else
                {
                    playButton.Text = "Save and Play";
                    playButton.Width = 207;
                    stopButton.Text = "Uninstall Mods";
                    stopButton.Visible = false;
                }
            }

            if (tab_Section.SelectedIndex != 0) { refreshButton.Enabled = false; }
            else { refreshButton.Enabled = true; }

            if (tab_Section.SelectedIndex == 0)
            {
                radio_All.Visible = true;
                radio_Xbox.Visible = true;
                radio_PlayStation.Visible = true;
            }
            else
            {
                radio_All.Visible = false;
                radio_Xbox.Visible = false;
                radio_PlayStation.Visible = false;
            }

            modList.ClearSelected();
            patchesList.ClearSelected();
        }

        private void PatchesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = this.patchesList.SelectedIndex >= 0;
        }

        private void Combo_API_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_API.SelectedIndex == 0)
            {
                check_RTV.Enabled = false;
                check_2xRes.Enabled = false;
                check_VulkanOnDX12.Enabled = false;
                HardTextureRAM.Enabled = false;
                SoftTextureRAM.Enabled = false;
                SoftCacheLifetime.Enabled = false;
                lbl_HardCache.Enabled = false;
                lbl_SoftCache.Enabled = false;
                lbl_SoftLifetime.Enabled = false;

                xeniaBox.Text = Properties.Settings.Default.vkXeniaPath;
            }
            else
            {
                check_VulkanOnDX12.Enabled = true;
                xeniaBox.Text = Properties.Settings.Default.dx12XeniaPath;

                if (check_VulkanOnDX12.Checked)
                {
                    check_RTV.Enabled = false;
                    check_2xRes.Enabled = false;
                    HardTextureRAM.Enabled = false;
                    SoftTextureRAM.Enabled = false;
                    SoftCacheLifetime.Enabled = false;
                    lbl_HardCache.Enabled = false;
                    lbl_SoftCache.Enabled = false;
                    lbl_SoftLifetime.Enabled = false;
                }
                else
                {
                    check_RTV.Enabled = true;
                    check_2xRes.Enabled = true;
                    check_VulkanOnDX12.Enabled = true;
                    HardTextureRAM.Enabled = true;
                    SoftTextureRAM.Enabled = true;
                    SoftCacheLifetime.Enabled = true;
                    lbl_HardCache.Enabled = true;
                    lbl_SoftCache.Enabled = true;
                    lbl_SoftLifetime.Enabled = true;
                }
            }
            Properties.Settings.Default.api = combo_API.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Check_VulkanOnDX12_CheckedChanged(object sender, EventArgs e)
        {
            if (check_VulkanOnDX12.Checked)
            {
                check_RTV.Enabled = false;
                check_2xRes.Enabled = false;
                HardTextureRAM.Enabled = false;
                SoftTextureRAM.Enabled = false;
                SoftCacheLifetime.Enabled = false;
                lbl_HardCache.Enabled = false;
                lbl_SoftCache.Enabled = false;
                lbl_SoftLifetime.Enabled = false;
            }
            else
            {
                check_RTV.Enabled = true;
                check_2xRes.Enabled = true;
                HardTextureRAM.Enabled = true;
                SoftTextureRAM.Enabled = true;
                SoftCacheLifetime.Enabled = true;
                lbl_HardCache.Enabled = true;
                lbl_SoftCache.Enabled = true;
                lbl_SoftLifetime.Enabled = true;
            }
            Properties.Settings.Default.vulkanOnDX12 = check_VulkanOnDX12.Checked;
            Properties.Settings.Default.Save();
        }

        private void Check_RTV_CheckedChanged(object sender, EventArgs e)
        {
            if (check_RTV.Checked)
            {
                check_2xRes.Enabled = false;
            }
            else
            {
                check_2xRes.Enabled = true;
            }
            Properties.Settings.Default.rtv = check_RTV.Checked;
            Properties.Settings.Default.Save();
        }

        private void Check_2xRes_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.doubleIntRes = check_2xRes.Checked;
            Properties.Settings.Default.Save();
        }

        private void Check_VSync_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.vsync = check_VSync.Checked;
            Properties.Settings.Default.Save();
        }

        private void Check_ProtectZero_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.protectZero = check_ProtectZero.Checked;
            Properties.Settings.Default.Save();
        }

        private void Check_Gamma_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.gamma = check_Gamma.Checked;
            Properties.Settings.Default.Save();
        }

        public static void WriteDecompiler()
        {
            //Writes the decompiler to the failsafe directory to ensure any LUBs left over from other open archives aren't copied over to the selected archive.
            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\");
            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs")) Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs");
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar")) File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar", Properties.Resources.unlub);
            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat"))
            {
                var decompilerWrite = File.Create($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat");
                var decompilerText = new UTF8Encoding(true).GetBytes("cd \".\\lubs\"\nfor /r %%i in (*.lub) do java -jar ..\\unlub.jar \"%%~dpni.lub\" > \"%%~dpni.lua\"\nxcopy \".\\*.lua\" \"..\\luas\" /y /i\ndel \".\\*.lua\" /q\n@ECHO OFF\n:delete\ndel /q /f *.lub\n@ECHO OFF\n:rename\ncd \"..\\luas\"\nrename \"*.lua\" \"*.lub\"\nexit");
                decompilerWrite.Write(decompilerText, 0, decompilerText.Length);
                decompilerWrite.Close();
            }
        }

        private void PatchARC(string arc, string output)
        {
            installState = "patch";
            var convertDialog = new ModStatus();
            var parentLeft = Left + ((Width - convertDialog.Width) / 2);
            var parentTop = Top + ((Height - convertDialog.Height) / 2);
            convertDialog.Location = new System.Drawing.Point(parentLeft, parentTop);
            convertDialog.Show();

            if (patchesList.GetItemChecked(1)) { Tools.Patch.Omega_Blur_Fix(); }

            string tempPath = $"{applicationData}\\Temp\\{Path.GetRandomFileName()}";
            var tempData = new DirectoryInfo(tempPath);
            Directory.CreateDirectory(tempPath);
            File.Copy(arc, Path.Combine(tempPath, Path.GetFileName(arc)));
            if (!File.Exists($"{arc}_orig")) File.Move(arc, $"{arc}_orig");

            ProcessStartInfo patch;

            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc))}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack1 = Process.Start(patch);
            Unpack1.WaitForExit();
            Unpack1.Close();

            WriteDecompiler();

            //Unused MSAA Code - Lua decompiler appears to break 'render_main.lub,' so this won't be possible
            //(it's pointless anyway, as the game crashes with anything other than 2x).
            #region Unused MSAA Code
            //if (combo_MSAA.Enabled)
            //{
            //    #region No MSAA
            //    if (combo_MSAA.SelectedIndex == 0)
            //    {
            //        //Checks the header for each file to ensure that it can be safely decompiled.
            //        if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub"))
            //        {
            //            if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub")[0].Contains("LuaP"))
            //            {
            //                File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_main.lub", true);

            //                patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
            //                {
            //                    WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
            //                    WindowStyle = ProcessWindowStyle.Hidden
            //                };

            //                var Patch1 = Process.Start(patch);
            //                Patch1.WaitForExit();
            //                Patch1.Close();

            //                File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_main.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", true);
            //            }
            //            else
            //            {
            //                string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub");
            //                for (int i = 0; i < lines.Length; i++)
            //                {
            //                    if (lines[i].Contains("MSAAType = \""))
            //                        lines[i] = "MSAAType = \"0x\"";
            //                    if (lines[i].Contains("SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0"))
            //                        lines[i] = "    SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0)";
            //                }
            //                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", lines);
            //            }
            //        }
            //    }
            //    #endregion

            //    #region 2x MSAA
            //    else if (combo_MSAA.SelectedIndex == 1)
            //    {
            //        //Checks the header for each file to ensure that it can be safely decompiled.
            //        if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub"))
            //        {
            //            if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub")[0].Contains("LuaP"))
            //            {
            //                File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_main.lub", true);

            //                patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
            //                {
            //                    WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
            //                    WindowStyle = ProcessWindowStyle.Hidden
            //                };

            //                var Patch1 = Process.Start(patch);
            //                Patch1.WaitForExit();
            //                Patch1.Close();

            //                File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_main.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", true);
            //            }
            //            else
            //            {
            //                string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub");
            //                for (int i = 0; i < lines.Length; i++)
            //                {
            //                    if (lines[i].Contains("MSAAType = \""))
            //                        lines[i] = "MSAAType = \"2x\"";
            //                    if (lines[i].Contains("SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0"))
            //                        lines[i] = "    SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0, MSAAType)";
            //                }
            //                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", lines);
            //            }
            //        }
            //    }
            //    #endregion

            //    #region 4x MSAA
            //    else if (combo_MSAA.SelectedIndex == 2)
            //    {
            //        //Checks the header for each file to ensure that it can be safely decompiled.
            //        if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub"))
            //        {
            //            if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub")[0].Contains("LuaP"))
            //            {
            //                File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_main.lub", true);

            //                patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
            //                {
            //                    WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
            //                    WindowStyle = ProcessWindowStyle.Hidden
            //                };

            //                var Patch1 = Process.Start(patch);
            //                Patch1.WaitForExit();
            //                Patch1.Close();

            //                File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_main.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", true);
            //            }
            //            else
            //            {
            //                string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub");
            //                for (int i = 0; i < lines.Length; i++)
            //                {
            //                    if (lines[i].Contains("MSAAType = \""))
            //                        lines[i] = "MSAAType = \"4x\"";
            //                    if (lines[i].Contains("SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0"))
            //                        lines[i] = "    SetFrameBufferObject(_ARG_0_, \"framebuffer_hdr\", _ARG_2_ .. \"_texture\", \"all\", 0, 0, 0, 0, MSAAType)";
            //                }
            //                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", lines);
            //            }
            //        }
            //    }
            //    #endregion
            //}
            #endregion

            if (combo_Reflections.Enabled)
            {
                #region No Reflections
                if (combo_Reflections.SelectedIndex == 0)
                {
                    //Checks the header for each file to ensure that it can be safely decompiled.
                    if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub"))
                    {
                        if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub")[0].Contains("LuaP"))
                        {
                            File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_reflection.lub", true);

                            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                            {
                                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            var Patch1 = Process.Start(patch);
                            Patch1.WaitForExit();
                            Patch1.Close();

                            File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_reflection.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", true);
                        }

                        string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("EnableReflection ="))
                                lines[i] = "EnableReflection = false";
                        }
                        File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", lines);
                    }
                }
                #endregion

                #region Quarter Reflections
                else if (combo_Reflections.SelectedIndex == 1)
                {
                    //Checks the header for each file to ensure that it can be safely decompiled.
                    if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub"))
                    {
                        if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub")[0].Contains("LuaP"))
                        {
                            File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_reflection.lub", true);

                            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                            {
                                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            var Patch1 = Process.Start(patch);
                            Patch1.WaitForExit();
                            Patch1.Close();

                            File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_reflection.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", true);
                        }

                        string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("EnableReflection ="))
                                lines[i] = "EnableReflection = true";
                            if (lines[i].Contains("texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\") / 4";
                            if (lines[i].Contains("texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\") / 4";
                        }
                        File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", lines);
                    }
                }
                #endregion

                #region Half Reflections
                else if (combo_Reflections.SelectedIndex == 2)
                {
                    //Checks the header for each file to ensure that it can be safely decompiled.
                    if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub"))
                    {
                        if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub")[0].Contains("LuaP"))
                        {
                            File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_reflection.lub", true);
                            
                            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                            {
                                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            var Patch1 = Process.Start(patch);
                            Patch1.WaitForExit();
                            Patch1.Close();

                            File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_reflection.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", true);
                        }

                        string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("EnableReflection ="))
                                lines[i] = "EnableReflection = true";
                            if (lines[i].Contains("texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\") / 2";
                            if (lines[i].Contains("texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\") / 2";
                        }
                        File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", lines);
                    }
                }
                #endregion

                #region Full Reflections
                else if (combo_Reflections.SelectedIndex == 3)
                {
                    //Checks the header for each file to ensure that it can be safely decompiled.
                    if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub"))
                    {
                        if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub")[0].Contains("LuaP"))
                        {
                            File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_reflection.lub", true);

                            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                            {
                                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            var Patch1 = Process.Start(patch);
                            Patch1.WaitForExit();
                            Patch1.Close();

                            File.Copy($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_reflection.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", true);
                        }

                        string[] lines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("EnableReflection ="))
                                lines[i] = "EnableReflection = true";
                            if (lines[i].Contains("texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_width = GetSurfaceWidth(_ARG_0_, \"backbuffer\")";
                            if (lines[i].Contains("texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\")"))
                                lines[i] = "texture_height = GetSurfaceHeight(_ARG_0_, \"backbuffer\")";
                        }
                        File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_reflection.lub", lines);
                    }
                }
                #endregion
            }

            if (patchesList.GetItemChecked(0)) { Tools.Patch.Disable_Shadows(tempPath); }
            Tools.Patch.Viewport(tempPath, Convert.ToInt32(viewportX.Value), Convert.ToInt32(viewportY.Value));
            if (patchesList.GetItemChecked(2)) { Tools.Patch.Vulkan_API_Compatibility(tempPath); }

            patch = new ProcessStartInfo($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc))}\" -c \"{output}\"")
            {
                WorkingDirectory = $"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack1 = Process.Start(patch);
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

            convertDialog.Close();
        }

        private void InstallPatches()
        {
            if (s06Path != string.Empty)
            {
                Console.WriteLine("Applying patches...");
                if (s06Path != string.Empty)
                {
                    var mods = Directory.GetFiles(s06Path, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".arc_orig"));

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
                PatchARC($"{s06Path}\\xenon\\archives\\cache.arc", $"{s06Path}\\xenon\\archives\\cache.arc");
            }
            else { MessageBox.Show("Please set your Game Directory! We can't patch (or even mod) the game without it...", "Stupid Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void HardTextureRAM_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hardTextureCache = Convert.ToInt32(HardTextureRAM.Value);
            Properties.Settings.Default.Save();
        }

        private void SoftTextureRAM_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.softTextureCache = Convert.ToInt32(SoftTextureRAM.Value);
            Properties.Settings.Default.Save();
        }

        private void SoftCacheLifetime_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.softCacheLifetime = Convert.ToInt32(SoftCacheLifetime.Value);
            Properties.Settings.Default.Save();
        }

        private void Check_Debug_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.debug = check_Debug.Checked;
            Properties.Settings.Default.Save();
        }

        #region Information Text
        private void Combo_System_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option tells Sonic '06 Mod Manager what type of system it's connecting to\n for the correct paths to the files."; }
        private void Combo_System_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void ModsBox_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This is the path to your mods directory... Or at least, we think it is."; }
        private void ModsBox_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void ModsButton_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "I think this button lets you browse for a mods directory."; }
        private void ModsButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void S06PathBox_MouseEnter(object sender, EventArgs e)
        {
            lbl_SettingsInformation.Text = "This should be the path to your game directory. If it's not pointing to the folder\ncontaining 'default.xex' or 'EBOOT.BIN,' you're doing it wrong. =P";
            if (!check_manUninstall.Checked) tm_CheckLabel.Start();
        }
        private void Tm_CheckLabel_Tick(object sender, EventArgs e)
        {
            lbl_SettingsInformation.Text = "This should be the path to your game directory. If it's not pointing to the folder\ncontaining 'default.xex' or 'EBOOT.BIN,' you're doing it wrong. =P\n\nOkay, well... 'EBOOT.BIN' isn't used on the Xbox 360, but you get the point.";
            tm_CheckLabel.Stop();
        }
        private void S06PathBox_MouseLeave(object sender, EventArgs e)
        {
            lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information.";
            tm_CheckLabel.Stop();
        }

        private void S06PathButton_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This might be the button to browse for your game directory."; }
        private void S06PathButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void XeniaBox_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This is the path to your executable file for Xenia. You can have up to two separate\nexecutables, one for Vulkan and one for DirectX 12."; }
        private void XeniaBox_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void XeniaButton_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "There's a very high chance that this button lets you browse for Xenia."; }
        private void XeniaButton_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void label4_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "We apologise for the amount of silly information tags. Those responsible have\nbeen sacked."; }
        private void label4_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Button2_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Opens the About section for Sonic '06 Mod Manager."; }
        private void Button2_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void FtpLocationBox_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This should be the path to your game directory on the FTP server. If it's not\npointing to the folder containing 'default.xex' or 'EBOOT.BIN,' you're doing it\nwrong. =P"; }
        private void FtpLocationBox_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void UserField_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "The username for your FTP server. This field is typically left empty for the\nPlayStation 3."; }
        private void UserField_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void PassField_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "The password for your FTP server. This field is typically left empty for the\nPlayStation 3."; }
        private void PassField_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_FTP_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option is for transferring mods to real hardware via an FTP server. Enable\nthis to make Sonic '06 Mod Manager work with a modded Xbox 360 or\nPlayStation 3 remotely."; }
        private void Check_FTP_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_manUninstall_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option is for both Xenia users and those who want to use real hardware\nwithout an Internet connection.\n\n- For Xenia users, this allows for a more permanent mod installation solution.\n- For those on real hardware, this will be the option for you to install the mods to\n  the game on an external drive."; }
        private void Check_manUninstall_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Btn_SaveMods_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This button will save your selected mods."; }
        private void Btn_SaveMods_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void PlayButton_MouseEnter(object sender, EventArgs e)
        {
            if (check_FTP.Checked && playButton.Text != "Test Connection")
            {
                lbl_SettingsInformation.Text = "This button will install your selected mods to the specified FTP server.";
            }
            else if (check_FTP.Checked && playButton.Text == "Test Connection")
            {
                lbl_SettingsInformation.Text = "This button will attempt to establish a connection to your FTP server.";
            }
            else if (check_manUninstall.Checked)
            {
                lbl_SettingsInformation.Text = "This button will install your selected mods.";
            }
            else
            {
                lbl_SettingsInformation.Text = "This button will install your selected mods and launch Xenia.";
            }
        }
        private void PlayButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void StopButton_MouseEnter(object sender, EventArgs e)
        {
            if (check_FTP.Checked)
            {
                lbl_SettingsInformation.Text = "This button will uninstall all mods in the specified FTP server.";
            }
            else
            {
                lbl_SettingsInformation.Text = "This button will uninstall all mods in the specified game directory.";
            }
        }
        private void StopButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void LaunchXeniaButton_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This button will launch Xenia."; }
        private void LaunchXeniaButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void CreateButton_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This button will reveal the Mod Creator window."; }
        private void CreateButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Button1_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This button will display information about the selected mod."; }
        private void Button1_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void RefreshButton_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This button will refresh the mods list."; }
        private void RefreshButton_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Radio_All_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option will display all mods in the mods list."; }
        private void Radio_All_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Radio_Xbox_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option will display only Xbox 360 mods in the mods list."; }
        private void Radio_Xbox_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Radio_PlayStation_MouseEnter(object sender, EventArgs e) { lbl_SettingsInformation.Text = "This option will display only PlayStation 3 mods in the mods list."; }
        private void Radio_PlayStation_MouseLeave(object sender, EventArgs e) { lbl_SettingsInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Combo_API_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This is where you specify what API the selected build of Xenia uses."; }
        private void Combo_API_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_RTV_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Render Target Views are default on Xenia if your GPU doesn't support\nRasteriser Ordered Views. Rasteriser Ordered Views typically perform better\nthan Render Target Views if your hardware supports it.\n\nIf unsure, leave this unchecked."; }
        private void Check_RTV_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_2xRes_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option will double the internal resolution.\n\nIf unsure, leave this unchecked."; }
        private void Check_2xRes_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_VSync_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Self-explanatory; this option will enable/disable V-Sync. Disabling V-Sync typically\nleads to unstable framerates, as in most cases it removes the framerate cap.\n\nRecommended for SONIC THE HEDGEHOG (2006)."; }
        private void Check_VSync_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_VulkanOnDX12_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option will use the Vulkan API if the selected build of Xenia uses DirectX 12\nby default.\n\nIf unsure, leave this unchecked."; }
        private void Check_VulkanOnDX12_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_ProtectZero_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Protect Zero is the default memory protection mode for Xenia. Disabling this will\nchange how memory protection works.\n\nIf unsure, leave this checked."; }
        private void Check_ProtectZero_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void label6_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "We apologise for the amount of silly information tags. Those responsible have\nbeen sacked."; }
        private void label6_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_Gamma_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option will enable gamma for accurate colours. May not be supported on\nolder Vulkan builds.\n\nRecommended for SONIC THE HEDGEHOG (2006)."; }
        private void Check_Gamma_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Lbl_HardCache_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option sets the hard texture cache limit.\n\nIf unsure, use 512."; }
        private void Lbl_HardCache_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Lbl_SoftCache_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option sets the soft texture cache limit.\n\nIf unsure, use 1024."; }
        private void Lbl_SoftCache_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Lbl_SoftLifetime_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option sets the soft texture cache lifetime.\n\nIf unsure, leave this set to 0."; }
        private void Lbl_SoftLifetime_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }

        private void Check_Debug_MouseEnter(object sender, EventArgs e) { lbl_XeniaInformation.Text = "This option will enable debug mode in Xenia. Once the emulator is closed, you will\nbe provided with error and warning information.\n\nIf unsure, leave this unchecked."; }
        private void Check_Debug_MouseLeave(object sender, EventArgs e) { lbl_XeniaInformation.Text = "Nothing to see here... Hover over an option for more information."; }
        #endregion

        private void ViewportX_ValueChanged(object sender, EventArgs e)
        {
            if (viewportX.Value != 1280) { label10.Text = "Experimental"; }
            else { label10.Text = "Default"; }
            Properties.Settings.Default.viewportX = Convert.ToInt32(viewportX.Value);
            Properties.Settings.Default.Save();
        }

        private void ViewportY_ValueChanged(object sender, EventArgs e)
        {
            if (viewportY.Value != 720) { label9.Text = "Experimental"; }
            else { label9.Text = "Default"; }
            Properties.Settings.Default.viewportY = Convert.ToInt32(viewportY.Value);
            Properties.Settings.Default.Save();
        }
    }
}
