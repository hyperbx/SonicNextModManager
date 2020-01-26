using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Patcher;
using Ookii.Dialogs;
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

 * Copyright (c) 2020 Knuxfan24 & HyperPolygon64

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
        public static bool _debug = false;
        private bool _isPathInvalid = false;

        public RushInterface() {
            InitializeComponent(); // Designer support

            // Begin first time setup
            if (Properties.Settings.Default.FirstLaunch &&
                Properties.Settings.Default.ModsDirectory == string.Empty) new UnifySetup().ShowDialog();

            // Prevents actions being performed in UnifyEnvironment's design time.
            if (!DesignMode) {
                LoadSettings(); // Load user settings

                Label_Version.Text = Program.VersionNumber; // Sets the version string in the About section
                Properties.Settings.Default.SettingsSaving += Settings_SettingsSaving; // Subscribe to event for SettingsSaving
                TabControl_Rush.Height += 23; // Increase height on load to accommodate for lack of tabs in the section controller

                // Force splitter widths - because WinForms is dumb and ignores it at design time
                SplitContainer_ModsControls.SplitterWidth = 1;
                SplitContainer_ModUpdate.SplitterWidth = 2;
#if DEBUG
                // If the application is a debug build, force debug mode on
                Properties.Settings.Default.Debug = _debug = true;
                Properties.Settings.Default.Save();
#endif
            }
        }

        /// <summary>
        /// Performs actions on launch.
        /// </summary>
        private void RushInterface_Load(object sender, EventArgs e) {
            SaveAndRefreshList(); // Refresh mods list
            UninstallThread(); // Uninstall everything
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
            #region Restore label strings
            Label_LastSoftwareUpdate.Text = Literal.Date("Last checked", Properties.Settings.Default.LastSoftwareUpdate);
            Label_LastModUpdate.Text = Literal.Date("Last checked", Properties.Settings.Default.LastModUpdate);
            Label_LastPatchUpdate.Text = Literal.Date("Last updated", Properties.Settings.Default.LastPatchUpdate);
            #endregion

            #region Restore directories
            _isPathInvalid = false;

            TextBox_ModsDirectory.Text = Properties.Settings.Default.ModsDirectory;

            if (Properties.Settings.Default.GameDirectory != string.Empty)
                if (Literal.IsPathSubdirectory(Properties.Settings.Default.ModsDirectory, Path.GetDirectoryName(Properties.Settings.Default.GameDirectory)) ||
                    Properties.Settings.Default.ModsDirectory == Path.GetDirectoryName(Properties.Settings.Default.GameDirectory)) {

                    // If the mods directory is inside the game directory, warn the user
                    Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                    _isPathInvalid = true;
                } else
                    Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;

            TextBox_GameDirectory.Text = Properties.Settings.Default.GameDirectory;

            if (Properties.Settings.Default.ModsDirectory != string.Empty)
                if (Literal.IsPathSubdirectory(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), Properties.Settings.Default.ModsDirectory) ||
                    Path.GetDirectoryName(Properties.Settings.Default.GameDirectory) == Properties.Settings.Default.ModsDirectory) {

                    // If the mods directory is inside the game directory, warn the user
                    Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                    _isPathInvalid = true;
                } else
                    Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;

            TextBox_EmulatorExecutable.Text = Properties.Settings.Default.EmulatorDirectory;
            TextBox_SaveData.Text = Properties.Settings.Default.SaveData;
            #endregion

            #region Restore combo box states
            if (!DesignMode) ComboBox_API.SelectedIndex = Properties.Settings.Default.GraphicsAPI;
            #endregion

            #region Restore check box states
            CheckBox_AutoColour.Checked         = Properties.Settings.Default.AutoColour;
            CheckBox_HighContrastText.Checked   = Properties.Settings.Default.HighContrastText;
            CheckBox_Xenia_ForceRTV.Checked     = Properties.Settings.Default.ForceRTV;
            CheckBox_Xenia_2xResolution.Checked = Properties.Settings.Default.DoubleResolution;
            CheckBox_Xenia_VerticalSync.Checked = Properties.Settings.Default.VerticalSync;
            CheckBox_Xenia_Gamma.Checked        = Properties.Settings.Default.Gamma;
            CheckBox_Xenia_Fullscreen.Checked   = Properties.Settings.Default.Fullscreen;
            CheckBox_Xenia_DiscordRPC.Checked   = Properties.Settings.Default.DiscordRPC;

            if (CheckBox_DebugMode.Checked = Rush_Section_Debug.Visible = _debug = Properties.Settings.Default.Debug)
                Console.SetOut(new ListBoxWriter(ListBox_Debug));

            if (CheckBox_LaunchEmulator.Checked = Properties.Settings.Default.LaunchEmulator) {
                SectionButton_InstallMods.SectionText = "Install mods and launch Sonic '06";
                SectionButton_InstallMods.Refresh();
            } else {
                SectionButton_InstallMods.SectionText = "Install mods";
                SectionButton_InstallMods.Refresh();
            }

            if (CheckBox_CheckUpdatesOnLaunch.Checked = Properties.Settings.Default.CheckUpdatesOnLaunch) {
                Properties.Settings.Default.LastSoftwareUpdate = DateTime.Now.Ticks;
                try { CheckForUpdates(Properties.Resources.VersionURI_SEGACarnival, Properties.Resources.ChangelogsURI_SEGACarnival); }
                catch {
                    try {
                        CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                    } catch (Exception ex) {
                        Label_UpdaterStatus.Text = "Connection error";
                        PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;
                        RichTextBox_Changelogs.Text = $"Failed to request changelogs...\n\n{ex}";
                    }
                }
            }

            if (CheckBox_SaveFileRedirection.Checked = Properties.Settings.Default.SaveFileRedirection) {
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

            #region Set controls to HighContrastText setting
            if (Properties.Settings.Default.HighContrastText) {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.ControlText;
            } else {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.Control;
            }
            #endregion

            #region Set controls to AccentColour setting
            Button_ColourPicker_Preview.FlatAppearance.MouseOverBackColor =
            Button_ColourPicker_Preview.FlatAppearance.MouseDownBackColor =
            Rush_Section_Settings.AccentColour =
            Button_ColourPicker_Preview.BackColor =
            StatusStrip_Main.BackColor =
            Label_Status.BackColor =
            TabControl_Patches.HorizontalLineColor =
            TabControl_Patches.ActiveColor =
            Properties.Settings.Default.AccentColour;
            #endregion

            #region Set controls depending on emulator
            if (Literal.Emulator() == "Xenia") {
                // Set text colour to Control
                Label_Subtitle_Emulator_Options.ForeColor =
                Label_GraphicsAPI.ForeColor =
                SystemColors.Control;

                // Set text colour to ControlDark
                Label_Description_GraphicsAPI.ForeColor = SystemColors.ControlDark;

                // Set enabled state of controls
                CheckBox_Xenia_ForceRTV.Enabled =
                CheckBox_Xenia_2xResolution.Enabled =
                CheckBox_Xenia_VerticalSync.Enabled =
                CheckBox_Xenia_Gamma.Enabled =
                CheckBox_Xenia_Fullscreen.Enabled =
                CheckBox_Xenia_DiscordRPC.Enabled =
                ComboBox_API.Enabled =
                true;

                // Set visibility state of controls
                Label_RPCS3Warning.Visible = false;
            } else if (Literal.Emulator() == "RPCS3") {
                // Set text colour to GrayText
                Label_Subtitle_Emulator_Options.ForeColor =
                Label_Description_GraphicsAPI.ForeColor =
                Label_GraphicsAPI.ForeColor =
                SystemColors.GrayText;

                // Set enabled state of controls
                CheckBox_Xenia_ForceRTV.Enabled =
                CheckBox_Xenia_2xResolution.Enabled =
                CheckBox_Xenia_VerticalSync.Enabled =
                CheckBox_Xenia_Gamma.Enabled =
                CheckBox_Xenia_Fullscreen.Enabled =
                CheckBox_Xenia_DiscordRPC.Enabled =
                ComboBox_API.Enabled =
                false;

                // Set visibility state of controls
                Label_RPCS3Warning.Visible = true;
            }
            #endregion
        }

        /// <summary>
        /// Re-deserialises the mods, then checks them - in turn, refreshing the list.
        /// </summary>
        private void SaveAndRefreshList() {
            DeserialiseMods(); // Refresh mods list
            CheckDeserialisedMods(); // Check saved items
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

            string latestVersion = await Client.RequestString(versionURI), // Request version number
                   changelogs    = await Client.RequestString(changelogsURI);
            if (Program.VersionNumber != latestVersion) // New update available!
                if (InvokeRequired)
                    Invoke(new MethodInvoker(delegate { OnCheckForUpdates(latestVersion, changelogs); }));
                else
                    OnCheckForUpdates(latestVersion, changelogs);

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
                VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                    Description = "Please select your mods directory...",
                    UseDescriptionForTitle = true
                };

                if (browseMods.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text = browseMods.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_GameDirectory) {
                // Browse for game executables
                OpenFileDialog browseGame = new OpenFileDialog() {
                    Title = "Please select an executable for Sonic '06...",
                    Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                };

                if (browseGame.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_EmulatorExecutable) {
                // Browse for emulator executables
                OpenFileDialog browseEmulator = new OpenFileDialog() {
                    Title = $"Please select an executable for {Literal.Emulator()}...",
                    Filter = "Programs (*.exe)|*.exe"
                };

                if (browseEmulator.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.EmulatorDirectory = TextBox_EmulatorExecutable.Text = browseEmulator.FileName;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_SaveData) {
                // Browse for save data
                OpenFileDialog browseSave = new OpenFileDialog() {
                    Title = $"Please select Sonic '06 save data...",
                    Filter = "Xbox 360 Save File (SonicNextSaveData.bin)|SonicNextSaveData.bin|PlayStation 3 Save File (SYS-DATA)|SYS-DATA"
                };

                if (browseSave.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.SaveData = TextBox_SaveData.Text = browseSave.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            SaveAndRefreshList();
        }

        /// <summary>
        /// Checks if a button has been clicked on the WindowsColourPicker user control.
        /// </summary>
        private void WindowsColourPicker_AccentColour_ButtonClick(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = ((Button)sender).BackColor;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Perform actions when the selected tab is changed.
        /// </summary>
        private void TabControl_Rush_SelectedIndexChanged(object sender, EventArgs e) {
            TabControl_Rush.SelectedTab.VerticalScroll.Value = 0;
            RefreshColumnSize();

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
            if (Properties.Settings.Default.ModsDirectory != string.Empty &&
                Directory.Exists(Properties.Settings.Default.ModsDirectory)) {
                    ListView_ModUpdates.Items.Clear();
                    ListBox_UpdateLogs.Items.Clear();
                    foreach (string mod in Directory.GetFiles(Properties.Settings.Default.ModsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                        // Block controls to ensure the list isn't added to
                        SectionButton_CheckForModUpdates.Enabled = false;

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

                        //Feedback
                        SectionButton_CheckForModUpdates.Enabled = true;
                    }

                    // If no mods are added to the updates list - presumably, all of them are up to date
                    if (ListView_ModUpdates.Items.Count == 0)
                        UnifyMessenger.UnifyMessage.ShowDialog("All mods are up to date! Check back later...",
                                                                "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                // Browse for mods directory
                VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                    Description = "Please select your mods directory...",
                    UseDescriptionForTitle = true
                };

                if (browseMods.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text = browseMods.SelectedPath;
                    Properties.Settings.Default.Save();
                    await CheckForModUpdates(string.Empty); // Check all mods in the mods list for updates with new path
                }
            }
        }

        /// <summary>
        /// Updates settings if sender's check state is changed.
        /// </summary>
        private void CheckBox_Settings_CheckedChanged(object sender, EventArgs e) {
            if (sender == CheckBox_AutoColour) {
                if (CheckBox_AutoColour.Checked) {
                    int RegistryColour = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null);
                    Properties.Settings.Default.AccentColour = Color.FromArgb(RegistryColour);
                } else Properties.Settings.Default.AccentColour = Color.FromArgb(186, 0, 0);
                Properties.Settings.Default.AutoColour = ((CheckBox)sender).Checked;
            } else if (sender == CheckBox_HighContrastText)   Properties.Settings.Default.HighContrastText     = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_DebugMode)            Properties.Settings.Default.Debug                = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_SaveFileRedirection)  Properties.Settings.Default.SaveFileRedirection  = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_CheckUpdatesOnLaunch) Properties.Settings.Default.CheckUpdatesOnLaunch = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_LaunchEmulator)       Properties.Settings.Default.LaunchEmulator       = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is being hovered over.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseEnter(object sender, EventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(48, 48, 51); }

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is no longer being hovered over.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseLeave(object sender, EventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(42, 42, 45); }

        /// <summary>
        /// Changes colour of the colour picker button if the preview button is clicked.
        /// </summary>
        private void Button_ColourPicker_Preview_MouseDown(object sender, MouseEventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(58, 58, 61); }

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
                Color = Properties.Settings.Default.AccentColour
            };

            if (accentPicker.ShowDialog() == DialogResult.OK) {
                Properties.Settings.Default.AccentColour = accentPicker.Color;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Resets the accent colour to default.
        /// </summary>
        private void Button_ColourPicker_Default_Click(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = Color.FromArgb(186, 0, 0);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Clears the debug log.
        /// </summary>
        private void SectionButton_ClearLog_Click(object sender, EventArgs e) { ListBox_Debug.Items.Clear(); }

        /// <summary>
        /// Create right-click context menu for the mods list at runtime.
        /// </summary>
        private void ListView_ModsList_MouseClick(object sender, MouseEventArgs e) {
            // Perform if the function was called with the right mouse button
            if (e.Button == MouseButtons.Right)
                if (ListView_ModsList.FocusedItem.Bounds.Contains(e.Location)) { // Get item by mouse focus
                    ContextMenuDark menuDark = new ContextMenuDark();
                    ToolStripMenuItem[] items = new ToolStripMenuItem[] {
                        new ToolStripMenuItem("Mod Information",   Properties.Resources.InformationSymbol_16x, ContextMenu_ModMenu_Items_Click),
                        new ToolStripMenuItem("Open Folder",       Properties.Resources.Open_grey_16x,         ContextMenu_ModMenu_Items_Click),
                        new ToolStripMenuItem("Check for Updates", Properties.Resources.Update_4,              ContextMenu_ModMenu_Items_Click),
                        new ToolStripMenuItem("Edit Mod",          Properties.Resources.EditPage_16x,          ContextMenu_ModMenu_Items_Click),
                        new ToolStripMenuItem("Delete Mod",        Properties.Resources.Cancel_16x,            ContextMenu_ModMenu_Items_Click)
                    };
                    menuDark.Items.AddRange(items);
                    menuDark.Show(Cursor.Position);
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
                        DeserialiseMods();
                    }
                    break;
                case "Check for Updates":
                    SectionButton_DeselectAll();
                    Rush_Section_Updates.SelectedSection = true;
                    TabControl_Rush.SelectedTab = Tab_Section_Updates;
                    TabControl_Rush.SelectedTab.ScrollControlIntoView(Panel_Updates_UICleanSpace);
                    await CheckForModUpdates(ListView_ModsList.FocusedItem.SubItems[6].Text);
                    break;
                case "Edit Mod":
                    new ModCreator(ListView_ModsList.FocusedItem.SubItems[6].Text, true).ShowDialog();
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
                                DeserialiseMods();
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
            if (Directory.Exists(Properties.Settings.Default.ModsDirectory)) {
                ListView_ModsList.Items.Clear(); // Clears the mods list
                Button_UpperPriority.Enabled = Button_DownerPriority.Enabled = false; // Disable priority buttons to prevent index errors
                foreach (string mod in Directory.GetFiles(Properties.Settings.Default.ModsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                    try {
                        //Add mod to list, getting information from its mod.ini file
                        ListViewItem config = new ListViewItem(new[] {
                                                  INI.DeserialiseKey("Title", mod), // Deserialise 'Title' key
                                                  INI.DeserialiseKey("Version", mod), // Deserialise 'Version' key
                                                  INI.DeserialiseKey("Author", mod), // Deserialise 'Author' key
                                                  INI.DeserialiseKey("Platform", mod), // Deserialise 'Platform' key
                                                  Literal.Bool(INI.DeserialiseKey("Merge", mod)), // Translates 'True' to 'Yes' and 'False' to 'No'
                                                  string.Empty,
                                                  mod
                                              });
                        ListView_ModsList.Items.Add(config);
                    } catch { }
                }
            }
        }

        /// <summary>
        /// Restore checked items from 'mods.ini'
        /// </summary>
        private void CheckDeserialisedMods() {
            string line = string.Empty; // Declare empty string for StreamReader
            string modConfig = Path.Combine(Properties.Settings.Default.ModsDirectory, "mods.ini");

            if (File.Exists(modConfig)) {
                // Read 'mods.ini'
                using (StreamReader mods = new StreamReader(modConfig)) {
                    mods.ReadLine(); // Skip [Main] line
                    while ((line = mods.ReadLine()) != null) { // Read all lines until null
                        try {
                            if (Directory.Exists(Path.Combine(Properties.Settings.Default.ModsDirectory, line))) {
                                // Deserialise 'Title' key.
                                string title = INI.DeserialiseKey("Title", Path.Combine(Properties.Settings.Default.ModsDirectory, line, "mod.ini"));

                                // If the mods list contains what's on the current line...
                                if (ListView_ModsList.Items.Contains(ListView_ModsList.FindItemWithText(title))) {
                                    List<string> listItem = new List<string>();

                                    // Locate item by Title key in the mods list
                                    int index = ListView_ModsList.Items.IndexOf(ListView_ModsList.FindItemWithText(title));

                                    // Reproduce original list item before shifting it in the list
                                    foreach (ListViewItem.ListViewSubItem item in ListView_ModsList.Items[index].SubItems) listItem.Add(item.Text);
                                    ListViewItem shiftItem = new ListViewItem(listItem.ToArray());

                                    ListView_ModsList.Items.RemoveAt(index); // Remove the mod already in the mods list

                                    // Insert the mod by the name provided in 'mods.ini', given it's at least present in the list
                                    ListView_ModsList.Items.Insert(0, shiftItem).Checked = true;
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
            string modCheckList = Path.Combine(Properties.Settings.Default.ModsDirectory, "mods.ini");
            string patchCheckList = Path.Combine(Properties.Settings.Default.ModsDirectory, "patches.ini");

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

            // Soon(tm)
            //try {
            //    using (StreamWriter sw = File.CreateText(patchCheckList))
            //        sw.WriteLine("[Main]"); //Header

            //    for (int i = view_PatchesList.Items.Count - 1; i >= 0; i--) { // Writes in reverse so the mods list writes it in it's preferred order
            //        if (view_PatchesList.Items[i].Checked)
            //            using (StreamWriter sw = File.AppendText(patchCheckList))
            //                sw.WriteLine(view_PatchesList.Items[i].Text); //Mod Name
            //    }
            //} catch { }
        }

        /// <summary>
        /// Begins the mod installation process by calling the required methods.
        /// </summary>
        private void SectionButton_InstallMods_Click(object sender, EventArgs e) {
            if (Properties.Settings.Default.GameDirectory != string.Empty ||
                File.Exists(Properties.Settings.Default.GameDirectory)) {
                    ModEngine.skipped.Clear(); // Clear the skipped list
                    SaveChecks(); // Save checked items
                    SaveAndRefreshList();
                    UninstallThread(); // Uninstall everything before installing more mods

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

                    if (Properties.Settings.Default.Priority) { //Top to Bottom Priority
                        for (int i = ListView_ModsList.Items.Count - 1; i >= 0; i--)
                            if (ListView_ModsList.Items[i].Checked) {
                                Label_Status.Text = $"Installing {ListView_ModsList.Items[i].Text}...";

                                // Install the specified mod
                                ModEngine.InstallMods(ListView_ModsList.Items[i].SubItems[6].Text, ListView_ModsList.Items[i].Text);

                                if (Properties.Settings.Default.SaveFileRedirection) {
                                    Label_Status.Text = $"Redirecting save file for {ListView_ModsList.Items[i].Text}...";

                                    // Redirect save data from the specified mod
                                    RedirectSaves(ListView_ModsList.Items[i].SubItems[6].Text, ListView_ModsList.Items[i].Text);
                                }
                            }
                    } else { //Bottom to Top Priority
                        foreach (ListViewItem mod in ListView_ModsList.CheckedItems)
                            if (ListView_ModsList.Items[ListView_ModsList.Items.IndexOf(mod)].Checked) {
                                Label_Status.Text = $"Installing {mod.Text}...";

                                // Install the specified mod
                                ModEngine.InstallMods(mod.SubItems[6].Text, mod.Text);

                                if (Properties.Settings.Default.SaveFileRedirection) {
                                    Label_Status.Text = $"Redirecting save file for {mod.Text}...";

                                    // Redirect save data from the specified mod
                                    RedirectSaves(mod.SubItems[6].Text, mod.Text);
                                }
                            }
                    }

                    if (ModEngine.skipped.Count != 0)
                        UnifyMessenger.UnifyMessage.ShowDialog($"Installation completed, but the following mods need revising:\n\n{string.Join("\n", ModEngine.skipped)}",
                                                               "Installation completed with warnings...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (Properties.Settings.Default.LaunchEmulator) LaunchEmulator(Literal.Emulator());
                    Label_Status.Text = $"Ready.";
            } else {
                OpenFileDialog browseGame = new OpenFileDialog() {
                    Title = "Please select an executable for Sonic '06...",
                    Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                };

                if (browseGame.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// Redirect save data from a mod to the user-specified save location.
        /// </summary>
        private void RedirectSaves(string mod, string name) {
            string saveLocation = Properties.Settings.Default.SaveData; // Stores Save Data location in string for ease of use

            // Deserialise 'Save' key
            if (INI.DeserialiseKey("Save", mod).Contains("savedata")) {
                if (File.Exists(saveLocation)) {
                        if (Literal.System() == "Xbox 360") {
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
                        } else if (Literal.System() == "PlayStation 3") {
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
            ModEngine.UninstallMods(); // Uninstalls all mods.
            ModEngine.UninstallCustomFilesystem(ListView_ModsList.Items); // Uninstalls user-made filesystems.
            ModEngine.UninstallSaves(ListView_ModsList.Items); // Removes redirected save data.
            Label_Status.Text = "Ready.";
        }

        /// <summary>
        /// Launches Xenia or RPCS3 depending on the selected game executable.
        /// </summary>
        private void LaunchEmulator(string emulator) {
            if (Properties.Settings.Default.EmulatorDirectory == string.Empty ||
                !File.Exists(Properties.Settings.Default.EmulatorDirectory)) { // If the emulator is empty/doesn't exist, prompt the user to select one
                    OpenFileDialog browseEmulator = new OpenFileDialog() {
                        Title = $"Please select an executable for {emulator}...",
                        Filter = "Programs (*.exe)|*.exe"
                    };

                    if (browseEmulator.ShowDialog() == DialogResult.OK) {
                        Properties.Settings.Default.EmulatorDirectory = TextBox_EmulatorExecutable.Text = browseEmulator.FileName;
                        Properties.Settings.Default.Save();
                        LaunchEmulator(Literal.Emulator()); // Perform task again with specified emulator
                    }
            } else {
                if (emulator == "Xenia") {
                    List<string> parameters = new List<string>();

                    if (File.Exists(Properties.Settings.Default.GameDirectory)) parameters.Add($"\"{Properties.Settings.Default.GameDirectory}\"");
                    else { // If the game directory is invalid, prompt the user to select a new one
                        OpenFileDialog browseGame = new OpenFileDialog() {
                            Title = "Please select an executable for Sonic '06...",
                            Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                        };

                        if (browseGame.ShowDialog() == DialogResult.OK) {
                            Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                            Properties.Settings.Default.Save();
                            LaunchEmulator(Literal.Emulator()); // Perform task again with specified emulator
                        }
                    }

                    // Xenia parameter setup
                    if (ComboBox_API.SelectedIndex == 0) {
                        parameters.Add("--gpu=d3d12"); // Use DirectX 12
                        if (CheckBox_Xenia_ForceRTV.Checked) parameters.Add("--d3d12_edram_rov=false"); // Force Render Target Views
                        if (CheckBox_Xenia_2xResolution.Checked) parameters.Add("--d3d12_resolution_scale=2"); // 2x Resolution
                    } else parameters.Add("--gpu=vulkan"); // Use Vulkan

                    if (!CheckBox_Xenia_VerticalSync.Checked) parameters.Add("--vsync=false"); // V-Sync
                    if (CheckBox_Xenia_Gamma.Checked) parameters.Add("--kernel_display_gamma_type=2"); // Enable Gamma
                    if (CheckBox_Xenia_Fullscreen.Checked) parameters.Add("--fullscreen"); // Launch in Fullscreen
                    if (!CheckBox_Xenia_DiscordRPC.Checked) parameters.Add("--discord=false"); // Discord Rich Presence

                    ProcessStartInfo xeniaProc = new ProcessStartInfo() {
                        FileName = Properties.Settings.Default.EmulatorDirectory,

                        // Ensure emulator directory is the working dir - prevents 'xenia.log' and save data being in the wrong locations
                        WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.EmulatorDirectory),

                        Arguments = string.Join(" ", parameters.ToArray()) // Join all parameters for args
                    };

                    Process xenia = Process.Start(xeniaProc); // Launch Xenia
                    Label_Status.Text = "Waiting for Xenia exit call...";
                    xenia.WaitForExit(); // Halt usage of Sonic '06 Mod Manager to prevent the user from breaking stuff in the background
                    UninstallThread(); // Uninstall mods after emulator quits
                } else if (emulator == "RPCS3") {
                    ProcessStartInfo rpcs3Proc = new ProcessStartInfo() {
                        FileName = Properties.Settings.Default.EmulatorDirectory,

                        // Same reason for Xenia, except this is just as a precaution in case RPCS3 changes anything
                        WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.EmulatorDirectory),
                    };

                    Process rpcs3 = Process.Start(rpcs3Proc); // Launch RPCS3
                    Label_Status.Text = "Waiting for RPCS3 exit call...";
                    rpcs3.WaitForExit(); // Halt usage of Sonic '06 Mod Manager to prevent the user from breaking stuff in the background
                    UninstallThread(); // Uninstall mods after emulator quits
                } else { // Emulator not detected...
                    UnifyMessenger.UnifyMessage.ShowDialog("Unable to detect the required emulator for the game's executable. The specified game directory may be invalid.",
                                                           "Unable to load...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UninstallThread(); // Failed to load emulator, so uninstall mods
                }
            }
        }

        /// <summary>
        /// Opens the requested location by sender.
        /// </summary>
        private void Button_Open_Click(object sender, EventArgs e) {
            try {
                string location = string.Empty;
                if (sender == Button_Open_ModsDirectory) location = Properties.Settings.Default.ModsDirectory; // Mods Directory
                else if (sender == Button_Open_GameDirectory) location = Path.GetDirectoryName(Properties.Settings.Default.GameDirectory); // Game Directory
                else if (sender == Button_Open_EmulatorExecutable) location = Properties.Settings.Default.EmulatorDirectory; // Xenia
                else if (sender == Button_Open_SaveData) location = Path.GetDirectoryName(Properties.Settings.Default.SaveData); // Save Data Directory
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
            SaveAndRefreshList(); // Refresh mods list
            CheckDeserialisedMods(); // Check saved items
        }

        /// <summary>
        /// Sets the item check state depending on the sender.
        /// </summary>
        private void Button_Mods_Selection_Click(object sender, EventArgs e) {
            if (sender == Button_Mods_SelectAll) foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = true; // Select All
            else if (sender == Button_Mods_DeselectAll) { // Deselect All
                foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = false;
                ListView_ModsList.SelectedItems.Clear();
            }
        }

        /// <summary>
        /// Switches between Top to Bottom or Bottom to Top priority.
        /// </summary>
        private void Button_Priority_Click(object sender, EventArgs e) {
            if (Properties.Settings.Default.Priority) {
                Button_Priority.Text = "Priority: Bottom to Top";
                Properties.Settings.Default.Priority = false;
            } else {
                Button_Priority.Text = "Priority: Top to Bottom";
                Properties.Settings.Default.Priority = true;
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Increases or decreases item priority in the list.
        /// </summary>
        private void Button_Priority_Iteration_Click(object sender, EventArgs e) {
            if (sender == Button_UpperPriority) {
                int selectedIndex = ListView_ModsList.SelectedItems[0].Index; // Declares the selected index
                List<string> listItem = new List<string>();
                bool check = false; // Check state bool

                // Rebuild list item
                foreach (ListViewItem.ListViewSubItem item in ListView_ModsList.Items[selectedIndex].SubItems) listItem.Add(item.Text);
                ListViewItem shiftItem = new ListViewItem(listItem.ToArray());

                if (ListView_ModsList.Items[selectedIndex].Checked == true) check = true; // Checks if the checkbox was checked
                ListView_ModsList.Items.RemoveAt(selectedIndex); // Removes the selected checkbox
                selectedIndex -= 1; // Move index up the list
                ListView_ModsList.Items.Insert(selectedIndex, shiftItem); // Insert checkbox at selectedIndex
                ListView_ModsList.Items[selectedIndex].Selected = true; // Selects the recently moved checkbox
                shiftItem.Checked = check; // Calls the 'check' bool and sets the checked state
            } else if (sender == Button_DownerPriority) {
                int selectedIndex = ListView_ModsList.SelectedItems[0].Index; // Declares the selected index
                List<string> listItem = new List<string>();
                bool check = false; // Check state bool

                // Rebuild list item
                foreach (ListViewItem.ListViewSubItem item in ListView_ModsList.Items[selectedIndex].SubItems) listItem.Add(item.Text);
                ListViewItem shiftItem = new ListViewItem(listItem.ToArray());

                if (ListView_ModsList.Items[selectedIndex].Checked == true) check = true; // Checks if the checkbox was checked
                ListView_ModsList.Items.RemoveAt(selectedIndex); // Removes the selected checkbox
                selectedIndex += 1; // Move index down the list
                ListView_ModsList.Items.Insert(selectedIndex, shiftItem); // Insert checkbox at selectedIndex
                ListView_ModsList.Items[selectedIndex].Selected = true; // Selects the recently moved checkbox
                shiftItem.Checked = check; // Calls the 'check' bool and sets the checked state
            }
        }

        /// <summary>
        /// Perform actions if user selects an item in the mods list.
        /// </summary>
        private void ListView_ModsList_SelectedIndexChanged(object sender, EventArgs e) {
            // Enables/disables the Upper Priority button depending on if a checkbox is selected
            Button_UpperPriority.Enabled = ListView_ModsList.SelectedItems.Count > 0 && ListView_ModsList.SelectedItems[0].Index > 0;

            // Enables/disables the Downer Priority button depending on if a checkbox is selected
            Button_DownerPriority.Enabled = ListView_ModsList.SelectedItems.Count > 0 && ListView_ModsList.SelectedItems[0].Index < ListView_ModsList.Items.Count - 1;
        }

        /// <summary>
        /// Resets Sonic '06 Mod Manager.
        /// </summary>
        private void LinkLabel_Reset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("This will clear all of the settings for Sonic '06 Mod Manager. Are you sure you want to continue?",
                                                                               "Sonic '06 Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes) {
                try {
                    string modManagerDataPath = Path.Combine(Program.ApplicationData, "Unify");

                    // Erases the Unify directory, containing Tools and user settings
                    DirectoryInfo modManagerData = new DirectoryInfo(modManagerDataPath);
                    if (Directory.Exists(modManagerDataPath)) {
                        foreach (FileInfo file in modManagerData.GetFiles()) file.Delete();
                        foreach (DirectoryInfo directory in modManagerData.GetDirectories()) directory.Delete(true);
                    }
                    Application.Restart();
                } catch { }
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
                Uri serverUri = new Uri(Properties.Resources.DataURI_SEGACarnival);
                if (useBackupServer) serverUri = new Uri(Properties.Resources.DataURI_GitHub);

                using (WebClient client = new WebClient()) {
                    client.DownloadProgressChanged += (s, clientEventArgs) => { ProgressBar_SoftwareUpdate.Value = clientEventArgs.ProgressPercentage; };
                    client.DownloadFileAsync(serverUri, $"{Application.ExecutablePath}.pak"); // Download archive from update servers
                    client.DownloadFileCompleted += (s, clientEventArgs) => {
                        using (ZipArchive archive = new ZipArchive(new MemoryStream(File.ReadAllBytes($"{Application.ExecutablePath}.pak")))) {
                            // Extract and overwrite all with ZIP contents
                            ZIP.ExtractToDirectory(archive, Application.StartupPath, true);

                            //Overwrite 'Sonic '06 Mod Manager.exe' with the newly extracted build
                            File.Replace($"{Application.ExecutablePath}.new", Application.ExecutablePath, $"{Application.ExecutablePath}.bak");

                            UnifyMessenger.UnifyMessage.ShowDialog("Update complete! Restarting Sonic '06 Mod Manager...",
                                                                   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        File.Delete($"{Application.ExecutablePath}.pak"); // Erase ZIP file
                    };
                }
            } catch (Exception ex) {
                if (_debug) Console.WriteLine(ex.ToString()); // Write exception to debug log
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
                        // Download scripts from update servers
                        client.DownloadFileAsync(new Uri(repoLinks[i]), Path.Combine(Program.Patches, Path.GetFileName(repoLinks[i])));

                //Feedback
                UnifyMessenger.UnifyMessage.ShowDialog("All patches have been updated!",
                                                       "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                if (_debug) Console.WriteLine(ex.ToString()); // Write exception to debug log
                UnifyMessenger.UnifyMessage.ShowDialog("Failed to update patches...",
                                                       "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Opens the Mod Creator.
        /// </summary>
        private void SectionButton_CreateNewMod_Click(object sender, EventArgs e) {
            new ModCreator(string.Empty, false).ShowDialog(); // Launch Mod Creator
            SaveAndRefreshList(); // Refresh mods list on close
        }

        /// <summary>
        /// Refreshes the mods list - there were plans initially to use FileSystemWatcher, but it caused too many issues with other parts of the application.
        ///                           it wasn't designed around it, so it won't work.
        /// </summary>
        private void SectionButton_RefreshMods_Click(object sender, EventArgs e) { SaveAndRefreshList(); }

        /// <summary>
        /// Enables/disables the Update Mods button depending on how many items are checked in the Mod Updates list.
        /// </summary>
        private void ListView_ModUpdates_ItemChecked(object sender, ItemCheckedEventArgs e) {
            SectionButton_UpdateMods.Enabled = ListView_ModUpdates.CheckedItems.Count > 0;
        }

        /// <summary>
        /// Code for all SectionButton controls in the Updates section.
        /// </summary>
        private async void SectionButton_Updates_Click(object sender, EventArgs e) {
            // Check for software updates is clicked
            if (sender == SectionButton_CheckForSoftwareUpdates) {
                try {
                    // Check for updates via SEGA Carnival
                    CheckForUpdates(Properties.Resources.VersionURI_SEGACarnival, Properties.Resources.ChangelogsURI_SEGACarnival);
                    Properties.Settings.Default.LastSoftwareUpdate = DateTime.Now.Ticks;
                    if (((SectionButton)sender).SectionText == "Fetch the latest version") UpdateVersion(false); // Update if prompted
                } catch { // SEGA Carnival timed out...
                    try {
                        // Check for updates via GitHub
                        CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                        Properties.Settings.Default.LastSoftwareUpdate = DateTime.Now.Ticks;
                        if (((SectionButton)sender).SectionText == "Fetch the latest version") UpdateVersion(true); // Update if prompted
                    } catch (Exception ex) { // GitHub timed out...
                        Label_UpdaterStatus.Text = "Connection error";
                        PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;

                        // Reset update button for future checking
                        SectionButton_CheckForSoftwareUpdates.SectionText = "Check for updates";
                        SectionButton_CheckForSoftwareUpdates.Refresh();

                        // Write exception to logs
                        RichTextBox_Changelogs.Text = $"Failed to request changelogs...\n\n{ex}";
                        if (_debug) Console.WriteLine(ex.ToString());
                    }
                }
                Properties.Settings.Default.Save();

            // Check for mod updates is clicked
            } else if (sender == SectionButton_CheckForModUpdates) {
                Properties.Settings.Default.LastModUpdate = DateTime.Now.Ticks;
                await CheckForModUpdates(string.Empty);
                Properties.Settings.Default.Save();
            }

            // Fetch latest patches is clicked
            else if (sender == SectionButton_FetchPatches) {
                DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("This will erase all patches locally and fetch the latest ones...",
                                                                                   "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.OK) {
                    Properties.Settings.Default.LastPatchUpdate = DateTime.Now.Ticks;
                    await UpdatePatches();
                    Properties.Settings.Default.Save();

                    // Reset update button for future checking
                    SectionButton_FetchPatches.Enabled = true;
                    SectionButton_FetchPatches.Refresh();
                }
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
                        Console.WriteLine(ex);
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
                                ZIP.ExtractToDirectory(zip, Properties.Settings.Default.ModsDirectory, true);
                        else
                            // Try 7-Zip - if it doesn't work, try WinRAR before throwing exception
                            ZIP.InstallFrom7zArchive(archive);

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
                lv.Columns[3].Width = (x * 6) - 5;
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
        /// Launches Protocol Manager for GameBanana registry key installation.
        /// </summary>
        private void LinkLabel_ProtocolManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string protocolManager = $"{Program.ApplicationData}\\Unify\\Tools\\Protocol Manager.exe";
            
            if (File.Exists(protocolManager)) {
                ProcessStartInfo info = new ProcessStartInfo() {
                    FileName = protocolManager,
                    Arguments = $"\"{Application.ExecutablePath}\" \"True\"",
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(info);
                Application.Exit();
            } else
                UnifyMessenger.UnifyMessage.ShowDialog("Protocol Manager is missing, please restart Sonic '06 Mod Manager.",
                                                       "Protocol Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Resizes Mod Updates container when splitter is moved.
        /// </summary>
        private void SplitContainer_ModUpdate_SplitterMoved(object sender, SplitterEventArgs e) { SizeLastColumn(ListView_ModUpdates); }
    }
}
