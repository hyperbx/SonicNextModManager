using System;
using System.IO;
using System.Drawing;
using Unify.Messenger;
using Unify.Serialisers;
using Unify.Environment3;
using System.Windows.Forms;
using System.Diagnostics;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperBE32

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

            // Initialise immersive dark mode.
            ImmersiveDarkMode.Initialise(Handle, true);

            LoadSettings(); // Load user settings

            // Sets the text of the title bar to contain the version number
            Text += $" ({Program.VersionNumber})";
        }

        /// <summary>
        /// Loads all user settings.
        /// </summary>
        private void LoadSettings() {
            TextBox_ModsDirectory.Text      = Properties.Settings.Default.Path_ModsDirectory;
            TextBox_GameDirectory.Text      = Properties.Settings.Default.Path_GameExecutable;
            TextBox_EmulatorExecutable.Text = Properties.Settings.Default.Path_EmulatorDirectory;
            CheckBox_LaunchEmulator.Checked = Properties.Settings.Default.General_LaunchEmulator;
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
                    Properties.Settings.Default.General_FirstLaunch = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// Saves the settings, unsubscribes from the FormClosing event and closes the form.
        /// </summary>
        private void Button_Continue_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Path_ModsDirectory     = TextBox_ModsDirectory.Text;
            Properties.Settings.Default.Path_GameExecutable    = TextBox_GameDirectory.Text;
            Properties.Settings.Default.Path_EmulatorDirectory = TextBox_EmulatorExecutable.Text;
            Properties.Settings.Default.General_LaunchEmulator = CheckBox_LaunchEmulator.Checked;

            // If something was changed, unsubscribe from event.
            if (TextBox_ModsDirectory.Text      != string.Empty ||
                TextBox_GameDirectory.Text      != string.Empty ||
                TextBox_EmulatorExecutable.Text != string.Empty ||
                CheckBox_LaunchEmulator.Checked != true) {
                    Properties.Settings.Default.General_FirstLaunch = false;
                    Properties.Settings.Default.Save();
                    FormClosing -= UnifySetup_FormClosing;
            }    

            if (!Program.CheckJava())
            {
                DialogResult javaWarning = UnifyMessenger.UnifyMessage.ShowDialog("No Java installation was found.\n" +
                                                                                  "Some patch scripts require Java to alter game logic in Lua scripts.\n" +
                                                                                  "Please install Java and restart your computer...",
                                                                                  "Java Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Close(); // Close the form
        }

        /// <summary>
        /// Defines what browser should be used by sender.
        /// </summary>
        private void Button_Browse_Click(object sender, EventArgs e) {
            if (sender == Button_ModsDirectory) {
                // Browse for mods directory
                string browseMods = Dialogs.ModsDirectory();

                if (browseMods != string.Empty)
                    TextBox_ModsDirectory.Text = browseMods;

                if (Paths.CheckFileLegitimacy(TextBox_GameDirectory.Text))
                    if (Paths.IsSubdirectory(browseMods, Path.GetDirectoryName(TextBox_GameDirectory.Text)) ||
                        browseMods == Path.GetDirectoryName(TextBox_GameDirectory.Text))

                        // If the mods directory is inside the game directory, warn the user
                        Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                    else
                        Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;
            } else if (sender == Button_GameDirectory) {
                // Browse for game executables
                string browseGame = Dialogs.GameExecutable();

                if (browseGame != string.Empty)
                    TextBox_GameDirectory.Text = browseGame;

                if (Paths.CheckPathLegitimacy(TextBox_ModsDirectory.Text))
                    if (Paths.IsSubdirectory(Path.GetDirectoryName(browseGame), TextBox_ModsDirectory.Text) ||
                        Path.GetDirectoryName(browseGame) == TextBox_ModsDirectory.Text)

                        // If the mods directory is inside the game directory, warn the user
                        Label_Warning_ModsDirectoryInvalid.ForeColor = Color.Tomato;
                    else
                        Label_Warning_ModsDirectoryInvalid.ForeColor = SystemColors.ControlDark;
            } else if (sender == Button_EmulatorExecutable) {
                // Browse for emulator executables
                string browseEmulator = Dialogs.EmulatorExecutable();

                if (browseEmulator != string.Empty)
                    TextBox_EmulatorExecutable.Text = browseEmulator;
            }
        }

        private void LinkLabel_Wiki_Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Knuxfan24/Sonic-06-Mod-Manager/wiki/First-Time-Setup");
        }
    }
}
