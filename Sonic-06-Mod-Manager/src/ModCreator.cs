﻿using System;
using System.IO;
using Unify.Tools;
using System.Text;
using Unify.Messages;
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
    public partial class ModCreator : Form
    {
        string modThumbnail = string.Empty;
        string modPath = string.Empty;
        bool edit = false;

        public ModCreator(string modPath, bool edit)
        {
            InitializeComponent();
            this.modPath = modPath;
            this.edit = edit;

            combo_System.SelectedIndex = 0;

            if (Properties.Settings.Default.theme) {
                pic_Thumbnail.BackColor = Color.FromArgb(45, 45, 48);
                check_Merge.ForeColor = SystemColors.Control;
                BackColor = Color.FromArgb(28, 28, 28);
                group_DescriptionField.BackColor = Color.FromArgb(45, 45, 48); group_DescriptionField.ForeColor = SystemColors.Control;
                tb_Description.BackColor = Color.FromArgb(45, 45, 48); tb_Description.ForeColor = SystemColors.Control;
                btn_RemoveThumbnail.BackColor = SystemColors.ControlLightLight;

                foreach (Control x in this.Controls)
                {
                    if (x is Label)
                    {
                        ((Label)x).ForeColor = SystemColors.Control;
                    }

                    if (x is TextBox)
                    {
                        ((TextBox)x).BackColor = Color.FromArgb(45, 45, 48);
                        ((TextBox)x).ForeColor = SystemColors.Control;
                    }
                }
            }

            if (edit)
            {
                using (StreamReader configFile = new StreamReader($"{Path.Combine(modPath)}\\mod.ini", Encoding.Default))
                {
                    string line;
                    string entryValue;
                    while ((line = configFile.ReadLine()) != null)
                    {
                        if (line.StartsWith("Title"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            text_Title.Text = entryValue;
                        }
                        if (line.StartsWith("Version"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            text_Version.Text = entryValue;
                        }
                        if (line.StartsWith("Date"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            text_Date.Text = entryValue;
                        }
                        if (line.StartsWith("Author"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            text_Author.Text = entryValue;
                        }
                        if (line.StartsWith("Platform"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            combo_System.SelectedText = entryValue;
                        }
                        if (line.StartsWith("Merge"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            check_Merge.Checked = bool.Parse(entryValue);
                            if (check_Merge.Checked)
                            {
                                text_ReadOnly.Enabled = true;
                                btn_ReadOnlyBrowser.Enabled = true;

                                if (!Properties.Settings.Default.theme)
                                    lbl_ReadOnly.ForeColor = SystemColors.ControlText;
                                else
                                    lbl_ReadOnly.ForeColor = SystemColors.Control;
                            }
                        }
                        if (line.StartsWith("Read-only"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            text_ReadOnly.Text = entryValue;
                        }
                        if (line.StartsWith("Description"))
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            tb_Description.Text += entryValue;
                        }
                    }
                }
                btn_Create.Text = "Edit Mod";
                btn_Create.BackColor = Color.SkyBlue;

                string[] getThumbnail = Directory.GetFiles(modPath, "thumbnail*", SearchOption.TopDirectoryOnly);
                foreach (var img in getThumbnail)
                    pic_Thumbnail.BackgroundImage = Image.FromFile(img);
            }

            if (!edit) lbl_ReadOnly.ForeColor = SystemColors.GrayText;
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return !string.IsNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidPathChars()) >= 0;
        }
        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (!FilePathHasInvalidChars(text_Title.Text))
            {
                if (Directory.Exists(Path.Combine(Properties.Settings.Default.modsDirectory, text_Title.Text)) && !edit)
                {
                    MessageBox.Show($"A mod called '{text_Title.Text}' already exists.", "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string newPath = Path.Combine(Properties.Settings.Default.modsDirectory, text_Title.Text);

                    if (!edit)
                        Directory.CreateDirectory(newPath);
                    else
                        if (!Directory.Exists(newPath))
                        Directory.Move(modPath, newPath);

                    using (Stream configCreate = File.Open(Path.Combine(newPath, "mod.ini"), FileMode.Create))
                    using (StreamWriter configInfo = new StreamWriter(configCreate))
                    {
                        configInfo.WriteLine($"Title=\"{text_Title.Text}\"");
                        if (text_Version.Text != string.Empty) configInfo.WriteLine($"Version=\"{text_Version.Text}\"");
                        if (text_Date.Text != string.Empty) configInfo.WriteLine($"Date=\"{text_Date.Text}\"");
                        if (text_Author.Text != string.Empty) configInfo.WriteLine($"Author=\"{text_Author.Text}\"");
                        configInfo.WriteLine($"Platform=\"{combo_System.Text}\"");
                        configInfo.WriteLine($"Merge=\"{check_Merge.Checked.ToString()}\"");
                        if (text_ReadOnly.Text != string.Empty) configInfo.WriteLine($"Read-only=\"{text_ReadOnly.Text}\"");
                        if (tb_Description.Text != string.Empty) configInfo.WriteLine($"Description=\"{tb_Description.Text}\"");
                        configInfo.Close();
                    }

                    if (File.Exists(modThumbnail))
                        File.Copy(modThumbnail, Path.Combine(newPath, $"thumbnail{Path.GetExtension(modThumbnail)}"));

                    if (modThumbnail == string.Empty && edit) {
                        try {
                        string[] getThumbnail = Directory.GetFiles(newPath, "thumbnail*", SearchOption.TopDirectoryOnly);
                        foreach (var img in getThumbnail)
                            if (File.Exists(img)) File.Delete(img);
                        }
                        catch (Exception ex) { MessageBox.Show($"{ModsMessages.msg_ThumbnailDeleteError}\n\n{ex}", ModsMessages.tl_FileError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }

                    Close();
                }
            }
        }

        private void Text_Title_TextChanged(object sender, EventArgs e)
        {
            if (text_Title.Text != string.Empty)
                btn_Create.Enabled = true;
            else
                btn_Create.Enabled = false;
        }

        private void Check_Merge_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Merge.Checked) {
                text_ReadOnly.Enabled = true;
                btn_ReadOnlyBrowser.Enabled = true;

                if (!Properties.Settings.Default.theme)
                    lbl_ReadOnly.ForeColor = SystemColors.ControlText;
                else
                    lbl_ReadOnly.ForeColor = SystemColors.Control;
            }
            else {
                text_ReadOnly.Enabled = false;
                btn_ReadOnlyBrowser.Enabled = false;
                lbl_ReadOnly.ForeColor = SystemColors.GrayText;
            }
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog thumbnail = new OpenFileDialog
            {
                Title = "Please search for a thumbnail...",
                Filter = "PNG (*.png)|*.png|JPEG (*.jpg; *.jpeg; *.jpe; *.jfif)|*.jpg; *.jpeg; *.jpe; *.jfif|BMP (*.bmp)|*.bmp"
            };

            if (thumbnail.ShowDialog() == DialogResult.OK) { 
                pic_Thumbnail.BackgroundImage = new Bitmap(thumbnail.FileName);
                modThumbnail = thumbnail.FileName;
            }
        }

        private void Btn_ReadOnlyBrowser_Click(object sender, EventArgs e) {
            string files = Locations.LocateARCs();

            if (files != string.Empty) {
                if (text_ReadOnly.Text != string.Empty && !text_ReadOnly.Text.EndsWith(","))
                    text_ReadOnly.Text += $",{files.Substring(0, files.Length - 1)}";
                else
                    text_ReadOnly.Text += files.Substring(0, files.Length - 1);
            }
        }

        private void Btn_RemoveThumbnail_Click(object sender, EventArgs e) {
            pic_Thumbnail.BackgroundImage.Dispose();
            pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception;
            modThumbnail = string.Empty;
        }
    }
}