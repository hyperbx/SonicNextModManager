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
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Unify.Messenger;

namespace Unify.Environment3
{
    public partial class ProfileSelect : Form
    {
        public ProfileSelect()
        {
            InitializeComponent();

            // Set theme colours
            unifytb_Profiles.ActiveColor =
            unifytb_Profiles.HorizontalLineColor =
            unifytb_Info.ActiveColor =
            unifytb_Info.HorizontalLineColor =
            Properties.Settings.Default.General_AccentColour;

            // Set contrast colour
            if (Properties.Settings.Default.General_HighContrastText)
                unifytb_Profiles.SelectedTextColor = unifytb_Info.SelectedTextColor = SystemColors.ControlText;

            // Display the last selected profile
            if (!string.IsNullOrEmpty(Properties.Settings.Default.General_Profile))
            {
                Label_CurrentProfile.Text = $"Last Used Profile: {Properties.Settings.Default.General_Profile}";
                Label_CurrentProfile.Visible = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GetProfiles();

            base.OnLoad(e);
        }

        private void GetProfiles()
        {
            if (Directory.Exists(Program.Profiles))
            {
                ListView_ProfilesList.Items.Clear(); // Clears the profiles list

                foreach (string profile in Directory.GetFiles(Program.Profiles, "*.06mm", SearchOption.AllDirectories))
                {
                    // Add profile to list
                    ListViewItem profileItem = new ListViewItem(Path.GetFileNameWithoutExtension(profile))
                    {
                        Tag = profile
                    };

                    ListView_ProfilesList.Items.Add(profileItem);
                }
            }

            // Draw dark items.
            ListViewDrawing.DrawDarkItems(ListView_ProfilesList);

            // Display error if there are no items.
            if (ListView_ProfilesList.Items.Count == 0)
            {
                UnifyMessenger.UnifyMessage.ShowDialog
                (
                    "No profiles detected - please create a profile to load one!",
                    "No profiles...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }

        private void UpdateInfo()
        {
            // Clear info list boxes
            ListBox_Mods.Items.Clear();
            ListBox_Patches.Items.Clear();
            ListBox_Tweaks.Items.Clear();

            string none = "N/A";

            if (ListView_ProfilesList.SelectedItems.Count == 0)
            {
                string noneSelected = "Please select a profile...";

                // No profile selected, so 'disable' preview
                ListBox_Mods.Items.Add(noneSelected);
                ListBox_Patches.Items.Add(noneSelected);
                ListBox_Tweaks.Items.Add(noneSelected);

                return;
            }

            // Update mod info list box
            if (Profile.Mods.Count == 0)
            {
                ListBox_Mods.Items.Add(none);
            }
            else
            {
                // Return reversed list so the order makes sense lol
                ListBox_Mods.Items.AddRange(Profile.Mods.AsEnumerable().Reverse().ToArray());
            }

            // Update patch info list box
            if (Profile.Patches.Count == 0)
            {
                ListBox_Patches.Items.Add(none);
            }
            else
            {
                // Return reversed list so the order makes sense lol
                ListBox_Patches.Items.AddRange(Profile.Patches.AsEnumerable().Reverse().ToArray());
            }

            // Update tweak info list box
            if (Profile.Tweaks.Count == 0)
            {
                ListBox_Tweaks.Items.Add(none);
            }
            else
            {
                // Update tweak info list box
                ListBox_Tweaks.Items.AddRange(Profile.Tweaks.ToArray());
            }
        }

        /// <summary>
        /// Draws the list view items.
        /// </summary>
        private void ListView_ProfilesList_DrawItem(object sender, DrawListViewItemEventArgs e)
            => e.DrawDefault = true;

        private void ListView_ProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_ProfilesList.SelectedItems.Count != 0)
            {
                // Load highlighted profile for info
                Profile.GetInfo((string)ListView_ProfilesList.FocusedItem.Tag);

                // Enable accept button
                Button_OK.Enabled = true;
            }
            else
            {
                // Clear the loaded profile
                Profile.Clear();

                // Disable accept button
                Button_OK.Enabled = false;
            }

            // Update info boxes
            UpdateInfo();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (ListView_ProfilesList.FocusedItem != null)
            {
                string profile = (string)ListView_ProfilesList.FocusedItem.Tag;

                // Load highlighted profile
                Profile.Load(profile);

                // Set last selected profile
                Properties.Settings.Default.General_Profile = Path.GetFileNameWithoutExtension(profile);
                Properties.Settings.Default.Save();
            }

            Close();
        }

        /// <summary>
        /// Refreshes the tab control because ugh
        /// </summary>
        private void unifytb_Info_SelectedIndexChanged(object sender, EventArgs e)
            => unifytb_Info.Refresh();

        /// <summary>
        /// Displays a context menu for the selected profile
        /// </summary>
        private void ListView_ProfilesList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Create the dark context menu
                ContextMenuDark menuDark = new ContextMenuDark();

                // Get item by mouse focus
                if (ListView_ProfilesList.FocusedItem.Bounds.Contains(e.Location))
                {
                    menuDark.Items.AddRange(new ToolStripMenuItem[]
                    {
                    new ToolStripMenuItem("Rename Profile", Properties.Resources.EditPage_16x, ContextMenu_ProfileMenu_Items_Click),
                    new ToolStripMenuItem("Delete Profile", Properties.Resources.Cancel_16x, ContextMenu_ProfileMenu_Items_Click)
                    });

                    menuDark.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Event handler for the right-click menu items by index.
        /// </summary>
        private void ContextMenu_ProfileMenu_Items_Click(object sender, EventArgs e)
        {
            ListViewItem focused = ListView_ProfilesList.FocusedItem;

            switch (((ToolStripMenuItem)sender).ToString())
            {
                case "Rename Profile":
                {
                    // Start editing item
                    focused.BeginEdit();

                    break;
                }

                case "Delete Profile":
                {
                    try
                    {
                        DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog
                        (
                            $"Are you sure you want to delete {focused.Text}?",
                            $"Deleting {focused.Text}...",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (confirmation == DialogResult.Yes)
                        {
                            // Delete profile
                            File.Delete((string)focused.Tag);

                            // Refresh profiles list
                            GetProfiles();
                        }
                    }
                    catch
                    {
                        UnifyMessenger.UnifyMessage.ShowDialog
                        (
                            "Failed to delete the data for the requested profile.",
                            "I/O Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Renames a profile after editing the label for it.
        /// </summary>
        private void ListView_ProfilesList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string path = (string)ListView_ProfilesList.Items[e.Item].Tag;

            if (e.Label != Path.GetFileName(path))
            {
                string newPath = Path.Combine(Path.GetDirectoryName(path), $"{e.Label}.06mm");

                if (File.Exists(newPath))
                {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog
                    (
                        "A profile already exists with this name! Would you like to overwrite it?",
                        "Profile already exists...",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmation == DialogResult.Yes)
                    {
                        // Deletes the profile
                        File.Delete(newPath);
                    }
                    else
                    {
                        return;
                    }
                }

                // Rename profile
                File.Move(path, newPath);

                // Cancel the edit made
                e.CancelEdit = true;

                // Refresh profiles list
                GetProfiles();
            }
        }
    }
}
