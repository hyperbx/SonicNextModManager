using System;
using System.Diagnostics;
using System.Windows.Forms;

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

namespace Sonic_06_Mod_Manager
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lbl_versionNumber.Text = ModManager.versionNumber;
        }

        private void Btn_GitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Knuxfan24/Sonic-06-Mod-Manager");
        }

        private void Pic_Logo_Click(object sender, EventArgs e)
        {
            var sfd_SaveLogo = new SaveFileDialog();
            sfd_SaveLogo.Title = "Save As";
            sfd_SaveLogo.Filter = "PNG|*.png";

            if (sfd_SaveLogo.ShowDialog() == DialogResult.OK)
            {
                Properties.Resources.logo_main.Save(sfd_SaveLogo.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Restart();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Knuxfan24");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/HyperPolygon64");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/sharu6262");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ModManager.serverStatus == "offline") MessageBox.Show("Unable to establish a connection to SEGA Carnival.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ModManager.serverStatus == "down") MessageBox.Show("The update servers are currently undergoing maintenance. Apologies for the inconvenience.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ModManager.updateState = "user";
                ModManager.CheckForUpdates(ModManager.versionNumber, "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe", "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt");
            }
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/user/Melpontro");
        }

        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UC35wsF1NUwoUWmw2DLz6uJg");
        }
    }
}
