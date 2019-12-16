﻿using System;
using System.IO;
using Unify.Tools;
using System.Text;
using System.Linq;
using Unify.Patcher;
using Ookii.Dialogs;
using Unify.Messages;
using System.Drawing;
using Microsoft.Win32;
using Unify.Networking;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

// Welcome to Project Unify!

// Project Unify is licensed under the MIT License:
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
        public readonly string versionNumber = "Version 2.3"; // Defines the version number to be used globally
        public readonly string modLoaderVersion = "Version 2.01";
        public static List<string> configs = new List<string>() { }; // Defines the configs list for 'mod.ini' files
        public static bool debugMode = false;
        public static DateTime dreamcastNA = new DateTime(1999, 09, 09);
        public static DateTime dreamcastEU = new DateTime(1999, 10, 14);
        public static DateTime dreamcastJP = new DateTime(1998, 11, 27);
        public static DateTime dreamcastAU = new DateTime(1999, 11, 30);
        public static bool dreamcastDay = false;

        public ModManager(string[] args) {
            InitializeComponent();
            ChangeAccentColours(); //Update colours from user settings on program launch.
            ChangeThemeColours(); //Select the theme that is being used from user settings on program launch.

            //Load settings from the Properties.
            #region Properties
            if (dreamcastNA.Day == DateTime.Today.Day && dreamcastNA.Month == DateTime.Today.Month ||
                dreamcastEU.Day == DateTime.Today.Day && dreamcastEU.Month == DateTime.Today.Month ||
                dreamcastJP.Day == DateTime.Today.Day && dreamcastJP.Month == DateTime.Today.Month ||
                dreamcastAU.Day == DateTime.Today.Day && dreamcastAU.Month == DateTime.Today.Month)
            {
                dreamcastDay = true;
                if (!Properties.Settings.Default.dream) { Icon = Properties.Resources.dreamcast_ntsc_icon; Properties.Settings.Default.dream = true; }
                else { Icon = Properties.Resources.dreamcast_pal_icon; Properties.Settings.Default.dream = false; }
                Properties.Settings.Default.Save();
            }

            combo_Emulator_System.SelectedIndex = Properties.Settings.Default.emulatorSystem;

            if (combo_Emulator_System.SelectedIndex == 0)
                text_EmulatorPath.Text = Properties.Settings.Default.xeniaPath;
            else
                text_EmulatorPath.Text = Properties.Settings.Default.RPCS3Path;

            combo_API.SelectedIndex = Properties.Settings.Default.API;
            text_ModsDirectory.Text = Properties.Settings.Default.modsDirectory;
            text_SaveData.Text = Properties.Settings.Default.saveData;
            text_FTPLocation.Text = Properties.Settings.Default.ftpLocation;
            text_Username.Text = Properties.Settings.Default.ftpUsername;

            switch (Properties.Settings.Default.filter) {
                case 0:
                    radio_All.Checked = true;
                    break;
                case 1:
                    radio_Xbox360.Checked = true;
                    break;
                case 2:
                    radio_PlayStation3.Checked = true;
                    break;
            }

            check_RTV.Checked = Properties.Settings.Default.emulator_RTV;
            check_2xRes.Checked = Properties.Settings.Default.emulator_2xRes;
            check_VSync.Checked = Properties.Settings.Default.emulator_VSync;
            check_ProtectZero.Checked = Properties.Settings.Default.emulator_ProtectZero;
            check_Gamma.Checked = Properties.Settings.Default.emulator_Gamma;
            check_Debug.Checked = Properties.Settings.Default.emulator_Debug;
            check_Fullscreen.Checked = Properties.Settings.Default.emulator_Fullscreen;
            check_Discord.Checked = Properties.Settings.Default.emulator_Discord;
            combo_Reflections.SelectedIndex = Properties.Settings.Default.patches_Reflections;
            combo_CameraType.SelectedIndex = Properties.Settings.Default.patches_CameraType;
            check_FTP.Checked = Properties.Settings.Default.FTP;
            check_ManualInstall.Checked = Properties.Settings.Default.manualInstall;
            nud_FieldOfView.Value = Properties.Settings.Default.patches_FieldOfView;
            check_DisableSoftwareUpdater.Checked = Properties.Settings.Default.disableSoftwareUpdater;

            if (Properties.Settings.Default.patches_CameraType == 1 && Properties.Settings.Default.patches_FieldOfView <= 90)
                nud_CameraDistance.Value = 450;
            else if (Properties.Settings.Default.patches_CameraType == 1 && Properties.Settings.Default.patches_FieldOfView > 90)
                nud_CameraDistance.Value = 350;
            else
                nud_CameraDistance.Value = Properties.Settings.Default.patches_CameraDistance;

            nud_CameraHeight.Value = Properties.Settings.Default.patches_CameraHeight;
            nud_FieldOfView.Value = Properties.Settings.Default.patches_FieldOfView;
            check_ManualPatches.Checked = Properties.Settings.Default.manualPatches;
            check_SaveRedirect.Checked = Properties.Settings.Default.saveRedirect;
            combo_Renderer.SelectedIndex = Properties.Settings.Default.patches_Renderer;

            switch (Properties.Settings.Default.priority) {
                case false:
                    btn_Priority.Text = "Priority: Top to Bottom";
                    break;
                case true:
                    btn_Priority.Text = "Priority: Bottom to Top";
                    break;
            }

            if (Properties.Settings.Default.gameDirectory == string.Empty) {
                byte[] bytes;
                string xexPath = Path.Combine(Application.StartupPath, "default.xex");
                string ebootPath = Path.Combine(Application.StartupPath, "EBOOT.BIN");

                if (File.Exists(xexPath)) {
                    bytes = File.ReadAllBytes(xexPath).Take(4).ToArray();
                    var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");

                    if (hexString == "58 45 58 32") {
                        Properties.Settings.Default.gameDirectory = Application.StartupPath;
                        text_GameDirectory.Text = Application.StartupPath;
                        combo_Emulator_System.SelectedIndex = 0;
                        Properties.Settings.Default.Save();
                    }
                } else if (File.Exists(ebootPath)) {
                    bytes = File.ReadAllBytes(ebootPath).Take(3).ToArray();
                    var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");

                    if (hexString == "53 43 45") {
                        Properties.Settings.Default.gameDirectory = Application.StartupPath;
                        text_GameDirectory.Text = Application.StartupPath;
                        combo_Emulator_System.SelectedIndex = 1;
                        Properties.Settings.Default.Save();
                    }
                }
            } else { text_GameDirectory.Text = Properties.Settings.Default.gameDirectory; }

            RegistryKey key = Registry.ClassesRoot.OpenSubKey(GB_Registry.protocol, false); // Open the Sonic '06 Mod Manager protocol key
            RegistryKey getLocation = Registry.ClassesRoot.OpenSubKey($"{GB_Registry.protocol}\\shell\\open\\command");
            if (key == null) // If the key does not exist, keep the checkbox unchecked.
                check_GameBanana.Checked = false;
            else {
                if (getLocation.GetValue(null).ToString() != $"\"{Application.ExecutablePath}\" \"-banana\" \"%1\"")
                    check_GameBanana.Checked = false;
                else
                    check_GameBanana.Checked = true;
            }
            #endregion

            Text = $"{SystemMessages.tl_DefaultTitle} ({versionNumber})";
        }

        public string Status { set { lbl_SetStatus.Text = value; } }

        private void ModManager_Shown(object sender, EventArgs e) { // Using the Shown method is cleaner, as it waits for the main window to appear before performing tasks
            //Ask the user for a mod directory if the textbox for it is empty/the specified path doesn't exist.
            if (text_ModsDirectory.Text == string.Empty || !Directory.Exists(text_ModsDirectory.Text)) {
                UnifyMessages.UnifyMessage.Show(ModsMessages.msg_NoModDirectory, SystemMessages.tl_DefaultTitle, "OK", "Information");

                VistaFolderBrowserDialog mods = new VistaFolderBrowserDialog {
                    Description = SettingsMessages.msg_LocateMods,
                    UseDescriptionForTitle = true,
                };

                if (mods.ShowDialog() == DialogResult.OK) {
                    text_ModsDirectory.Text = mods.SelectedPath;
                    Properties.Settings.Default.modsDirectory = mods.SelectedPath;
                    Properties.Settings.Default.Save();

                    if (Directory.Exists(Properties.Settings.Default.modsDirectory)) GetMods(); // Basically just refreshes and clears up mods on launch
                    else Application.Exit();
                }
                else Application.Exit(); // Close the program if no mods directory is set. Why? Because it's redundant.
            }

            if (Properties.Settings.Default.modsDirectory != string.Empty)
                if (Directory.Exists(Properties.Settings.Default.modsDirectory))
                    GetMods(); // Basically just refreshes and clears up mods on launch
            if (Properties.Settings.Default.gameDirectory != string.Empty) {
                if (Directory.Exists(Properties.Settings.Default.gameDirectory) && !check_ManualInstall.Checked)
                    ARC.CleanupMods(0); // Ensures manual mod install is disabled first
                if (Directory.Exists(Properties.Settings.Default.gameDirectory) && !check_ManualPatches.Checked)
                    ARC.CleanupMods(1); // Ensures manual patch install is disabled first
            }
            if (Properties.Settings.Default.xeniaPath != string.Empty || Properties.Settings.Default.RPCS3Path != string.Empty)
                if (Directory.Exists(Path.GetDirectoryName(Properties.Settings.Default.xeniaPath)) || Directory.Exists(Path.GetDirectoryName(Properties.Settings.Default.RPCS3Path)))
                    if (!check_ManualInstall.Checked) RestoreSaves(); // Ensures manual install is disabled first
            if ((versionNumber.Contains("-indev") || versionNumber.Contains("-beta") || versionNumber.Contains("-test")) == false)
                if (!Properties.Settings.Default.disableSoftwareUpdater)
                    Updater.CheckForUpdates(versionNumber, "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe", "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt", string.Empty);

            if (!Prerequisites.JavaCheck()) UnifyMessages.UnifyMessage.Show(SystemMessages.ex_JavaMissing, SystemMessages.tl_JavaError, "OK", "Information");
        }

        #region Mods
        private void Btn_ModInfo_Click(object sender, EventArgs e) {
            if (unifytb_Main.SelectedIndex == 0) {
                Status = SystemMessages.msg_ModInfo;
                if (File.Exists(configs[clb_ModsList.SelectedIndex]))
                    new src.ModInfo(Path.GetDirectoryName(configs[clb_ModsList.SelectedIndex])).ShowDialog();
                else { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_ModInfoError, SystemMessages.tl_FileError, "OK", "Error"); }
                GetMods();
            } else if (unifytb_Main.SelectedIndex == 2) {
                Status = SystemMessages.msg_PatchInfo;
                if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Action Gauge Fixes for Sonic")) {
                    UnifyMessages.UnifyMessage.Show("This patch will restore Sonic's Action Gauge draining and replenishment when using Gems.", "Action Gauge Fixes for Sonic", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Curved Homing Attack for Sonic")) {
                    UnifyMessages.UnifyMessage.Show("This patch will swap Sonic's homing module with Blaze's to simulate the homing attack from early versions of Sonic '06. However, this removes Sonic's ability to destroy physics objects.", "Curved Homing Attack for Sonic", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Debug Mode")) {
                    UnifyMessages.UnifyMessage.Show("This patch will enable Debug Mode, allowing you to navigate stages with no-clip.\n\nControls:\n► Left Analog Stick/Directional Pad - Move.\n► Right Bumper (R1) - Increase Ring count by 100.\n► Y (Triangle) - Increase height.\n► A (Cross) - Decrease height.", "Debug Mode", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Disable Bloom")) {
                    UnifyMessages.UnifyMessage.Show("This patch will disable bloom entirely, as you would expect from a patch called 'Disable Bloom.'", "Disable Bloom", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Disable HUD")) {
                    UnifyMessages.UnifyMessage.Show("This patch will disable the HUD entirely; including the enemy gauge and water effects on the screen in Kingdom Valley.", "Disable HUD", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Disable Intro Logos")) {
                    UnifyMessages.UnifyMessage.Show("This patch will disable the logos that display when the game launches.", "Disable Intro Logos", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Disable Music")) {
                    UnifyMessages.UnifyMessage.Show("This patch will disable all music tracks. This may only be useful to Xbox 360 players, since the game doesn't save audio settings on that version.", "Disable Music", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Disable Shadows")) {
                    UnifyMessages.UnifyMessage.Show("This patch will disable real-time shadow rendering and baked shadows. This may provide a significant performance boost, but looks pretty ugly.", "Disable Shadows", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Omega Blur Fix")) {
                    UnifyMessages.UnifyMessage.Show("This patch will remove Omega's transparency materials to fix a bug on Xenia where the sprites become blurry.", "Omega Blur Fix", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Silver Grind Trick Fix")) {
                    UnifyMessages.UnifyMessage.Show("This patch will remove a duplicate file extension in Silver's model package for the grind trick animation name, therefore making the animation play in-game.", "Silver Grind Trick Fix", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Unlock Mid-air Momentum")) {
                    UnifyMessages.UnifyMessage.Show("This patch will unlock all mid-air momentum for every character, making it easier to move in the air.", "Unlock Mid-air Momentum", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Unlock Tails' Flight Limit")) {
                    UnifyMessages.UnifyMessage.Show("This patch will unlock Tails' flight limit so he doesn't slam into a ceiling whilst flying. This provides more free control akin to Sonic Adventure.", "Unlock Tails' Flight Limit", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Use Dynamic Bones for Snowboard States")) {
                    UnifyMessages.UnifyMessage.Show("This patch will restore Sonic's hair bones whilst using the snowboard.", "Use Dynamic Bones for Snowboard States", "OK", "Information");
                } else if (clb_PatchesList.SelectedIndex == clb_PatchesList.Items.IndexOf("Xbox Live Arcade Radial Blur")) {
                    UnifyMessages.UnifyMessage.Show("This patch will restore the higher quality radial blur from the Xbox Live Arcade Demo.", "Xbox Live Arcade Radial Blur", "OK", "Information");
                }
            }
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void Btn_EditMod_Click(object sender, EventArgs e) {
            Status = SystemMessages.msg_EditMod;
            if (File.Exists(configs[clb_ModsList.SelectedIndex]))
                new src.ModCreator(Path.GetDirectoryName(configs[clb_ModsList.SelectedIndex]), true).ShowDialog();
            else { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_ModInfoError, SystemMessages.tl_FileError, "OK", "Error"); }
            Status = SystemMessages.msg_DefaultStatus;
            GetMods();
        }

        private void SaveUserOptions()
        {
            Properties.Settings.Default.emulator_RTV = check_RTV.Checked;
            Properties.Settings.Default.emulator_2xRes = check_2xRes.Checked;
            Properties.Settings.Default.emulator_VSync = check_VSync.Checked;
            Properties.Settings.Default.emulator_ProtectZero = check_ProtectZero.Checked;
            Properties.Settings.Default.emulator_Gamma = check_Gamma.Checked;
            Properties.Settings.Default.emulator_Debug = check_Debug.Checked;
            Properties.Settings.Default.emulator_Fullscreen = check_Fullscreen.Checked;
            Properties.Settings.Default.emulator_Discord = check_Discord.Checked;
            Properties.Settings.Default.patches_CameraDistance = Convert.ToInt32(nud_CameraDistance.Value);
            Properties.Settings.Default.patches_FieldOfView = Convert.ToInt32(nud_FieldOfView.Value);
            Properties.Settings.Default.patches_CameraHeight = Convert.ToInt32(nud_CameraHeight.Value);
            Properties.Settings.Default.Save();
        }

        private void Btn_SaveAndPlay_Click(object sender, EventArgs e) {
            ARC.skippedMods.Clear();
            SaveUserOptions();
            SaveChecks();
            GetMods();

            if (((sender as Button).Text == "Save and Play" || (sender as Button).Text == "Install Mods") && !check_FTP.Checked) {
                try {
                    RestoreSaves();
                    ARC.CleanupMods(0);
                    ARC.CleanupMods(1);

                    if (Properties.Settings.Default.priority == false) {
                        //Top to Bottom Priority
                        for (int i = clb_ModsList.Items.Count - 1; i >= 0; i--) {
                            if (clb_ModsList.GetItemChecked(i)) {
                                Status = SystemMessages.msg_InstallingMod(clb_ModsList.Items[i].ToString());
                                ARC.InstallMods(Path.GetDirectoryName(configs[i]), clb_ModsList.Items[i].ToString());
                                Status = SystemMessages.msg_DefaultStatus;

                                if (check_SaveRedirect.Checked) {
                                    Status = SystemMessages.msg_RedirectingSave(clb_ModsList.Items[i].ToString());
                                    ARC.RedirectSaves(Path.GetDirectoryName(configs[i]), clb_ModsList.Items[i].ToString());
                                    Status = SystemMessages.msg_DefaultStatus;
                                }
                            }
                        }
                    } else {
                        //Bottom to Top Priority
                        foreach (object mod in clb_ModsList.CheckedItems) {
                            if (clb_ModsList.GetItemChecked(clb_ModsList.Items.IndexOf(mod))) {
                                Status = SystemMessages.msg_InstallingMod(clb_ModsList.GetItemText(mod));
                                ARC.InstallMods(Path.GetDirectoryName(configs[clb_ModsList.Items.IndexOf(mod)]), clb_ModsList.GetItemText(mod));
                                Status = SystemMessages.msg_DefaultStatus;

                                if (check_SaveRedirect.Checked) {
                                    Status = SystemMessages.msg_RedirectingSave(clb_ModsList.GetItemText(mod));
                                    ARC.RedirectSaves(Path.GetDirectoryName(configs[clb_ModsList.Items.IndexOf(mod)]), clb_ModsList.GetItemText(mod));
                                    Status = SystemMessages.msg_DefaultStatus;
                                }
                            }
                        }
                    }

                    if (!check_ManualPatches.Checked) PatchAll();

                    //Show a MessageBox explaining what mods were skipped due to failing to copy.
                    if (ARC.skippedMods.ToString() != string.Empty) {
                        StringBuilder getString = new StringBuilder();
                        foreach (var modName in ARC.skippedMods)
                            getString.Append(modName);

                        if (getString.Length > 0)
                            UnifyMessages.UnifyMessage.Show(ModsMessages.ex_SkippedModsTally(getString.ToString()), SystemMessages.tl_SuccessWarn, "OK", "Warning");
                    }

                    if (!check_ManualInstall.Checked) {
                        if (combo_Emulator_System.SelectedIndex == 0) {
                            Status = SystemMessages.msg_LaunchXenia;
                            LaunchXenia();
                            Status = SystemMessages.msg_DefaultStatus;
                        }
                        if (combo_Emulator_System.SelectedIndex == 1) {
                            Status = SystemMessages.msg_LaunchRPCS3;
                            LaunchRPCS3();
                            Status = SystemMessages.msg_DefaultStatus;
                        }
                    }
                } catch (Exception ex) {
                    UnifyMessages.UnifyMessage.Show($"{ModsMessages.ex_ModInstallFailure}\n\n{ex}", SystemMessages.tl_FileError, "OK", "Warning");
                    unifytb_Main.SelectedIndex = 3;
                    Status = SystemMessages.msg_DefaultStatus;
                }
            }
            else if ((sender as Button).Text == "Apply Patches") {
                try {
                    if (!check_FTP.Checked) { ARC.CleanupMods(1); PatchAll(); }
                }
                catch (Exception ex) {
                    UnifyMessages.UnifyMessage.Show($"{PatchesMessages.ex_PatchInstallFailure}\n\n{ex}", SystemMessages.tl_FileError, "OK", "Warning");
                    unifytb_Main.SelectedIndex = 3;
                    Status = SystemMessages.msg_DefaultStatus;
                }
            } else {
                if (Properties.Settings.Default.priority == false) {
                    //Top to Bottom Priority
                    for (int i = clb_ModsList.Items.Count - 1; i >= 0; i--) {
                        if (clb_ModsList.GetItemChecked(i)) {
                            Status = SystemMessages.msg_TransferringMod(clb_ModsList.Items[i].ToString());
                            FTP.InstallMods(text_FTPLocation.Text, Path.GetDirectoryName(configs[i]), text_Username.Text, text_Password.Text);
                            Status = SystemMessages.msg_DefaultStatus;
                        }
                    }
                } else {
                    //Bottom to Top Priority
                    foreach (object mod in clb_ModsList.CheckedItems) {
                        if (clb_ModsList.GetItemChecked(clb_ModsList.Items.IndexOf(mod))) {
                            Status = SystemMessages.msg_TransferringMod(clb_ModsList.GetItemText(mod));
                            FTP.InstallMods(text_FTPLocation.Text, Path.GetDirectoryName(configs[clb_ModsList.Items.IndexOf(mod)]), text_Username.Text, text_Password.Text);
                            Status = SystemMessages.msg_DefaultStatus;
                        }
                    }
                }

                //Show a MessageBox explaining what mods were skipped due to failing to copy.
                if (ARC.skippedMods.ToString() != string.Empty) {
                    StringBuilder getString = new StringBuilder();
                    foreach (var modName in ARC.skippedMods)
                        getString.Append(modName);

                    if (getString.Length > 0)
                        UnifyMessages.UnifyMessage.Show(ModsMessages.ex_SkippedModsTally(getString.ToString()), SystemMessages.tl_SuccessWarn, "OK", "Warning");
                }
            }
        }

        private void RestoreSaves()
        {
            if (Properties.Settings.Default.priority == false) {
                //Top to Bottom Priority
                for (int i = clb_ModsList.Items.Count - 1; i >= 0; i--) {
                    if (clb_ModsList.GetItemChecked(i)) {
                        try {
                            Status = SystemMessages.msg_Cleanup;
                            ARC.CleanupSaves(Path.GetDirectoryName(configs[i]), clb_ModsList.Items[i].ToString());
                            Status = SystemMessages.msg_DefaultStatus;
                        }
                        catch { }
                    }
                }
            } else {
                //Bottom to Top Priority
                foreach (object mod in clb_ModsList.CheckedItems) {
                    try {
                        Status = SystemMessages.msg_Cleanup;
                        ARC.CleanupSaves(Path.GetDirectoryName(configs[clb_ModsList.Items.IndexOf(mod)]), clb_ModsList.GetItemText(mod));
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                    catch { }
                }
            }
        }

        private void PatchAll()
        {
            var files = Directory.GetFiles(Properties.Settings.Default.gameDirectory, "*.arc", SearchOption.AllDirectories);
            string unpack = string.Empty;
            string system = "xenon";

            if (combo_Emulator_System.SelectedIndex == 0) system = "xenon";
            else if (combo_Emulator_System.SelectedIndex == 1) system = "ps3";
            else return;

            if (nud_FieldOfView.Value != 90 && system == "xenon") {
                Status = SystemMessages.msg_PatchingCamera;
                if (text_GameDirectory.Text != string.Empty && Directory.Exists(text_GameDirectory.Text)) {
                    if (!File.Exists(Path.Combine(text_GameDirectory.Text, "default.xex_back")) && !File.Exists(Path.Combine(text_GameDirectory.Text, "default.xex_orig")))
                        File.Copy(Path.Combine(text_GameDirectory.Text, "default.xex"), Path.Combine(text_GameDirectory.Text, "default.xex_orig"), true);
                    XEX.Decrypt(Path.Combine(text_GameDirectory.Text, "default.xex"));
                    XEX.FieldOfView(Path.Combine(text_GameDirectory.Text, "default.xex"), nud_FieldOfView.Value);
                }
                Status = SystemMessages.msg_DefaultStatus;
            }

            if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Music"))) {
                Status = SystemMessages.msg_PatchingAudio;
                if (system == "xenon") {
                    AV.DisableMusic(Path.Combine(Properties.Settings.Default.gameDirectory, "xenon", "sound"));
                    AV.DisableMusic(Path.Combine(Properties.Settings.Default.gameDirectory, "xenon", "sound", "event"));
                } else if (system == "ps3") {
                    AV.DisableMusic(Path.Combine(Properties.Settings.Default.gameDirectory, "ps3", "sound"));
                    AV.DisableMusic(Path.Combine(Properties.Settings.Default.gameDirectory, "ps3", "sound", "event"));
                }
                Status = SystemMessages.msg_DefaultStatus;
            }

            if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Intro Logos"))) {
                string HDSEGARoot = Path.Combine(Properties.Settings.Default.gameDirectory, "xenon", "sound", "HD_SEGA");
                Status = SystemMessages.msg_PatchingVideo;
                if (system == "xenon") {
                    if (!File.Exists($"{HDSEGARoot}.wmv_back") && !File.Exists($"{HDSEGARoot}.wmv_orig"))
                        File.Move($"{HDSEGARoot}.wmv", $"{HDSEGARoot}.wmv_orig");
                    else if (File.Exists($"{HDSEGARoot}.wmv_back")) {
                        File.Move($"{HDSEGARoot}.wmv_back", $"{HDSEGARoot}.wmv_orig");
                        File.Delete($"{HDSEGARoot}.wmv");
                    }
                } else if (system == "ps3") {
                    if (!File.Exists($"{HDSEGARoot}.pam_back") && !File.Exists($"{HDSEGARoot}.pam_orig"))
                        File.Move($"{HDSEGARoot}.pam", $"{HDSEGARoot}.pam_orig");
                    else if (File.Exists($"{HDSEGARoot}.pam_back")) {
                        File.Move($"{HDSEGARoot}.pam_back", $"{HDSEGARoot}.pam_orig");
                        File.Delete($"{HDSEGARoot}.pam");
                    }
                }
                Status = SystemMessages.msg_DefaultStatus;
            }

            foreach (var arc in files) {
                if (Path.GetFileName(arc) == "cache.arc") {
                    int proceed = 0;
                    if (combo_Renderer.SelectedIndex != 0) proceed++;
                    if (combo_Reflections.SelectedIndex != 1) proceed++;
                    if (combo_CameraType.SelectedIndex != 0 && system == "ps3") proceed++;
                    if (nud_CameraDistance.Value != 650 && system == "ps3") proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows"))) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (combo_Renderer.SelectedIndex == 1) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            if (system == "xenon") File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\render_gamemode.lub"), Properties.Resources.barebones_render_gamemode);
                            File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\core\\render_main.lub"), Properties.Resources.barebones_render_main);
                        } else if (combo_Renderer.SelectedIndex == 2) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            if (system == "xenon") {
                                File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\render_gamemode.lub"), Properties.Resources.vulkan_render_gamemode);
                                File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\render_title.lub"), Properties.Resources.vulkan_render_title);
                                File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\core\\render_main.lub"), Properties.Resources.vulkan_render_main);
                            }
                        } else if (combo_Renderer.SelectedIndex == 3) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            File.WriteAllBytes(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\render_gamemode.lub"), Properties.Resources.render_cheap);
                        }

                        if (combo_Reflections.SelectedIndex != 1) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.Reflections(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\core\\render_reflection.lub"), combo_Reflections.SelectedIndex);
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableBloom(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableHUD(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableShadows(Path.Combine(unpack, $"cache\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows")));
                        }

                        if (system == "ps3") {
                            if (combo_CameraType.SelectedIndex != 0) {
                                Status = SystemMessages.msg_PatchingCamera;
                                Lua.CameraType(Path.Combine(unpack, $"cache\\{system}\\cameraparam.lub"), combo_CameraType.SelectedIndex, nud_FieldOfView.Value);
                            }
                            if (nud_CameraDistance.Value != 650 && nud_CameraDistance.Enabled) {
                                Status = SystemMessages.msg_PatchingCamera;
                                Lua.CameraDistance(Path.Combine(unpack, $"cache\\{system}\\cameraparam.lub"), decimal.ToInt32(nud_CameraDistance.Value));
                            }
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "scripts.arc") {
                    int proceed = 0;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows"))) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableBloom(Path.Combine(unpack, $"scripts\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Bloom")));
                        }
                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableHUD(Path.Combine(unpack, $"scripts\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable HUD")));
                        }
                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            Lua.DisableShadows(Path.Combine(unpack, $"scripts\\{system}\\scripts\\render\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Shadows")));
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "game.arc") {
                    int proceed = 0;
                    if (combo_CameraType.SelectedIndex != 0 && system == "xenon") proceed++;
                    if (nud_CameraDistance.Value != 650 && system == "xenon") proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (system == "xenon") {
                            if (combo_CameraType.SelectedIndex != 0) {
                                Status = SystemMessages.msg_PatchingCamera;
                                Lua.CameraType(Path.Combine(unpack, $"game\\{system}\\cameraparam.lub"), combo_CameraType.SelectedIndex, nud_FieldOfView.Value);
                            }
                            if (nud_CameraDistance.Value != 650 && nud_CameraDistance.Enabled) {
                                Status = SystemMessages.msg_PatchingCamera;
                                Lua.CameraDistance(Path.Combine(unpack, $"game\\{system}\\cameraparam.lub"), decimal.ToInt32(nud_CameraDistance.Value));
                            }
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "player_omega.arc") {
                    int proceed = 0;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Omega Blur Fix"))) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Omega Blur Fix"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            File.WriteAllBytes(Path.Combine(unpack, "player_omega\\win32\\player\\omega\\omega_Root.xno"), Properties.Resources.omega_Root_Fix);
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "sprite.arc") {
                    int proceed = 0;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Intro Logos"))) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Disable Intro Logos"))) {
                            Status = SystemMessages.msg_PatchingVideo;
                            string criLogo = Path.Combine(unpack, "sprite\\win32\\sprite\\logo\\cri_logo.xncp");
                            string sonicteamLogo = Path.Combine(unpack, "sprite\\win32\\sprite\\logo\\sonicteam_logo.xncp");
                            if (File.Exists(criLogo)) File.Delete(criLogo);
                            if (File.Exists(sonicteamLogo)) File.Delete(sonicteamLogo);
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "shader.arc") {
                    int proceed = 0;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Xbox Live Arcade Radial Blur"))) proceed++;

                    if (proceed != 0 && system == "xenon") {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Xbox Live Arcade Radial Blur"))) {
                            Status = SystemMessages.msg_PatchingRenderer;
                            string blurShader = Path.Combine(unpack, "shader\\xenon\\shader\\std\\BurnoutBlurFilter.fxo");
                            File.WriteAllBytes(blurShader, Properties.Resources.BurnoutBlurFilter);
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                } else if (Path.GetFileName(arc) == "player.arc") {
                    int proceed = 0;
                    if (combo_CameraType.SelectedIndex != 0) proceed++;
                    if (nud_CameraHeight.Value != 70) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Action Gauge Fixes for Sonic"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Curved Homing Attack for Sonic"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Debug Mode"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Silver Grind Trick Fix"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Mid-air Momentum"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Tails' Flight Limit"))) proceed++;
                    if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Use Dynamic Bones for Snowboard States"))) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{arc}_back") && !File.Exists($"{arc}_orig"))
                            File.Copy(arc, $"{arc}_orig", true);
                        unpack = ARC.UnpackARC(arc);

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Action Gauge Fixes for Sonic"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.ActionGaugeFixes(Path.Combine(unpack, $"player\\{system}\\player\\sonic_new.lub"), clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Action Gauge Fixes for Sonic")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Silver Grind Trick Fix"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            PKG.SilverGrindTrick(Path.Combine(unpack, $"player\\{system}\\player\\silver.pkg"));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Curved Homing Attack for Sonic"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.CurvedHomingAttack(Path.Combine(unpack, $"player\\{system}\\player\\sonic_new.lub"), clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Curved Homing Attack for Sonic")));
                            Lua.CurvedHomingAttack(Path.Combine(unpack, $"player\\{system}\\player\\princess.lub"), clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Curved Homing Attack for Sonic")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Debug Mode"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.DebugMode(Path.Combine(unpack, $"player\\{system}\\player\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Debug Mode")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Mid-air Momentum"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.UnlockMidairMomentum(Path.Combine(unpack, $"player\\{system}\\player\\"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Mid-air Momentum")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Tails' Flight Limit"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.UnlockTailsFlightLimit(Path.Combine(unpack, $"player\\{system}\\player\\tails.lub"), !clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Unlock Tails' Flight Limit")));
                        }

                        if (clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Use Dynamic Bones for Snowboard States"))) {
                            Status = SystemMessages.msg_PatchingCharacters;
                            Lua.UseDynamicBonesForSnowboard(Path.Combine(unpack, $"player\\{system}\\player\\snow_board.lub"), clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Use Dynamic Bones for Snowboard States")));
                            Lua.UseDynamicBonesForSnowboard(Path.Combine(unpack, $"player\\{system}\\player\\snow_board_wap.lub"), clb_PatchesList.GetItemChecked(clb_PatchesList.Items.IndexOf("Use Dynamic Bones for Snowboard States")));
                        }

                        if (combo_CameraType.SelectedIndex == 1) {
                            Status = SystemMessages.msg_PatchingCamera;
                            Lua.CameraType(Path.Combine(unpack, $"player\\{system}\\player\\common.lub"), combo_CameraType.SelectedIndex, nud_FieldOfView.Value);
                        }

                        if (nud_CameraHeight.Value != 70) {
                            Lua.CameraHeight(Path.Combine(unpack, $"player\\{system}\\player\\common.lub"), nud_CameraHeight.Value);
                        }

                        ARC.RepackARC(unpack, arc);
                        Status = SystemMessages.msg_DefaultStatus;
                    }
                }
            }
        }

        private void Btn_UninstallMods_Click(object sender, EventArgs e) {
            if (btn_UninstallMods.Text == "Restore Defaults") {
                ARC.CleanupMods(1);
                nud_CameraDistance.Value = 650; Properties.Settings.Default.patches_CameraDistance = 650;
                nud_FieldOfView.Value = 90; Properties.Settings.Default.patches_FieldOfView = 90;
                combo_Reflections.SelectedIndex = 1; Properties.Settings.Default.patches_Reflections = 1;
                combo_CameraType.SelectedIndex = 0; Properties.Settings.Default.patches_CameraType = 0;
                combo_Renderer.SelectedIndex = 0; Properties.Settings.Default.patches_Renderer = 0;
                for (int i = 0; i < clb_PatchesList.Items.Count; i++) clb_PatchesList.SetItemChecked(i, false);
                Properties.Settings.Default.Save();
                SaveChecks();
            }
            else if (!check_FTP.Checked) ARC.CleanupMods(0);
        }

        private void Btn_RefreshMods_Click(object sender, EventArgs e) { GetMods(); }

        private void Btn_Save_Click(object sender, EventArgs e) {
            SaveUserOptions();
            SaveChecks();
            GetMods();

            Properties.Settings.Default.Save();
        }

        private void Btn_Priority_Click(object sender, EventArgs e) { // Switches priority - cleaner than using a combo box in this case
            if (!Properties.Settings.Default.priority) {
                btn_Priority.Text = "Priority: Bottom to Top";
                Properties.Settings.Default.priority = true;
            } else {
                btn_Priority.Text = "Priority: Top to Bottom";
                Properties.Settings.Default.priority = false;
            }
            Properties.Settings.Default.Save();
        }

        private void GetMods() {
            clb_ModsList.Items.Clear();
            btn_UpperPriority.Enabled = false;
            btn_DownerPriority.Enabled = false;
            split_ListControls.Visible = false;
            btn_ModInfo.Enabled = false;

            try {
                configs.Clear();
                foreach (var mod in Directory.GetFiles(Properties.Settings.Default.modsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                    using (StreamReader configFile = new StreamReader(mod)) {
                        string line = string.Empty;
                        string entryValue = string.Empty;
                        string modName = string.Empty;

                        try {
                            while ((line = configFile.ReadLine()) != null) {
                                if (line.Contains("Title=\"")) {
                                    entryValue = line.Substring(line.IndexOf("=") + 2);
                                    modName = entryValue.Remove(entryValue.Length - 1); // Gets title directly from 'mod.ini'
                                }

                                //Handle Platforms based on Radio Buttons.
                                if (line.Contains("Platform=\"")) {
                                    entryValue = line.Substring(line.IndexOf("=") + 2);
                                    entryValue = entryValue.Remove(entryValue.Length - 1);

                                    if (!radio_PlayStation3.Checked && entryValue.Contains("Xbox 360")) {
                                        clb_ModsList.Items.Add(modName);
                                        configs.Add(mod);
                                    }

                                    if (!radio_Xbox360.Checked && entryValue.Contains("PlayStation 3")) {
                                        clb_ModsList.Items.Add(modName);
                                        configs.Add(mod);
                                    }

                                    if (entryValue.Contains("All Systems")) {
                                        clb_ModsList.Items.Add(modName);
                                        configs.Add(mod);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }

                GetModsChecks();
                GetPatchesChecks();
            }
            catch (Exception ex) { UnifyMessages.UnifyMessage.Show($"{ModsMessages.ex_ModListError}\n\n{ex}", SystemMessages.tl_ListError, "OK", "Error"); }
        }

        private void GetModsChecks()
        {
            string line = string.Empty; // Declare empty string for StreamReader

            if (File.Exists(Path.Combine(Properties.Settings.Default.modsDirectory, "mods.ini"))) {
                using (StreamReader mods = new StreamReader(Path.Combine(Properties.Settings.Default.modsDirectory, "mods.ini"))) { // Read 'mods.ini'
                    mods.ReadLine(); // Skip [Main] line
                    while ((line = mods.ReadLine()) != null) { // Read all lines until null
                        if (clb_ModsList.Items.Contains(line)) { // If the mods list contains what's on the current line...
                            int checkedIndex = clb_ModsList.Items.IndexOf(line); // Get the index of the mod already in the mods list
                            string cachePath = configs[checkedIndex]; // Get the index of the mod in the configs list

                            clb_ModsList.Items.RemoveAt(checkedIndex); // Remove the mod already in the mods list
                            configs.Remove(cachePath); // Remove the config location from the configs list

                            clb_ModsList.Items.Insert(checkedIndex - checkedIndex, line); // Insert the mod by the name provided in 'mods.ini', given it's at least present in the list
                            configs.Insert(checkedIndex - checkedIndex, cachePath); // Insert the mod at the top of the configs list to re-arrange the information
                            clb_ModsList.SetItemChecked(checkedIndex - checkedIndex, true); // Set the new item to the checked state
                        }
                    }
                }
            }
        }

        private void GetPatchesChecks()
        {
            string line = string.Empty; // Declare empty string for StreamReader

            if (File.Exists(Path.Combine(Properties.Settings.Default.modsDirectory, "patches.ini"))) {
                using (StreamReader patches = new StreamReader(Path.Combine(Properties.Settings.Default.modsDirectory, "patches.ini"))) { // Read 'patches.ini'
                    patches.ReadLine(); // Skip [Main] line
                    while ((line = patches.ReadLine()) != null) { // Read all lines until null
                        if (clb_PatchesList.Items.Contains(line)) { // If the mods list contains what's on the current line...
                            int checkedIndex = clb_PatchesList.Items.IndexOf(line); // Get the index of the mod already in the mods list
                            clb_PatchesList.SetItemChecked(checkedIndex, true); // Set the new item to the checked state
                        }
                    }
                }
            }
        }

        private void SaveChecks()
        {
            //Save the names of the selected mods and the indexes of the selected patches to their appropriate ini files
            string modCheckList = Path.Combine(text_ModsDirectory.Text, "mods.ini");
            string patchCheckList = Path.Combine(text_ModsDirectory.Text, "patches.ini");

            using (StreamWriter sw = File.CreateText(modCheckList))
                sw.WriteLine("[Main]"); //Header

            for (int i = clb_ModsList.Items.Count - 1; i >= 0; i--) { // Writes in reverse so the mods list writes it in it's preferred order
                if (clb_ModsList.GetItemChecked(i)) 
                    using (StreamWriter sw = File.AppendText(modCheckList)) 
                        sw.WriteLine(clb_ModsList.Items[i].ToString()); //Mod Name
            }

            using (StreamWriter sw = File.CreateText(patchCheckList))
                sw.WriteLine("[Main]"); //Header

            for (int i = clb_PatchesList.Items.Count - 1; i >= 0; i--) // Writes in reverse so the mods list writes it in it's preferred order
            {
                if (clb_PatchesList.GetItemChecked(i))
                    using (StreamWriter sw = File.AppendText(patchCheckList))
                        sw.WriteLine(clb_PatchesList.Items[i].ToString()); //Mod Name
            }
        }

        private void Radio_All_CheckedChanged(object sender, EventArgs e) { // Refreshes mods list based on All filter
            Properties.Settings.Default.filter = 0;
            Properties.Settings.Default.Save();
            if (Directory.Exists(Properties.Settings.Default.modsDirectory)) GetMods();
        }

        private void Radio_Xbox360_CheckedChanged(object sender, EventArgs e) { // Refreshes mods list based on Xbox 360 filter
            Properties.Settings.Default.filter = 1;
            Properties.Settings.Default.Save();
            if (Directory.Exists(Properties.Settings.Default.modsDirectory)) GetMods();
        }

        private void Radio_PlayStation3_CheckedChanged(object sender, EventArgs e) { // Refreshes mods list based on PlayStation 3 filter
            Properties.Settings.Default.filter = 2;
            Properties.Settings.Default.Save();
            if (Directory.Exists(Properties.Settings.Default.modsDirectory)) GetMods();
        }

        private void Btn_Play_Click(object sender, EventArgs e) { // Launches the emulator respective to what system is chosen
            ARC.skippedMods.Clear();

            try {
                if (!check_FTP.Checked && !check_ManualPatches.Checked) { ARC.CleanupMods(1); PatchAll(); }
            }
            catch (Exception ex) {
                UnifyMessages.UnifyMessage.Show($"{PatchesMessages.ex_PatchInstallFailure}\n\n{ex}", SystemMessages.tl_FileError, "OK", "Warning");
                unifytb_Main.SelectedIndex = 3;
                Status = SystemMessages.msg_DefaultStatus;
            }

            if (combo_Emulator_System.SelectedIndex == 0) {
                Status = SystemMessages.msg_LaunchXenia;
                LaunchXenia();
                Status = SystemMessages.msg_DefaultStatus;
            }
            if (combo_Emulator_System.SelectedIndex == 1) {
                Status = SystemMessages.msg_LaunchRPCS3;
                LaunchRPCS3();
                Status = SystemMessages.msg_DefaultStatus;
            }
        }

        //Checks all available checkboxes.
        private void Btn_SelectAll_Click(object sender, EventArgs e) { for (int i = 0; i < clb_ModsList.Items.Count; i++) clb_ModsList.SetItemChecked(i, true); }

        //Unchecks all available checkboxes.
        private void Btn_DeselectAll_Click(object sender, EventArgs e) {
            for (int i = 0; i < clb_ModsList.Items.Count; i++) clb_ModsList.SetItemChecked(i, false);
            clb_ModsList.ClearSelected();
            split_ListControls.Visible = false;
        }

        private void Btn_UpperPriority_Click(object sender, EventArgs e) { // Moves selected checkbox up the list
            int selectedIndex = clb_ModsList.SelectedIndex; // Declares the selected index
            object selectedItem = clb_ModsList.SelectedItem; // Selected checkbox
            string cachePath = configs[selectedIndex]; // Info based on selectedIndex
            bool check = false; // Check state bool

            if (clb_ModsList.GetItemCheckState(selectedIndex) == CheckState.Checked) { check = true; } // Checks if the checkbox was checked

            clb_ModsList.Items.RemoveAt(selectedIndex); // Removes the selected checkbox
            configs.Remove(cachePath); // Remove the selected item's info from the configs list
            selectedIndex -= 1; // Move index up the list

            clb_ModsList.Items.Insert(selectedIndex, selectedItem); // Insert checkbox at selectedIndex
            configs.Insert(selectedIndex, cachePath); // Shifts the moved checkbox's info up the configs list
            clb_ModsList.SelectedIndex = selectedIndex; // Selects the recently moved checkbox
            clb_ModsList.SetItemChecked(selectedIndex, check); // Calls the 'check' bool and sets the checked state
        }

        private void Btn_DownerPriority_Click(object sender, EventArgs e) { // Moves selected checkbox down the list
            int selectedIndex = clb_ModsList.SelectedIndex; // Declares the selected index
            object selectedItem = clb_ModsList.SelectedItem; // Selected checkbox
            string cachePath = configs[selectedIndex]; // Info based on selectedIndex
            bool check = false; // Check state bool

            if (clb_ModsList.GetItemCheckState(selectedIndex) == CheckState.Checked) { check = true; } // Checks if the checkbox was checked

            clb_ModsList.Items.RemoveAt(selectedIndex); // Removes the selected checkbox
            configs.Remove(cachePath); // Remove the selected item's info from the configs list
            selectedIndex += 1; // Move index down the list

            clb_ModsList.Items.Insert(selectedIndex, selectedItem); // Insert checkbox at selectedIndex
            configs.Insert(selectedIndex, cachePath); // Shifts the moved checkbox's info up the configs list
            clb_ModsList.SelectedIndex = selectedIndex; // Selects the recently moved checkbox
            clb_ModsList.SetItemChecked(selectedIndex, check); // Calls the 'check' bool and sets the checked state
        }

        private void Clb_ModsList_SelectedIndexChanged(object sender, EventArgs e) {
            btn_ModInfo.Enabled = clb_ModsList.SelectedIndex >= 0; // Enables/disables the Mod Info button depending on if a checkbox is selected
            if (clb_ModsList.SelectedIndex >= 0) split_ListControls.Visible = true;
            else split_ListControls.Visible = false;
            btn_UpperPriority.Enabled = clb_ModsList.SelectedIndex > 0; // Enables/disables the Upper Priority button depending on if a checkbox is selected
            btn_DownerPriority.Enabled = clb_ModsList.SelectedIndex >= 0 && clb_ModsList.SelectedIndex < clb_ModsList.Items.Count - 1; // Enables/disables the Downer Priority button depending on if a checkbox is selected
        }

        private void Btn_CreateNewMod_Click(object sender, EventArgs e) { // Opens the Mod Creator form - refreshes upon exit
            Status = SystemMessages.msg_CreateNewMod;
            new src.ModCreator(string.Empty, false).ShowDialog();
            Status = SystemMessages.msg_DefaultStatus;
            GetMods();
        }
#endregion

        #region Emulator
        private void LaunchXenia() {
            if (text_GameDirectory.Text == string.Empty) {
                //Select game directory and save if we don't have one specified.
                VistaFolderBrowserDialog game = new VistaFolderBrowserDialog {
                    Description = EmulatorMessages.msg_LocateGame,
                    UseDescriptionForTitle = true,
                };

                if (game.ShowDialog() == DialogResult.OK) {
                    text_GameDirectory.Text = game.SelectedPath;
                    Properties.Settings.Default.gameDirectory = game.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else return;
            }

            if (text_EmulatorPath.Text != string.Empty) {
                ProcessStartInfo xeniaExec;
                List<string> xeniaParameters = new List<string>() { };

                if (File.Exists(Path.Combine(text_GameDirectory.Text, "default.xex"))) { xeniaParameters.Add($"\"{Path.Combine(text_GameDirectory.Text, "default.xex")}\""); }

                if (combo_API.SelectedIndex == 1) { //Make sure we're using DX12 before adding the D3D12 Parameters.
                    if (check_RTV.Checked) xeniaParameters.Add("--d3d12_edram_rov=false"); // Render Target Views
                    if (check_2xRes.Checked) xeniaParameters.Add("--d3d12_resolution_scale=2"); // 2x Resolution
                }
                if (combo_API.SelectedIndex == 0) xeniaParameters.Add("--gpu=vulkan"); // Vulkan
                if (!check_VSync.Checked) xeniaParameters.Add("--vsync=false"); // V-Sync
                if (!check_ProtectZero.Checked) xeniaParameters.Add("--protect_zero=false"); // Protect Zero
                if (check_Gamma.Checked) xeniaParameters.Add("--kernel_display_gamma_type=2"); // Enable Gamma
                if (check_Debug.Checked) xeniaParameters.Add("--debug"); // Debug
                if (check_Fullscreen.Checked) xeniaParameters.Add("--fullscreen"); // Launch in Fullscreen
                if (!check_Discord.Checked) xeniaParameters.Add("--discord=false"); // Discord Rich Presence

                // Saves selected settings
                Properties.Settings.Default.emulator_RTV = check_RTV.Checked;
                Properties.Settings.Default.emulator_2xRes = check_2xRes.Checked;
                Properties.Settings.Default.emulator_VSync = check_VSync.Checked;
                Properties.Settings.Default.emulator_ProtectZero = check_ProtectZero.Checked;
                Properties.Settings.Default.emulator_Gamma = check_Gamma.Checked;
                Properties.Settings.Default.emulator_Debug = check_Debug.Checked;
                Properties.Settings.Default.emulator_Fullscreen = check_Fullscreen.Checked;
                Properties.Settings.Default.emulator_Discord = check_Discord.Checked;
                Properties.Settings.Default.Save();

                // Checks if the array is populated before applying arguments
                if (xeniaParameters.ToArray().Length > 0) {
                    xeniaExec = new ProcessStartInfo(text_EmulatorPath.Text) {
                        WorkingDirectory = Path.GetDirectoryName(text_EmulatorPath.Text),
                        Arguments = string.Join(" ", xeniaParameters.ToArray())
                    };
                }
                else {
                    xeniaExec = new ProcessStartInfo(text_EmulatorPath.Text)
                    { WorkingDirectory = Path.GetDirectoryName(text_EmulatorPath.Text) };
                }

                var xenia = Process.Start(xeniaExec); // Launch Xenia
                Status = SystemMessages.msg_XeniaExitCall;
                xenia.WaitForExit(); // Wait for Xenia to exit
                if (!check_ManualInstall.Checked) {
                    ARC.CleanupMods(0);
                    if (check_SaveRedirect.Checked) RestoreSaves();
                }
                Status = SystemMessages.msg_DefaultStatus;
            }
            else {
                text_EmulatorPath.Text = Locations.LocateEmulator(); // Relocate Xenia if the emulator path is not set
                LaunchXenia();
            }
        }

        private void LaunchRPCS3()
        {
            if (text_GameDirectory.Text == string.Empty) {
                //Select game directory and save if we don't have one specified.
                VistaFolderBrowserDialog game = new VistaFolderBrowserDialog {
                    Description = EmulatorMessages.msg_LocateGame,
                    UseDescriptionForTitle = true,
                };

                if (game.ShowDialog() == DialogResult.OK) {
                    text_GameDirectory.Text = game.SelectedPath;
                    Properties.Settings.Default.gameDirectory = game.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else return;
            }

            if (text_EmulatorPath.Text != string.Empty) {
                ProcessStartInfo RPCS3Exec;
                List<string> RPCS3Parameters = new List<string>() { };

                if (File.Exists(Path.Combine(text_GameDirectory.Text, "EBOOT.BIN"))) { RPCS3Parameters.Add($"\"{Path.Combine(text_GameDirectory.Text, "EBOOT.BIN")}\""); }

                // Checks if the array is populated before applying arguments
                if (RPCS3Parameters.ToArray().Length > 0) {
                    RPCS3Exec = new ProcessStartInfo(text_EmulatorPath.Text) {
                        WorkingDirectory = Path.GetDirectoryName(text_EmulatorPath.Text),
                        Arguments = string.Join(" ", RPCS3Parameters.ToArray())
                    };
                }
                else {
                    RPCS3Exec = new ProcessStartInfo(text_EmulatorPath.Text)
                    { WorkingDirectory = Path.GetDirectoryName(text_EmulatorPath.Text) };
                }

                var RPCS3 = Process.Start(RPCS3Exec); // Launch RPCS3
                Status = SystemMessages.msg_RPCS3ExitCall;
                RPCS3.WaitForExit(); // Wait for RPCS3 to exit
                if (!check_ManualInstall.Checked) {
                    ARC.CleanupMods(0);
                    if (check_SaveRedirect.Checked) RestoreSaves();
                }
                Status = SystemMessages.msg_DefaultStatus;
            }
            else {
                text_EmulatorPath.Text = Locations.LocateEmulator(); // Relocate RPCS3 if the emulator path is not set
                LaunchRPCS3();
            }
        }

        private void Btn_EmulatorPath_Click(object sender, EventArgs e) { text_EmulatorPath.Text = Locations.LocateEmulator(); } // Locate the emulator of choice

        private void Combo_Emulator_System_SelectedIndexChanged(object sender, EventArgs e) {
            //Depending on the selected system and theme, change text to disabled colour.
            if (combo_Emulator_System.SelectedIndex == 0) {
                group_Settings.Enabled = true;
                combo_API.Enabled = true;
                nud_FieldOfView.Enabled = true;
                btn_ResetFOV.Enabled = true;

                if (!Properties.Settings.Default.theme) {
                    lbl_API.ForeColor = SystemColors.ControlText;
                    lbl_ForceRTV.ForeColor = SystemColors.ControlText;
                    lbl_2xResolution.ForeColor = SystemColors.ControlText;
                    lbl_VSync.ForeColor = SystemColors.ControlText;
                    lbl_ProtectZero.ForeColor = SystemColors.ControlText;
                    lbl_EnableGamma.ForeColor = SystemColors.ControlText;
                    lbl_Fullscreen.ForeColor = SystemColors.ControlText;
                    lbl_Discord.ForeColor = SystemColors.ControlText;
                    lbl_Debug.ForeColor = SystemColors.ControlText;
                    lbl_SettingsOverlay.ForeColor = SystemColors.ControlText;
                    lbl_FieldOfView.ForeColor = SystemColors.ControlText;
                }
                else {
                    lbl_API.ForeColor = SystemColors.Control;
                    lbl_ForceRTV.ForeColor = SystemColors.Control;
                    lbl_2xResolution.ForeColor = SystemColors.Control;
                    lbl_VSync.ForeColor = SystemColors.Control;
                    lbl_ProtectZero.ForeColor = SystemColors.Control;
                    lbl_EnableGamma.ForeColor = SystemColors.Control;
                    lbl_Fullscreen.ForeColor = SystemColors.Control;
                    lbl_Discord.ForeColor = SystemColors.Control;
                    lbl_Debug.ForeColor = SystemColors.Control;
                    lbl_SettingsOverlay.ForeColor = SystemColors.Control;
                    lbl_FieldOfView.ForeColor = SystemColors.Control;
                }

                text_EmulatorPath.Text = Properties.Settings.Default.xeniaPath;
            }
            else {
                //Disable Xenia specific objects when RPCS3 is selected
                group_Settings.Enabled = false;
                combo_API.Enabled = false;
                lbl_API.ForeColor = SystemColors.GrayText;
                lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                lbl_2xResolution.ForeColor = SystemColors.GrayText;
                lbl_VSync.ForeColor = SystemColors.GrayText;
                lbl_ProtectZero.ForeColor = SystemColors.GrayText;
                lbl_EnableGamma.ForeColor = SystemColors.GrayText;
                lbl_Fullscreen.ForeColor = SystemColors.GrayText;
                lbl_Discord.ForeColor = SystemColors.GrayText;
                lbl_Debug.ForeColor = SystemColors.GrayText;
                lbl_SettingsOverlay.ForeColor = SystemColors.GrayText;
                lbl_FieldOfView.ForeColor = SystemColors.GrayText;
                nud_FieldOfView.Enabled = false;
                btn_ResetFOV.Enabled = false;

                text_EmulatorPath.Text = Properties.Settings.Default.RPCS3Path;
            }
            Properties.Settings.Default.emulatorSystem = combo_Emulator_System.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Combo_API_SelectedIndexChanged(object sender, EventArgs e) {
            //Depending on the selected API and theme, change text to disabled colour.
            if (combo_API.SelectedIndex == 0) {
                if (!Properties.Settings.Default.seenVulkanWarning && combo_Renderer.SelectedIndex != 2) {
                    UnifyMessages.UnifyMessage.Show(SystemMessages.msg_VulkanWarning, SystemMessages.tl_DefaultTitle, "OK", "Warning");
                    Properties.Settings.Default.seenVulkanWarning = true;
                }
                check_RTV.Enabled = false;
                check_2xRes.Enabled = false;
                lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                lbl_2xResolution.ForeColor = SystemColors.GrayText;
            }
            else {
                check_RTV.Enabled = true;
                check_2xRes.Enabled = true;
                
                if (!Properties.Settings.Default.theme) {
                    if (combo_Emulator_System.SelectedIndex == 1) {
                        lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                        lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    }
                    else {
                        lbl_ForceRTV.ForeColor = SystemColors.ControlText;
                        lbl_2xResolution.ForeColor = SystemColors.ControlText;
                    }
                }
                else {
                    if (combo_Emulator_System.SelectedIndex == 1) {
                        lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                        lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    }
                    else {
                        lbl_ForceRTV.ForeColor = SystemColors.Control;
                        lbl_2xResolution.ForeColor = SystemColors.Control;
                    }
                }
            }
            Properties.Settings.Default.API = combo_API.SelectedIndex;
            Properties.Settings.Default.Save();
        }
#endregion

        #region Patches
        private void Combo_Renderer_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.patches_Renderer = combo_Renderer.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Combo_Reflections_SelectedIndexChanged(object sender, EventArgs e) { // Save Reflections value
            Properties.Settings.Default.patches_Reflections = combo_Reflections.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Combo_CameraType_SelectedIndexChanged(object sender, EventArgs e) { // Save Camera Type value
            if (combo_CameraType.SelectedIndex != 0) {
                if (combo_CameraType.SelectedIndex == 1) {
                    if (combo_Emulator_System.SelectedIndex == 0) {
                        nud_CameraDistance.Value = 350;
                        nud_CameraHeight.Value = 32.5m;
                        nud_FieldOfView.Value = 110;
                    } else {
                        nud_CameraDistance.Value = 450;
                        nud_CameraHeight.Value = 32.5m;
                        nud_FieldOfView.Value = 90;
                    }
                } else if (combo_CameraType.SelectedIndex == 2) {
                    nud_CameraDistance.Value = 550;
                    nud_CameraHeight.Value = 70;
                    nud_FieldOfView.Value = 90;
                }
            } else {
                nud_CameraDistance.Value = 650;
                nud_CameraHeight.Value = 70;
                nud_FieldOfView.Value = 90;
            }
            Properties.Settings.Default.patches_CameraType = combo_CameraType.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Btn_ResetRenderer_Click(object sender, EventArgs e) {
            combo_Renderer.SelectedIndex = 0;
            Properties.Settings.Default.patches_Renderer = 0;
            Properties.Settings.Default.Save();
        }

        private void Btn_ResetReflections_Click(object sender, EventArgs e) { // Default Reflections to Quarter
            combo_Reflections.SelectedIndex = 1;
            Properties.Settings.Default.patches_Reflections = 1;
            Properties.Settings.Default.Save();
        }

        private void Btn_ResetCameraType_Click(object sender, EventArgs e) { // Default Camera Type to Retail
            combo_CameraType.SelectedIndex = 0;
            nud_CameraDistance.Value = 650;
            nud_CameraHeight.Value = 70;
            nud_FieldOfView.Value = 90;
            Properties.Settings.Default.patches_CameraType = 0;
            Properties.Settings.Default.Save();
        }

        private void Btn_ResetCameraDistance_Click(object sender, EventArgs e) { // Default Camera Distance to 650
            if (combo_CameraType.SelectedIndex == 0) {
                nud_CameraDistance.Value = 650;
                Properties.Settings.Default.patches_CameraDistance = 650;
            } else if (combo_CameraType.SelectedIndex == 1) {
                nud_CameraDistance.Value = 350;
                Properties.Settings.Default.patches_CameraDistance = 350;
            } else if (combo_CameraType.SelectedIndex == 2) {
                nud_CameraDistance.Value = 550;
                Properties.Settings.Default.patches_CameraDistance = 550;
            } 
            Properties.Settings.Default.Save();
        }

        private void Btn_ResetFOV_Click(object sender, EventArgs e) { // Default Field of View to 90
            if (combo_CameraType.SelectedIndex == 1) {
                if (nud_CameraDistance.Value == 450) { 
                    nud_FieldOfView.Value = 90;
                    Properties.Settings.Default.patches_FieldOfView = 90;
                } else {
                    nud_FieldOfView.Value = 110;
                    Properties.Settings.Default.patches_FieldOfView = 110;
                }
            } else { 
                nud_FieldOfView.Value = 90;
                Properties.Settings.Default.patches_FieldOfView = 90;
            }
            Properties.Settings.Default.Save();
        }

        private void Nud_FieldOfView_ValueChanged(object sender, EventArgs e) {
            if (combo_CameraType.SelectedIndex == 1) { 
                if (nud_FieldOfView.Value == 90)
                    nud_CameraDistance.Value = 450; 
                else if (nud_FieldOfView.Value == 110)
                    nud_CameraDistance.Value = 350;
            }
        }

        private void Btn_ResetCameraHeight_Click(object sender, EventArgs e) {
            if (combo_CameraType.SelectedIndex == 1) {
                nud_CameraHeight.Value = 32.5m;
                Properties.Settings.Default.patches_CameraHeight = 32.5m;
            } else {
                nud_CameraHeight.Value = 70;
                Properties.Settings.Default.patches_CameraHeight = 70;
            } 
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Settings
        private void Check_SaveRedirect_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.saveRedirect = check_SaveRedirect.Checked;
            Properties.Settings.Default.Save();
        }

        private void Text_FTPLocation_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.ftpLocation = text_FTPLocation.Text;
            Properties.Settings.Default.Save();
        }

        private void Text_Username_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.ftpUsername = text_Username.Text;
            Properties.Settings.Default.Save();
        }

        private void Check_ManualPatches_CheckedChanged(object sender, EventArgs e) {
            if (check_ManualPatches.Checked) {
                Properties.Settings.Default.manualPatches = true;
                check_FTP.Enabled = false;
                lbl_FTP.ForeColor = SystemColors.GrayText;
            } else {
                Properties.Settings.Default.manualPatches = false;
                check_FTP.Enabled = true;
                if (!Properties.Settings.Default.theme)
                    lbl_FTP.ForeColor = SystemColors.ControlText;
                else
                    lbl_FTP.ForeColor = SystemColors.Control;
            }
            Properties.Settings.Default.Save();
        }

        private void Check_DisableSoftwareUpdater_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.disableSoftwareUpdater = check_DisableSoftwareUpdater.Checked;
            Properties.Settings.Default.Save();
        }

        private void Btn_Update_Click(object sender, EventArgs e) { Updater.CheckForUpdates(versionNumber, "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe", "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt", "user"); }

        private void Btn_ModsFolder_Click(object sender, EventArgs e) { text_ModsDirectory.Text = Locations.LocateMods(); GetMods(); } // Locate Mods folder

        private void Btn_GameFolder_Click(object sender, EventArgs e) { text_GameDirectory.Text = Locations.LocateGame(); GetMods(); } // Locate Game folder

        private void Btn_ColourPicker_Click(object sender, System.EventArgs e) {
            //Create the Colour Picker, with the Custom Colours menu open and the colour set to the one from settings.
            ColorDialog accentPicker = new ColorDialog {
                FullOpen = true,
                Color = Properties.Settings.Default.accentColour
            };

            if (accentPicker.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.accentColour = accentPicker.Color;

            Properties.Settings.Default.Save();
            ChangeAccentColours();
        }

        private void Aldi(object sender, EventArgs e)
        {
            Text = "Aldi Mod Manager";
            Icon = Properties.Resources.icon_aldi;
            debugMode = true;
            SystemMessages.tl_DefaultTitle = "Aldi Mod Manager";
            btn_About.Text = "About Aldi Mod Manager";
        }

        private void ChangeAccentColours() {
            btn_ColourPicker.BackColor = Properties.Settings.Default.accentColour; //Change the colour of the selector button.
            unifytb_Main.ActiveColor = Properties.Settings.Default.accentColour; //Colour the selected tab is highlighted in.
            unifytb_Main.HorizontalLineColor = Properties.Settings.Default.accentColour; //Colour the line at the top is.
            unifytb_Main.Refresh(); //Refresh user control to remove software rendering leftovers.
        }

        private void Unifytb_Main_SelectedIndexChanged(object sender, System.EventArgs e) {
            clb_ModsList.ClearSelected();
            clb_PatchesList.ClearSelected();
            btn_ModInfo.Text = "Mod Info";

            if (check_ManualInstall.Checked) {
                Properties.Settings.Default.manualInstall = true;
                check_FTP.Enabled = false;
                lbl_FTP.ForeColor = SystemColors.GrayText;
                btn_InstallMods.Text = "Install Mods";
                split_Mods.Visible = true;
                btn_UninstallMods.Visible = true;
            } else if (check_ManualPatches.Checked) {
                Properties.Settings.Default.manualPatches = true;
                check_FTP.Enabled = false;
                lbl_FTP.ForeColor = SystemColors.GrayText;
            } else {
                Properties.Settings.Default.manualInstall = false;
                check_FTP.Enabled = true;
                if (!Properties.Settings.Default.theme)
                    lbl_FTP.ForeColor = SystemColors.ControlText;
                else
                    lbl_FTP.ForeColor = SystemColors.Control;
                split_Mods.Visible = false;
                btn_UninstallMods.Visible = false;
            }

            if (unifytb_Main.SelectedIndex == 2 && !check_FTP.Checked) {
                if (Prerequisites.JavaCheck()) {
                    btn_InstallMods.Text = "Apply Patches";
                    split_Mods.Visible = true;
                    btn_UninstallMods.Text = "Restore Defaults";
                    btn_UninstallMods.Visible = true;
                    btn_ModInfo.Text = "Patch Info";
                } else {
                    check_ManualPatches.Enabled = false;
                    lbl_ManualPatches.ForeColor = SystemColors.GrayText;
                    lbl_TweaksOverlay.ForeColor = SystemColors.GrayText;
                    lbl_Reflections.ForeColor = SystemColors.GrayText;
                    lbl_CameraDistance.ForeColor = SystemColors.GrayText;
                    clb_PatchesList.Enabled = false;
                    btn_ResetReflections.Enabled = false;
                    btn_ResetCameraDistance.Enabled = false;
                    combo_Reflections.Enabled = false;
                    nud_CameraDistance.Enabled = false;
                    btn_ModInfo.Text = "Mod Info";
                }
            } else {
                if (check_FTP.Checked || check_ManualInstall.Checked) {
                    btn_InstallMods.Text = "Install Mods";
                    split_Mods.Visible = true;
                    btn_UninstallMods.Text = "Uninstall Mods";
                    btn_UninstallMods.Visible = true;
                } else {
                    split_Mods.Visible = false;
                    btn_UninstallMods.Text = "Uninstall Mods";
                    btn_UninstallMods.Visible = false;
                }
            }

            Properties.Settings.Default.Save();
            split_ListControls.Visible = false;
            unifytb_Main.Refresh(); //Refresh user control to remove software rendering leftovers.
        }

        private void Btn_ColourPicker_Default_Click(object sender, System.EventArgs e) { // Default Accent Colour to RGB: (186, 0, 0)
            Properties.Settings.Default.accentColour = Color.FromArgb(186, 0, 0);
            Properties.Settings.Default.Save();
            ChangeAccentColours();
        }

        private void Btn_Theme_Click(object sender, System.EventArgs e) {
            if (Properties.Settings.Default.theme) //Dark to Light
                Properties.Settings.Default.theme = false;
            else //Light to Dark
                Properties.Settings.Default.theme = true;

            Properties.Settings.Default.Save();
            ChangeThemeColours();
        }

        private void ChangeThemeColours() {
            //You get the idea. =P
            if (!Properties.Settings.Default.theme) {
                btn_Theme.Text = "Theme: Light";

                unifytb_Main.BackTabColor = SystemColors.Control;
                unifytb_Main.BorderColor = SystemColors.Control;
                unifytb_Main.HeaderColor = SystemColors.ControlLightLight;
                unifytb_Main.TextColor = SystemColors.ControlText;
                status_Main.BackColor = SystemColors.Control;
                BackColor = SystemColors.ControlLight;

                lbl_SetupOverlay.ForeColor = SystemColors.ControlText;
                lbl_TweaksOverlay.ForeColor = SystemColors.ControlText;
                lbl_AccentColour.ForeColor = SystemColors.ControlText;
                lbl_CameraDistance.ForeColor = SystemColors.ControlText;
                lbl_FTPLocation.ForeColor = SystemColors.ControlText;
                lbl_GameDirectory.ForeColor = SystemColors.ControlText;
                lbl_ModsDirectory.ForeColor = SystemColors.ControlText;
                lbl_Password.ForeColor = SystemColors.ControlText;
                lbl_Reflections.ForeColor = SystemColors.ControlText;
                sonic06mm_Aldi.BackColor = SystemColors.ControlLightLight;
                lbl_Username.ForeColor = SystemColors.ControlText;
                statuslbl_Status.ForeColor = SystemColors.ControlText;
                lbl_GameBanana.ForeColor = SystemColors.ControlText;
                lbl_SetStatus.ForeColor = SystemColors.ControlText; lbl_SetStatus.BackColor = SystemColors.Control;
                lbl_ManualPatches.ForeColor = SystemColors.ControlText;
                lbl_DisableSoftwareUpdater.ForeColor = SystemColors.ControlText;
                if (check_FTP.Checked) {
                    lbl_ManualInstall.ForeColor = SystemColors.GrayText;
                    lbl_ManualPatches.ForeColor = SystemColors.GrayText;
                    lbl_TweaksOverlay.ForeColor = SystemColors.GrayText;
                    lbl_Reflections.ForeColor = SystemColors.GrayText;
                    lbl_CameraDistance.ForeColor = SystemColors.GrayText;
                    lbl_SaveRedirect.ForeColor = SystemColors.GrayText;
                    lbl_CameraType.ForeColor = SystemColors.GrayText;
                    lbl_FieldOfView.ForeColor = SystemColors.GrayText;
                    lbl_Renderer.ForeColor = SystemColors.GrayText;
                    lbl_CameraHeight.ForeColor = SystemColors.GrayText;
                } else {
                    lbl_ManualInstall.ForeColor = SystemColors.ControlText;
                    if (Prerequisites.JavaCheck()) lbl_ManualPatches.ForeColor = SystemColors.ControlText;
                    lbl_TweaksOverlay.ForeColor = SystemColors.ControlText;
                    lbl_Reflections.ForeColor = SystemColors.ControlText;
                    lbl_CameraDistance.ForeColor = SystemColors.ControlText;
                    lbl_SaveRedirect.ForeColor = SystemColors.ControlText;
                    lbl_CameraType.ForeColor = SystemColors.ControlText;
                    if (combo_Emulator_System.SelectedIndex != 1) lbl_FieldOfView.ForeColor = SystemColors.ControlText;
                    lbl_Renderer.ForeColor = SystemColors.ControlText;
                    lbl_CameraHeight.ForeColor = SystemColors.ControlText;
                }
                if (check_ManualInstall.Checked)
                    lbl_FTP.ForeColor = SystemColors.GrayText;
                else
                    lbl_FTP.ForeColor = SystemColors.ControlText;

                lbl_EmulatorEXE.ForeColor = SystemColors.ControlText;
                lbl_Emulator_System.ForeColor = SystemColors.ControlText;
                if (combo_Emulator_System.SelectedIndex == 0) { //Depending on the selected system, change text to disabled colour.
                    lbl_API.ForeColor = SystemColors.ControlText;
                    if (combo_API.SelectedIndex == 0) {
                        lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                        lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    }
                    else {
                        lbl_ForceRTV.ForeColor = SystemColors.ControlText;
                        lbl_2xResolution.ForeColor = SystemColors.ControlText;
                    }
                    lbl_VSync.ForeColor = SystemColors.ControlText;
                    lbl_ProtectZero.ForeColor = SystemColors.ControlText;
                    lbl_EnableGamma.ForeColor = SystemColors.ControlText;
                    lbl_Fullscreen.ForeColor = SystemColors.ControlText;
                    lbl_Discord.ForeColor = SystemColors.ControlText;
                    lbl_Debug.ForeColor = SystemColors.ControlText;
                    lbl_SettingsOverlay.ForeColor = SystemColors.ControlText;
                }
                else {
                    lbl_API.ForeColor = SystemColors.GrayText;
                    lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                    lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    lbl_VSync.ForeColor = SystemColors.GrayText;
                    lbl_ProtectZero.ForeColor = SystemColors.GrayText;
                    lbl_EnableGamma.ForeColor = SystemColors.GrayText;
                    lbl_Fullscreen.ForeColor = SystemColors.GrayText;
                    lbl_Discord.ForeColor = SystemColors.GrayText;
                    lbl_Debug.ForeColor = SystemColors.GrayText;
                    lbl_SettingsOverlay.ForeColor = SystemColors.GrayText;
                }

                group_Directories.ForeColor = SystemColors.ControlText;
                group_FTP.ForeColor = SystemColors.ControlText;
                group_Options.ForeColor = SystemColors.ControlText;
                group_Tweaks.ForeColor = SystemColors.ControlText;
                group_Setup.ForeColor = SystemColors.ControlText;
                group_Settings.ForeColor = SystemColors.ControlText;

                check_FTP.ForeColor = SystemColors.ControlText;
                check_ManualInstall.ForeColor = SystemColors.ControlText;

                text_FTPLocation.BackColor = SystemColors.ControlLightLight; text_FTPLocation.ForeColor = SystemColors.ControlText;
                text_GameDirectory.BackColor = SystemColors.ControlLightLight; text_GameDirectory.ForeColor = SystemColors.ControlText;
                text_ModsDirectory.BackColor = SystemColors.ControlLightLight; text_ModsDirectory.ForeColor = SystemColors.ControlText;
                text_Password.BackColor = SystemColors.ControlLightLight; text_Password.ForeColor = SystemColors.ControlText;
                text_Username.BackColor = SystemColors.ControlLightLight; text_Username.ForeColor = SystemColors.ControlText;
                text_EmulatorPath.BackColor = SystemColors.ControlLightLight; text_EmulatorPath.ForeColor = SystemColors.ControlText;
                text_SaveData.BackColor = SystemColors.ControlLightLight; text_SaveData.ForeColor = SystemColors.ControlText;

                pnl_ModBackdrop.BackColor = clb_ModsList.BackColor = SystemColors.ControlLightLight;
                clb_ModsList.ForeColor = SystemColors.ControlText;
                pnl_PatchBackdrop.BackColor = clb_PatchesList.BackColor = SystemColors.ControlLightLight;
                clb_PatchesList.ForeColor = SystemColors.ControlText;

                radio_All.ForeColor = SystemColors.ControlText; radio_All.BackColor = SystemColors.ControlLightLight;
                radio_Xbox360.ForeColor = SystemColors.ControlText; radio_Xbox360.BackColor = SystemColors.ControlLightLight;
                radio_PlayStation3.ForeColor = SystemColors.ControlText; radio_PlayStation3.BackColor = SystemColors.ControlLightLight;
            }
            else {
                btn_Theme.Text = "Theme: Dark";

                unifytb_Main.BackTabColor = Color.FromArgb(28, 28, 28);
                unifytb_Main.BorderColor = Color.FromArgb(30, 30, 30);
                unifytb_Main.HeaderColor = Color.FromArgb(45, 45, 48);
                unifytb_Main.TextColor = Color.FromArgb(255, 255, 255);
                status_Main.BackColor = Color.FromArgb(28, 28, 28);
                BackColor = Color.FromArgb(45, 45, 48);

                lbl_SetupOverlay.ForeColor = SystemColors.Control;
                lbl_TweaksOverlay.ForeColor = SystemColors.Control;
                lbl_AccentColour.ForeColor = SystemColors.Control;
                lbl_CameraDistance.ForeColor = SystemColors.Control;
                lbl_FTPLocation.ForeColor = SystemColors.Control;
                lbl_GameDirectory.ForeColor = SystemColors.Control;
                lbl_ModsDirectory.ForeColor = SystemColors.Control;
                lbl_Password.ForeColor = SystemColors.Control;
                lbl_Reflections.ForeColor = SystemColors.Control;
                lbl_Username.ForeColor = SystemColors.Control;
                statuslbl_Status.ForeColor = SystemColors.Control;
                lbl_GameBanana.ForeColor = SystemColors.Control;
                sonic06mm_Aldi.BackColor = Color.FromArgb(45, 45, 48);
                lbl_SetStatus.ForeColor = SystemColors.Control; lbl_SetStatus.BackColor = Color.FromArgb(28, 28, 28);
                lbl_ManualPatches.ForeColor = SystemColors.Control;
                lbl_DisableSoftwareUpdater.ForeColor = SystemColors.Control;
                if (check_FTP.Checked) {
                    lbl_ManualInstall.ForeColor = SystemColors.GrayText;
                    lbl_ManualPatches.ForeColor = SystemColors.GrayText;
                    lbl_TweaksOverlay.ForeColor = SystemColors.GrayText;
                    lbl_Reflections.ForeColor = SystemColors.GrayText;
                    lbl_CameraDistance.ForeColor = SystemColors.GrayText;
                    lbl_SaveRedirect.ForeColor = SystemColors.GrayText;
                    lbl_CameraType.ForeColor = SystemColors.GrayText;
                    lbl_FieldOfView.ForeColor = SystemColors.GrayText;
                    lbl_Renderer.ForeColor = SystemColors.GrayText;
                    lbl_CameraHeight.ForeColor = SystemColors.GrayText;
                } else {
                    lbl_ManualInstall.ForeColor = SystemColors.Control;
                    if (Prerequisites.JavaCheck()) lbl_ManualPatches.ForeColor = SystemColors.Control;
                    lbl_TweaksOverlay.ForeColor = SystemColors.Control;
                    lbl_Reflections.ForeColor = SystemColors.Control;
                    lbl_CameraDistance.ForeColor = SystemColors.Control;
                    lbl_SaveRedirect.ForeColor = SystemColors.Control;
                    lbl_CameraType.ForeColor = SystemColors.Control;
                    if (combo_Emulator_System.SelectedIndex != 1) lbl_FieldOfView.ForeColor = SystemColors.Control;
                    lbl_Renderer.ForeColor = SystemColors.Control;
                    lbl_CameraHeight.ForeColor = SystemColors.Control;
                }
                if (check_ManualInstall.Checked)
                    lbl_FTP.ForeColor = SystemColors.GrayText;
                else
                    lbl_FTP.ForeColor = SystemColors.Control;

                lbl_EmulatorEXE.ForeColor = SystemColors.Control;
                lbl_Emulator_System.ForeColor = SystemColors.Control;
                if (combo_Emulator_System.SelectedIndex == 0) { //Depending on the selected system, change text to disabled colour.
                    lbl_API.ForeColor = SystemColors.Control;
                    if (combo_API.SelectedIndex == 0) {
                        lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                        lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    }
                    else {
                        lbl_ForceRTV.ForeColor = SystemColors.Control;
                        lbl_2xResolution.ForeColor = SystemColors.Control;
                    }
                    lbl_VSync.ForeColor = SystemColors.Control;
                    lbl_ProtectZero.ForeColor = SystemColors.Control;
                    lbl_EnableGamma.ForeColor = SystemColors.Control;
                    lbl_Fullscreen.ForeColor = SystemColors.Control;
                    lbl_Discord.ForeColor = SystemColors.Control;
                    lbl_Debug.ForeColor = SystemColors.Control;
                    lbl_SettingsOverlay.ForeColor = SystemColors.Control;
                }
                else {
                    lbl_API.ForeColor = SystemColors.GrayText;
                    lbl_ForceRTV.ForeColor = SystemColors.GrayText;
                    lbl_2xResolution.ForeColor = SystemColors.GrayText;
                    lbl_VSync.ForeColor = SystemColors.GrayText;
                    lbl_ProtectZero.ForeColor = SystemColors.GrayText;
                    lbl_EnableGamma.ForeColor = SystemColors.GrayText;
                    lbl_Fullscreen.ForeColor = SystemColors.GrayText;
                    lbl_Discord.ForeColor = SystemColors.GrayText;
                    lbl_Debug.ForeColor = SystemColors.GrayText;
                    lbl_SettingsOverlay.ForeColor = SystemColors.GrayText;
                }

                group_Directories.ForeColor = SystemColors.Control;
                group_FTP.ForeColor = SystemColors.Control;
                group_Options.ForeColor = SystemColors.Control;
                group_Tweaks.ForeColor = SystemColors.Control;
                group_Setup.ForeColor = SystemColors.Control;
                group_Settings.ForeColor = SystemColors.Control;

                check_FTP.ForeColor = SystemColors.Control;
                check_ManualInstall.ForeColor = SystemColors.Control;

                text_FTPLocation.BackColor = Color.FromArgb(45, 45, 48); text_FTPLocation.ForeColor = SystemColors.Control;
                text_GameDirectory.BackColor = Color.FromArgb(45, 45, 48); text_GameDirectory.ForeColor = SystemColors.Control;
                text_ModsDirectory.BackColor = Color.FromArgb(45, 45, 48); text_ModsDirectory.ForeColor = SystemColors.Control;
                text_Password.BackColor = Color.FromArgb(45, 45, 48); text_Password.ForeColor = SystemColors.Control;
                text_Username.BackColor = Color.FromArgb(45, 45, 48); text_Username.ForeColor = SystemColors.Control;
                text_EmulatorPath.BackColor = Color.FromArgb(45, 45, 48); text_EmulatorPath.ForeColor = SystemColors.Control;
                text_SaveData.BackColor = Color.FromArgb(45, 45, 48); text_SaveData.ForeColor = SystemColors.Control;

                pnl_ModBackdrop.BackColor = clb_ModsList.BackColor = Color.FromArgb(45, 45, 48); 
                clb_ModsList.ForeColor = SystemColors.Control;
                pnl_PatchBackdrop.BackColor = clb_PatchesList.BackColor = Color.FromArgb(45, 45, 48); 
                clb_PatchesList.ForeColor = SystemColors.Control;

                radio_All.ForeColor = SystemColors.Control; radio_All.BackColor = Color.FromArgb(45, 45, 48);
                radio_Xbox360.ForeColor = SystemColors.Control; radio_Xbox360.BackColor = Color.FromArgb(45, 45, 48);
                radio_PlayStation3.ForeColor = SystemColors.Control; radio_PlayStation3.BackColor = Color.FromArgb(45, 45, 48);
            }

            unifytb_Main.Refresh(); //Refresh user control to remove software rendering leftovers.
        }

        //Navigate to the GitHub page in the default web browser.
        private void Btn_GitHub_Click(object sender, EventArgs e) { Process.Start("https://github.com/Knuxfan24/Sonic-06-Mod-Manager"); }

        //Show About Form, passing the Version Number in to be displayed.
        private void Btn_About_Click(object sender, EventArgs e) { new src.AboutForm(versionNumber).ShowDialog(); }

        private void Btn_About_MouseUp(object sender, MouseEventArgs e) {
            switch (e.Button) {
                case MouseButtons.Right:
                    string inst = "Unknown";
                    if (IntPtr.Size == 4)
                        inst = "x86";
                    else if (IntPtr.Size == 8)
                        inst = "x64";
                    else
                        inst = "Unknown";

                    UnifyMessages.UnifyMessage.Show(
                        $"Sonic '06 Mod Manager\n" +
                        $"Architecture: {inst}\n\n" +
                        $"" +
                        $"Framework Version: {versionNumber.Substring(8)}\n" +
                        $"Sonic '06 Mod Loader Version: {modLoaderVersion.Substring(8)}\n\n" +
                        $"" +
                        $"Dreamcast Day: {dreamcastDay.ToString()}\n" +
                        $"Vulkan Warning: {Properties.Settings.Default.seenVulkanWarning.ToString()}",
                        "Debug Information", "OK", "Information");
                    break;
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e) {
            //Read the message box text if you're confused.
            string resetConfirmation = UnifyMessages.UnifyMessage.Show(SettingsMessages.msg_Reset, SystemMessages.tl_DefaultTitle, "YesNo", "Warning");

            if (resetConfirmation == "Yes") {
                Properties.Settings.Default.Reset();
                Application.Restart();
            }
        }

        private void Btn_ReportBug_Click(object sender, EventArgs e) { Process.Start("https://github.com/Knuxfan24/Sonic-06-Mod-Manager/issues"); }

        private void Lbl_ModsDirectory_Click(object sender, EventArgs e) { if (Directory.Exists(Properties.Settings.Default.modsDirectory)) Process.Start(Properties.Settings.Default.modsDirectory); } // Open Mods directory shortcut

        private void Lbl_GameDirectory_Click(object sender, EventArgs e) { if (Directory.Exists(Properties.Settings.Default.gameDirectory)) Process.Start(Properties.Settings.Default.gameDirectory); } // Open Game directory shortcut

        private void Lbl_EmulatorEXE_Click(object sender, EventArgs e) {
            if (combo_Emulator_System.SelectedIndex == 0)
                LaunchXenia();
            else
                LaunchRPCS3();
        }

        private void Check_ManualInstall_CheckedChanged(object sender, EventArgs e) {
            if (check_ManualInstall.Checked) {
                Properties.Settings.Default.manualInstall = true;
                check_FTP.Enabled = false;
                lbl_FTP.ForeColor = SystemColors.GrayText;
                btn_InstallMods.Text = "Install Mods";
                split_Mods.Visible = true;
                btn_UninstallMods.Visible = true;
            } else {
                Properties.Settings.Default.manualInstall = false;
                check_FTP.Enabled = true;
                if (!Properties.Settings.Default.theme)
                    lbl_FTP.ForeColor = SystemColors.ControlText;
                else
                    lbl_FTP.ForeColor = SystemColors.Control;
                split_Mods.Visible = false;
                btn_UninstallMods.Visible = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Check_FTP_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FTP.Checked)
            {
                Properties.Settings.Default.FTP = true;
                check_ManualInstall.Enabled = false;
                check_ManualPatches.Enabled = false;
                check_SaveRedirect.Enabled = false;
                lbl_ManualInstall.ForeColor = SystemColors.GrayText;
                lbl_ManualPatches.ForeColor = SystemColors.GrayText;
                lbl_SaveRedirect.ForeColor = SystemColors.GrayText;
                btn_InstallMods.Text = "Install Mods";
                split_Mods.Visible = true;
                btn_UninstallMods.Visible = true;

                lbl_TweaksOverlay.ForeColor = SystemColors.GrayText;
                lbl_Reflections.ForeColor = SystemColors.GrayText;
                lbl_CameraDistance.ForeColor = SystemColors.GrayText;
                lbl_CameraType.ForeColor = SystemColors.GrayText;
                lbl_FieldOfView.ForeColor = SystemColors.GrayText;
                lbl_Renderer.ForeColor = SystemColors.GrayText;
                lbl_CameraHeight.ForeColor = SystemColors.GrayText;
                combo_CameraType.Enabled = false;
                btn_ResetCameraType.Enabled = false;
                clb_PatchesList.Enabled = false;
                btn_ResetReflections.Enabled = false;
                btn_ResetCameraDistance.Enabled = false;
                combo_Reflections.Enabled = false;
                nud_CameraDistance.Enabled = false;
                btn_Play.Enabled = false;
                nud_FieldOfView.Enabled = false;
                btn_ResetFOV.Enabled = false;
                combo_Renderer.Enabled = false;
                btn_ResetRenderer.Enabled = false;
                nud_CameraHeight.Enabled = false;
                btn_ResetCameraHeight.Enabled = false;
            }
            else
            {
                Properties.Settings.Default.FTP = false;
                check_ManualInstall.Enabled = true;
                if (Prerequisites.JavaCheck()) check_ManualPatches.Enabled = true;
                check_SaveRedirect.Enabled = true;
                if (combo_Emulator_System.SelectedIndex != 1) {
                    nud_FieldOfView.Enabled = true;
                    btn_ResetFOV.Enabled = true;
                }
                if (combo_CameraType.SelectedIndex != 1) {
                    nud_CameraDistance.Enabled = true;
                    btn_ResetCameraDistance.Enabled = true;
                }
                if (!Properties.Settings.Default.theme) {
                    lbl_ManualInstall.ForeColor = SystemColors.ControlText;
                    if (Prerequisites.JavaCheck()) lbl_ManualPatches.ForeColor = SystemColors.ControlText;
                    lbl_TweaksOverlay.ForeColor = SystemColors.ControlText;
                    lbl_Reflections.ForeColor = SystemColors.ControlText;
                    lbl_SaveRedirect.ForeColor = SystemColors.ControlText;
                    lbl_CameraType.ForeColor = SystemColors.ControlText;
                    if (combo_Emulator_System.SelectedIndex != 1)
                        lbl_FieldOfView.ForeColor = SystemColors.ControlText;
                    if (combo_CameraType.SelectedIndex != 1)
                        lbl_CameraDistance.ForeColor = SystemColors.ControlText;
                    lbl_Renderer.ForeColor = SystemColors.ControlText;
                    lbl_CameraHeight.ForeColor = SystemColors.ControlText;
                } else {
                    lbl_ManualInstall.ForeColor = SystemColors.Control;
                    if (Prerequisites.JavaCheck()) lbl_ManualPatches.ForeColor = SystemColors.Control;
                    lbl_TweaksOverlay.ForeColor = SystemColors.Control;
                    lbl_Reflections.ForeColor = SystemColors.Control;
                    lbl_SaveRedirect.ForeColor = SystemColors.Control;
                    lbl_CameraType.ForeColor = SystemColors.Control;
                    if (combo_Emulator_System.SelectedIndex != 1)
                        lbl_FieldOfView.ForeColor = SystemColors.Control;
                    if (combo_CameraType.SelectedIndex != 1)
                        lbl_CameraDistance.ForeColor = SystemColors.Control;
                    lbl_Renderer.ForeColor = SystemColors.Control;
                    lbl_CameraHeight.ForeColor = SystemColors.Control;
                }
                split_Mods.Visible = false;
                btn_UninstallMods.Visible = false;
                combo_CameraType.Enabled = true;
                btn_ResetCameraType.Enabled = true;
                clb_PatchesList.Enabled = true;
                btn_ResetReflections.Enabled = true;
                combo_Reflections.Enabled = true;
                btn_Play.Enabled = true;
                combo_Renderer.Enabled = true;
                btn_ResetRenderer.Enabled = true;
                nud_CameraHeight.Enabled = true;
                btn_ResetCameraHeight.Enabled = true;
            }

            Properties.Settings.Default.Save();
        }

        private void Check_GameBanana_CheckedChanged(object sender, EventArgs e) {
            if (check_GameBanana.Checked) {
                try {
                    var Protocol = "sonic06mm";
                    var key = Registry.ClassesRoot.OpenSubKey($"{Protocol}\\shell\\open\\command");

                    if (key == null) {
                        if (!Program.RunningAsAdmin()) {
                            string registry = UnifyMessages.UnifyMessage.Show(SystemMessages.msg_GameBananaRegistry, SystemMessages.tl_DefaultTitle, "YesNo", "Warning");

                            switch (registry) {
                                case "Yes":
                                    Program.ExecuteAsAdmin(Application.ExecutablePath, "-registry_add");
                                    Application.Exit();
                                    break;
                                case "No":
                                    check_GameBanana.Checked = false;
                                    break;
                            }
                        }
                        else GB_Registry.AddRegistry();
                    }
                }
                catch { }
            } else {
                try {
                    var Protocol = "sonic06mm";
                    var key = Registry.ClassesRoot.OpenSubKey(Protocol);

                    if (key != null) {
                        if (!Program.RunningAsAdmin()) {
                            string registry = UnifyMessages.UnifyMessage.Show(SystemMessages.msg_GameBananaRegistryUninstall, SystemMessages.tl_DefaultTitle, "YesNo", "Warning");

                            switch (registry) {
                                case "Yes":
                                    Program.ExecuteAsAdmin(Application.ExecutablePath, "-registry_remove");
                                    Application.Exit();
                                    break;
                                case "No":
                                    check_GameBanana.Checked = true;
                                    break;
                            }
                        }
                        else GB_Registry.RemoveRegistry();
                    }
                }
                catch { }
            }
        }
        #endregion

        private void Help_Renderer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to pick which renderer the game uses.\n\n" +
                                            "" +
                                            "► Default - Standard Sonic '06 renderer.\n" +
                                            "► Optimised - HyperPolygon64's Optimised Renderer which improves performance without compromising visuals.\n" +
                                            "► Destructive - AllanCat's renderer which is optimised for the Vulkan API on Xenia.\n" +
                                            "► Cheap - Sonic Team's bizarre renderer which disables a lot of effects.", "Renderer", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void Help_Reflections_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to choose the reflection resolution. Changing this doesn't impact performance.\n\n" +
                                            "" +
                                            "► Off - Disables reflections entirely.\n" +
                                            "► Quarter - Default (320x180).\n" +
                                            "► Half - Halved internal resolution for reflections (640x360).\n" +
                                            "► Full - Full internal resolution for reflections (1280x720).", "Reflections", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void Help_CameraType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to change the way the camera works.\n\n" +
                                            "" +
                                            "► Retail - Standard Sonic '06 camera.\n" +
                                            "► Tokyo Game Show (TGS) - A recreation of the look and feel of Tokyo Game Show (2005)'s camera.\n" +
                                            "► Electronic Entertainment Expo (E3) - The same camera used in the Xbox Live Arcade Demo.", "Camera Type", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void help_CameraDistance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to change the distance between the camera and the player.", "Camera Distance", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void help_CameraHeight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to change the height at where the camera sits in relation to the player.", "Camera Height", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void help_FieldOfView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Status = SystemMessages.msg_PatchInfo;
            UnifyMessages.UnifyMessage.Show("This tweak allows you to change the field of view for the main camera.", "Field of View", "OK", "Information");
            Status = SystemMessages.msg_DefaultStatus;
        }

        private void clb_PatchesList_SelectedIndexChanged(object sender, EventArgs e) { btn_ModInfo.Enabled = clb_PatchesList.SelectedIndex >= 0; }

        private void btn_SaveData_Click(object sender, EventArgs e) { Properties.Settings.Default.saveData = text_SaveData.Text = Locations.LocateSaves(combo_Emulator_System.SelectedIndex); }
    }
}
