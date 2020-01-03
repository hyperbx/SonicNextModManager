using System;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

// Protocol Manager is licensed under the MIT License:
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

namespace Protocol_Manager
{
    public partial class Main : Form
    {
        public static bool theme = false;
        public static string protocol = "sonic06mm";
        public static string modManager = string.Empty;
        public static RegistryKey sonic06mmKey = Registry.ClassesRoot.OpenSubKey($"{protocol}\\shell\\open\\command");

        public Main(string[] args) {
            InitializeComponent();
            try {
                if (File.Exists(args[0])) modManager = args[0];
                theme = bool.Parse(args[1]);
            } catch {
                modManager = string.Empty;
                theme = false;
            }

            if (theme) {
                lbl_Title.ForeColor = SystemColors.Control;
                pnl_Backdrop.BackColor = Color.FromArgb(59, 59, 63);
                BackColor = Color.FromArgb(28, 28, 28);
                lbl_StatusText.ForeColor = lbl_ValidText.ForeColor = SystemColors.Control;
            }

            CheckRegistry();
        }

        private void CheckRegistry() {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(protocol, false); // Open the Sonic '06 Mod Manager protocol key
            RegistryKey getLocation = Registry.ClassesRoot.OpenSubKey($"{protocol}\\shell\\open\\command");

            if (key == null) { // If the key does not exist, keep the checkbox unchecked.
                lbl_Status.Text = "Not Installed";
                lbl_Valid.Text = "Unknown";
                lbl_Status.ForeColor = lbl_Valid.ForeColor = Color.Tomato;
                btn_Install.Text = "Install";
                btn_Install.Enabled = true;
                btn_Uninstall.Enabled = false;
                help_Invalid.Visible = false;
            } else {
                if (getLocation.GetValue(null).ToString() != $"\"{modManager}\" \"-banana\" \"%1\"") {
                    lbl_Status.Text = "Installed";
                    lbl_Valid.Text = "Invalid";
                    lbl_Status.ForeColor = Color.LimeGreen;
                    lbl_Valid.ForeColor = Color.Tomato;
                    btn_Install.Text = "Update";
                    btn_Install.Enabled = true;
                    btn_Uninstall.Enabled = true;
                    help_Invalid.Visible = true;
                } else {
                    lbl_Status.Text = "Installed";
                    lbl_Valid.Text = "Valid";
                    lbl_Status.ForeColor = lbl_Valid.ForeColor = Color.LimeGreen;
                    btn_Install.Text = "Install";
                    btn_Install.Enabled = false;
                    btn_Uninstall.Enabled = true;
                    help_Invalid.Visible = false;
                }
            }
        }

        private void btn_Install_Click(object sender, EventArgs e) {
            sonic06mmKey = Registry.ClassesRoot.OpenSubKey(protocol, true);
            if (sonic06mmKey == null)
                sonic06mmKey = Registry.ClassesRoot.CreateSubKey(protocol);
            sonic06mmKey.SetValue("", "URL:Sonic '06 Mod Manager");
            sonic06mmKey.SetValue("URL Protocol", "");
            var prevkey = sonic06mmKey;
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

            sonic06mmKey.SetValue("", $"\"{modManager}\" \"-banana\" \"%1\"");
            sonic06mmKey.Close();

            CheckRegistry();
        }

        private void btn_Uninstall_Click(object sender, EventArgs e) {
            var CurrentUser = Registry.ClassesRoot;
            CurrentUser.DeleteSubKeyTree(protocol, false);
            CurrentUser.Close();

            CheckRegistry();
        }

        private void help_Invalid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("If you launched Protocol Manager manually and not through Sonic '06 Mod Manager, this will always be invalid.\n\n" +
                            "" +
                            "If otherwise, please update your protocol.",
                            "Invalid Protocol", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (modManager != string.Empty) Process.Start(modManager);
            } catch {
                MessageBox.Show("Failed to launch Sonic '06 Mod Manager... Please run it manually.",
                                "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
