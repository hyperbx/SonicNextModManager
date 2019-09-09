using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

// Project Unify is licensed under the MIT License:
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

namespace Sonic_06_Mod_Manager.src
{
    public partial class ModInfo : Form
    {
        public ModInfo(string modPath) {
            InitializeComponent();

             if (ModManager.dreamcastDay) {
                if (Properties.Settings.Default.dream)
                    Icon = Properties.Resources.dreamcast_ntsc_icon;
                else
                    Icon = Properties.Resources.dreamcast_pal_icon;
            }

            if (Properties.Settings.Default.theme) {
                lbl_Title.ForeColor = SystemColors.Control;
                pnl_Backdrop.BackColor = Color.FromArgb(59, 59, 63);
                pic_Thumbnail.BackColor = Color.FromArgb(45, 45, 48);
                BackColor = Color.FromArgb(28, 28, 28);
                tb_Description.BackColor = Color.FromArgb(45, 45, 48); tb_Description.ForeColor = SystemColors.Control;
                tb_Information.BackColor = Color.FromArgb(45, 45, 48); tb_Information.ForeColor = SystemColors.Control;
            }

            string[] getThumbnail = Directory.GetFiles(modPath, "thumbnail*", SearchOption.TopDirectoryOnly);
            foreach (var img in getThumbnail)
                pic_Thumbnail.BackgroundImage = Image.FromFile(img);

            using (StreamReader configFile = new StreamReader($"{Path.Combine(modPath)}\\mod.ini", Encoding.Default)) {
                string line;
                string entryValue;
                while ((line = configFile.ReadLine()) != null) {
                    if (line.StartsWith("Title")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        lbl_Title.Text = entryValue;
                        Text = entryValue;
                    }
                    if (line.StartsWith("Version")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Version: {entryValue}\n";
                    }
                    if (line.StartsWith("Date")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Date: {entryValue}\n";
                    }
                    if (line.StartsWith("Author")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Author: {entryValue}\n";
                    }
                    if (line.StartsWith("Platform")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Platform: {entryValue}\n";
                    }
                    if (line.StartsWith("Merge")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Merge: {entryValue}\n";
                    }
                    if (line.StartsWith("Description"))
                    {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Description.Text += entryValue;
                    }
                }
            }

            if (lbl_Title.Width >= MinimumSize.Width) {
                Width = lbl_Title.Width + 110;
                MinimumSize = new Size(Width, Height);
            }
        }

        private void ModInfo_FormClosing(object sender, FormClosingEventArgs e) { pic_Thumbnail.BackgroundImage.Dispose(); }
    }
}
