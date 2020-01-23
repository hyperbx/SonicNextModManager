using System;
using System.IO;
using System.Linq;
using Unify.Patcher;
using Ookii.Dialogs;
using System.Drawing;
using Microsoft.Win32;
using Unify.Serialisers;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.ComponentModel;
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
            LoadSettings();

            Label_Version.Text = Program.VersionNumber;
            Properties.Settings.Default.SettingsSaving += Settings_SettingsSaving;
            TabControl_Rush.Height += 23;
            SplitContainer_ModsControls.SplitterWidth = 1;

#if DEBUG
            Properties.Settings.Default.Debug = true;
            Properties.Settings.Default.Save();
#endif
        }

        public static string Log { set { Console.WriteLine(value); } }

        private void Settings_SettingsSaving(object sender, CancelEventArgs e) { LoadSettings(); }

        private void LoadSettings() {
            if (Properties.Settings.Default.Debug) {
                CheckBox_DebugMode.Checked = Rush_Section_Debug.Visible = true;
                Console.SetOut(new ListBoxWriter(ListBox_Debug));
            } else Rush_Section_Debug.Visible = false;

            // Restore text box strings.
            TextBox_ModsDirectory.Text = Properties.Settings.Default.ModsDirectory;
            TextBox_GameDirectory.Text = Properties.Settings.Default.GameDirectory;
            TextBox_EmulatorExecutable.Text = Properties.Settings.Default.EmulatorDirectory;
            TextBox_SaveData.Text = Properties.Settings.Default.SaveData;

            // Restore combo box states.
            ComboBox_API.SelectedIndex = Properties.Settings.Default.GraphicsAPI;

            // Restore check box states.
            CheckBox_AutoColour.Checked = Properties.Settings.Default.AutoColour;
            CheckBox_HighContrastText.Checked = Properties.Settings.Default.HighContrastText;
            CheckBox_Xenia_ForceRTV.Checked = Properties.Settings.Default.ForceRTV;
            CheckBox_Xenia_2xResolution.Checked = Properties.Settings.Default.DoubleResolution;
            CheckBox_Xenia_VerticalSync.Checked = Properties.Settings.Default.VerticalSync;
            CheckBox_Xenia_Gamma.Checked = Properties.Settings.Default.Gamma;
            CheckBox_Xenia_Fullscreen.Checked = Properties.Settings.Default.Fullscreen;
            CheckBox_Xenia_DiscordRPC.Checked = Properties.Settings.Default.DiscordRPC;

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

            // Set controls to HighContrastText setting.
            if (Properties.Settings.Default.HighContrastText) {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.ControlText;
            } else {
                Label_Status.ForeColor =
                TabControl_Patches.SelectedTextColor =
                SystemColors.Control;
            }

            // Set controls to AccentColour setting.
            Button_ColourPicker_Preview.FlatAppearance.MouseOverBackColor =
            Button_ColourPicker_Preview.FlatAppearance.MouseDownBackColor =
            Rush_Section_Settings.AccentColour =
            Button_ColourPicker_Preview.BackColor =
            StatusStrip_Main.BackColor =
            Label_Status.BackColor =
            TabControl_Patches.HorizontalLineColor =
            TabControl_Patches.ActiveColor =
            Properties.Settings.Default.AccentColour;

            // Set controls depending on emulator.
            if (Literal.Emulator() == "Xenia") {
                // Set text colour to Control.
                Label_Subtitle_Emulator_Options.ForeColor =
                Label_GraphicsAPI.ForeColor =
                SystemColors.Control;

                // Set enabled state of controls.
                CheckBox_Xenia_ForceRTV.Enabled =
                CheckBox_Xenia_2xResolution.Enabled =
                CheckBox_Xenia_VerticalSync.Enabled =
                CheckBox_Xenia_Gamma.Enabled =
                CheckBox_Xenia_Fullscreen.Enabled =
                CheckBox_Xenia_DiscordRPC.Enabled =
                ComboBox_API.Enabled =
                true;

                // Set visibility state of controls.
                Label_RPCS3Warning.Visible = false;
            } else if (Literal.Emulator() == "RPCS3") {
                // Set text colour to GrayText.
                Label_Subtitle_Emulator_Options.ForeColor =
                Label_GraphicsAPI.ForeColor =
                SystemColors.GrayText;

                // Set enabled state of controls.
                CheckBox_Xenia_ForceRTV.Enabled =
                CheckBox_Xenia_2xResolution.Enabled =
                CheckBox_Xenia_VerticalSync.Enabled =
                CheckBox_Xenia_Gamma.Enabled =
                CheckBox_Xenia_Fullscreen.Enabled =
                CheckBox_Xenia_DiscordRPC.Enabled =
                ComboBox_API.Enabled =
                false;

                // Set visibility state of controls.
                Label_RPCS3Warning.Visible = true;
            }
        }

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
        /// Takes click control from all section buttons and switches the navigator control.
        /// </summary>
        private void Rush_Section_Click(object sender, EventArgs e) {
            foreach (Control control in Controls)
                if (control is SectionButton) ((SectionButton)control).SelectedSection = false;

            if (sender == Rush_Section_Mods) TabControl_Rush.SelectedTab = Tab_Section_Mods;
            else if (sender == Rush_Section_Emulator) TabControl_Rush.SelectedTab = Tab_Section_Emulator;
            else if (sender == Rush_Section_Patches) TabControl_Rush.SelectedTab = Tab_Section_Patches;
            else if (sender == Rush_Section_Settings) TabControl_Rush.SelectedTab = Tab_Section_Settings;
            else if (sender == Rush_Section_Debug) TabControl_Rush.SelectedTab = Tab_Section_Debug;
            else if (sender == Rush_Section_Updates) TabControl_Rush.SelectedTab = Tab_Section_Updates;
            else if (sender == Rush_Section_About) TabControl_Rush.SelectedTab = Tab_Section_About;
            ((SectionButton)sender).SelectedSection = true;
            Container_Rush.Title = ((SectionButton)sender).SectionText;
        }

        private void Button_Browse_Click(object sender, EventArgs e) {
            if (sender == Button_ModsDirectory) {
                VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                    Description = "Please select a folder...",
                    UseDescriptionForTitle = true
                };

                if (browseMods.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text = browseMods.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_GameDirectory) {
                OpenFileDialog browseGame = new OpenFileDialog() {
                    Title = "Please select an executable for Sonic '06...",
                    Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                };

                if (browseGame.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_EmulatorExecutable) {
                OpenFileDialog browseEmulator = new OpenFileDialog() {
                    Title = $"Please select an executable for {Literal.Emulator()}...",
                    Filter = "Programs (*.exe)|*.exe"
                };

                if (browseEmulator.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.EmulatorDirectory = TextBox_EmulatorExecutable.Text = browseEmulator.FileName;
                    Properties.Settings.Default.Save();
                }
            } else if (sender == Button_SaveData) {
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

        private void WindowsColourPicker_AccentColour_ButtonClick(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = ((Button)sender).BackColor;
            Properties.Settings.Default.Save();
        }

        private void Rush_TabControl_SelectedIndexChanged(object sender, EventArgs e) { TabControl_Rush.SelectedTab.VerticalScroll.Value = 0; }

        private void CheckBox_Settings_CheckedChanged(object sender, EventArgs e) {
            if (sender == CheckBox_AutoColour) {
                if (CheckBox_AutoColour.Checked) {
                    int RegistryColour = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null);
                    Properties.Settings.Default.AccentColour = Color.FromArgb(RegistryColour);
                } else Properties.Settings.Default.AccentColour = Color.FromArgb(186, 0, 0);
                Properties.Settings.Default.AutoColour = ((CheckBox)sender).Checked;
            } else if (sender == CheckBox_HighContrastText) Properties.Settings.Default.HighContrastText = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_DebugMode) Properties.Settings.Default.Debug = ((CheckBox)sender).Checked;
            else if (sender == CheckBox_SaveFileRedirection) Properties.Settings.Default.SaveFileRedirection = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        private void Button_ColourPicker_Preview_MouseEnter(object sender, EventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(48, 48, 51); }

        private void Button_ColourPicker_Preview_MouseLeave(object sender, EventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(42, 42, 45); }

        private void Button_ColourPicker_Preview_MouseDown(object sender, MouseEventArgs e) { Section_Appearance_ColourPicker.BackColor = Color.FromArgb(58, 58, 61); }

        private void Button_ColourPicker_Preview_MouseUp(object sender, MouseEventArgs e) {
            Section_Appearance_ColourPicker.BackColor = Color.FromArgb(48, 48, 51);
            Section_Appearance_ColourPicker_Click(sender, e);
        }

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

        private void Button_ColourPicker_Default_Click(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = Color.FromArgb(186, 0, 0);
            Properties.Settings.Default.Save();
        }

        private void SectionButton_ClearLog_Click(object sender, EventArgs e) { ListBox_Debug.Items.Clear(); }

        private void ListView_ModsList_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                if (ListView_ModsList.FocusedItem.Bounds.Contains(e.Location)) {
                    MenuItem[] items = new MenuItem[] {
                        new MenuItem("Mod Information", ContextMenu_ModMenu_Items_Click),
                        new MenuItem("Open Folder", ContextMenu_ModMenu_Items_Click),
                        new MenuItem("Check for Updates", ContextMenu_ModMenu_Items_Click),
                        new MenuItem("Edit Mod", ContextMenu_ModMenu_Items_Click),
                        new MenuItem("Delete Mod", ContextMenu_ModMenu_Items_Click)
                    };
                    ListView_ModsList.ContextMenu = new ContextMenu(items);
                }
        }

        private void ContextMenu_ModMenu_Items_Click(object sender, EventArgs e) {
            switch (((MenuItem)sender).Index) {
                case 0: //Mod Information
                    // Load mod info pisshead
                    break;
                case 1: //Open Folder
                    try { Process.Start(Path.GetDirectoryName(ListView_ModsList.FocusedItem.SubItems[6].Text)); }
                    catch {
                        MessageBox.Show("Unable to locate the selected mod. It may have been removed from the mods directory. Removing from list...",
                                        "Unable to find mod...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Refresh mods list here
                    }
                    break;
                case 2: //Check for Updates
                    // Updater goes here lol
                    break;
                case 3: //Edit Mod
                    // Load mod editor or something... nerd
                    break;
                case 4: //Delete Mod
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
                                // Refresh mods list here
                            }
                        }
                    } catch {
                        MessageBox.Show("Failed to delete the data for the requested mod.",
                                        "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            Color theme = Color.FromArgb(45, 45, 48);
            e.Graphics.DrawLine(new Pen(Properties.Settings.Default.AccentColour, 1), new Point(0, 21), new Point(Width, 21));
            e.Graphics.FillRectangle(new SolidBrush(theme), e.Bounds);
            Point point = new Point(0, 3);
            point.X = e.Bounds.X;

            if (sender == ListView_ModsList) {
                ColumnHeader column = ListView_ModsList.Columns[e.ColumnIndex];
                e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
                point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ListView_ModsList.Font).Width / 2;
                TextRenderer.DrawText(e.Graphics, column.Text, ListView_ModsList.Font, point, ListView_ModsList.ForeColor);
            } else if (sender == ListView_PatchesList) {
                ColumnHeader column = ListView_PatchesList.Columns[e.ColumnIndex];
                e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
                point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ListView_PatchesList.Font).Width / 2;
                TextRenderer.DrawText(e.Graphics, column.Text, ListView_PatchesList.Font, point, ListView_PatchesList.ForeColor);
            }
        }

        private void RushInterface_Load(object sender, EventArgs e) {
            DeserialiseMods();
            CheckDeserialisedMods();
            UninstallThread();
        }

        private void DeserialiseMods() {
            if (Directory.Exists(Properties.Settings.Default.ModsDirectory)) {
                ListView_ModsList.Items.Clear();
                Button_UpperPriority.Enabled = Button_DownerPriority.Enabled = false;
                foreach (string mod in Directory.GetFiles(Properties.Settings.Default.ModsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                    //Add mod to list, getting information from its mod.ini file
                    ListView_ModsList.Items.Add(new ListViewItem(new[] {
                        INISerialiser.DeserialiseKey("Title", mod),
                        INISerialiser.DeserialiseKey("Version", mod),
                        INISerialiser.DeserialiseKey("Author", mod),
                        INISerialiser.DeserialiseKey("Platform", mod),
                        Literal.Bool(INISerialiser.DeserialiseKey("Merge", mod)),
                        string.Empty,
                        mod
                    }));
                }
            } else {
                if (MessageBox.Show("No mods directory specified, or the specified directory is invalid - please select your Sonic '06 mods directory...",
                                    "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                        Description = "Please select a folder...",
                        UseDescriptionForTitle = true
                    };

                    if (browseMods.ShowDialog() == DialogResult.OK) {
                        Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text = browseMods.SelectedPath;
                        Properties.Settings.Default.Save();
                        DeserialiseMods();
                    }
                }
            }
        }

        private void CheckDeserialisedMods() {
            string line = string.Empty; // Declare empty string for StreamReader
            string modConfig = Path.Combine(Properties.Settings.Default.ModsDirectory, "mods.ini");

            if (File.Exists(modConfig)) {
                using (StreamReader mods = new StreamReader(modConfig)) { // Read 'mods.ini'
                    mods.ReadLine(); // Skip [Main] line
                    while ((line = mods.ReadLine()) != null) { // Read all lines until null
                        try {
                            if (Directory.Exists(Path.Combine(Properties.Settings.Default.ModsDirectory, line))) {
                                string title = INISerialiser.DeserialiseKey("Title", Path.Combine(Properties.Settings.Default.ModsDirectory, line, "mod.ini"));

                                if (ListView_ModsList.Items.Contains(ListView_ModsList.FindItemWithText(title))) { // If the mods list contains what's on the current line...
                                    List<string> listItem = new List<string>();
                                    int index = ListView_ModsList.Items.IndexOf(ListView_ModsList.FindItemWithText(title));

                                    foreach (ListViewItem.ListViewSubItem item in ListView_ModsList.Items[index].SubItems) listItem.Add(item.Text);
                                    ListViewItem shiftItem = new ListViewItem(listItem.ToArray());

                                    ListView_ModsList.Items.RemoveAt(index); // Remove the mod already in the mods list
                                    ListView_ModsList.Items.Insert(0, shiftItem).Checked = true; // Insert the mod by the name provided in 'mods.ini', given it's at least present in the list
                                }
                            }
                        } catch { }
                    }
                }
            }
        }

        private void SaveChecks() {
            //Save the names of the selected mods and the indexes of the selected patches to their appropriate ini files
            string modCheckList = Path.Combine(Properties.Settings.Default.ModsDirectory, "mods.ini");
            string patchCheckList = Path.Combine(Properties.Settings.Default.ModsDirectory, "patches.ini");

            using (StreamWriter sw = File.CreateText(modCheckList))
                sw.WriteLine("[Main]"); //Header

            for (int i = ListView_ModsList.Items.Count - 1; i >= 0; i--) { // Writes in reverse so the mods list writes it in it's preferred order
                if (ListView_ModsList.Items[i].Checked)
                    using (StreamWriter sw = File.AppendText(modCheckList))
                        sw.WriteLine(Path.GetFileName(Path.GetDirectoryName(ListView_ModsList.Items[i].SubItems[6].Text))); //Mod Name
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

        private void SectionButton_InstallMods_Click(object sender, EventArgs e) {
            ModEngine.skipped.Clear();
            UninstallThread();

            if (Properties.Settings.Default.Priority) {
                for (int i = ListView_ModsList.Items.Count - 1; i >= 0; i--) //Top to Bottom Priority
                    if (ListView_ModsList.Items[i].Checked) {
                        Label_Status.Text = $"Installing {ListView_ModsList.Items[i].Text}...";
                        ModEngine.InstallMods(ListView_ModsList.Items[i].SubItems[6].Text, ListView_ModsList.Items[i].Text);

                        if (Properties.Settings.Default.SaveFileRedirection) {
                            Label_Status.Text = $"Redirecting save file for {ListView_ModsList.Items[i].Text}...";
                            RedirectSaves(ListView_ModsList.Items[i].SubItems[6].Text, ListView_ModsList.Items[i].Text);
                        }
                    }
            } else {
                foreach (ListViewItem mod in ListView_ModsList.CheckedItems) //Bottom to Top Priority
                    if (ListView_ModsList.Items[ListView_ModsList.Items.IndexOf(mod)].Checked) {
                        Label_Status.Text = $"Installing {mod.Text}...";
                        ModEngine.InstallMods(mod.SubItems[6].Text, mod.Text);

                        if (Properties.Settings.Default.SaveFileRedirection) {
                            Label_Status.Text = $"Redirecting save file for {mod.Text}...";
                            RedirectSaves(mod.SubItems[6].Text, mod.Text);
                        }
                    }
            }

            if (ModEngine.skipped.Count != 0)
                MessageBox.Show($"Installation completed, but the following mods need revising:\n\n{string.Join("\n", ModEngine.skipped)}",
                                "Installation completed with warnings...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LaunchEmulator(Literal.Emulator());
            Label_Status.Text = $"Ready.";
        }

        private void RedirectSaves(string mod, string name) {
            string saveLocation = Properties.Settings.Default.SaveData;
            bool savedata = INISerialiser.DeserialiseKey("Save", mod) != string.Empty;

            if (savedata) {
                if (File.Exists(saveLocation)) {
                        if (Literal.System() == "Xbox 360") {
                            try {
                                if (!Directory.Exists($"{Path.GetDirectoryName(saveLocation)}_back")) {
                                    Directory.CreateDirectory($"{Path.GetDirectoryName(saveLocation)}_back");
                                    DirectoryInfo backupSave = new DirectoryInfo(Path.GetDirectoryName(saveLocation));
                                    foreach (FileInfo fi in backupSave.GetFiles())
                                        fi.CopyTo(Path.Combine($"{Path.GetDirectoryName(saveLocation)}_back", fi.Name), true);
                                    File.Copy(Path.Combine(Path.GetDirectoryName(mod), "savedata.360"), saveLocation, true);
                                }
                            } catch { ModEngine.skipped.Add($"► {name} (save redirect failed because the save was not targeted for the Xbox 360)"); }
                        } else if (Literal.System() == "PlayStation 3") {
                            try {
                                if (File.Exists(Path.Combine(Path.GetDirectoryName(mod), "savedata.ps3")) && Directory.Exists(Path.GetDirectoryName(saveLocation))) {
                                    if (!File.Exists($"{saveLocation}_back")) {
                                        File.Move(saveLocation, $"{saveLocation}_back");
                                        File.Copy(Path.Combine(Path.GetDirectoryName(mod), "savedata.ps3"), saveLocation, true);
                                    }
                                }
                            } catch { ModEngine.skipped.Add($"► {name} (save redirect failed because the save was not targeted for the PlayStation 3)"); }
                        }
                } else ModEngine.skipped.Add($"► {mod} (save redirect failed because no save data was specified)");
            } else return;
        }

        private void UninstallThread() {
            Label_Status.Text = "Removing modified game data...";
            UninstallMods();
            UninstallCustomFilesystem();
            UninstallSaves();
            Label_Status.Text = "Ready.";
        }

        private void UninstallMods() {
            if (Properties.Settings.Default.GameDirectory != string.Empty) {
                if (!Directory.Exists(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory))) return;

                List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), "*.*", SearchOption.AllDirectories)
                                    .Where(s => s.EndsWith(".arc_back") ||
                                                s.EndsWith(".arc_orig")).ToList();

                foreach (string file in files) {
                    if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                        if (Properties.Settings.Default.Debug) Log = $"Removing: {file}";
                        File.Delete(file.ToString().Remove(file.Length - 5));
                    }
                    File.Move(file, file.ToString().Remove(file.Length - 5));
                }
            }
        }

        private void UninstallCustomFilesystem() {
            if (Properties.Settings.Default.GameDirectory != string.Empty) {
                foreach (ListViewItem mod in ListView_ModsList.Items) {
                    string[] custom = INISerialiser.DeserialiseKey("Custom", mod.SubItems[6].Text).Split(',');

                    if (custom[0] != "N/A") {
                        foreach (string file in custom) { //Search for all files with filters from custom
                            List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), file, SearchOption.AllDirectories).ToList();
                            foreach (string customfile in files)
                                try {
                                    if (Properties.Settings.Default.Debug) Log = $"Removing: {file}";
                                    File.Delete(customfile);
                                } catch { }
                        }
                    }
                }
            }
        }

        private void UninstallSaves() {
            if (Properties.Settings.Default.SaveData != string.Empty) {
                foreach (ListViewItem mod in ListView_ModsList.Items) {
                    string saveLocation = Path.GetDirectoryName(Path.GetDirectoryName(Properties.Settings.Default.SaveData));
                    string savedata = INISerialiser.DeserialiseKey("Save", mod.SubItems[6].Text);

                    if (savedata != "N/A") {
                        if (Literal.Emulator() == "Xenia") {
                            if (!Directory.Exists(Path.GetDirectoryName(Properties.Settings.Default.EmulatorDirectory))) return;

                            string[] saves = Array.Empty<string>();
                            if (Directory.Exists(saveLocation)) saves = Directory.GetDirectories(saveLocation, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);

                            foreach (var file in saves) {
                                string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));

                                if (File.Exists(saveFile)) {
                                    Log = $"Removing: {file}";
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.360"), true);
                                }
                                if (Directory.Exists(file.ToString().Remove(file.Length - 5))) {
                                    Log = $"Removing: {file}";
                                    Directory.Delete(file.ToString().Remove(file.Length - 5), true);
                                }

                                Directory.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                            }
                        } else if (Literal.Emulator() == "RPCS3") {
                            string[] saves = Array.Empty<string>();
                            if (Directory.Exists(saveLocation)) saves = Directory.GetFiles(saveLocation, "SYS-DATA_back", SearchOption.AllDirectories);

                            foreach (var file in saves) {
                                string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));

                                if (File.Exists(saveFile)) {
                                    Log = $"Removing: {file}";
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.ps3"), true);
                                }
                                if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                                    Log = $"Removing: {file}";
                                    File.Delete(file.ToString().Remove(file.Length - 5));
                                }

                                File.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                            }
                        }
                    }
                }
            }
        }

        private void LaunchEmulator(string emulator) {
            if (Properties.Settings.Default.GameDirectory == string.Empty) {
                OpenFileDialog browseGame = new OpenFileDialog() {
                    Title = "Please select an executable for Sonic '06...",
                    Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                };

                if (browseGame.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                    Properties.Settings.Default.Save();
                    LaunchEmulator(Literal.Emulator());
                }
            } else {
                if (Properties.Settings.Default.EmulatorDirectory == string.Empty) {
                    OpenFileDialog browseEmulator = new OpenFileDialog() {
                        Title = $"Please select an executable for {emulator}...",
                        Filter = "Programs (*.exe)|*.exe"
                    };

                    if (browseEmulator.ShowDialog() == DialogResult.OK) {
                        Properties.Settings.Default.EmulatorDirectory = TextBox_EmulatorExecutable.Text = browseEmulator.FileName;
                        Properties.Settings.Default.Save();
                        LaunchEmulator(Literal.Emulator());
                    }
                } else {
                    if (emulator == "Xenia") {
                        List<string> parameters = new List<string>();

                        if (File.Exists(Properties.Settings.Default.GameDirectory)) parameters.Add($"\"{Properties.Settings.Default.GameDirectory}\"");
                        else {
                            OpenFileDialog browseGame = new OpenFileDialog() {
                                Title = "Please select an executable for Sonic '06...",
                                Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                            };

                            if (browseGame.ShowDialog() == DialogResult.OK) {
                                Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text = browseGame.FileName;
                                Properties.Settings.Default.Save();
                                LaunchEmulator(Literal.Emulator());
                            }
                        }

                        if (ComboBox_API.SelectedIndex == 0) {
                            parameters.Add("--gpu=d3d12");
                            if (CheckBox_Xenia_ForceRTV.Checked) parameters.Add("--d3d12_edram_rov=false");
                            if (CheckBox_Xenia_2xResolution.Checked) parameters.Add("--d3d12_resolution_scale=2");
                        } else parameters.Add("--gpu=vulkan");

                        if (!CheckBox_Xenia_VerticalSync.Checked) parameters.Add("--vsync=false");
                        if (CheckBox_Xenia_Gamma.Checked) parameters.Add("--kernel_display_gamma_type=2");
                        if (CheckBox_Xenia_Fullscreen.Checked) parameters.Add("--fullscreen");
                        if (!CheckBox_Xenia_DiscordRPC.Checked) parameters.Add("--discord=false");

                        ProcessStartInfo xeniaProc = new ProcessStartInfo() {
                            FileName = Properties.Settings.Default.EmulatorDirectory,
                            WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.EmulatorDirectory),
                            Arguments = string.Join(" ", parameters.ToArray())
                        };

                        Process xenia = Process.Start(xeniaProc);
                        Label_Status.Text = "Waiting for Xenia exit call...";
                        xenia.WaitForExit();
                        UninstallThread();
                    } else if (emulator == "RPCS3") {
                        ProcessStartInfo rpcs3Proc = new ProcessStartInfo() {
                            FileName = Properties.Settings.Default.EmulatorDirectory,
                            WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.EmulatorDirectory),
                        };

                        Process rpcs3 = Process.Start(rpcs3Proc);
                        Label_Status.Text = "Waiting for RPCS3 exit call...";
                        rpcs3.WaitForExit();
                        UninstallThread();
                    } else {
                        MessageBox.Show("Unable to detect the required emulator for the game's executable. The specified game directory may be invalid.",
                                        "Unable to load...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UninstallThread();
                    }
                }
            }
        }

        private void Button_Open_Click(object sender, EventArgs e) {
            try {
                string location = string.Empty;
                if (sender == Button_Open_ModsDirectory) location = Properties.Settings.Default.ModsDirectory;
                else if (sender == Button_Open_GameDirectory) location = Path.GetDirectoryName(Properties.Settings.Default.GameDirectory);
                else if (sender == Button_Open_EmulatorExecutable) location = Properties.Settings.Default.EmulatorDirectory;
                else if (sender == Button_Open_SaveData) location = Path.GetDirectoryName(Properties.Settings.Default.SaveData);
                Process.Start(location);
            } catch {
                MessageBox.Show("The requested location was invalid or unspecified. Ensure the box is populated.",
                                "Unable to load...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SectionButton_SaveChecks_Click(object sender, EventArgs e) {
            SaveChecks();
            DeserialiseMods();
            CheckDeserialisedMods();
        }

        private void Button_Mods_Selection_Click(object sender, EventArgs e) {
            if (sender == Button_Mods_SelectAll) foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = true;
            else if (sender == Button_Mods_DeselectAll) foreach (ListViewItem item in ListView_ModsList.Items) item.Checked = false;
        }

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
                selectedIndex += 1; // Move index up the list

                ListView_ModsList.Items.Insert(selectedIndex, shiftItem); // Insert checkbox at selectedIndex

                ListView_ModsList.Items[selectedIndex].Selected = true; // Selects the recently moved checkbox
                shiftItem.Checked = check; // Calls the 'check' bool and sets the checked state
            }
        }

        private void ListView_ModsList_SelectedIndexChanged(object sender, EventArgs e) {
            // Enables/disables the Upper Priority button depending on if a checkbox is selected
            Button_UpperPriority.Enabled = ListView_ModsList.SelectedItems.Count > 0 && ListView_ModsList.SelectedItems[0].Index > 0;

            // Enables/disables the Downer Priority button depending on if a checkbox is selected
            Button_DownerPriority.Enabled = ListView_ModsList.SelectedItems.Count > 0 && ListView_ModsList.SelectedItems[0].Index < ListView_ModsList.Items.Count - 1;
        }

        private void LinkLabel_Reset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult confirmation = MessageBox.Show("This will clear all of the settings for Sonic '06 Mod Manager. Are you sure you want to continue?",
                                                        "Sonic '06 Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes) {
                try {
                    string modManagerDataPath = Path.Combine(Program.ApplicationData, "Unify");
                    DirectoryInfo modManagerData = new DirectoryInfo(modManagerDataPath);
                    if (Directory.Exists(modManagerDataPath)) {
                        foreach (FileInfo file in modManagerData.GetFiles()) file.Delete();
                        foreach (DirectoryInfo directory in modManagerData.GetDirectories()) directory.Delete(true);
                    }
                    Application.Exit();
                } catch { }
            }
        }
    }
}
