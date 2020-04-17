using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperPolygon64

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
    public partial class SectionButton : UserControl
    {
        private Bitmap sectionImage = Properties.Resources.Refresh_grey_16x;
        private string sectionText = "None";
        private bool selectedSection = false;
        private Color accentColour = Properties.Settings.Default.General_AccentColour;
        private Color textColour = SystemColors.Control;

        [Category("Images"), Browsable(true), Description("The image used for the section.")]
        public Bitmap SectionImage {
            get { return this.sectionImage; }
            set { this.sectionImage = value; }
        }

        [Category("Options"), Browsable(true), Description("The text used for the section.")]
        public string SectionText {
            get { return this.sectionText; }
            set { this.sectionText = value; }
        }

        [Category("Options"), Browsable(true), Description("Displays the selected cursor when enabled.")]
        public bool SelectedSection {
            get { return this.selectedSection; }
            set { Selected.Visible = this.selectedSection = value; }
        }

        [Category("Options"), Browsable(true), Description("Displays the selected cursor when enabled.")]
        public Color AccentColour {
            get { return this.accentColour; }
            set { Selected.BackColor = this.accentColour = value; }
        }

        public SectionButton() { InitializeComponent(); }

        private void SectionButton_MouseEnter(object sender, EventArgs e) { BackColor = Color.FromArgb(48, 48, 51); }

        private void SectionButton_MouseLeave(object sender, EventArgs e) { BackColor = Color.FromArgb(42, 42, 45); }

        private void SectionButton_MouseDown(object sender, MouseEventArgs e) { BackColor = Color.FromArgb(58, 58, 61); }

        private void SectionButton_MouseUp(object sender, MouseEventArgs e) {
            BackColor = Color.FromArgb(48, 48, 51);
            Selected.BackColor = AccentColour = Properties.Settings.Default.General_AccentColour;
            Selected.Visible = selectedSection;
        }

        public Color TextColour {
            get { return this.textColour; }
            set {
                this.textColour = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics Drawer = e.Graphics;
            Drawer.SmoothingMode = SmoothingMode.HighQuality;
            Drawer.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Drawer.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Drawer.DrawString(sectionText, Font, new SolidBrush(TextColour), 40, 10);
            Drawer.DrawImage(sectionImage, 10, 10);
        }

        private void SectionButton_EnabledChanged(object sender, EventArgs e) {
            if (Enabled) {
                TextColour = SystemColors.Control;
                BackColor = Color.FromArgb(42, 42, 45);
            } else {
                TextColour = SystemColors.GrayText;
                BackColor = Color.FromArgb(32, 32, 35);
            }
            Refresh();
        }
    }
}
