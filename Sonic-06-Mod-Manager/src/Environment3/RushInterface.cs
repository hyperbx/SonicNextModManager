using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Patcher;
using Ookii.Dialogs;
using System.Drawing;
using Microsoft.Win32;
using Unify.Networking;
using System.Threading;
using Unify.Serialisers;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO.Compression;
using System.Collections.Generic;

// Sonic '06 Toolkit is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Gabriel (HyperPolygon64)

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
        public RushInterface() {
            InitializeComponent();
            LoadSettings(); // Load user settings

            Label_Version.Text = Program.VersionNumber; // Sets the version string in the About section
            Properties.Settings.Default.SettingsSaving += Settings_SettingsSaving; // Define event for SettingsSaving
            TabControl_Rush.Height += 23; // Increase height on load to accommodate for lack of tabs in the section controller
            SplitContainer_ModsControls.SplitterWidth = 1; // Force splitter width to one pixel, because WinForms is dumb
#if DEBUG
            // If the application is a debug build, force debug mode on
            Properties.Settings.Default.Debug = true;
            Properties.Settings.Default.Save();
#endif
        }

        /// <summary>
        /// Performs actions on launch.
        /// </summary>
        private void RushInterface_Load(object sender, EventArgs e) {
            if (!DesignMode) { // Prevents actions being performed in UnifyEnvironment's design time.
                DeserialiseMods(); // Refresh mods list
                CheckDeserialisedMods(); // Check saved items
                UninstallThread(); // Uninstall everything
            }
        }

        /// <summary>
        /// If 'Properties.Settings.Default.Save()' is called, the 'LoadSettings()' function will be executed.
        /// </summary>
        private void Settings_SettingsSaving(object sender, CancelEventArgs e) { LoadSettings(); }

        /// <summary>
        /// Loads all user settings.
        /// </summary>
        private void LoadSettings() {
            if (Properties.Settings.Default.Debug) {
                CheckBox_DebugMode.Checked = Rush_Section_Debug.Visible = true;
                Console.SetOut(new ListBoxWriter(ListBox_Debug));
            } else Rush_Section_Debug.Visible = false;

            // Restore label strings
            if (Properties.Settings.Default.LastUpdateCheck.ToString("dd/MM/yyyy") == "01/01/0001") Label_LastUpdateCheck.Text = $"Last checked: Never";
            else {
                if (Properties.Settings.Default.LastUpdateCheck.Date == DateTime.Today)
                    Label_LastUpdateCheck.Text = $"Last checked: Today, {Properties.Settings.Default.LastUpdateCheck.ToString("hh:mm tt")}";
                else if (Properties.Settings.Default.LastUpdateCheck.Date == DateTime.Today.AddDays(-1))
                    Label_LastUpdateCheck.Text = $"Last checked: Yesterday, {Properties.Settings.Default.LastUpdateCheck.ToString("hh:mm tt")}";
                else
                    Label_LastUpdateCheck.Text = $"Last checked: {Properties.Settings.Default.LastUpdateCheck.ToString("dd/MM/yyyy, hh:mm tt")}";
            }

            // Restore text box strings
            TextBox_GameDirectory.Text = Properties.Settings.Default.GameDirectory;
            TextBox_EmulatorExecutable.Text = Properties.Settings.Default.EmulatorDirectory;
            TextBox_SaveData.Text = Properties.Settings.Default.SaveData;

            if ((TextBox_ModsDirectory.Text = Properties.Settings.Default.ModsDirectory) != string.Empty &&
                Directory.Exists(TextBox_ModsDirectory.Text = Properties.Settings.Default.ModsDirectory)) {
                    // Track the mods directory for changes
                    FileSystemWatcher handleModsDir = new FileSystemWatcher() {
                        Path = Properties.Settings.Default.ModsDirectory,
                        EnableRaisingEvents = true
                    };
                    SynchronizationContext context = SynchronizationContext.Current;
                    handleModsDir.Created += (s, e) => { context.Post(val => DeserialiseMods(), s); };
                    handleModsDir.Renamed += (s, e) => { context.Post(val => DeserialiseMods(), s); };
                    handleModsDir.Deleted += (s, e) => { context.Post(val => DeserialiseMods(), s); };
            }

            // Restore combo box states
            ComboBox_API.SelectedIndex = Properties.Settings.Default.GraphicsAPI;

            // Restore check box states
            CheckBox_AutoColour.Checked         = Properties.Settings.Default.AutoColour;
            CheckBox_HighContrastText.Checked   = Properties.Settings.Default.HighContrastText;
            CheckBox_Xenia_ForceRTV.Checked     = Properties.Settings.Default.ForceRTV;
            CheckBox_Xenia_2xResolution.Checked = Properties.Settings.Default.DoubleResolution;
            CheckBox_Xenia_VerticalSync.Checked = Properties.Settings.Default.VerticalSync;
            CheckBox_Xenia_Gamma.Checked        = Properties.Settings.Default.Gamma;
            CheckBox_Xenia_Fullscreen.Checked   = Properties.Settings.Default.Fullscreen;
            CheckBox_Xenia_DiscordRPC.Checked   = Properties.Settings.Default.DiscordRPC;

            if (CheckBox_LaunchEmulator.Checked = Properties.Settings.Default.LaunchEmulator) {
                SectionButton_InstallMods.SectionText = "Install mods and launch Sonic '06";
                SectionButton_InstallMods.Refresh();
            } else {
                SectionButton_InstallMods.SectionText = "Install mods";
                SectionButton_InstallMods.Refresh();
            }

            if (CheckBox_CheckUpdatesOnLaunch.Checked = Properties.Settings.Default.CheckUpdatesOnLaunch)
                try {
                    CheckForUpdates(Properties.Resources.VersionURI_SEGACarnival, Properties.Resources.ChangelogsURI_SEGACarnival);
                    Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
                } catch {
                    try {
                        CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                        Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
                    } catch (Exception ex) {
                        Label_UpdaterStatus.Text = "Connection error";
                        PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;
                        RichTextBox_Changelogs.Text = $"Failed to request changelogs...\n\n{ex}";
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

            // Set controls to HighContrastText setting
            if (Properties.Settings.Default.HighContrastText) {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.ControlText;
            } else {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.Control;
            }

            // Set controls to AccentColour setting
            Button_ColourPicker_Preview.FlatAppearance.MouseOverBackColor =
            Button_ColourPicker_Preview.FlatAppearance.MouseDownBackColor =
            Rush_Section_Settings.AccentColour =
            Button_ColourPicker_Preview.BackColor =
            StatusStrip_Main.BackColor =
            Label_Status.BackColor =
            TabControl_Patches.HorizontalLineColor =
            TabControl_Patches.ActiveColor =
            Properties.Settings.Default.AccentColour;

            // Set controls depending on emulator
            if (Literal.Emulator() == "Xenia") {
                // Set text colour to Control
                Label_Subtitle_Emulator_Options.ForeColor =
                Label_GraphicsAPI.ForeColor =
                SystemColors.Control;

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
        }

        /// <summary>
        /// Gets/sets the selected index of the tab control.
        /// </summary>
        public int SelectedIndex {
            get { return TabControl_Rush.SelectedIndex; }
            set {
                TabControl_Rush.SelectedIndex = value;

                if (value == 2) {
                    foreach (Control control in Controls)
                        if (control is SectionButton) ((SectionButton)control).SelectedSection = false;
                    TabControl_Rush.Visible = true;
                    Rush_Section_About.SelectedSection = true;
                }
            }
        }

        /// <summary>
        /// Pings the update servers to check for a new version.
        /// </summary>
        private async void CheckForUpdates(string versionURI, string changelogsURI) {
            string latestVersion = await Client.RequestString(versionURI); // Request version number
            if (Program.VersionNumber != latestVersion) { // New update available!
                // Give feedback on update status
                Label_UpdaterStatus.Text = "Updates available";
                Label_Status.Text = "A new version of Sonic '06 Mod Manager is available!";
                PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;

                // Request changelogs
                RichTextBox_Changelogs.Text = $"Sonic '06 Mod Manager - {latestVersion}\n\n" +
                                                $"" +
                                                $"{await Client.RequestString(changelogsURI)}";

                // Defines new appearance for the Check for Updates button
                SectionButton_CheckForUpdates.SectionImage = Properties.Resources.InstallMods;
                SectionButton_CheckForUpdates.SectionText = "Fetch the latest version";
                SectionButton_CheckForUpdates.Refresh(); // Refreshes custom user control to display new properties
            }
        }

        /// <summary>
        /// Takes click control from all section buttons and switches the navigator control.
        /// </summary>
        private void Rush_Section_Click(object sender, EventArgs e) {
            // Deselect all SectionButton controls
            foreach (Control control in Controls)
                if (control is SectionButton) ((SectionButton)control).SelectedSection = false;

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
                    Description = "Please select a folder...",
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
        }

        /// <summary>
        /// Checks if a button has been clicked on the WindowsColourPicker user control.
        /// </summary>
        private void WindowsColourPicker_AccentColour_ButtonClick(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = ((Button)sender).BackColor;
            Properties.Settings.Default.Save();
        }

        private void Rush_TabControl_SelectedIndexChanged(object sender, EventArgs e) { TabControl_Rush.SelectedTab.VerticalScroll.Value = 0; }

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
        private void ContextMenu_ModMenu_Items_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).ToString()) {
                case "Mod Information":

                    break;
                case "Open Folder":
                    try { Process.Start(Path.GetDirectoryName(ListView_ModsList.FocusedItem.SubItems[6].Text)); }
                    catch {
                        MessageBox.Show("Unable to locate the selected mod. It may have been removed from the mods directory. Removing from list...",
                                        "Unable to find mod...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DeserialiseMods();
                    }
                    break;
                case "Check for Updates":

                    break;
                case "Edit Mod":

                    break;
                case "Delete Mod":
                    try {
                        DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete {ListView_ModsList.FocusedItem.Text}?",
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
                        MessageBox.Show("Failed to delete the data for the requested mod.",
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
            // Draws the horizontal line in the accent colour
            e.Graphics.DrawLine(new Pen(Properties.Settings.Default.AccentColour, 1), new Point(0, 21), new Point(Width, 21));

            // Draws the column background colour
            Color theme = Color.FromArgb(45, 45, 48);
            e.Graphics.FillRectangle(new SolidBrush(theme), e.Bounds);
            Point point = new Point(0, 3);
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
            } else { // Specify the mods directory if it doesn't exist (first thing the application will request)
                if (MessageBox.Show("No mods directory specified, or the specified directory is invalid - please select your Sonic '06 mods directory...",
                                    "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                        Description = "Please select a folder...",
                        UseDescriptionForTitle = true
                    };

                    if (browseMods.ShowDialog() == DialogResult.OK) {
                        Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text = browseMods.SelectedPath;
                        Properties.Settings.Default.Save();
                        DeserialiseMods(); // Repeat function after directory is set
                    } else Application.Exit(); // No directory is set, so just close...
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
                    DeserialiseMods(); // Refresh mods list
                    CheckDeserialisedMods(); // Check saved items
                    UninstallThread(); // Uninstall everything before installing more mods

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
                        MessageBox.Show($"Installation completed, but the following mods need revising:\n\n{string.Join("\n", ModEngine.skipped)}",
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
            UninstallMods(); // Uninstalls all mods.
            UninstallCustomFilesystem(); // Uninstalls user-made filesystems.
            UninstallSaves(); // Removes redirected save data.
            Label_Status.Text = "Ready.";
        }

        /// <summary>
        /// Uninstalls all mods.
        /// </summary>
        private void UninstallMods() {
            if (Properties.Settings.Default.GameDirectory != string.Empty ||
                File.Exists(Properties.Settings.Default.GameDirectory)) { // If the game directory is empty/doesn't exist, ignore request
                    // Search for all files with specified LINQ filters
                    List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), "*.*", SearchOption.AllDirectories)
                                        .Where(s => s.EndsWith(".arc_back") ||
                                                    s.EndsWith(".arc_orig")).ToList();

                    foreach (string file in files) {
                        if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                            if (Properties.Settings.Default.Debug) Console.WriteLine($"Removing: {file}");
                            File.Delete(file.ToString().Remove(file.Length - 5)); // Delete file with last five characters set to '_back' or '_orig'
                        }
                        File.Move(file, file.ToString().Remove(file.Length - 5)); // Remove last five characters ('_back' or '_orig')
                }
            }
        }

        /// <summary>
        /// Uninstalls user-made filesystems.
        /// </summary>
        private void UninstallCustomFilesystem() {
            if (Properties.Settings.Default.GameDirectory != string.Empty ||
                File.Exists(Properties.Settings.Default.GameDirectory)) { // If the game directory is empty/doesn't exist, ignore request
                    foreach (ListViewItem mod in ListView_ModsList.Items) {
                        string[] custom = INI.DeserialiseKey("Custom", mod.SubItems[6].Text).Split(','); // Deserialise 'Custom' key

                        if (custom[0] != "N/A") { // Speeds things up a bit - ensures it's not checking a default null parameter
                            foreach (string file in custom) {
                                // Search for all files with filters from custom
                                List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), file, SearchOption.AllDirectories).ToList();
                                
                                foreach (string customfile in files)
                                    try {
                                        if (Properties.Settings.Default.Debug) Console.WriteLine($"Removing: {file}");
                                        File.Delete(customfile); // If custom archive is found, erase...
                                    } catch { }
                            }
                        }
                    }
            }
        }

        /// <summary>
        /// Removes redirected save data.
        /// </summary>
        private void UninstallSaves() {
            if (Properties.Settings.Default.SaveData != string.Empty || File.Exists(Properties.Settings.Default.SaveData)) {
                foreach (ListViewItem mod in ListView_ModsList.Items) {
                    // Basically just to check 'SonicNextSaveData.bin' as a directory
                    string saveLocation = Path.GetDirectoryName(Path.GetDirectoryName(Properties.Settings.Default.SaveData));

                    // Deserialise 'Save' key
                    string savedata = INI.DeserialiseKey("Save", mod.SubItems[6].Text);

                    if (savedata != "N/A") { // Speeds things up a bit - ensures it's not checking a default null parameter
                        if (Literal.Emulator() == "Xenia") {
                            string[] saves = Array.Empty<string>();

                            // Get all backup directories
                            if (Directory.Exists(saveLocation)) saves = Directory.GetDirectories(saveLocation, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);

                            foreach (var dir in saves) {
                                // Original save data path
                                string saveFile = Path.Combine(dir.ToString().Remove(dir.Length - 5), Path.GetFileName(dir.ToString().Remove(dir.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"Removing: {dir}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.360"), true);
                                }

                                // Recursively erase redirected save data
                                if (Directory.Exists(dir.ToString().Remove(dir.Length - 5))) {
                                    Console.WriteLine($"Removing: {dir}");
                                    Directory.Delete(dir.ToString().Remove(dir.Length - 5), true);
                                }

                                // Restore original save data
                                Directory.Move(dir.ToString(), dir.ToString().Remove(dir.Length - 5));
                            }
                        } else if (Literal.Emulator() == "RPCS3") {
                            string[] saves = Array.Empty<string>();

                            // Original save data path
                            if (Directory.Exists(saveLocation)) saves = Directory.GetFiles(saveLocation, "SYS-DATA_back", SearchOption.AllDirectories);

                            foreach (var file in saves) {
                                string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"Removing: {file}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.ps3"), true);
                                }

                                // Erase redirected save data
                                if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                                    Console.WriteLine($"Removing: {file}");
                                    File.Delete(file.ToString().Remove(file.Length - 5));
                                }

                                // Restore original save data
                                File.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                            }
                        }
                    }
                }
            }
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
                    MessageBox.Show("Unable to detect the required emulator for the game's executable. The specified game directory may be invalid.",
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
                MessageBox.Show("The requested location was invalid or unspecified. Ensure the box is populated.",
                                "Unable to load...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save checked items at their specified locations in the list.
        /// </summary>
        private void SectionButton_SaveChecks_Click(object sender, EventArgs e) {
            SaveChecks(); // Save checked items
            DeserialiseMods(); // Refresh mods list
            CheckDeserialisedMods(); // Check saved items
        }

        /// <summary>
        /// Sets the item check state depending on the sender.
        /// </summary>
        private void Button_Mods_Selection_Click(object sender, EventArgs e) {
            if (sender == Button_Mods_SelectAll) foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = true; // Select All
            else if (sender == Button_Mods_DeselectAll) foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = false; // Deselect All
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
            DialogResult confirmation = MessageBox.Show("This will clear all of the settings for Sonic '06 Mod Manager. Are you sure you want to continue?",
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
        /// Ping servers to check for updates.
        /// </summary>
        private void SectionButton_CheckForUpdates_Click(object sender, EventArgs e) {
            try {
                // Check for updates via SEGA Carnival
                CheckForUpdates(Properties.Resources.VersionURI_SEGACarnival, Properties.Resources.ChangelogsURI_SEGACarnival);
                Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
                if (((SectionButton)sender).SectionText == "Fetch the latest version") UpdateVersion(false); // Update if prompted
            } catch { // SEGA Carnival timed out...
                try {
                    // Check for updates via GitHub
                    CheckForUpdates(Properties.Resources.VersionURI_GitHub, Properties.Resources.ChangelogsURI_GitHub);
                    Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
                    if (((SectionButton)sender).SectionText == "Fetch the latest version") UpdateVersion(true); // Update if prompted
                } catch (Exception ex) { // GitHub timed out...
                    Label_UpdaterStatus.Text = "Connection error";
                    PictureBox_UpdaterIcon.BackgroundImage = Properties.Resources.Exception_Logo;

                    // Reset update button for future checking
                    SectionButton_CheckForUpdates.SectionText = "Check for updates";
                    SectionButton_CheckForUpdates.Refresh();

                    // Write exception to logs
                    RichTextBox_Changelogs.Text = $"Failed to request changelogs...\n\n{ex}";
                    if (Properties.Settings.Default.Debug) Console.WriteLine(ex.ToString());
                }
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Update Sonic '06 Mod Manager via requested server
        /// </summary>
        private void UpdateVersion(bool useBackupServer) {
            // Set controls enabled and visibility state
            CheckBox_CheckUpdatesOnLaunch.Enabled = false;
            ProgressBar_SoftwareUpdate.Visible = true;

            // If SEGA Carnival is offline, use GitHub
            Uri serverUri = new Uri(Properties.Resources.DataURI_SEGACarnival);
            if (useBackupServer) serverUri = new Uri(Properties.Resources.DataURI_GitHub);

            try {
                using (WebClient client = new WebClient()) {
                    client.DownloadProgressChanged += (s, clientEventArgs) => { ProgressBar_SoftwareUpdate.Value = clientEventArgs.ProgressPercentage; };
                    client.DownloadFileTaskAsync(serverUri, $"{Application.ExecutablePath}.pak"); // Download archive from update servers
                    client.DownloadFileCompleted += (s, clientEventArgs) => {
                        using (ZipArchive archive = new ZipArchive(new MemoryStream(File.ReadAllBytes($"{Application.ExecutablePath}.pak")))) {
                            ZIP.ExtractToDirectory(archive, Application.StartupPath, true); // Extract and overwrite all with ZIP contents

                            //Overwrite 'Sonic '06 Mod Manager.exe' with the newly extracted build
                            File.Replace($"{Application.ExecutablePath}.new", Application.ExecutablePath, $"{Application.ExecutablePath}.bak");

                            MessageBox.Show("Update complete! Restarting Sonic '06 Mod Manager...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        File.Delete($"{Application.ExecutablePath}.pak"); // Erase ZIP file
                    };
                }
            } catch (Exception ex) {
                if (Properties.Settings.Default.Debug) Console.WriteLine(ex.ToString()); // Write exception to debug log
                MessageBox.Show("Failed to update Sonic '06 Mod Manager. Reverting back to the previous version...", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                // Reset update button for future checking
                SectionButton_CheckForUpdates.SectionText = "Check for updates";
                SectionButton_CheckForUpdates.Refresh();

                // Replace 'Sonic '06 Mod Manager.exe' with the backup created earlier
                if (File.Exists($"{Application.ExecutablePath}.bak")) {
                    File.Replace($"{Application.ExecutablePath}.bak", Application.ExecutablePath, $"{Application.ExecutablePath}.err");
                    File.Delete($"{Application.ExecutablePath}.err");
                }
            }
        }

        /// <summary>
        /// Opens the Mod Creator
        /// </summary>
        private void SectionButton_CreateNewMod_Click(object sender, EventArgs e) {
            // Deselect all SectionButton controls
            foreach (Control control in Controls)
                if (control is SectionButton) ((SectionButton)control).SelectedSection = false;

            Container_Rush.Title = Tab_Section_ModCreator.Text; // Set title to 'Mod Creator'
            TabControl_Rush.SelectedTab = Tab_Section_ModCreator; // Select the Mod Creator tab
        }
    }
}
