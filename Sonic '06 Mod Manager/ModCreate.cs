using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Sonic_06_Mod_Manager
{
    public partial class ModCreate : Form
    {
        string modName = "";
        string modVersion = "";
        string modDate = "";
        string modAuthor = "";
        string modCopy = "";
        bool modMerge = false;
        string modPathTrue;
        string modNameTrue;
        bool editMode = false;

        public ModCreate(string modPath, string modName, bool edit)
        {
            Console.WriteLine(Path.Combine(modPath, modName));
            InitializeComponent();
            modPathTrue = modPath;
            modNameTrue = modName;
            editMode = edit;
        }

        private void ModTitleBox_TextChanged(object sender, EventArgs e)
        {
            if (modTitleBox.Text != "")
            {
                createButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = false;
            }
            modName = modTitleBox.Text;
        }

        private void ModVersionBox_TextChanged(object sender, EventArgs e)
        {
            modVersion = modVersionBox.Text;
        }

        private void ModDateBox_TextChanged(object sender, EventArgs e)
        {
            modDate = modDateBox.Text;
        }

        private void ModAuthorBox_TextChanged(object sender, EventArgs e)
        {
            modAuthor = modAuthorBox.Text;
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                if (!FilePathHasInvalidChars(modName))
                {
                    Console.WriteLine(Path.Combine(modPathTrue, modName));
                    if (Directory.Exists(Path.Combine(modPathTrue, modName)) && modName != modNameTrue)
                    {
                        MessageBox.Show("A mod called '" + modName + "' already exists.", "Stupid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        try
                        {

                            if (modName != modNameTrue) Directory.Move(Path.Combine(modPathTrue, modNameTrue), Path.Combine(modPathTrue, modName));
                            using (Stream modINILocation = File.Open(Path.Combine(modPathTrue, modName, "mod.ini"), FileMode.Create))
                            using (StreamWriter modINI = new StreamWriter(modINILocation))
                            {
                                modINI.WriteLine("Title=\"" + modName + "\"");
                                if (modVersion != "") { modINI.WriteLine("Version=\"" + modVersion + "\""); }
                                if (modDate != "") { modINI.WriteLine("Date=\"" + modDate + "\""); }
                                if (modAuthor != "") { modINI.WriteLine("Author=\"" + modAuthor + "\""); }
                                modINI.WriteLine("Platform=\"" + combo_System.Text + "\"");
                                modINI.WriteLine("Merge=\"" + modMerge.ToString() + "\"");
                                if (modCopy != "") { modINI.WriteLine("Read-only=\"" + modCopy + "\""); }
                                modINI.Close();
                            }
                        }
                        catch { MessageBox.Show("An error occurred when creating the directory.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    }
                }
                else { MessageBox.Show("Please check for invalid characters in your mod name.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                ModManager.isCreatorDisposed = true;
                Close();
            }
            else
            {
                if (!FilePathHasInvalidChars(modName))
                {
                    Console.WriteLine(Path.Combine(modPathTrue, modName));
                    if (Directory.Exists(Path.Combine(modPathTrue, modName)))
                    {
                        MessageBox.Show("A mod called '" + modName + "' already exists.", "Stupid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(Path.Combine(modPathTrue, modName));
                            using (Stream modINILocation = File.Open(Path.Combine(modPathTrue, modName, "mod.ini"), FileMode.Create))
                            using (StreamWriter modINI = new StreamWriter(modINILocation))
                            {
                                modINI.WriteLine("Title=\"" + modName + "\"");
                                if (modVersion != "") { modINI.WriteLine("Version=\"" + modVersion + "\""); }
                                if (modDate != "") { modINI.WriteLine("Date=\"" + modDate + "\""); }
                                if (modAuthor != "") { modINI.WriteLine("Author=\"" + modAuthor + "\""); }
                                modINI.WriteLine("Platform=\"" + combo_System.Text + "\"");
                                modINI.WriteLine("Merge=\"" + modMerge.ToString() + "\"");
                                if (modCopy != "") { modINI.WriteLine("Read-only=\"" + modCopy + "\""); }
                                modINI.Close();
                            }
                        }
                        catch { MessageBox.Show("An error occurred when creating the directory.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    }
                }
                else { MessageBox.Show("Please check for invalid characters in your mod name.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                ModManager.isCreatorDisposed = true;
                Close();
            }
        }

        private void Check_Merge_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Merge.Checked == true)
            {
                modMerge = true;
                lbl_Copy.Enabled = true;
                modCopyBox.Enabled = true;
                readonlyButtonHelp.Enabled = true;
            }
            else
            {
                modMerge = false;
                lbl_Copy.Enabled = false;
                modCopyBox.Enabled = false;
                readonlyButtonHelp.Enabled = false;
            }
        }

        private void ModCreate_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(int.MaxValue, 239);

            if (editMode)
            {
                Text = "Mod Editor";
                createButton.Text = "Edit Mod";
                createButton.BackColor = Color.SkyBlue;
                deleteMod.Visible = true;

                if (File.Exists($"{Path.Combine(modPathTrue, modNameTrue)}\\mod.ini"))
                {
                    using (StreamReader configFile = new StreamReader($"{Path.Combine(modPathTrue, modNameTrue)}\\mod.ini"))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.Contains("Title=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modTitleBox.Text = entryValue;
                            }
                            if (line.Contains("Version=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modVersionBox.Text = entryValue;
                            }
                            if (line.Contains("Date=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDateBox.Text = entryValue;
                            }
                            if (line.Contains("Author=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modAuthorBox.Text = entryValue;
                            }
                            if (line.Contains("Platform=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                if (entryValue == "Xbox 360") { combo_System.SelectedIndex = 0; }
                                else if (entryValue == "PlayStation 3") { combo_System.SelectedIndex = 1; }
                            }
                            if (line.Contains("Merge=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                if (bool.TryParse(entryValue, out bool getBool)) { check_Merge.Checked = getBool; }
                                else { check_Merge.Checked = false; }
                            }
                            if (line.Contains("Read-only=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modCopyBox.Text = entryValue;
                            }
                        }
                    }
                }
                else { MessageBox.Show("No configuration file found for the selected mod.", "None", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                Text = "Mod Creator";
                createButton.Text = "Create Mod";
                createButton.BackColor = Color.LightGreen;
                combo_System.SelectedIndex = 0;
                deleteMod.Visible = false;
            }
        }

        private void ModCopy_TextChanged(object sender, EventArgs e)
        {
            modCopy = modCopyBox.Text;
        }

        private void ReadonlyButtonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This parameter tells the Mod Manager not to merge files marked as 'read-only.' Files must be listed as comma separated values (e.g. 'cache.arc,player.arc,object.arc').", "Read-only", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteMod_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure you want to delete '" + modNameTrue + "?'", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (confirmation)
            {
                case DialogResult.Yes:
                    var tempData = new DirectoryInfo(Path.Combine(modPathTrue, modNameTrue));

                    try
                    {
                        if (Directory.Exists(Path.Combine(modPathTrue, modNameTrue)))
                        {
                            foreach (FileInfo file in tempData.GetFiles())
                            {
                                file.Delete();
                            }
                            foreach (DirectoryInfo directory in tempData.GetDirectories())
                            {
                                directory.Delete(true);
                            }

                            Directory.Delete(Path.Combine(modPathTrue, modNameTrue));
                        }
                    }
                    catch { MessageBox.Show("Failed to delete '" + modNameTrue + ".' Please ensure that nothing is accessing that mod's directory, or delete it manually.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    Close();
                    break;
            }
        }
    }
}
