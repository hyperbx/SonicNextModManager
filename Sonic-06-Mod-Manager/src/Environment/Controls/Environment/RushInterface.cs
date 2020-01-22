using System;
using Ookii.Dialogs;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.ComponentModel;

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

namespace Unify.Environment
{
    public partial class RushInterface : UserControl
    {
        public RushInterface() {
            InitializeComponent();
            LoadSettings();

#if DEBUG   
            Rush_Section_Debug.Visible = true;
#endif

            Label_Version.Text = UnifyEnvironment.VersionNumber;
            Properties.Settings.Default.SettingsSaving += Settings_SettingsSaving;
            TabControl_Rush.Height += 23;
        }

        private void Settings_SettingsSaving(object sender, CancelEventArgs e) { LoadSettings(); }

        private void LoadSettings() {
            // Restore text box strings.
            TextBox_ModsDirectory.Text = Properties.Settings.Default.DefaultDirectory;

            // Restore check box states.
            CheckBox_AutoColour.Checked = Properties.Settings.Default.AutoColour;
            CheckBox_HighContrastText.Checked = Properties.Settings.Default.HighContrastText;

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
        }

#if DEBUG
        public string Log {
            set {
                ListBox_Debug.Items.Add(value);
                Console.WriteLine(value);
            }
        }
#endif

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

        private void Button_ModsDirectory_Click(object sender, EventArgs e) {
            VistaFolderBrowserDialog browseDefault = new VistaFolderBrowserDialog() {
                Description = "Please select a folder...",
                UseDescriptionForTitle = true
            };

            if (browseDefault.ShowDialog() == DialogResult.OK) {
                Properties.Settings.Default.DefaultDirectory = TextBox_ModsDirectory.Text = browseDefault.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void WindowsColourPicker_AccentColour_ButtonClick(object sender, EventArgs e) {
            Properties.Settings.Default.AccentColour = ((Button)sender).BackColor;
            Properties.Settings.Default.Save();
        }

        private void Rush_TabControl_SelectedIndexChanged(object sender, EventArgs e) { TabControl_Rush.SelectedTab.VerticalScroll.Value = 0; }

        private void CheckBox_AutoColour_CheckedChanged(object sender, EventArgs e) {
            if (CheckBox_AutoColour.Checked) {
                int RegistryColour = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", null);
                Properties.Settings.Default.AccentColour = Color.FromArgb(RegistryColour);
            } else Properties.Settings.Default.AccentColour = Color.FromArgb(186, 0, 0);
            Properties.Settings.Default.AutoColour = CheckBox_AutoColour.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBox_HighContrastText_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.HighContrastText = CheckBox_HighContrastText.Checked;
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
                if (ListView_ModsList.FocusedItem.Bounds.Contains(e.Location))
                    ContextMenuStrip_ModMenu.Show(Cursor.Position);
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            Color theme = Color.FromArgb(45, 45, 48);
            e.Graphics.DrawLine(new Pen(Properties.Settings.Default.AccentColour, 1), new Point(0, 21), new Point(Width, 21));
            e.Graphics.FillRectangle(new SolidBrush(theme), e.Bounds);
            var point = new Point(0, 3);
            point.X = e.Bounds.X;

            if (sender == ListView_ModsList) {
                var column = ListView_ModsList.Columns[e.ColumnIndex];
                e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
                point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ListView_ModsList.Font).Width / 2;
                TextRenderer.DrawText(e.Graphics, column.Text, ListView_ModsList.Font, point, ListView_ModsList.ForeColor);
            } else if (sender == ListView_PatchesList) {
                var column = ListView_PatchesList.Columns[e.ColumnIndex];
                e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
                point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ListView_PatchesList.Font).Width / 2;
                TextRenderer.DrawText(e.Graphics, column.Text, ListView_PatchesList.Font, point, ListView_PatchesList.ForeColor);
            }

        }
    }
}
