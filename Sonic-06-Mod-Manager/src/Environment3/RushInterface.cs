using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Patcher;
using Unify.Dialogs;
using System.Drawing;
using Microsoft.Win32;
using Unify.Messenger;
using Unify.Networking;
using Unify.Serialisers;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperPolygon64

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

namespace Unify.Environment3
{
    public partial class RushInterface : UserControl
    {
        private bool _isPathInvalid = false;
        private static string protocol = "sonic06mm";
        private bool _useBackupServer = false;

        public RushInterface() {
            InitializeComponent(); // Designer support

            // Prevents actions being performed in UnifyEnvironment's design time.
            if (!DesignMode) {
                // Begin first time setup
                if (Properties.Settings.Default.General_FirstLaunch &&
                    Properties.Settings.Default.Path_ModsDirectory == string.Empty)
                        new UnifySetup().ShowDialog();

                if (Paths.IsDirectoryEmpty(Program.Patches)) {
                    Properties.Settings.Default.General_LastPatchUpdate = DateTime.Now.Ticks;
                    // Update patches synchronously
                    if (Client.CheckNetworkConnection().Result) Task.Run(() => UpdatePatches()).GetAwaiter().GetResult();

                    // Reset update button for future checking
                    SectionButton_FetchPatches.Enabled = true;
                    SectionButton_FetchPatches.Refresh();
                    RefreshLists();
                }

                LoadSettings(); // Load user settings

                // Check registry for 1-Click Install registry key
                try { CheckRegistry(); } catch { LinkLabel_1ClickURLHandler.Text = "Reinstall 1-Click URL Handler"; }

                Label_Version.Text = Program.VersionNumber; // Sets the version string in the About section
                Properties.Settings.Default.SettingsSaving += Settings_SettingsSaving; // Subscribe to event for SettingsSaving
                TabControl_Rush.Height += 23; // Increase height on load to accommodate for lack of tabs in the section controller

                // Force splitter widths - because WinForms is dumb and ignores it at design time
                SplitContainer_ModsControls.SplitterWidth = SplitContainer_PatchesControls.SplitterWidth = SplitContainer_MainControls.SplitterWidth = 1;
                SplitContainer_ModUpdate.SplitterWidth = 2;
#if DEBUG
                // If the application is a debug build, force debug mode on
                Properties.Settings.Default.General_Debug = Program._debug = true;
                Properties.Settings.Default.Save();
#endif
            }
        }

        public string Status {
            get { return Label_Status.Text; }
            set { Label_Status.Text = value; }
        }

        /// <summary>
        /// Performs actions on launch.
        /// </summary>
        private void RushInterface_Load(object sender, EventArgs e) {
            RefreshLists(); // Refresh mods list
            if (Paths.CheckFileLegitimacy(Properties.Settings.Default.Path_GameExecutable) && 
                Properties.Settings.Default.General_AutoUninstall) UninstallThread(); // Uninstall everything
        }

        /// <summary>
        /// If 'Properties.Settings.Default.Save()' is called, the 'LoadSettings()' function will be executed.
        /// </summary>
        private void Settings_SettingsSaving(object sender, CancelEventArgs e) { LoadSettings(); }

        /// <summary>
        /// Loads all user settings.
        /// </summary>
        private void LoadSettings()
        {
            if (!DesignMode) {

                #region Unsubscribe from events
                // Prevents replacement values being saved
                NumericUpDown_CameraDistance.ValueChanged -= NumericUpDown_Tweaks_ValueChanged;
                NumericUpDown_CameraHeight.ValueChanged -= NumericUpDown_Tweaks_ValueChanged;
                NumericUpDown_FieldOfView.ValueChanged -= NumericUpDown_Tweaks_ValueChanged;
                #endregion

                #region Restore label strings
                Label_LastSoftwareUpdate.Text = Literal.Date("Last checked", Properties.Settings.Default.General_LastSoftwareUpdate);
                Label_LastModUpdate.Text      = Literal.Date("Last checked", Properties.Settings.Default.General_LastModUpdate);
                Label_LastPatchUpdate.Text    = Literal.Date("Last updated", Properties.Settings.Default.General_LastPatchUpdate);

                if (Properties.Settings.Default.General_Mods_Priority)
                    Button_Mods_Priority.Text = "Priority: Bottom to Top";
                else
                    Button_Mods_Priority.Text = "Priority: Top to Bottom";

                if (Properties.Settings.Default.General_Patches_Priority)
                    Button_Patches_Priority.Text = "Priority: Bottom to Top";
                else
                    Button_Patches_Priority.Text = "Priority: Top to Bottom";
                #endregion

                #region Restore text fields
                _isPathInvalid = false;
                TextBox_GameDirectory.Text      = Properties.Settings.Default.Path_GameExecutable;
                TextBox_ModsDirectory.Text      = Properties.Settings.Default.Path_ModsDirectory;
                TextBox_EmulatorExecutable.Text = Properties.Settings.Default.Path_EmulatorDirectory;
                TextBox_SaveData.Text           = Properties.Settings.Default.Path_SaveData;
                TextBox_Arguments.Text          = Properties.Settings.Default.Emulator_Arguments;

                if (Properties.Settings.Default.Path_ModsDirectory != string.Empty && Properties.Settings.Default.Path_GameExecutable != string.Empty) {
                    if (Paths.IsSubdirectory(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), Properties.Settings.Default.Path_ModsDirectory) ||
                        Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable) == Properties.Settings.Default.Path_ModsDirectory) {
                            // If the mods directory is inside the game directory, warn the user
                            Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                            _isPathInvalid = true;
                    }
                    else
                        Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;

                    if (Paths.IsSubdirectory(Properties.Settings.Default.Path_ModsDirectory, Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable)) ||
                        Properties.Settings.Default.Path_ModsDirectory == Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable)) {
                            // If the mods directory is inside the game directory, warn the user
                            Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                            _isPathInvalid = true;
                    }
                    else
                        Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;
                }
                #endregion

                #region Restore combo box states
                ComboBox_API.SelectedIndex          = Properties.Settings.Default.Emulator_API;
                ComboBox_UserLanguage.SelectedIndex = Properties.Settings.Default.Emulator_UserLanguage;
                ComboBox_Reflections.SelectedIndex  = Properties.Settings.Default.Tweak_Reflections;
                ComboBox_AntiAliasing.SelectedIndex = Properties.Settings.Default.Tweak_AntiAliasing;
                ComboBox_CameraType.SelectedIndex   = Properties.Settings.Default.Tweak_CameraType;

                if ((ComboBox_Renderer.SelectedIndex = Properties.Settings.Default.Tweak_Renderer) != 0) {
                    // Set enabled state for controls
                    ComboBox_AntiAliasing.Enabled = Button_AntiAliasing_Default.Enabled = CheckBox_ForceMSAA.Enabled = false;

                    // Set controls to GrayText
                    Label_AntiAliasing.ForeColor =
                    Label_Description_AntiAliasing.ForeColor =
                    Label_Description_ForceMSAA.ForeColor =
                    SystemColors.GrayText;
                } else {
                    // Set enabled state for controls
                    ComboBox_AntiAliasing.Enabled = Button_AntiAliasing_Default.Enabled = CheckBox_ForceMSAA.Enabled = true;

                    // Set controls to Control
                    Label_AntiAliasing.ForeColor = SystemColors.Control;

                    // Set controls to GrayText
                    Label_Description_AntiAliasing.ForeColor =
                    Label_Description_ForceMSAA.ForeColor =
                    SystemColors.ControlDark;
                }
                #endregion

                #region Restore numeric up down decimals
                NumericUpDown_CameraDistance.Value = Properties.Settings.Default.Tweak_CameraDistance;
                NumericUpDown_CameraHeight.Value   = Properties.Settings.Default.Tweak_CameraHeight;
                NumericUpDown_FieldOfView.Value    = Properties.Settings.Default.Tweak_FieldOfView;
                NumericUpDown_AmyHammerRange.Value = Properties.Settings.Default.Tweak_AmyHammerRange;
                NumericUpDown_BeginWithRings.Value = Properties.Settings.Default.Tweak_BeginWithRings;
                #endregion

                #region Restore check box states
                CheckBox_AutoColour.Checked         = Properties.Settings.Default.General_AutoColour;
                CheckBox_Xenia_ForceRTV.Checked     = Properties.Settings.Default.Emulator_ForceRTV;
                CheckBox_Xenia_2xResolution.Checked = Properties.Settings.Default.Emulator_DoubleResolution;
                CheckBox_Xenia_VerticalSync.Checked = Properties.Settings.Default.Emulator_VerticalSync;
                CheckBox_Xenia_Gamma.Checked        = Properties.Settings.Default.Emulator_Gamma;
                CheckBox_Xenia_Fullscreen.Checked   = Properties.Settings.Default.Emulator_Fullscreen;
                CheckBox_Xenia_DiscordRPC.Checked   = Properties.Settings.Default.Emulator_DiscordRPC;
                CheckBox_ForceMSAA.Checked          = Properties.Settings.Default.Tweak_ForceMSAA;
                CheckBox_TailsFlightLimit.Checked   = Properties.Settings.Default.Tweak_TailsFlightLimit;
                CheckBox_UninstallOnLaunch.Checked  = Properties.Settings.Default.General_AutoUninstall;
                CheckBox_AllowModStacking.Checked   = Properties.Settings.Default.Debug_AllowModStacking;

                if (CheckBox_HighContrastText.Checked = Properties.Settings.Default.General_HighContrastText)
                    Label_Status.ForeColor = SystemColors.ControlText;
                else
                    Label_Status.ForeColor = SystemColors.Control;

                if (CheckBox_DebugMode.Checked = Rush_Section_Debug.Visible = Program._debug = Properties.Settings.Default.General_Debug)
                    Console.SetOut(new ListBoxWriter(ListBox_Debug));

                if (CheckBox_LaunchEmulator.Checked = Properties.Settings.Default.General_LaunchEmulator) {
                    SectionButton_InstallMods.SectionText = "Save, install content and launch Sonic '06";
                    SectionButton_InstallMods.Refresh();
                } else {
                    SectionButton_InstallMods.SectionText = "Save and install content";
                    SectionButton_InstallMods.Refresh();
                }

                if (CheckBox_CheckUpdatesOnLaunch.Checked = Properties.Settings.Default.General_CheckUpdatesOnLaunch) {
                    Properties.Settings.Default.General_LastSoftwareUpdate = DateTime.Now.Ticks;
                    CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                }

                if (CheckBox_SaveFileRedirection.Checked = Properties.Settings.Default.General_SaveFileRedirection) {
                    // Set text colour to Control
                    Label_SaveData.ForeColor = SystemColors.Control;

                    // Set text colour to ControlDark
                    Label_Optional_SaveData.ForeColor =
                    Label_Description_SaveData.ForeColor =
                    SystemColors.ControlDark;

                    // Set controls enabled state
                    TextBox_SaveData.Enabled =
                    Button_SaveData.Enabled =
                    Button_Open_SaveData.Enabled =
                    true;
                } else {
                    // Set text colour to GrayText (spelt the wrong way)
                    Label_SaveData.ForeColor =
                    Label_Optional_SaveData.ForeColor =
                    Label_Description_SaveData.ForeColor =
                    SystemColors.GrayText;

                    // Set controls enabled state
                    TextBox_SaveData.Enabled =
                    Button_SaveData.Enabled =
                    Button_Open_SaveData.Enabled =
                    false;
                }
                #endregion

                #region Set controls to AccentColour setting
                Button_ColourPicker_Preview.FlatAppearance.MouseOverBackColor =
                Button_ColourPicker_Preview.FlatAppearance.MouseDownBackColor =
                Rush_Section_Mods.AccentColour =
                Rush_Section_Settings.AccentColour =
                Button_ColourPicker_Preview.BackColor =
                StatusStrip_Main.BackColor =
                Label_Status.BackColor =
                Properties.Settings.Default.General_AccentColour;
                #endregion

                #region Set controls depending on emulator
                if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) == "Xenia") {
                    if (Properties.Settings.Default.Emulator_API != 2)
                        // Enables most controls in the Emulator UI
                        EnableEmulatorInterface();
                    else
                        // Disables most controls in the Emulator UI
                        DisableEmulatorInterface();

                    // Set visibility state of controls
                    Label_RPCS3Warning.Visible = false;
                } else if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) == "RPCS3") {
                    // Disables most controls in the Emulator UI
                    DisableEmulatorInterface();

                    ComboBox_API.Enabled = false;

                    Label_Subtitle_Emulator_Options.ForeColor =
                    Label_API.ForeColor =
                    Label_Description_API.ForeColor =
                    SystemColors.GrayText;

                    // Set visibility state of controls
                    Label_RPCS3Warning.Visible = true;
                }
                #endregion

                #region Subscribe to events
                // Prevents replacement values being saved
                NumericUpDown_CameraDistance.ValueChanged += NumericUpDown_Tweaks_ValueChanged;
                NumericUpDown_CameraHeight.ValueChanged += NumericUpDown_Tweaks_ValueChanged;
                NumericUpDown_FieldOfView.ValueChanged += NumericUpDown_Tweaks_ValueChanged;
                #endregion

            }
        }

        /// <summary>
        /// Enables most controls in the Emulator UI.
        /// </summary>
        private void EnableEmulatorInterface() {
            #region Enable controls
            if (Properties.Settings.Default.Tweak_Renderer == 0) {
                // Set text colour to Control
                Label_AntiAliasing.ForeColor = Label_Reflections.ForeColor = SystemColors.Control;

                // Set text colour to ControlDark
                Label_Description_AntiAliasing.ForeColor =
                Label_Description_Reflections.ForeColor =
                SystemColors.ControlDark;

                // Set enabled state of controls
                Button_AntiAliasing_Default.Enabled =
                ComboBox_AntiAliasing.Enabled =
                ComboBox_Reflections.Enabled =
                Button_Reflections_Default.Enabled =
                true;

                if (CheckBox_ForceMSAA.Enabled = Properties.Settings.Default.Tweak_AntiAliasing == 1)
                    // Set text colour to ControlDark
                    Label_Description_ForceMSAA.ForeColor = SystemColors.ControlDark;
                else
                    // Set text colour to GrayText
                    Label_Description_ForceMSAA.ForeColor = SystemColors.GrayText;
            }

            if (Properties.Settings.Default.Emulator_API != 0) {
                CheckBox_Xenia_ForceRTV.Enabled = CheckBox_Xenia_2xResolution.Enabled = false;
                Label_Description_ForceRTV.ForeColor = Label_Description_2xResolution.ForeColor = SystemColors.GrayText;
            } else {
                CheckBox_Xenia_ForceRTV.Enabled = CheckBox_Xenia_2xResolution.Enabled = true;
                Label_Description_ForceRTV.ForeColor = Label_Description_2xResolution.ForeColor = SystemColors.ControlDark;
            }

            // Set text colour to Control
            Label_Subtitle_Emulator_Options.ForeColor =
            Label_API.ForeColor =
            Label_FieldOfView.ForeColor =
            Label_UserLanguage.ForeColor =
            SystemColors.Control;

            // Set text colour to ControlDark
            Label_Description_API.ForeColor =
            Label_Description_FieldOfView.ForeColor =
            Label_Description_UserLanguage.ForeColor =
            Label_Description_VerticalSync.ForeColor =
            Label_Description_Gamma.ForeColor =
            Label_Description_Fullscreen.ForeColor =
            Label_Description_DiscordRPC.ForeColor =
            SystemColors.ControlDark;

            // Set enabled state of controls
            ComboBox_API.Enabled =
            NumericUpDown_FieldOfView.Enabled =
            Button_FieldOfView_Default.Enabled =
            ComboBox_UserLanguage.Enabled =
            CheckBox_Xenia_VerticalSync.Enabled =
            CheckBox_Xenia_Gamma.Enabled =
            CheckBox_Xenia_Fullscreen.Enabled =
            CheckBox_Xenia_DiscordRPC.Enabled =
            true;
            #endregion
        }

        /// <summary>
        /// Disables most controls in the Emulator UI.
        /// </summary>
        private void DisableEmulatorInterface() {
            #region Disable controls
            // Set text colour to GrayText
            Label_Description_FieldOfView.ForeColor =
            Label_Description_AntiAliasing.ForeColor =
            Label_Description_ForceMSAA.ForeColor =
            Label_Description_Reflections.ForeColor =
            Label_Description_UserLanguage.ForeColor =
            Label_Description_ForceRTV.ForeColor =
            Label_Description_2xResolution.ForeColor =
            Label_Description_VerticalSync.ForeColor =
            Label_Description_Gamma.ForeColor =
            Label_Description_Fullscreen.ForeColor =
            Label_Description_DiscordRPC.ForeColor =
            Label_AntiAliasing.ForeColor =
            Label_FieldOfView.ForeColor =
            Label_Reflections.ForeColor =
            Label_UserLanguage.ForeColor =
            SystemColors.GrayText;

            // Set enabled state of controls
            NumericUpDown_FieldOfView.Enabled =
            Button_FieldOfView_Default.Enabled =
            Button_AntiAliasing_Default.Enabled =
            ComboBox_AntiAliasing.Enabled =
            CheckBox_ForceMSAA.Enabled =
            ComboBox_Reflections.Enabled =
            Button_Reflections_Default.Enabled =
            ComboBox_UserLanguage.Enabled =
            CheckBox_Xenia_ForceRTV.Enabled =
            CheckBox_Xenia_2xResolution.Enabled =
            CheckBox_Xenia_VerticalSync.Enabled =
            CheckBox_Xenia_Gamma.Enabled =
            CheckBox_Xenia_Fullscreen.Enabled =
            CheckBox_Xenia_DiscordRPC.Enabled =
            false;
            #endregion
        }

        /// <summary>
        /// Re-deserialises the mods, then checks them - in turn, refreshing the list.
        /// </summary>
        private void RefreshLists() {
            DeserialiseMods(); // Refresh mods list
            DeserialisePatches(); // Refresh patches list
            CheckDeserialisedMods(); // Check saved mods
            CheckDeserialisedPatches(); // Check saved patches
        }

        /// <summary>
        /// Removes the selected highlight for all SectionButton controls.
        /// </summary>
        private void SectionButton_DeselectAll() {
            foreach (Control control in Controls)
                if (control is SectionButton) ((SectionButton)control).SelectedSection = false;
        }

        /// <summary>
        /// Pings the update servers to check for a new version.
        /// </summary>
        private async void CheckForUpdates(string versionURI, string changelogsURI) {
            // Block controls
            SectionButton_CheckForSoftwareUpdates.Enabled = false;

            try {
                if (Client.CheckNetworkConnection().Result) {
                    string latestVersion = await Client.RequestString(versionURI),    // Request version number
                           changelogs    = await Client.RequestString(changelogsURI); // Request changelogs

                    // New update available!
                    if (Program.VersionNumber != latestVersion && latestVersion.StartsWith("Version"))
                        if (InvokeRequired)
                            Invoke(new MethodInvoker(delegate { OnCheckForUpdates(latestVersion, changelogs); }));
                        else
                            OnCheckForUpdates(latestVersion, changelogs);

                    // String was downloaded, but invalid
                    else if (!latestVersion.StartsWith("Version"))
                        throw new WebException("Invalid version number - server might be down...");
                } else
                    throw new WebException("Could not establish a connection...");
            } catch {
                try {
                    // Check for updates via SEGA Carnival
                    if (Client.CheckNetworkConnection().Result) {
                        CheckForUpdates(Properties.Resources.VersionURI_SEGACarnival, Properties.Resources.ChangelogsURI_SEGACarnival);
                        Properties.Settings.Default.General_LastSoftwareUpdate = DateTime.Now.Ticks;
                        _useBackupServer = true;
                    } else
                        throw new WebException("Could not establish a connection...");
                } catch (Exception ex) {
                    Label_UpdaterStatus.Text = "Connection error";
                    PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;

                    // Reset update button for future checking
                    SectionButton_CheckForSoftwareUpdates.SectionText = "Check for software updates";
                    SectionButton_CheckForSoftwareUpdates.Refresh();

                    // Write exception to logs
                    RichTextBox_Changelogs.Text = $"Failed to request changelogs...\n\n{ex}";
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to request changelogs...\n{ex}");
                }
            }

            // Feedback
            SectionButton_CheckForSoftwareUpdates.Enabled = true;
        }

        /// <summary>
        /// Function called if there's a new version detected - avoids exceptions caused by async calls.
        /// </summary>
        private void OnCheckForUpdates(string latestVersion, string changelogs) {
            // Give feedback on update status
            Label_UpdaterStatus.Text = "Updates available";
            Label_Status.Text = "A new version of Sonic '06 Mod Manager is available!";
            PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;

            // Request changelogs
            RichTextBox_Changelogs.Text = $"Sonic '06 Mod Manager - {latestVersion}\n\n" +
                                          $"" +
                                          $"{changelogs}";

            // Defines new appearance for the Check for Updates button
            SectionButton_CheckForSoftwareUpdates.SectionImage = Properties.Resources.InstallMods;
            SectionButton_CheckForSoftwareUpdates.SectionText = "Fetch the latest version";
            SectionButton_CheckForSoftwareUpdates.Refresh(); // Refreshes custom user control to display new properties
        }

        /// <summary>
        /// Takes click control from all section buttons and switches the navigator control.
        /// </summary>
        private void Rush_Section_Click(object sender, EventArgs e) {
            SectionButton_DeselectAll();
            if          (sender == Rush_Section_Mods) TabControl_Rush.SelectedTab = Tab_Section_Mods;     // Set tab to Mods
            else if (sender == Rush_Section_Emulator) TabControl_Rush.SelectedTab = Tab_Section_Emulator; // Set tab to Emulator
            else if  (sender == Rush_Section_Patches) TabControl_Rush.SelectedTab = Tab_Section_Patches;  // Set tab to Patches
            else if   (sender == Rush_Section_Tweaks) TabControl_Rush.SelectedTab = Tab_Section_Tweaks;   // Set tab to Patches
            else if (sender == Rush_Section_Settings) TabControl_Rush.SelectedTab = Tab_Section_Settings; // Set tab to Settings
            else if    (sender == Rush_Section_Debug) TabControl_Rush.SelectedTab = Tab_Section_Debug;    // Set tab to Debug
            else if  (sender == Rush_Section_Updates) TabControl_Rush.SelectedTab = Tab_Section_Updates;  // Set tab to Updates
            else if    (sender == Rush_Section_About) TabControl_Rush.SelectedTab = Tab_Section_About;    // Set tab to About
            ((SectionButton)sender).SelectedSection = true;
            Container_Rush.Title = ((SectionButton)sender).SectionText;
        }

        /// <summary>
        /// Defines what browser should be used by sender.
        /// </summary>
        private void Button_Browse_Click(object sender, EventArgs e) {
            if (sender == Button_ModsDirectory) {
                // Browse for mods directory
                string browseMods = RequestPath.ModsDirectory();

                if (browseMods != string.Empty) {
                    Properties.Settings.Default.Path_ModsDirectory = TextBox_ModsDirectory.Text = browseMods;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_GameDirectory) {
                // Browse for game executables
                string gameExecutable = RequestPath.GameExecutable();

                if (gameExecutable != string.Empty) {
                    Properties.Settings.Default.Path_GameExecutable = TextBox_GameDirectory.Text = gameExecutable;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_EmulatorExecutable) {
                // Browse for emulator executables
                string emulatorExecutable = RequestPath.EmulatorExecutable();

                if (emulatorExecutable != string.Empty) {
                    Properties.Settings.Default.Path_EmulatorDirectory = TextBox_EmulatorExecutable.Text = emulatorExecutable;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_SaveData) {
                // Browse for save data
                string saveData = RequestPath.SaveData();

                if (saveData != string.Empty) {
                    Properties.Settings.Default.Path_SaveData = TextBox_SaveData.Text = saveData;
                    Properties.Settings.Default.Save();
                }
            }
            RefreshLists();
        }

        /// <summary>
        /// Checks if a button has been clicked on the WindowsColourPicker user control.
        /// </summary>
        private void WindowsColourPicker_AccentColour_ButtonClick(object sender, EventArgs e) {
            Properties.Settings.Default.General_AutoColour = false;
            Properties.Settings.Default.General_AccentColour = ((Button)sender).BackColor;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Perform actions when the selected tab is changed.
        /// </summary>
        private void TabControl_Rush_SelectedIndexChanged(object sender, EventArgs e) {
            TabControl_Rush.SelectedTab.VerticalScroll.Value = 0;
            RefreshColumnSize();

            if ((string)TabControl_Rush.SelectedTab.Tag == "HideControls") {
                if (Panel_MainControls.Visible) {
                    Panel_MainControls.Visible = false;
                    TabControl_Rush.Height += 40;
                }
            } else {
                if (!Panel_MainControls.Visible) {
                    Panel_MainControls.Visible = true;
                    TabControl_Rush.Height -= 40;
                }
            }

            // Clear mod updating UI to delist any mods that may be changed later
            if (TabControl_Rush.SelectedTab != Tab_Section_Updates) {
                ListBox_UpdateLogs.Items.Clear();
                ListView_ModUpdates.Items.Clear();
            }
        }

        /// <summary>
        /// Deserialises 'mod.ini' for each iterated mod and checks for updates.
        /// </summary>
        /// <param name="searchByMod">File path to another mod's INI to ensure it's searching for the correct mod.</param>
        private async Task CheckForModUpdates(string searchByMod) {
            if (Paths.CheckPathLegitimacy(Properties.Settings.Default.Path_ModsDirectory)) {
                ListView_ModUpdates.Items.Clear();
                ListBox_UpdateLogs.Items.Clear();
                SectionButton_CheckForModUpdates.Enabled = false; // Block controls to ensure the list isn't added to

                foreach (string mod in Directory.GetFiles(Properties.Settings.Default.Path_ModsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                    // Deserialise INI
                    string title     = INI.DeserialiseKey("Title", mod),
                           version   = INI.DeserialiseKey("Version", mod),
                           metadata  = INI.DeserialiseKey("Metadata", mod),
                           data      = INI.DeserialiseKey("Data", mod),
                           versionDL = string.Empty;

                    if (metadata.Length != 0) {
                        string config = await Client.RequestString(metadata);
                        if (config.Length != 0) {
                            string[] configLines = config.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                            // Manually deserialise downloaded string
                            foreach (string metadataLine in configLines) {
                                string metadataEntry = string.Empty;
                                if (metadataLine.StartsWith("Version")) {
                                    metadataEntry = metadataLine.Substring(metadataLine.IndexOf("=") + 2);
                                    metadataEntry = metadataEntry.Remove(metadataEntry.Length - 1);
                                    versionDL = metadataEntry;
                                }
                                if (metadataLine.StartsWith("Data")) {
                                    metadataEntry = metadataLine.Substring(metadataLine.IndexOf("=") + 2);
                                    metadataEntry = metadataEntry.Remove(metadataEntry.Length - 1);
                                    if (data != metadataEntry) data = metadataEntry;
                                }
                            }

                            if (versionDL != version) {
                                // Mod needs updating - add to list
                                ListViewItem update = new ListViewItem(new[] { title, string.Empty, mod });
                                ListView_ModUpdates.Items.Add(update);

                                // If the paths are identical, then the mod shall be checked
                                update.Checked = mod == searchByMod;
                            }
                        }
                    }
                }

                //Feedback
                SectionButton_CheckForModUpdates.Enabled = true;

                // If no mods are added to the updates list - presumably, all of them are up to date
                if (ListView_ModUpdates.Items.Count == 0)
                    UnifyMessenger.UnifyMessage.ShowDialog("All mods are up to date! Check back later...",
                                                           "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                // Browse for mods directory
                string browseMods = RequestPath.ModsDirectory();

                if (browseMods != string.Empty) {
                    Properties.Settings.Default.Path_ModsDirectory = TextBox_ModsDirectory.Text = browseMods;
                    Properties.Settings.Default.Save();
                    await CheckForModUpdates(string.Empty); // Check all mods in the mods list for updates with new path
                } else return;
            }
        }

        /// <summary>
        /// Updates settings if sender's check state is changed.
        /// </summary>
        private void CheckBox_Settings_CheckedChanged(object sender, EventArgs e) {
            if (sender == CheckBox_AutoColour) {
                if (CheckBox_AutoColour.Checked) {
                    int RegistryColour = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null);
                    Properties.Settings.Default.General_AccentColour = Color.FromArgb(RegistryColour);
                }
                Properties.Settings.Default.General_AutoColour = ((CheckBox)sender).Checked;
            } else if (sender == CheckBox_HighContrastText)   Properties.Settings.Default.General_HighContrastText     = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_UninstallOnLaunch)    Properties.Settings.Default.General_AutoUninstall        = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_DebugMode)            Properties.Settings.Default.General_Debug                = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_SaveFileRedirection)  Properties.Settings.Default.General_SaveFileRedirection  = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_CheckUpdatesOnLaunch) Properties.Settings.Default.General_CheckUpdatesOnLaunch = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_LaunchEmulator)       Properties.Settings.Default.General_LaunchEmulator       = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is being hovered over.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseEnter(object sender, EventArgs e) => Section_Appearance_ColourPicker.BackColor = Color.FromArgb(48, 48, 51);

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is no longer being hovered over.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseLeave(object sender, EventArgs e) => Section_Appearance_ColourPicker.BackColor = Color.FromArgb(42, 42, 45);

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is clicked.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseDown(object sender, MouseEventArgs e) => Section_Appearance_ColourPicker.BackColor = Color.FromArgb(58, 58, 61);

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is released.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseUp(object sender, MouseEventArgs e) {
            Section_Appearance_ColourPicker.BackColor = Color.FromArgb(48, 48, 51);
            Section_Appearance_ColourPicker_Click(sender, e);
        }

        /// <summary>
        /// Opens the colour picker to define a new accent colour.
        /// </summary>
        private void Section_Appearance_ColourPicker_Click(object sender, EventArgs e) {
            ColorDialog accentPicker = new ColorDialog {
                FullOpen = true,
                Color = Properties.Settings.Default.General_AccentColour
            };

            if (accentPicker.ShowDialog() == DialogResult.OK) {
                Properties.Settings.Default.General_AutoColour = false;
                Properties.Settings.Default.General_AccentColour = accentPicker.Color;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Resets the accent colour to default.
        /// </summary>
        private void Button_ColourPicker_Default_Click(object sender, EventArgs e) {
            Properties.Settings.Default.General_AutoColour = false;
            Properties.Settings.Default.General_AccentColour = Color.FromArgb(186, 0, 0);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Clears the debug log.
        /// </summary>
        private void SectionButton_ClearLog_Click(object sender, EventArgs e) => ListBox_Debug.Items.Clear();

        /// <summary>
        /// Create right-click context menu for the lists at runtime.
        /// Only called when an item is selected.
        /// </summary>
        private void ListView_MouseClick(object sender, MouseEventArgs e) {
            // Perform if the function was called with the right mouse button
            if (e.Button == MouseButtons.Right) {
                // Create the dark context menu
                ContextMenuDark menuDark = new ContextMenuDark();

                // Get item by mouse focus
                if (sender == ListView_ModsList) {
                    if (ListView_ModsList.FocusedItem.Bounds.Contains(e.Location)) {
                        menuDark.Items.Clear();
                        menuDark.Items.AddRange(new ToolStripMenuItem[] {
                            new ToolStripMenuItem("Mod Information",   Properties.Resources.InformationSymbol_16x, ContextMenu_ModMenu_Items_Click),
                            new ToolStripMenuItem("Open Folder",       Properties.Resources.Open_grey_16x,         ContextMenu_ModMenu_Items_Click),
                            new ToolStripMenuItem("Check for Updates", Properties.Resources.Update_4,              ContextMenu_ModMenu_Items_Click)
                        });
                        menuDark.Items.Add(new ToolStripSeparator());
                        menuDark.Items.AddRange(new ToolStripMenuItem[] {
                            new ToolStripMenuItem("Create Mod",        Properties.Resources.NewFileCollection_16x, ContextMenu_ModMenu_Items_Click),
                            new ToolStripMenuItem("Edit Mod",          Properties.Resources.EditPage_16x,          ContextMenu_ModMenu_Items_Click),
                            new ToolStripMenuItem("Delete Mod",        Properties.Resources.Cancel_16x,            ContextMenu_ModMenu_Items_Click)
                        });
                        menuDark.Show(Cursor.Position);
                    }
                } else if (sender == ListView_PatchesList) {
                    if (ListView_PatchesList.FocusedItem.Bounds.Contains(e.Location)) {
                        menuDark.Items.Clear();
                        menuDark.Items.AddRange(new ToolStripMenuItem[] {
                            new ToolStripMenuItem("Patch Information", Properties.Resources.InformationSymbol_16x, ContextMenu_PatchMenu_Items_Click),
                            new ToolStripMenuItem("Open Folder",       Properties.Resources.Open_grey_16x,         ContextMenu_PatchMenu_Items_Click)
                        });
                        menuDark.Items.Add(new ToolStripSeparator());
                        menuDark.Items.AddRange(new ToolStripMenuItem[] {
                            new ToolStripMenuItem("Create Patch",      Properties.Resources.NewPatchPackage_16x,   ContextMenu_PatchMenu_Items_Click),
                            new ToolStripMenuItem("Edit Patch",        Properties.Resources.EditPage_16x,          ContextMenu_PatchMenu_Items_Click),
                            new ToolStripMenuItem("Delete Patch",      Properties.Resources.Cancel_16x,            ContextMenu_PatchMenu_Items_Click)
                        });
                        menuDark.Show(Cursor.Position);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the right-click menu items by index.
        /// </summary>
        private async void ContextMenu_ModMenu_Items_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).ToString()) {
                case "Mod Information":
                    new ModInfo(ListView_ModsList.FocusedItem.SubItems[6].Text).ShowDialog();
                    break;
                case "Open Folder":
                    try { Process.Start(Path.GetDirectoryName(ListView_ModsList.FocusedItem.SubItems[6].Text)); }
                    catch {
                        UnifyMessenger.UnifyMessage.ShowDialog("Unable to locate the selected mod. It may have been removed from the mods directory. Removing from list...",
                                                               "Unable to find mod...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshLists(); // Refresh mods list
                    }
                    break;
                case "Check for Updates":
                    // Navigate to Updates section
                    SectionButton_DeselectAll();
                    Rush_Section_Updates.SelectedSection = true;
                    TabControl_Rush.SelectedTab = Tab_Section_Updates;
                    TabControl_Rush.SelectedTab.ScrollControlIntoView(Panel_Updates_UICleanSpace);

                    // Check for updates...
                    await CheckForModUpdates(ListView_ModsList.FocusedItem.SubItems[6].Text);
                    break;
                case "Create Mod":
                    // Launch Mod Creator
                    new ModCreator(string.Empty, false).ShowDialog();
                    RefreshLists(); // Refresh on Mod Creator exit
                    break;
                case "Edit Mod":
                    // Launch Mod Editor
                    new ModCreator(ListView_ModsList.FocusedItem.SubItems[6].Text, true).ShowDialog();
                    RefreshLists(); // Refresh on Mod Editor exit
                    break;
                case "Delete Mod":
                    try {
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Are you sure you want to delete {ListView_ModsList.FocusedItem.Text}?",
                                                                                           $"Deleting {ListView_ModsList.FocusedItem.Text}...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) {
                            string modPath = Path.GetDirectoryName(ListView_ModsList.FocusedItem.SubItems[6].Text);
                            DirectoryInfo modData = new DirectoryInfo(modPath);

                            if (Directory.Exists(modPath)) {
                                foreach (FileInfo file in modData.GetFiles()) file.Delete();
                                foreach (DirectoryInfo directory in modData.GetDirectories()) directory.Delete(true);
                                Directory.Delete(modPath);
                                RefreshLists();
                            }
                        }
                    } catch {
                        UnifyMessenger.UnifyMessage.ShowDialog("Failed to delete the data for the requested mod.",
                                                               "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        /// <summary>
        /// Event handler for the right-click menu items by index.
        /// </summary>
        private void ContextMenu_PatchMenu_Items_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).ToString()) {
                case "Patch Information":
                    string patch = ListView_PatchesList.FocusedItem.SubItems[5].Text,
                           blurb = Lua.DeserialiseParameter("Blurb", patch, true), // Deserialise 'Blurb' parameter
                           description = Lua.DeserialiseParameter("Description", patch, true), // Deserialise 'Description' parameter
                           patchInfo = string.Empty;

                    if (description == string.Empty) patchInfo = blurb.Replace(@"\n", " ");
                    else if  (blurb == string.Empty) patchInfo = description.Replace(@"\n", Environment.NewLine);
                    else                             patchInfo = description.Replace(@"\n", Environment.NewLine);

                    UnifyMessenger.UnifyMessage.ShowDialog(patchInfo, ListView_PatchesList.FocusedItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "Open Folder":
                    try { Process.Start(Program.Patches); }
                    catch {
                        UnifyMessenger.UnifyMessage.ShowDialog("The patches directory is missing... Please restart Sonic '06 Mod Manager.",
                                                               "Unable to locate patches...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshLists(); // Refresh patches list
                    }
                    break;
                case "Create Patch":
                    // Launch Patch Creator
                    new PatchCreator(string.Empty, false).ShowDialog();
                    RefreshLists(); // Refresh on Patch Creator exit
                    break;
                case "Edit Patch":
                    try { Process.Start(ListView_PatchesList.FocusedItem.SubItems[5].Text); }
                    catch {
                        UnifyMessenger.UnifyMessage.ShowDialog("The selected patch is missing...",
                                                               "Unable to locate patch...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    RefreshLists(); // Refresh patches list
                    break;
                case "Delete Patch":
                    try {
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Are you sure you want to delete {ListView_PatchesList.FocusedItem.Text}?",
                                                                                           $"Deleting {ListView_PatchesList.FocusedItem.Text}...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) {
                            string patchPath = ListView_PatchesList.FocusedItem.SubItems[5].Text;

                            if (File.Exists(patchPath)) {
                                File.Delete(patchPath);
                                RefreshLists();
                            }
                        }
                    } catch {
                        UnifyMessenger.UnifyMessage.ShowDialog("Failed to delete the data for the requested patch.",
                                                               "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        /// <summary>
        /// Renders the items with the default software renderer.
        /// </summary>
        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }

        /// <summary>
        /// Draws the column header in the presented design language by sender.
        /// </summary>
        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            // Draws the column background colour
            Color theme = Color.FromArgb(35, 35, 38);
            e.Graphics.FillRectangle(new SolidBrush(theme), e.Bounds);
            Point point = new Point(0, 4);
            point.X = e.Bounds.X;

            // Draws the column header by sender
            ColumnHeader column = ((ListView)sender).Columns[e.ColumnIndex];
            e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
            point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ((ListView)sender).Font).Width / 2;
            TextRenderer.DrawText(e.Graphics, column.Text, ((ListView)sender).Font, point, ((ListView)sender).ForeColor);
        }

        /// <summary>
        /// Deserialises 'mod.ini' for each mod in the mods directory.
        /// </summary>
        private void DeserialiseMods() {
            if (Directory.Exists(Properties.Settings.Default.Path_ModsDirectory)) {
                ListView_ModsList.Items.Clear(); // Clears the mods list
                Button_Mods_UpperPriority.Enabled = Button_Mods_DownerPriority.Enabled = false; // Disable priority buttons to prevent index errors
                foreach (string mod in Directory.GetFiles(Properties.Settings.Default.Path_ModsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                    try {
                        string title = INI.DeserialiseKey("Title", mod); // Deserialise 'Title' key

                        if (title != string.Empty) {
                            // Add mod to list, getting information from its mod.ini file
                            ListViewItem config = new ListViewItem(new[] {
                                                      title,
                                                      INI.DeserialiseKey("Version", mod),             // Deserialise 'Version' key
                                                      INI.DeserialiseKey("Author", mod),              // Deserialise 'Author' key
                                                      INI.DeserialiseKey("Platform", mod),            // Deserialise 'Platform' key
                                                      Literal.Bool(INI.DeserialiseKey("Merge", mod)), // Translates 'True' to 'Yes' and 'False' to 'No'
                                                      string.Empty,
                                                      mod
                                                  });
                            ListView_ModsList.Items.Add(config);
                        }
                    } catch { }
                }
            }
        }

        /// <summary>
        /// Deserialises all patches in the patches directory.
        /// </summary>
        private void DeserialisePatches() {
            if (Directory.Exists(Program.Patches)) {
                ListView_PatchesList.Items.Clear(); // Clears the patches list
                Button_Patches_UpperPriority.Enabled = Button_Patches_DownerPriority.Enabled = false; // Disable priority buttons to prevent index errors
                foreach (string patch in Directory.GetFiles(Program.Patches, "*.mlua", SearchOption.AllDirectories)) {
                    try {
                        string title       = Lua.DeserialiseParameter("Title", patch, true),       // Deserialise 'Title' parameter
                               blurb       = Lua.DeserialiseParameter("Blurb", patch, true),       // Deserialise 'Blurb' parameter
                               description = Lua.DeserialiseParameter("Description", patch, true), // Deserialise 'Description' parameter
                               patchInfo   = string.Empty;

                        if (description == string.Empty) patchInfo = blurb.Replace(@"\n", " ");
                        else if  (blurb == string.Empty) patchInfo = description.Replace(@"\n", Environment.NewLine);
                        else                             patchInfo = blurb.Replace(@"\n", " ");

                        if (title != string.Empty) {
                            // Add patch to list, getting information from its *.mlua file
                            ListViewItem script = new ListViewItem(new[] {
                                                      title,
                                                      Lua.DeserialiseParameter("Author", patch, true),   // Deserialise 'Author' parameter
                                                      Lua.DeserialiseParameter("Platform", patch, true), // Deserialise 'Platform' parameter
                                                      patchInfo,
                                                      string.Empty,
                                                      patch
                                                  });
                            ListView_PatchesList.Items.Add(script);
                        }
                    } catch { }
                }
            }
        }

        /// <summary>
        /// Restore checked items from 'mods.ini'
        /// </summary>
        private void CheckDeserialisedMods() {
            string line = string.Empty; // Declare empty string for StreamReader
            string modConfig = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "mods.ini");

            if (File.Exists(modConfig)) {
                // Read 'mods.ini'
                using (StreamReader mods = new StreamReader(modConfig)) {
                    mods.ReadLine(); // Skip [Main] line
                    while ((line = mods.ReadLine()) != null) { // Read all lines until null
                        try {
                            if (Directory.Exists(Path.Combine(Properties.Settings.Default.Path_ModsDirectory, line)))
                                // If the item exists, shift it to the top of the list and check it
                                for (int i = 0; i <= ListView_ModsList.Items.Count - 1; i++)
                                    if (Paths.GetContainingFolder(ListView_ModsList.Items[i].SubItems[6].Text) == line)
                                    {
                                        // Store original list item before shifting it in the list
                                        ListViewItem shiftItem = ListView_ModsList.Items[i];

                                        // Remove the mod already in the mods list
                                        ListView_ModsList.Items.RemoveAt(i);

                                        // Insert the mod stored previously
                                        ListView_ModsList.Items.Insert(0, shiftItem).Checked = true;
                                        break;
                                    }
                        } catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Restore checked items from 'patches.ini'
        /// </summary>
        private void CheckDeserialisedPatches() {
            string line = string.Empty; // Declare empty string for StreamReader
            string patchConfig = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "patches.ini");

            if (File.Exists(patchConfig)) {
                // Read 'patches.ini'
                using (StreamReader patches = new StreamReader(patchConfig)) {
                    patches.ReadLine(); // Skip [Main] line
                    while ((line = patches.ReadLine()) != null) { // Read all lines until null
                        try {
                            if (File.Exists(Path.Combine(Program.Patches, line))) {
                                // If the item exists, shift it to the top of the list and check it
                                for (int i = 0; i <= ListView_PatchesList.Items.Count - 1; i++)
                                    if (Path.GetFileName(ListView_PatchesList.Items[i].SubItems[5].Text) == line)
                                    {
                                        // Store original list item before shifting it in the list
                                        ListViewItem shiftItem = ListView_PatchesList.Items[i];

                                        // Remove the mod already in the mods list
                                        ListView_PatchesList.Items.RemoveAt(i);

                                        // Insert the mod stored previously
                                        ListView_PatchesList.Items.Insert(0, shiftItem).Checked = true;
                                        break;
                                    }
                            }
                        } catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Save checked items from the mods and patches lists respectively.
        /// </summary>
        private void SaveChecks() {
            //Save the names of the selected mods and the indexes of the selected patches to their appropriate INI files
            string modCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "mods.ini");
            string patchCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "patches.ini");

            // Create 'mods.ini'
            using (StreamWriter sw = File.CreateText(modCheckList))
                sw.WriteLine("[Main]"); // [Main] specification

            // Writes the list in reverse so the mods list writes it in it's preferred order
            for (int i = ListView_ModsList.Items.Count - 1; i >= 0; i--) {
                if (ListView_ModsList.Items[i].Checked) // Get checked state
                    using (StreamWriter sw = File.AppendText(modCheckList))
                        // Write mod name by folder name to prevent duplicate mod names conflicting
                        sw.WriteLine(Path.GetFileName(Path.GetDirectoryName(ListView_ModsList.Items[i].SubItems[6].Text)));
            }

            // Create 'patches.ini'
            try {
                using (StreamWriter sw = File.CreateText(patchCheckList))
                    sw.WriteLine("[Main]"); // [Main] specification

                // Writes in reverse so the patches list writes it in it's preferred order
                for (int i = ListView_PatchesList.Items.Count - 1; i >= 0; i--) {
                    if (ListView_PatchesList.Items[i].Checked) // Get checked state
                        using (StreamWriter sw = File.AppendText(patchCheckList))
                            // Write patch name by file name to prevent duplicate patch names conflicting
                            sw.WriteLine(Path.GetFileName(ListView_PatchesList.Items[i].SubItems[5].Text));
                }
            } catch { }
        }

        /// <summary>
        /// Redirect save data from a mod to the user-specified save location.
        /// </summary>
        private void RedirectSaves(string mod, string name) {
            string saveLocation = Properties.Settings.Default.Path_SaveData; // Stores Save Data location in string for ease of use

            // Deserialise 'Save' key
            if (INI.DeserialiseKey("Save", mod).Contains("savedata")) {
                if (File.Exists(saveLocation)) {
                    // Feedback
                    Label_Status.Text = $"Redirecting save file for {name}...";
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Save] Redirecting save file for {name}...");

                    if (Literal.System(Properties.Settings.Default.Path_GameExecutable) == "Xbox 360") {
                        try {
                            // If the backup directory doesn't exist, create it
                            if (!Directory.Exists($"{Path.GetDirectoryName(saveLocation)}_back")) 
                                Directory.CreateDirectory($"{Path.GetDirectoryName(saveLocation)}_back");

                                // Copy original save to backup directory
                                DirectoryInfo backupSave = new DirectoryInfo(Path.GetDirectoryName(saveLocation));
                                foreach (FileInfo fi in backupSave.GetFiles())
                                    fi.CopyTo(Path.Combine($"{Path.GetDirectoryName(saveLocation)}_back", fi.Name), true);

                                // Copy mod's save to the save data location
                                File.Copy(Path.Combine(Path.GetDirectoryName(mod), "savedata.360"), saveLocation, true);
                        } catch { ModEngine.skipped.Add($"► {name} (save redirect failed because the save was not targeted for the Xbox 360)"); }
                    } else if (Literal.System(Properties.Settings.Default.Path_GameExecutable) == "PlayStation 3") {
                        try {
                            if (File.Exists(Path.Combine(Path.GetDirectoryName(mod), "savedata.ps3")) && Directory.Exists(Path.GetDirectoryName(saveLocation))) {
                                // If the backup save data doesn't exist, create it
                                if (!File.Exists($"{saveLocation}_back"))
                                    File.Move(saveLocation, $"{saveLocation}_back");

                                // Copy mod's save to the save data location
                                File.Copy(Path.Combine(Path.GetDirectoryName(mod), "savedata.ps3"), saveLocation, true);
                            }
                        } catch { ModEngine.skipped.Add($"► {name} (save redirect failed because the save was not targeted for the PlayStation 3)"); }
                    }
                } else ModEngine.skipped.Add($"► {name} (save redirect failed because no save data was specified)");
            } else return;
        }

        /// <summary>
        /// Simutaneously uninstall everything...
        /// </summary>
        private void UninstallThread() {
            Label_Status.Text = "Removing modified game data...";
            try {
                ModEngine.UninstallMods(); // Uninstalls all mods.
                ModEngine.UninstallCustomFilesystem(ListView_ModsList.Items); // Uninstalls user-made filesystems.
                ModEngine.UninstallSaves(ListView_ModsList.Items); // Removes redirected save data. 
            } catch (Exception ex) {
                UnifyMessenger.UnifyMessage.ShowDialog($"Failed to uninstall modified game data...\n\n{ex}",
                                                       "Uninstall failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Label_Status.Text = "Ready.";
        }

        /// <summary>
        /// Launches Xenia or RPCS3 depending on the selected game executable.
        /// </summary>
        private void LaunchEmulator(string emulator) {
            List<string> parameters = new List<string>();

            if (File.Exists(Properties.Settings.Default.Path_GameExecutable)) parameters.Add($"\"{Properties.Settings.Default.Path_GameExecutable}\"");
            else { // If the game directory is invalid, prompt the user to select a new one
                string gameExecutable = RequestPath.GameExecutable();

                if (gameExecutable != string.Empty) {
                    Properties.Settings.Default.Path_GameExecutable = TextBox_GameDirectory.Text = gameExecutable;
                    Properties.Settings.Default.Save();
                    LaunchEmulator(Literal.Emulator(Properties.Settings.Default.Path_GameExecutable)); // Perform task again with specified emulator
                } else return;
            }

            parameters.AddRange(Properties.Settings.Default.Emulator_Arguments.Split(' '));

            if (Properties.Settings.Default.Path_EmulatorDirectory == string.Empty ||
                !File.Exists(Properties.Settings.Default.Path_EmulatorDirectory)) { // If the emulator is empty/doesn't exist, prompt the user to select one
                    string emulatorExecutable = RequestPath.EmulatorExecutable();

                    if (emulatorExecutable != string.Empty) {
                        Properties.Settings.Default.Path_EmulatorDirectory = TextBox_EmulatorExecutable.Text = emulatorExecutable;
                        Properties.Settings.Default.Save();
                        LaunchEmulator(Literal.Emulator(Properties.Settings.Default.Path_GameExecutable)); // Perform task again with specified emulator
                    } else return;
            } else {
                if (emulator == "Xenia") {
                    // Xenia parameter setup
                    if (ComboBox_API.SelectedIndex != 2) {
                        if (ComboBox_API.SelectedIndex == 0) {
                            parameters.Add("--gpu=d3d12"); // Use DirectX 12
                            if (CheckBox_Xenia_ForceRTV.Checked)     parameters.Add("--d3d12_edram_rov=false"); // Force Render Target Views
                            if (CheckBox_Xenia_2xResolution.Checked) parameters.Add("--d3d12_resolution_scale=2"); // 2x Resolution
                        } else
                            parameters.Add("--gpu=vulkan"); // Use Vulkan

                        if (!CheckBox_Xenia_VerticalSync.Checked) parameters.Add("--vsync=false"); // V-Sync
                        if (CheckBox_Xenia_Gamma.Checked)         parameters.Add("--kernel_display_gamma_type=2"); // Enable Gamma
                        if (CheckBox_Xenia_Fullscreen.Checked)    parameters.Add("--fullscreen"); // Launch in Fullscreen
                        if (!CheckBox_Xenia_DiscordRPC.Checked)   parameters.Add("--discord=false"); // Discord Rich Presence
                        parameters.Add($"--user_language={Properties.Settings.Default.Emulator_UserLanguage + 1}");
                    }
                }

                ProcessStartInfo xeniaProc = new ProcessStartInfo() {
                    FileName = Properties.Settings.Default.Path_EmulatorDirectory,

                    // Ensure emulator directory is the working dir - prevents 'xenia.log' and save data being in the wrong locations
                    WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.Path_EmulatorDirectory),

                    // Join all parameters for arguments
                    Arguments = string.Join(" ", parameters.ToArray())
                };

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Emulator] Launched {emulator}...");
                Process emulatorProc = Process.Start(xeniaProc); // Launch the emulator
                Label_Status.Text = "Waiting for emulator exit call...";
                emulatorProc.WaitForExit(); // Halt usage of Sonic '06 Mod Manager to prevent the user from breaking stuff in the background
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Emulator] {emulator} session ended...");

                // Uninstall mods after emulator quits
                if (Properties.Settings.Default.General_AutoUninstall) UninstallThread();
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                               private void Ugh(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) { UnifyMessenger.UnifyMessage.ShowDialog("This source code is a huge mess... I can't wait for the next rewrite.", "Ugh", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }

        /// <summary>
        /// Opens the requested location by sender.
        /// </summary>
        private void Button_Open_Click(object sender, EventArgs e) {
            try {
                string location = string.Empty;
                if (sender == Button_Open_ModsDirectory)           location = Properties.Settings.Default.Path_ModsDirectory; // Mods Directory
                else if (sender == Button_Open_GameDirectory)      location = Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable); // Game Directory
                else if (sender == Button_Open_EmulatorExecutable) location = Properties.Settings.Default.Path_EmulatorDirectory; // Xenia
                else if (sender == Button_Open_SaveData)           location = Path.GetDirectoryName(Properties.Settings.Default.Path_SaveData); // Save Data Directory
                Process.Start(location); // Launch requested location
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog("The requested location was invalid or unspecified. Ensure the box is populated.",
                                                       "Unable to load...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save checked items at their specified locations in the list.
        /// </summary>
        private void SectionButton_SaveChecks_Click(object sender, EventArgs e) {
            SaveChecks(); // Save checked items
            RefreshLists(); // Refresh mods list
        }

        /// <summary>
        /// Sets the item check state depending on the sender.
        /// </summary>
        private void Button_Selection_Click(object sender, EventArgs e) {
            // Mods List
            if      (sender == Button_Mods_SelectAll) ListView_ModsList.Items.Cast<ListViewItem>().All(i => i.Checked = true); // Select All
            else if (sender == Button_Mods_DeselectAll) { // Deselect All
                foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = false;
                ListView_ModsList.SelectedItems.Clear();
            }

            // Patches List
            else if (sender == Button_Patches_SelectAll) ListView_PatchesList.Items.Cast<ListViewItem>().All(i => i.Checked = true); // Select All
            else if (sender == Button_Patches_DeselectAll) { // Deselect All
                foreach (ListViewItem item in ListView_PatchesList.Items) item.Checked = false;
                ListView_PatchesList.SelectedItems.Clear();
            }
        }

        /// <summary>
        /// Switches between Top to Bottom or Bottom to Top priority.
        /// </summary>
        private void Button_Priority_Click(object sender, EventArgs e) {
            if (sender == Button_Mods_Priority) Properties.Settings.Default.General_Mods_Priority = !Properties.Settings.Default.General_Mods_Priority;
            else if (sender == Button_Patches_Priority) Properties.Settings.Default.General_Patches_Priority = !Properties.Settings.Default.General_Patches_Priority;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Perform actions if user selects an item in the content list.
        /// </summary>
        private void ListView_ContentList_SelectedIndexChanged(object sender, EventArgs e) {
            ListView list = (ListView)sender;
            Button upperPriorityIterator  = new Button(),
                   downerPriorityIterator = new Button();

            // Get the buttons to enable/disable
            if (sender == ListView_ModsList) {
                upperPriorityIterator = Button_Mods_UpperPriority;
                downerPriorityIterator = Button_Mods_DownerPriority;
            }
            else if (sender == ListView_PatchesList) {
                upperPriorityIterator = Button_Patches_UpperPriority;
                downerPriorityIterator = Button_Patches_DownerPriority;
            }

            // Enables/disables the Upper Priority button depending on if a checkbox is selected
            upperPriorityIterator.Enabled = list.SelectedItems.Count > 0 && list.SelectedItems[0].Index > 0;

            // Enables/disables the Downer Priority button depending on if a checkbox is selected
            downerPriorityIterator.Enabled = list.SelectedItems.Count > 0 && list.SelectedItems[0].Index < list.Items.Count - 1;
        }

        /// <summary>
        /// Resets Sonic '06 Mod Manager.
        /// </summary>
        private void LinkLabel_Reset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("This will clear all of the settings for Sonic '06 Mod Manager. Are you sure you want to continue?",
                                                                               "Sonic '06 Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes) {
                Program.Reset();
                Application.Restart();
            }
        }

        /// <summary>
        /// Update Sonic '06 Mod Manager via requested server.
        /// </summary>
        private void UpdateVersion(bool useBackupServer) {
            // Set controls enabled and visibility state
            SectionButton_CheckForSoftwareUpdates.Visible = CheckBox_CheckUpdatesOnLaunch.Enabled = false;
            TabControl_Rush.SelectedTab.VerticalScroll.Value = 0;
            ProgressBar_SoftwareUpdate.Visible = true;

            try {
                // If SEGA Carnival is offline, use GitHub
                Uri serverUri = new Uri(Properties.Resources.DataURI_GitHub);
                if (useBackupServer) serverUri = new Uri(Properties.Resources.DataURI_SEGACarnival);

                using (WebClient client = new WebClient()) {
                    client.DownloadProgressChanged += (s, clientEventArgs) => { ProgressBar_SoftwareUpdate.Value = clientEventArgs.ProgressPercentage; };
                    client.DownloadFileAsync(serverUri, $"{Application.ExecutablePath}.pak"); // Download archive from update servers
                    client.DownloadFileCompleted += (s, clientEventArgs) => {
                        using (ZipArchive archive = new ZipArchive(new MemoryStream(File.ReadAllBytes($"{Application.ExecutablePath}.pak")))) {
                            // Extract and overwrite all with ZIP contents
                            ZIP.ExtractToDirectory(archive, Application.StartupPath, true);

                            // Overwrite 'Sonic '06 Mod Manager.exe' with the newly extracted build
                            File.Replace($"{Application.ExecutablePath}.new", Application.ExecutablePath, $"{Application.ExecutablePath}.bak");

                            UnifyMessenger.UnifyMessage.ShowDialog("Update complete! Restarting Sonic '06 Mod Manager...",
                                                                   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Erase ZIP file
                            File.Delete($"{Application.ExecutablePath}.pak");
                            Application.Restart();
                        }
                    };
                }
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to update Sonic '06 Mod Manager...\n{ex}"); // Write exception to debug log
                UnifyMessenger.UnifyMessage.ShowDialog("Failed to update Sonic '06 Mod Manager. Reverting back to the previous version...",
                                                       "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset update button for future checking
                SectionButton_CheckForSoftwareUpdates.Visible = CheckBox_CheckUpdatesOnLaunch.Enabled = true;
                ProgressBar_SoftwareUpdate.Visible = false;
                SectionButton_CheckForSoftwareUpdates.SectionText = "Check for updates";
                SectionButton_CheckForSoftwareUpdates.Refresh();

                // Replace 'Sonic '06 Mod Manager.exe' with the backup created earlier
                if (File.Exists($"{Application.ExecutablePath}.bak")) {
                    File.Replace($"{Application.ExecutablePath}.bak", Application.ExecutablePath, $"{Application.ExecutablePath}.err");
                    File.Delete($"{Application.ExecutablePath}.err");
                }
            }
        }

        /// <summary>
        /// Update community patches via requested server.
        /// </summary>
        private async Task UpdatePatches() {
            // Set controls enabled and visibility state
            SectionButton_FetchPatches.Enabled = false;
            TabControl_Rush.SelectedTab.ScrollControlIntoView(Panel_Updates_UICleanSpace);

            try {
                //Clone Sonic '06 Mod Manager Patches repository from GitHub
                string getRepoContents = await Client.RequestString(Properties.Resources.PatchURI_GitHub);
                string[] repoLinks = getRepoContents.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < repoLinks.Length; i++)
                    using (WebClient client = new WebClient())
                        if (repoLinks[i] != string.Empty)
                            // Download scripts from update servers
                            client.DownloadFileAsync(new Uri(repoLinks[i]), Path.Combine(Program.Patches, Path.GetFileName(repoLinks[i])));

                //Feedback
                UnifyMessenger.UnifyMessage.ShowDialog("The latest patches have been downloaded!",
                                                       "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to update patches...\n{ex}"); // Write exception to debug log
                UnifyMessenger.UnifyMessage.ShowDialog("Failed to update patches...",
                                                       "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Refreshes the lists.
        /// </summary>
        private void SectionButton_Refresh_Click(object sender, EventArgs e) => RefreshLists();

        /// <summary>
        /// Enables/disables the Update Mods button depending on how many items are checked in the Mod Updates list.
        /// </summary>
        private void ListView_ModUpdates_ItemChecked(object sender, ItemCheckedEventArgs e)
            => SectionButton_UpdateMods.Enabled = ListView_ModUpdates.CheckedItems.Count > 0;

        /// <summary>
        /// Code for all SectionButton controls in the Updates section.
        /// </summary>
        private async void SectionButton_Updates_Click(object sender, EventArgs e) {
            // Check for software updates is clicked
            if (sender == SectionButton_CheckForSoftwareUpdates) {
                // Check for updates via GitHub
                CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                Properties.Settings.Default.General_LastSoftwareUpdate = DateTime.Now.Ticks;
                if (((SectionButton)sender).SectionText == "Fetch the latest version") UpdateVersion(_useBackupServer); // Update if prompted
                Properties.Settings.Default.Save();

            // Check for mod updates is clicked
            } else if (sender == SectionButton_CheckForModUpdates) {
                Properties.Settings.Default.General_LastModUpdate = DateTime.Now.Ticks;
                await CheckForModUpdates(string.Empty);
                Properties.Settings.Default.Save();
            }

            // Fetch latest patches is clicked
            else if (sender == SectionButton_FetchPatches) {
                Properties.Settings.Default.General_LastPatchUpdate = DateTime.Now.Ticks;

                DialogResult deleteOrNah = UnifyMessenger.UnifyMessage.ShowDialog("Do you want to delete all existing patches?\n\n" +
                                                                                  "" +
                                                                                  "Clicking No will overwrite existing patches with the latest instead.",
                                                                                  "Delete existing patches?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (deleteOrNah != DialogResult.Cancel)
                {
                    // Answer: delete
                    if (deleteOrNah == DialogResult.Yes)
                    {
                        // Literally just nuke the whole folder
                        foreach (string file in Directory.GetFiles(Program.Patches, "*.mlua", SearchOption.TopDirectoryOnly))
                        {
                            File.Delete(file);
                        }
                    }

                    await UpdatePatches();
                }

                Properties.Settings.Default.Save();

                // Reset update button for future checking
                SectionButton_FetchPatches.Enabled = true;
                SectionButton_FetchPatches.Refresh();
                RefreshLists();
            }

            // Update mods is clicked
            else if (sender == SectionButton_UpdateMods) {
                ListBox_UpdateLogs.Items.Clear(); // Clear update logs
                ListView_ModUpdates.SelectedItems.Clear(); // Clear selected

                // Item is checked in the mod updates list
                foreach (ListViewItem mod in ListView_ModUpdates.CheckedItems) {
                    // Block controls
                    SectionButton_UpdateMods.Enabled =
                    SectionButton_CheckForModUpdates.Enabled = false;

                    // Feedback
                    ListBox_UpdateLogs.Items.Add($"Updating {mod.Text}...");

                    try {
                        // Update the mod using deserialised keys from the 'mod.ini'
                        await UpdateMod(mod.SubItems[2].Text,
                                        mod.Text,
                                        INI.DeserialiseKey("Version",  mod.SubItems[2].Text),
                                        INI.DeserialiseKey("Metadata", mod.SubItems[2].Text),
                                        INI.DeserialiseKey("Data",     mod.SubItems[2].Text),
                                        mod
                                        );
                    } catch (Exception ex) {
                        // Update failed - prints error to debug console and is subsequently ignored
                        ListBox_UpdateLogs.Items.Add($"Failed to update {mod.Text}...");
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to update {mod.Text}\n{ex}");
                    }

                    // Feedback
                    SectionButton_CheckForModUpdates.Enabled = true;
                    if (ListView_ModUpdates.CheckedItems.Count == ListView_ModUpdates.Items.Count) SectionButton_UpdateMods.Enabled = false;
                    else SectionButton_UpdateMods.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Updates the selected mod using parameters from it's 'mod.ini'
        /// </summary>
        /// <param name="mod">Location of 'mod.ini'</param>
        /// <param name="title">Name of the mod</param>
        /// <param name="version">Current version of the mod</param>
        /// <param name="metadata">Network location of 'mod.ini'</param>
        /// <param name="data">Network location of new data</param>
        private async Task UpdateMod(string mod, string title, string version, string metadata, string data, ListViewItem listViewItem) {
            string archive = Path.GetTempFileName(), // Creates a temporary name for the mod update package
                   versionDL = string.Empty; // Defined string to contain the latest version number

            // Download latest 'mod.ini' from update server (in case any changes have been made)
            try { metadata = await Client.RequestString(metadata); }
            catch { return; }

            if (metadata.Length != 0) {
                string[] splitMetadata = metadata.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Manually deserialise split lines
                foreach (string line in splitMetadata) {
                    string entryValue = string.Empty;
                    if (line.StartsWith("Version")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        versionDL = entryValue;
                    }
                    if (line.StartsWith("Data")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        if (data != entryValue) data = entryValue; // Overwrite data location if changed
                    }
                }
            }

            // If the version number differs...
            if (versionDL != version) {
                using (WebClient client = new WebClient()) {
                    client.DownloadProgressChanged += (s, dlevent) => { ProgressBar_ModUpdate.Value = dlevent.ProgressPercentage; };
                    client.DownloadFileAsync(new Uri(data), archive); // Download archive data
                    client.DownloadFileCompleted += (s, dlevent) => {
                        // Get header info for verification
                        byte[] bytes = File.ReadAllBytes(archive).Take(2).ToArray();
                        string hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");

                        // Erase temporary update data
                        DirectoryInfo extractData = new DirectoryInfo(mod);
                        try {
                            if (Directory.Exists(mod)) {
                                foreach (FileInfo file in extractData.GetFiles())
                                    file.Delete();
                                foreach (DirectoryInfo directory in extractData.GetDirectories())
                                    directory.Delete(true);
                            }
                            Directory.Delete(mod);
                        } catch { }

                        // Determine what should be used to extract the downloaded archive
                        if (hexString == "50 4B") // ZIP header
                            using (ZipArchive zip = new ZipArchive(new MemoryStream(File.ReadAllBytes(archive))))
                                ZIP.ExtractToDirectory(zip, Properties.Settings.Default.Path_ModsDirectory, true);
                        else
                            // Try 7-Zip - if it doesn't work, try WinRAR before throwing exception
                            ZIP.InstallFromCustomArchive(archive, Properties.Settings.Default.Path_ModsDirectory);

                        // Delete archive regardless of extracted state
                        File.Delete(archive);

                        // Feedback
                        ListBox_UpdateLogs.Items.Add($"{title} was updated successfully...");
                        ListView_ModUpdates.Items.Remove(listViewItem);
                        ProgressBar_ModUpdate.Value = 0;
                    };
                }
            }
        }

        /// <summary>
        /// Column resizing algorithm.
        /// </summary>
        private void SizeLastColumn(ListView lv) {
            if (lv == ListView_ModsList) {
                int x = lv.Width / 15 == 0 ? 1 : lv.Width / 15;
                lv.Columns[0].Width = (x * 7) - 7;
                lv.Columns[1].Width = (x * 2) - 20;
                lv.Columns[2].Width = (x * 2) + 20;
                lv.Columns[3].Width = (x * 2) + 10;
                lv.Columns[4].Width = (x * 2) - 9;
                lv.Columns[5].Width = x * 100;
            } else if (lv == ListView_PatchesList) {
                int x = lv.Width / 15 == 0 ? 1 : lv.Width / 15;
                lv.Columns[0].Width = (x * 5) - 5;
                lv.Columns[1].Width = (x * 2) + 20;
                lv.Columns[3].Width = (x * 2) + 10;
                lv.Columns[3].Width = (x * 6) - 30;
                lv.Columns[4].Width = x * 100;
            } else if (lv == ListView_ModUpdates) {
                int x = lv.Width / 15 == 0 ? 1 : lv.Width / 15;
                lv.Columns[0].Width = Panel_ModUpdateBackdrop.Width;
                lv.Columns[1].Width = x * 100;
            }
            lv.Refresh();
        }

        /// <summary>
        /// Resizes all columns.
        /// </summary>
        private void RefreshColumnSize() {
            SizeLastColumn(ListView_ModsList);
            SizeLastColumn(ListView_PatchesList);
            SizeLastColumn(ListView_ModUpdates);
        }

        /// <summary>
        /// Refreshes the column size on the Resize event.
        /// </summary>
        private void RushInterface_Resize(object sender, EventArgs e) {
            TabControl_Rush.SelectedTab.VerticalScroll.Value = 0;
            RefreshColumnSize();
        }

        /// <summary>
        /// Installs/uninstalls the GameBanana registry key.
        /// </summary>
        private void LinkLabel_1ClickURLHandler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                RegistryKey sonic06mmKey = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}\\shell\\open\\command", true);

                // Install handler
                if (((LinkLabel)sender).Text == "Install 1-Click URL Handler" || ((LinkLabel)sender).Text == "Reinstall 1-Click URL Handler") {
                    sonic06mmKey = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}", true);
                    if (sonic06mmKey == null)
                        sonic06mmKey = Registry.CurrentUser.CreateSubKey($"Software\\Classes\\{protocol}");
                    sonic06mmKey.SetValue(string.Empty, "URL:Sonic '06 Mod Manager");
                    sonic06mmKey.SetValue("URL Protocol", string.Empty);
                    RegistryKey prevkey = sonic06mmKey;
                    sonic06mmKey = sonic06mmKey.OpenSubKey("shell", true);
                    if (sonic06mmKey == null)
                        sonic06mmKey = prevkey.CreateSubKey("shell");
                    prevkey = sonic06mmKey;
                    sonic06mmKey = sonic06mmKey.OpenSubKey("open", true);
                    if (sonic06mmKey == null)
                        sonic06mmKey = prevkey.CreateSubKey("open");
                    prevkey = sonic06mmKey;
                    sonic06mmKey = sonic06mmKey.OpenSubKey("command", true);
                    if (sonic06mmKey == null)
                        sonic06mmKey = prevkey.CreateSubKey("command");

                    sonic06mmKey.SetValue(string.Empty, $"\"{Application.ExecutablePath}\" \"-banana\" \"%1\"");
                    sonic06mmKey.Close();

                // Uninstall handler
                } else if (((LinkLabel)sender).Text == "Uninstall 1-Click URL Handler") {
                    sonic06mmKey = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}", true);
                    sonic06mmKey.SetValue(string.Empty, string.Empty);
                    sonic06mmKey = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}\\shell\\open\\command", true);
                    sonic06mmKey.SetValue(string.Empty, string.Empty);
                    sonic06mmKey.Close();
                }

                CheckRegistry();
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog("Failed to modify the Windows Registry...",
                                                       "Registry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Checks to see if the GameBanana 1-Click registry key is installed.
        /// </summary>
        private void CheckRegistry() {
            RegistryKey key         = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}", false), // Open the Sonic '06 Mod Manager protocol key
                        getLocation = Registry.CurrentUser.OpenSubKey($"Software\\Classes\\{protocol}\\shell\\open\\command", false);

            string command = $"\"{Application.ExecutablePath}\" \"-banana\" \"%1\"";

            // If the key does not exist, keep the checkbox unchecked.
            if (key == null || getLocation.GetValue(null).ToString() == string.Empty)
                LinkLabel_1ClickURLHandler.Text = "Install 1-Click URL Handler";
            else {
                if (getLocation.GetValue(null).ToString() != command)
                    LinkLabel_1ClickURLHandler.Text = "Reinstall 1-Click URL Handler";
                else if (getLocation.GetValue(null).ToString() == command)
                    LinkLabel_1ClickURLHandler.Text = "Uninstall 1-Click URL Handler";
            }
        }

        /// <summary>
        /// Tells the list view how it should handle the DragDrop event.
        /// </summary>
        private void ListView_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

        /// <summary>
        /// Tells the list view what to do with the dropped item.
        /// </summary>
        private void ListView_DragDrop(object sender, DragEventArgs e) {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Mods DragDrop event
            if (sender == ListView_ModsList) {
                if (droppedFiles.Length == 1) {
                    // File is an archive
                    if (Path.GetExtension(droppedFiles[0]) == ".zip" || Path.GetExtension(droppedFiles[0]) == ".7z" || Path.GetExtension(droppedFiles[0]) == ".rar") { 
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Do you want to add '{Path.GetFileName(droppedFiles[0])}' as a mod?",
                                                                                           "Add mod?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) {
                            byte[] bytes = File.ReadAllBytes(droppedFiles[0]).Take(2).ToArray();
                            string hexString = BitConverter.ToString(bytes);

                            if (hexString == "50-4B") ZIP.InstallFromZip(droppedFiles[0], Properties.Settings.Default.Path_ModsDirectory);
                            else ZIP.InstallFromCustomArchive(droppedFiles[0], Properties.Settings.Default.Path_ModsDirectory);

                            RefreshLists();
                        }
                    }
                } else {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Do you want to add all {droppedFiles.Length} items as mods?",
                                                                                       "Add mods?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmation == DialogResult.Yes) {
                        Label_Status.Text = $"Extracting {droppedFiles.Length} mods...";

                        // Install
                        foreach (string item in droppedFiles) {
                            byte[] bytes = File.ReadAllBytes(item).Take(2).ToArray();
                            string hexString = BitConverter.ToString(bytes);

                            // File is an archive
                            if (Path.GetExtension(item) == ".zip" || Path.GetExtension(item) == ".7z" || Path.GetExtension(item) == ".rar")
                                if (hexString == "50-4B") ZIP.InstallFromZip(item, Properties.Settings.Default.Path_ModsDirectory);
                                else ZIP.InstallFromCustomArchive(item, Properties.Settings.Default.Path_ModsDirectory);

                            RefreshLists(); // Refresh on completion
                        }

                        Label_Status.Text = "Ready.";
                    }
                }

            // Patches DragDrop event
            } else if (sender == ListView_PatchesList) {
                if (droppedFiles.Length == 1) {
                    // File is an archive
                    if (Path.GetExtension(droppedFiles[0]) == ".zip" || Path.GetExtension(droppedFiles[0]) == ".7z" || Path.GetExtension(droppedFiles[0]) == ".rar") {
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Do you want to add '{Path.GetFileName(droppedFiles[0])}' as a patch?",
                                                                                           "Add patch?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) {
                            byte[] bytes = File.ReadAllBytes(droppedFiles[0]).Take(2).ToArray();
                            string hexString = BitConverter.ToString(bytes);

                            if (hexString == "50-4B") ZIP.InstallFromZip(droppedFiles[0], Program.Patches);
                            else ZIP.InstallFromCustomArchive(droppedFiles[0], Program.Patches);

                            RefreshLists();
                        }

                        // File is a MLUA
                    } else if (Path.GetExtension(droppedFiles[0]) == ".mlua") {
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Do you want to add '{Path.GetFileName(droppedFiles[0])}' as a patch?",
                                                                                           "Add patch?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) {
                            File.Copy(droppedFiles[0], Path.Combine(Program.Patches, Path.GetFileName(droppedFiles[0])));
                            RefreshLists();
                        }
                    }
                } else {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Do you want to add all {droppedFiles.Length} items as patches?",
                                                                                       "Add patches?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmation == DialogResult.Yes) {
                        Label_Status.Text = $"Adding {droppedFiles.Length} patches...";

                        // Install
                        foreach (string item in droppedFiles) {
                            byte[] bytes = File.ReadAllBytes(item).Take(2).ToArray();
                            string hexString = BitConverter.ToString(bytes);

                            // File is an archive
                            if (Path.GetExtension(item) == ".zip" || Path.GetExtension(item) == ".7z" || Path.GetExtension(item) == ".rar")
                                if (hexString == "50-4B") ZIP.InstallFromZip(item, Program.Patches);
                                else ZIP.InstallFromCustomArchive(item, Program.Patches);

                            // File is a MLUA
                            else if (Path.GetExtension(item) == ".mlua")
                                File.Copy(item, Path.Combine(Program.Patches, Path.GetFileName(item)));

                            RefreshLists(); // Refresh on completion
                        }

                        Label_Status.Text = "Ready.";
                    }
                }
            }
        }

        /// <summary>
        /// Event on index change for tweaks.
        /// </summary>
        private void ComboBox_Tweaks_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender == ComboBox_Renderer) {
                if ((Properties.Settings.Default.Tweak_Renderer = ((ComboBox)sender).SelectedIndex) != 0) {
                    // Set enabled state for controls
                    ComboBox_AntiAliasing.Enabled = Button_AntiAliasing_Default.Enabled = CheckBox_ForceMSAA.Enabled = false;

                    // Set controls to GrayText
                    Label_AntiAliasing.ForeColor =
                    Label_Description_AntiAliasing.ForeColor =
                    Label_Description_ForceMSAA.ForeColor =
                    SystemColors.GrayText;
                } else {
                    if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) == "Xenia") {
                        // Set enabled state for controls
                        ComboBox_AntiAliasing.Enabled = Button_AntiAliasing_Default.Enabled = CheckBox_ForceMSAA.Enabled = true;

                        // Set controls to Control
                        Label_AntiAliasing.ForeColor = SystemColors.Control;

                        // Set controls to GrayText
                        Label_Description_AntiAliasing.ForeColor =
                        Label_Description_ForceMSAA.ForeColor =
                        SystemColors.ControlDark;
                    }
                }
            }

            else if (sender == ComboBox_Reflections) Properties.Settings.Default.Tweak_Reflections  = ((ComboBox)sender).SelectedIndex;

            else if (sender == ComboBox_AntiAliasing) {
                if ((Properties.Settings.Default.Tweak_AntiAliasing = ((ComboBox)sender).SelectedIndex) != 1) {
                    CheckBox_ForceMSAA.Enabled = false; // Set enabled state for Force MSAA
                    Label_Description_ForceMSAA.ForeColor = SystemColors.GrayText; // Set description to GrayText
                } else {
                    CheckBox_ForceMSAA.Enabled = true; // Set enabled state for Force MSAA
                    Label_Description_ForceMSAA.ForeColor = SystemColors.ControlDark; // Set description to ControlDark
                }
            }

            else if (sender == ComboBox_CameraType) {
                // Save Camera Type ahead of tweaking other values
                Properties.Settings.Default.Tweak_CameraType = ((ComboBox)sender).SelectedIndex;

                // Anything but Retail
                if (ComboBox_CameraType.SelectedIndex != 0) {

                    // Tokyo Game Show
                    if (ComboBox_CameraType.SelectedIndex == 1) {

                        // Xbox 360 supports FOV changes
                        if (Literal.System(Properties.Settings.Default.Path_GameExecutable) == "Xbox 360") {
                            NumericUpDown_CameraDistance.Value = 350;
                            NumericUpDown_CameraHeight.Value = 32.5m;
                            NumericUpDown_FieldOfView.Value = 0.929929435253143m;

                        // PlayStation 3 does not support FOV changes
                        } else {
                            NumericUpDown_CameraDistance.Value = 450;
                            NumericUpDown_CameraHeight.Value = 32.5m;
                            NumericUpDown_FieldOfView.Value = 0.785398185253143m;
                        }

                    // Electronic Entertainment Expo
                    } else if (ComboBox_CameraType.SelectedIndex == 2) {
                        NumericUpDown_CameraDistance.Value = 550;
                        NumericUpDown_CameraHeight.Value = 70;
                        NumericUpDown_FieldOfView.Value = 0.785398185253143m;
                    }

                // Retail
                } else {
                    NumericUpDown_CameraDistance.Value = 650;
                    NumericUpDown_CameraHeight.Value = 70;
                    NumericUpDown_FieldOfView.Value = 0.785398185253143m;
                }
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event on value change for tweaks.
        /// </summary>
        private void NumericUpDown_Tweaks_ValueChanged(object sender, EventArgs e) {
            if      (sender == NumericUpDown_CameraDistance) Properties.Settings.Default.Tweak_CameraDistance = ((NumericUpDown)sender).Value;
            else if   (sender == NumericUpDown_CameraHeight) Properties.Settings.Default.Tweak_CameraHeight   = ((NumericUpDown)sender).Value;
            else if    (sender == NumericUpDown_FieldOfView) Properties.Settings.Default.Tweak_FieldOfView    = ((NumericUpDown)sender).Value;
            else if (sender == NumericUpDown_AmyHammerRange) Properties.Settings.Default.Tweak_AmyHammerRange = ((NumericUpDown)sender).Value;
            else if (sender == NumericUpDown_BeginWithRings) Properties.Settings.Default.Tweak_BeginWithRings = ((NumericUpDown)sender).Value;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event on default button press for tweaks.
        /// </summary>
        private void Button_Tweaks_Default(object sender, EventArgs e) {
            // Check if the system is Xbox 360
            bool isXbox360 = Literal.System(Properties.Settings.Default.Path_GameExecutable) == "Xbox 360";

            // Reset Renderer
            if (sender == Button_Renderer_Default)
                Properties.Settings.Default.Tweak_Renderer = 0;

            // Reset Reflections
            else if (sender == Button_Reflections_Default)
                Properties.Settings.Default.Tweak_Reflections = 1;

            // Reset Anti-Aliasing
            else if (sender == Button_AntiAliasing_Default)
                Properties.Settings.Default.Tweak_AntiAliasing = 1;

            // Reset Camera Type
            else if (sender == Button_CameraType_Default)
            {
                Properties.Settings.Default.Tweak_CameraType = 0;
                Properties.Settings.Default.Tweak_CameraDistance = 650;
                Properties.Settings.Default.Tweak_CameraHeight = 70;
                Properties.Settings.Default.Tweak_FieldOfView = 0.785398185253143m;
            }

            // Reset Camera Distance
            else if (sender == Button_CameraDistance_Default)
            {
                if (ComboBox_CameraType.SelectedIndex == 0) // Retail
                    Properties.Settings.Default.Tweak_CameraDistance = 650;
                else if (ComboBox_CameraType.SelectedIndex == 1) // Tokyo Game Show
                    if (isXbox360) // Xbox 360 supports FOV changes
                        Properties.Settings.Default.Tweak_CameraDistance = 350;
                    else // PlayStation 3 does not support FOV changes
                        Properties.Settings.Default.Tweak_CameraDistance = 450;
                else if (ComboBox_CameraType.SelectedIndex == 2) // Electronic Entertainment Expo
                    Properties.Settings.Default.Tweak_CameraDistance = 550;
            }

            // Reset Camera Height
            else if (sender == Button_CameraHeight_Default)
            {
                if (ComboBox_CameraType.SelectedIndex == 1) // Tokyo Game Show
                    Properties.Settings.Default.Tweak_CameraHeight = 32.5m;
                else // Retail
                    Properties.Settings.Default.Tweak_CameraHeight = 70;
            }

            // Reset Field of View
            else if (sender == Button_FieldOfView_Default)
            {
                if (ComboBox_CameraType.SelectedIndex == 1) // Tokyo Game Show
                    if (isXbox360) // Xbox 360 supports FOV changes
                        Properties.Settings.Default.Tweak_FieldOfView = 0.929929435253143m;
                    else // PlayStation 3 does not support FOV changes
                        Properties.Settings.Default.Tweak_FieldOfView = 0.785398185253143m;
                else // Retail
                    Properties.Settings.Default.Tweak_FieldOfView = 0.785398185253143m;
            }

            // Reset Amy's Hammer Range
            else if (sender == Button_AmyHammerRange_Default)
                Properties.Settings.Default.Tweak_AmyHammerRange = 50;

            // Reset Begin with Rings
            else if (sender == Button_BeginWithRings_Default)
                Properties.Settings.Default.Tweak_BeginWithRings = 0;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event on checkbox tick for tweaks.
        /// </summary>
        private void CheckBox_Tweaks_CheckedChanged(object sender, EventArgs e) {
            if             (sender == CheckBox_ForceMSAA) Properties.Settings.Default.Tweak_ForceMSAA        = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_TailsFlightLimit) Properties.Settings.Default.Tweak_TailsFlightLimit = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Redirects the user to a webpage about the selected contributor.
        /// </summary>
        private void Link_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if    (sender == LinkLabel_HyperPolygon64) Process.Start("https://github.com/HyperPolygon64");
            else if    (sender == LinkLabel_Knuxfan24) Process.Start("https://github.com/Knuxfan24");
            else if   (sender == LinkLabel_GerbilSoft) Process.Start("https://github.com/GerbilSoft");
            else if (sender == LinkLabel_SuperSonic16) Process.Start("https://github.com/thesupersonic16");
            else if (sender == LinkLabel_Contributors_Radfordhound || sender == LinkLabel_Testers_Radfordhound)
                Process.Start("https://github.com/Radfordhound");
            else if    (sender == LinkLabel_Microsoft) Process.Start("https://github.com/Microsoft");
            else if   (sender == LinkLabel_AssemblyPP) Process.Start("https://gamebanana.com/tools/6738");
            else if (sender == LinkLabel_SEGACarnival) Process.Start("https://www.segacarnival.com/forum/index.php");
            else if    (sender == LinkLabel_sharu6262) Process.Start("https://twitter.com/sharu6262");
            else if    (sender == LinkLabel_Melpontro) Process.Start("https://www.youtube.com/user/Melpontro");
            else if     (sender == LinkLabel_Velcomia) Process.Start("https://twitter.com/Velcomia");
        }

        /// <summary>
        /// Launches Sonic '06 without installing any mods, patches or tweaks.
        /// Keeps the game intact, whether it have mods installed or not.
        /// </summary>
        private void SectionButton_LaunchGame_Click(object sender, EventArgs e) {
            // Launch the emulator of choice
            LaunchEmulator(Literal.Emulator(Properties.Settings.Default.Path_GameExecutable));

            // Reset status label once emulator process has ended
            Label_Status.Text = $"Ready.";
        }

        /// <summary>
        /// Create right-click context menu for the lists at runtime.
        /// Called when mouse clicked in the ListView whitespace.
        /// </summary>
        private void ListView_MouseUp(object sender, MouseEventArgs e) {
            // Perform if the function was called with the right mouse button
            if (e.Button == MouseButtons.Right) {
                // Create the dark context menu
                ContextMenuDark menuDark = new ContextMenuDark();

                // Get item by mouse focus
                if (sender == ListView_ModsList) {
                    if (ListView_ModsList.SelectedItems.Count == 0) {
                        menuDark.Items.Clear();
                        menuDark.Items.Add(new ToolStripMenuItem("Create Mod", Properties.Resources.NewFileCollection_16x, ContextMenu_ModMenu_Items_Click));
                        menuDark.Show(Cursor.Position);
                    }
                } else if (sender == ListView_PatchesList) {
                    if (ListView_PatchesList.SelectedItems.Count == 0) {
                        menuDark.Items.Clear();
                        menuDark.Items.Add(new ToolStripMenuItem("Create Patch", Properties.Resources.NewPatchPackage_16x, ContextMenu_PatchMenu_Items_Click));
                        menuDark.Show(Cursor.Position);
                    }
                }
            }
        }

        /// <summary>
        /// Dumps/loads user settings and selected items.
        /// </summary>
        private void LinkLabel_Debug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (sender == LinkLabel_Snapshot_Create) Snapshot.Create(ListView_ModsList, ListView_PatchesList);
            else if (sender == LinkLabel_Snapshot_Load) Snapshot.Load(ListView_ModsList, ListView_PatchesList);
            else if (sender == LinkLabel_Troubleshoot_Mod) {
                string troubleshooter = Troubleshoot.Mod();

                if (troubleshooter != string.Empty)
                    UnifyMessenger.UnifyMessage.ShowDialog(troubleshooter, "Troubleshoot complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefreshLists();
        }

        /// <summary>
        /// Changed index selection events for the Emulator section.
        /// </summary>
        private void ComboBox_Emulator_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender == ComboBox_API) {
                if ((Properties.Settings.Default.Emulator_API = ((ComboBox)sender).SelectedIndex) != 0) {
                    CheckBox_Xenia_ForceRTV.Enabled = CheckBox_Xenia_2xResolution.Enabled = false;
                    Label_Description_ForceRTV.ForeColor = Label_Description_2xResolution.ForeColor = SystemColors.GrayText;
                } else {
                    CheckBox_Xenia_ForceRTV.Enabled = CheckBox_Xenia_2xResolution.Enabled = true;
                    Label_Description_ForceRTV.ForeColor = Label_Description_2xResolution.ForeColor = SystemColors.ControlDark;
                }
            }
            else if (sender == ComboBox_UserLanguage) Properties.Settings.Default.Emulator_UserLanguage = ((ComboBox)sender).SelectedIndex;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Save arguments on text changed.
        /// </summary>
        private void TextBox_Arguments_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.Emulator_Arguments = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Save Xenia parameter settings.
        /// </summary>
        private void CheckBox_Xenia_CheckedChanged(object sender, EventArgs e) {
            if          (sender == CheckBox_Xenia_ForceRTV) Properties.Settings.Default.Emulator_ForceRTV         = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_Xenia_2xResolution) Properties.Settings.Default.Emulator_DoubleResolution = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_Xenia_VerticalSync) Properties.Settings.Default.Emulator_VerticalSync     = ((CheckBox)sender).Checked;
            else if        (sender == CheckBox_Xenia_Gamma) Properties.Settings.Default.Emulator_Gamma            = ((CheckBox)sender).Checked;
            else if   (sender == CheckBox_Xenia_Fullscreen) Properties.Settings.Default.Emulator_Fullscreen       = ((CheckBox)sender).Checked;
            else if   (sender == CheckBox_Xenia_DiscordRPC) Properties.Settings.Default.Emulator_DiscordRPC       = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Opens the context menu for the debug box.
        /// </summary>
        private void ListBox_Debug_MouseUp(object sender, MouseEventArgs e) {
            // Perform if the function was called with the right mouse button
            if (e.Button == MouseButtons.Right) {
                if (ListBox_Debug.Items.Count != 0) {
                    // Create the dark context menu
                    ContextMenuDark menuDark = new ContextMenuDark();
                    menuDark.Items.Clear();
                    menuDark.Items.AddRange(new ToolStripMenuItem[] {
                                            new ToolStripMenuItem("Copy Debug Log", Properties.Resources.Copy_16x,      ContextMenu_Debug_Items_Click),
                                            new ToolStripMenuItem("Save Debug Log", Properties.Resources.Save_grey_16x, ContextMenu_Debug_Items_Click)
                                        });
                    menuDark.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Event handler for the right-click menu items by index.
        /// </summary>
        private void ContextMenu_Debug_Items_Click(object sender, EventArgs e) {
            string log = $"Sonic '06 Mod Manager ({Program.VersionNumber})\n\n{string.Join(string.Empty, ListBox_Debug.Items.OfType<object>().Select(item => item.ToString()).ToArray())}";

            switch (((ToolStripMenuItem)sender).ToString()) {
                case "Copy Debug Log":
                    Clipboard.SetText(log);
                    break;
                case "Save Debug Log":
                    // Save location for debug log
                    SaveFileDialog debug = new SaveFileDialog() {
                        Title = "Save debug log...",
                        Filter = "Log files (*.log)|*.log",
                        FileName = $"sonic06mm-debug-{DateTime.Now:ddMMyy}.log"
                    };

                    if (debug.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(debug.FileName, log);
                    break;
            }
        }

        /// <summary>
        /// Checked event handler for Allow Mod Stacking.
        /// </summary>
        private void CheckBox_AllowModStacking_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.Debug_AllowModStacking = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.General_AutoUninstall && ((CheckBox)sender).Checked)
                UnifyMessenger.UnifyMessage.ShowDialog("Please disable 'Uninstall mods automatically' to use mod stacking correctly.", "Property Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Begins the mod installation process by calling the required methods.
        /// </summary>
        private void SectionButton_InstallMods_MouseClick(object sender, MouseEventArgs e)
        {
            // If button is left-clicked, install content
            if (e.Button == MouseButtons.Left) InstallThread(true, true);

            // If button is right-clicked, show a context menu
            else if (e.Button == MouseButtons.Right) {
                // Create the dark context menu
                ContextMenuDark menuDark = new ContextMenuDark();

                /* Menu items that need to have local events assigned */

                // Uninstalls everything
                ToolStripMenuItem uninstallThread = new ToolStripMenuItem() {
                    Text = "Uninstall content",
                    Image = Properties.Resources.Refresh_grey_16x,
                };

                // Installs mods without patches
                ToolStripMenuItem installWithoutPatches = new ToolStripMenuItem() {
                    Text = "Install mods without patches",
                    Image = Properties.Resources.ConfigurationFile_16x,
                };

                // Installs patches without mods
                ToolStripMenuItem installWithoutMods = new ToolStripMenuItem() {
                    Text = "Install patches without mods",
                    Image = Properties.Resources.PatchPackage_16x,
                };

                // Subscribe to events
                uninstallThread.Click += (uSender, uArgs) => UninstallThread();
                installWithoutPatches.Click += (uSender, uArgs) => InstallThread(true, false);
                installWithoutMods.Click += (uSender, uArgs) => InstallThread(false, true);

                // Add menu items to control
                menuDark.Items.Clear();
                menuDark.Items.AddRange(new ToolStripMenuItem[] {
                    uninstallThread
                });
                menuDark.Items.Add(new ToolStripSeparator());
                menuDark.Items.AddRange(new ToolStripMenuItem[] {
                    installWithoutPatches,
                    installWithoutMods
                });
                menuDark.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Installs content...
        /// </summary>
        private void InstallThread(bool mods, bool patches)
        {
            if (Paths.CheckFileLegitimacy(Properties.Settings.Default.Path_GameExecutable))
            {
                if (!File.Exists($"{Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable)}\\xenon\\sound\\voice\\j\\wvo01_w00_tl.xma"))
                {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("This copy of the game does not appear to be a complete extraction! " +
                                                                                        "This may cause issues with mod and patch installation." +
                                                                                        "\n\nPlease refer to the Mod Manager Wiki's First Time Setup page for information." +
                                                                                        "\nDo you wish to try and continue?",
                                                                                        "Incomplete Dump", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.No)
                    {
                        return;
                    }
                }
                ModEngine.skipped.Clear(); // Clear the skipped list
                SaveChecks(); // Save checked items
                RefreshLists();

                // Uninstall everything before installing more mods
                if (!Properties.Settings.Default.Debug_AllowModStacking) UninstallThread();

                if (_isPathInvalid) {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("Ensure that your mods directory is outside your game directory! " +
                                                                                        "This may cause issues with mod and patch installation.",
                                                                                        "Invalid directory", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Cancel) {
                        SectionButton_DeselectAll();
                        Rush_Section_Settings.SelectedSection = true;
                        TabControl_Rush.SelectedTab = Tab_Section_Settings;
                        return;
                    }
                }

                if (mods) {
                    // Top to Bottom Priority
                    if (Properties.Settings.Default.General_Mods_Priority) {
                        for (int i = ListView_ModsList.Items.Count - 1; i >= 0; i--)
                            if (ListView_ModsList.Items[i].Checked)
                            {
                                ListViewItem @mod = ListView_ModsList.Items[i];

                                Label_Status.Text = $"Installing {@mod.Text}...";

                                // Install the specified mod
                            #if !DEBUG
                                try {
                            #endif
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Mod] Installing {@mod.Text}...");
                                    ModEngine.InstallMods(@mod.SubItems[6].Text, @mod.Text);
                            #if !DEBUG
                                } catch (Exception ex) {
                                    UnifyMessenger.UnifyMessage.ShowDialog($"An error occurred whilst installing your mods...\n\n{ex}",
                                                                            "Installation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            #endif

                                if (Properties.Settings.Default.General_SaveFileRedirection)
                                    // Redirect save data from the specified mod
                                    RedirectSaves(@mod.SubItems[6].Text, @mod.Text);
                            }

                    // Bottom to Top Priority
                    } else {
                        foreach (ListViewItem mod in ListView_ModsList.CheckedItems)
                            if (mod.Checked)
                            {
                                Label_Status.Text = $"Installing {mod.Text}...";

                                // Install the specified mod
                            #if !DEBUG
                                try {
                            #endif
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Mod] Installing {mod.Text}...");
                                    ModEngine.InstallMods(mod.SubItems[6].Text, mod.Text);
                            #if !DEBUG
                                } catch (Exception ex) {
                                    UnifyMessenger.UnifyMessage.ShowDialog($"An error occurred whilst installing your mods...\n\n{ex}",
                                                                            "Installation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            #endif

                                if (Properties.Settings.Default.General_SaveFileRedirection)
                                        // Redirect save data from the specified mod
                                        RedirectSaves(mod.SubItems[6].Text, mod.Text);
                            }
                    }
                }

                if (patches) {
                    if (!Program.CheckJava())
                    {
                        DialogResult javaWarning = UnifyMessenger.UnifyMessage.ShowDialog("No Java installation was found.\n" +
                                                                                          "Some patch scripts require Java to alter game logic in Lua scripts.\n" +
                                                                                          "Please install Java and restart your computer...",
                                                                                          "Java Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    TweakEngine.ApplyTweaks(this); // Begin tweak installation
                    InstallPatches(); // Begin patch installation
                }

                // Check skipped list to ensure any errors occurred
                if (ModEngine.skipped.Count != 0)
                    UnifyMessenger.UnifyMessage.ShowDialog($"Installation completed, but the following content needs revising...\n\n{string.Join("\n", ModEngine.skipped)}",
                                                            "Installation completed with warnings...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Launch the emulator of choice
                if (Properties.Settings.Default.General_LaunchEmulator)
                    LaunchEmulator(Literal.Emulator(Properties.Settings.Default.Path_GameExecutable));

                // Reset status label once emulator process has ended
                Label_Status.Text = $"Ready.";

            // No game directory set - choose a new one...
            } else {
                string browseGame = RequestPath.GameExecutable();

                if (browseGame != string.Empty) {
                    Properties.Settings.Default.Path_GameExecutable = TextBox_GameDirectory.Text = browseGame;
                    Properties.Settings.Default.Save();
                } else return;
            }
        }

        /// <summary>
        /// Begins the patch installation process.
        /// </summary>
        private void InstallPatches() {
            // Top to Bottom Priority
            if (Properties.Settings.Default.General_Patches_Priority)
                for (int i = ListView_PatchesList.Items.Count - 1; i >= 0; i--)
                {
                    ListViewItem @patch = ListView_PatchesList.Items[i];

                    if (@patch.Checked)
                    {
                        Label_Status.Text = $"Patching {@patch.Text}...";

                        // Install the specified patch
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Patch] Patching {@patch.Text}...");
                        PatchEngine.InstallPatches(@patch.SubItems[5].Text, @patch.Text);
                    }
                }

            // Bottom to Top Priority
            else
                foreach (ListViewItem patch in ListView_PatchesList.CheckedItems)
                    if (patch.Checked)
                    {
                        Label_Status.Text = $"Patching {patch.Text}...";

                        // Install the specified patch
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Patch] Patching {patch.Text}...");
                        PatchEngine.InstallPatches(patch.SubItems[5].Text, patch.Text);
                    }

            // Encrypt if decrypted EBOOT
            if (PatchEngine.decrypted && Literal.System(Properties.Settings.Default.Path_GameExecutable) == "PlayStation 3") {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Patch] Encrypted game executable...");
                PatchEngine.EncryptExecutable();
            }
        }

        /// <summary>
        /// Increases or decreases item priority in the list.
        /// </summary>
        private void Button_Priority_Iteration_MouseUp(object sender, MouseEventArgs e)
        {
            ListView list = new ListView();

            // Get the list to modify
            if (sender == Button_Mods_UpperPriority || sender == Button_Mods_DownerPriority) list = ListView_ModsList;
            else if (sender == Button_Patches_UpperPriority || sender == Button_Patches_DownerPriority) list = ListView_PatchesList;

            int selectedIndex = list.SelectedItems[0].Index; // Store the selected index
            bool check = list.SelectedItems[0].Checked;      // Check state bool
            ListViewItem shiftItem = list.SelectedItems[0];  // Store the item

            // Iterate once...
            if (e.Button == MouseButtons.Left) {
                // Iterate item in list by sender
                if (sender == Button_Mods_UpperPriority || sender == Button_Patches_UpperPriority) {
                    list.Items.RemoveAt(selectedIndex);                              // Removes the selected item
                    list.Items.Insert(selectedIndex - 1, shiftItem).Checked = check; // Insert checkbox at selectedIndex
                    list.Items[selectedIndex - 1].Selected = true;                   // Selects the recently moved checkbox
                }
                else if (sender == Button_Mods_DownerPriority || sender == Button_Patches_DownerPriority) {
                    list.Items.RemoveAt(selectedIndex);                              // Removes the selected item
                    list.Items.Insert(selectedIndex + 1, shiftItem).Checked = check; // Insert checkbox at selectedIndex
                    list.Items[selectedIndex + 1].Selected = true;                   // Selects the recently moved checkbox
                }
            }

            // Iterate fully...
            else if (e.Button == MouseButtons.Right) {
                // Iterate item in list by sender
                if (sender == Button_Mods_UpperPriority || sender == Button_Patches_UpperPriority) {
                    list.Items.RemoveAt(selectedIndex);              // Removes the selected item
                    list.Items.Insert(0, shiftItem).Checked = check; // Insert checkbox at selectedIndex
                    list.Items[0].Selected = true;                   // Selects the recently moved checkbox
                }
                else if (sender == Button_Mods_DownerPriority || sender == Button_Patches_DownerPriority) {
                    list.Items.RemoveAt(selectedIndex);                               // Removes the selected item
                    list.Items.Insert(list.Items.Count, shiftItem).Checked = check; // Insert checkbox at selectedIndex
                    list.Items[list.Items.Count - 1].Selected = true;                   // Selects the recently moved checkbox
                }
            }
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e) {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
