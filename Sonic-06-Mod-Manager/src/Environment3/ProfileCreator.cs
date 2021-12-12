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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unify.Environment3
{
    public partial class ProfileCreator : Form
    {
        public ProfileCreator(ListView modsList, ListView patchesList)
        {
            InitializeComponent();

            // Initialise immersive dark mode.
            ImmersiveDarkMode.Initialise(Handle, true);

            // Set theme colours
            unifytb_ProfileCreator.ActiveColor =
            unifytb_ProfileCreator.HorizontalLineColor =
            Properties.Settings.Default.General_AccentColour;

            // Set contrast colour
            if (Properties.Settings.Default.General_HighContrastText)
                unifytb_ProfileCreator.SelectedTextColor = SystemColors.ControlText;

            Mods = modsList;
            Patches = patchesList;
        }

        ListView Mods, Patches;

        /// <summary>
        /// Makes the title box the active control on form load.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            ActiveControl = text_Title;

            base.OnLoad(e);
        }

        /// <summary>
        /// Enables/disables the create button depending on the text input.
        /// </summary>
        private void text_Title_TextChanged(object sender, EventArgs e)
        {
            if (text_Title.Text != string.Empty)
                Button_Create.Enabled = true;
            else
                Button_Create.Enabled = false;
        }

        /// <summary>
        /// Create profile upon hitting confirm.
        /// </summary>
        private void Button_Create_Click(object sender, EventArgs e)
        {
            Profile.Create(text_Title.Text, Mods, Patches);

            Close();
        }
    }
}
