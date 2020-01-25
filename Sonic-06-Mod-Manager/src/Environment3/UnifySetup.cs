using System;
using Ookii.Dialogs;
using Unify.Messenger;
using Unify.Environment3;
using Unify.Globalisation;
using System.Windows.Forms;

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

namespace Unify
{
    public partial class UnifySetup : Form
    {
        public UnifySetup() {
            InitializeComponent(); // Designer support
            LoadSettings(); // Load user settings

            // Sets the text of the title bar to contain the version number
            Text += $" ({Program.VersionNumber})";
        }

        /// <summary>
        /// Loads all user settings.
        /// </summary>
        private void LoadSettings() {
            TextBox_ModsDirectory.Text = Properties.Settings.Default.ModsDirectory;
            TextBox_GameDirectory.Text = Properties.Settings.Default.GameDirectory;
            TextBox_EmulatorExecutable.Text = Properties.Settings.Default.EmulatorDirectory;
            TextBox_SaveData.Text = Properties.Settings.Default.SaveData;
            CheckBox_LaunchEmulator.Checked = Properties.Settings.Default.LaunchEmulator;
        }

        /// <summary>
        /// Asks for confirmation before closing the setup window.
        /// </summary>
        private void UnifySetup_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog("Are you sure you want to skip the first time setup?",
                                                                                   "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // Cancel event if user doesn't want to skip
                if (confirmation == DialogResult.No) e.Cancel = true;
                else {
                    Properties.Settings.Default.FirstLaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// Saves the settings, unsubscribes from the FormClosing event and closes the form.
        /// </summary>
        private void Button_Continue_Click(object sender, EventArgs e) {
            Properties.Settings.Default.ModsDirectory = TextBox_ModsDirectory.Text;
            Properties.Settings.Default.GameDirectory = TextBox_GameDirectory.Text;
            Properties.Settings.Default.EmulatorDirectory = TextBox_EmulatorExecutable.Text;
            Properties.Settings.Default.SaveData = TextBox_SaveData.Text;
            Properties.Settings.Default.LaunchEmulator = CheckBox_LaunchEmulator.Checked;

            // If something was changed, unsubscribe from event.
            if (TextBox_ModsDirectory.Text      != string.Empty ||
                TextBox_GameDirectory.Text      != string.Empty ||
                TextBox_EmulatorExecutable.Text != string.Empty ||
                TextBox_SaveData.Text           != string.Empty ||
                CheckBox_LaunchEmulator.Checked != true) {
                    Properties.Settings.Default.FirstLaunch = false;
                    Properties.Settings.Default.Save();
                    FormClosing -= UnifySetup_FormClosing;
            }      

            Close(); // Close the form
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

                if (browseMods.ShowDialog() == DialogResult.OK) TextBox_ModsDirectory.Text = browseMods.SelectedPath;
            } else if (sender == Button_GameDirectory) {
                // Browse for game executables
                OpenFileDialog browseGame = new OpenFileDialog() {
                    Title = "Please select an executable for Sonic '06...",
                    Filter = "Xbox Executable (*.xex)|*.xex|PlayStation Executable (*.bin)|*.bin"
                };

                if (browseGame.ShowDialog() == DialogResult.OK) TextBox_GameDirectory.Text = browseGame.FileName;
            } else if (sender == Button_EmulatorExecutable) {
                // Browse for emulator executables
                OpenFileDialog browseEmulator = new OpenFileDialog() {
                    Title = $"Please select an executable for {Literal.Emulator()}...",
                    Filter = "Programs (*.exe)|*.exe"
                };

                if (browseEmulator.ShowDialog() == DialogResult.OK) TextBox_EmulatorExecutable.Text = browseEmulator.FileName;
            } else if (sender == Button_SaveData) {
                // Browse for save data
                OpenFileDialog browseSave = new OpenFileDialog() {
                    Title = $"Please select Sonic '06 save data...",
                    Filter = "Xbox 360 Save File (SonicNextSaveData.bin)|SonicNextSaveData.bin|PlayStation 3 Save File (SYS-DATA)|SYS-DATA"
                };

                if (browseSave.ShowDialog() == DialogResult.OK) TextBox_SaveData.Text = browseSave.FileName;
            }
        }
    }
}
