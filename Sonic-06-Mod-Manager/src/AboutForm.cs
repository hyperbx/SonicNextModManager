using System;
using System.Media;
using Unify.Messages;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

// Project Unify is licensed under the MIT License:
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

namespace Sonic_06_Mod_Manager.src
{
    public partial class AboutForm : Form
    {
        public AboutForm(string versionNumber)
        {
            InitializeComponent();
            Size = new Size(717, 425);
            lbl_versionNumber.Text = versionNumber;

            if (ModManager.dreamcastDay) {
                Text = "Happy birthday, Dreamcast!";
                if (Properties.Settings.Default.dream) {
                    Icon = Properties.Resources.dreamcast_ntsc_icon;
                    pic_Logo.BackgroundImage = Properties.Resources.dreamcast_ntsc;
                } else {
                    Icon = Properties.Resources.dreamcast_pal_icon;
                    pic_Logo.BackgroundImage = Properties.Resources.dreamcast_pal;
                }
            } else if (ModManager.debugMode) {
                lbl_Title.Text = SystemMessages.tl_DefaultTitle;
                pic_Logo.BackgroundImage = Properties.Resources.logo_aldi;
            }

            if (ModManager.christmas) {
                Icon = Properties.Resources.icon_christmas;
                pic_Logo.BackgroundImage = Properties.Resources.logo_main_christmas;
            }

            if (Properties.Settings.Default.theme) {
                pic_Logo.BackColor = Color.FromArgb(45, 45, 48);
                BackColor = Color.FromArgb(28, 28, 28);

                foreach (Control x in Container_About.Panel2.Controls) {
                    if (x is Label)
                        ((Label)x).ForeColor = SystemColors.Control;
                    if (x is LinkLabel)
                        ((LinkLabel)x).LinkColor = SystemColors.Control;
                }
            }
        }

        private void Link_Knuxfan24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://github.com/Knuxfan24"); }
        //Rich money.

        private void Link_Hyper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://github.com/HyperPolygon64"); }
        //lol

        private void Link_SuperSonic16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://github.com/thesupersonic16"); }
        //Great programmer who can code, he thinks.

        private void Link_SEGACarnival_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://www.segacarnival.com/forum/index.php"); }
        //Great community with great people, what's there more to ask?

        private void Link_Nonami_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://www.youtube.com/channel/UC35wsF1NUwoUWmw2DLz6uJg"); }
        //Moyai.

        private void Link_sharu6262_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://twitter.com/sharu6262"); }
        //Speedrunner that speedruns things.

        private void Link_Melpontro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://www.youtube.com/user/Melpontro"); }
        //The humble rights holder to Pelé.

        private void Link_acro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://gamebanana.com/members/1447045"); }
        //Bellend. =P

        private void Link_ChaosX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://twitter.com/ChaosX2006"); }
        //Never heard of 'em.

        private void Pic_Logo_Click(object sender, System.EventArgs e) {
            if (ModManager.dreamcastDay) {
                SoundPlayer dreamLaunch = new SoundPlayer(Properties.Resources.dreamLaunch);
                dreamLaunch.Play();
            } else if (ModManager.christmas) {
                int getRandomBell = new Random().Next(1, 19);
                SoundPlayer bell = new SoundPlayer();

                switch (getRandomBell) {
                    case 1: bell = new SoundPlayer(Properties.Resources.bell01); break;
                    case 2: bell = new SoundPlayer(Properties.Resources.bell02); break;
                    case 3: bell = new SoundPlayer(Properties.Resources.bell04); break;
                    case 5: bell = new SoundPlayer(Properties.Resources.bell05); break;
                    case 6: bell = new SoundPlayer(Properties.Resources.bell06); break;
                    case 7: bell = new SoundPlayer(Properties.Resources.bell07); break;
                    case 8: bell = new SoundPlayer(Properties.Resources.bell08); break;
                    case 9: bell = new SoundPlayer(Properties.Resources.bell09); break;
                    case 10: bell = new SoundPlayer(Properties.Resources.bell10); break;
                    case 11: bell = new SoundPlayer(Properties.Resources.bell11); break;
                    case 12: bell = new SoundPlayer(Properties.Resources.bell12); break;
                    case 13: bell = new SoundPlayer(Properties.Resources.bell13); break;
                    case 14: bell = new SoundPlayer(Properties.Resources.bell14); break;
                    case 15: bell = new SoundPlayer(Properties.Resources.bell15); break;
                    case 16: bell = new SoundPlayer(Properties.Resources.bell16); break;
                    case 17: bell = new SoundPlayer(Properties.Resources.bell17); break;
                    case 18: bell = new SoundPlayer(Properties.Resources.bell18); break;
                    case 19: bell = new SoundPlayer(Properties.Resources.bell19); break;
                    case 20: bell = new SoundPlayer(Properties.Resources.bell20); break;
                }

                bell.Play();
            }
        }

        private void Link_Velcomia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://www.youtube.com/user/Velcomia"); }
        //The ultimate bug hunter.

        private void link_Mefiresu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://twitter.com/Mefiresu"); }
        //Debug Mode developer.

        private void link_GerbilSoft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { Process.Start("https://github.com/GerbilSoft"); }
        //Helped unfuck the .NET WebClient
    }
}
