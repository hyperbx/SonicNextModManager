using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;
using Unify.Messenger;
using Unify.Serialisers;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

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

namespace Unify.Environment3
{
    public partial class PatchCreator : Form
    {
        string patch = string.Empty;
        bool edit = false;

        public PatchCreator(string patch, bool edit)
        {
            InitializeComponent();

            // Initialise immersive dark mode.
            ImmersiveDarkMode.Initialise(Handle, true);

            this.patch = patch;
            this.edit = edit;
            if (!this.edit) {
                text_Author.Text = Environment.UserName;
                combo_System.SelectedIndex = 0;
            }

            unifytb_PatchCreator.ActiveColor = unifytb_PatchCreator.HorizontalLineColor = Properties.Settings.Default.General_AccentColour;
            if (Properties.Settings.Default.General_HighContrastText) unifytb_PatchCreator.SelectedTextColor = SystemColors.ControlText;

            if (edit) {
                Text = "Patch Editor";
                if (File.Exists(patch)) {
                    text_Title.Text = Lua.DeserialiseParameter("Title", patch, true);
                    text_Author.Text = Lua.DeserialiseParameter("Author", patch, true);

                    switch (Lua.DeserialiseParameter("Platform", patch, true)) {
                        case "Xbox 360":
                            combo_System.SelectedIndex = 0;
                            break;
                        case "PlayStation 3":
                            combo_System.SelectedIndex = 1;
                            break;
                        case "All Systems":
                            combo_System.SelectedIndex = 2;
                            break;
                        default:
                            combo_System.SelectedIndex = 0;
                            break;
                    }

                    text_Blurb.Text = Lua.DeserialiseParameter("Blurb", patch, true);
                    tb_Description.Text += Lua.DeserialiseParameter("Description", patch, true).Replace(@"\n", Environment.NewLine);
                }
                else { Close(); }

                btn_Create.Text = "Edit Patch";
                btn_Create.BackColor = Color.SkyBlue;
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try {
                string safeTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Literal.UseSafeFormattedCharacters(text_Title.Text)).Replace(" ", "");

                if (File.Exists($"{Path.Combine(Program.Patches, safeTitle)}.mlua") && !edit)
                    UnifyMessenger.UnifyMessage.ShowDialog($"A patch called '{text_Title.Text}' already exists. Please rename your patch.",
                                                           "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    string newPath = $"{Path.Combine(Program.Patches, safeTitle)}.mlua";

                    if (!edit) {
                        using (Stream configCreate = File.Open(newPath, FileMode.Create))
                            using (StreamWriter configInfo = new StreamWriter(configCreate)) {
                                                                      configInfo.WriteLine("--[Patch]--");
                                                                      configInfo.WriteLine($"Title(\"{text_Title.Text}\")");
                                if (text_Author.Text != string.Empty) configInfo.WriteLine($"Author(\"{text_Author.Text}\")");
                                                                      configInfo.WriteLine($"Platform(\"{combo_System.Text}\")");
                                if (text_Blurb.Text != string.Empty)  configInfo.WriteLine($"Blurb(\"{text_Blurb.Text}\")");

                                if (tb_Description.Text != string.Empty) {
                                    string descriptionText = string.Empty;
                                    string lastLine = tb_Description.Lines.Last();
                                    foreach (var newLine in tb_Description.Lines) {
                                        if (newLine != lastLine) descriptionText += $"{newLine}\\n";
                                        else descriptionText += newLine;
                                    }
                                    configInfo.WriteLine($"Description(\"{descriptionText}\")");
                                }

                                configInfo.WriteLine("\n--[Functions]--");
                                configInfo.Close();
                            }

                        try { Process.Start(newPath); }
                        catch {
                            UnifyMessenger.UnifyMessage.ShowDialog($"Please associate the MLUA format with your text editor of choice.",
                                                                   "Unable to load patch...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Process.Start(Program.Patches);
                        }
                    } else {
                        // Backup functions from edited patch
                        List<string> patch = new List<string>();
                        using (StreamReader patchScript = new StreamReader(this.patch, Encoding.Default)) {
                            string line;
                            bool functionsReached = false;
                            while ((line = patchScript.ReadLine()) != null) {
                                if (line.StartsWith("--[Functions]--")) functionsReached = true;
                                if (functionsReached) patch.Add(line);
                            }
                        }

                        File.Delete(this.patch);

                        using (Stream configOpen = File.Open(newPath, FileMode.Create))
                            using (StreamWriter configInfo = new StreamWriter(configOpen)) {
                                                                      configInfo.WriteLine("--[Patch]--");
                                                                      configInfo.WriteLine($"Title(\"{text_Title.Text}\")");
                                if (text_Author.Text != string.Empty) configInfo.WriteLine($"Author(\"{text_Author.Text}\")");
                                                                      configInfo.WriteLine($"Platform(\"{combo_System.Text}\")");
                                if (text_Blurb.Text != string.Empty)  configInfo.WriteLine($"Blurb(\"{text_Blurb.Text}\")");

                                if (tb_Description.Text != string.Empty) {
                                    string descriptionText = string.Empty;
                                    string lastLine = tb_Description.Lines.Last();
                                    foreach (var newLine in tb_Description.Lines) {
                                        if (newLine != lastLine) descriptionText += $"{newLine}\\n";
                                        else descriptionText += newLine;
                                    }
                                    configInfo.WriteLine($"Description(\"{descriptionText}\")");
                                }

                                // Write stored functions to patch
                                configInfo.WriteLine();
                                foreach (string function in patch) configInfo.WriteLine(function);

                                configInfo.Close();
                            }
                    }

                    Close();
                }
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog($"Failed to edit '{text_Title.Text}.'",
                                                       "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void text_Title_TextChanged(object sender, EventArgs e) {
            if (text_Title.Text != string.Empty)
                btn_Create.Enabled = true;
            else
                btn_Create.Enabled = false;
        }
    }
}
