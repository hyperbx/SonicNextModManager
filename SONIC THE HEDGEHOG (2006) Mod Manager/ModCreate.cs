using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONIC_THE_HEDGEHOG__2006__Mod_Manager
{
    public partial class ModCreate : Form
    {
        string modName = "";
        string modVersion = "";
        string modDate = "";
        string modAuthor = "";
        string modPathTrue;
        public ModCreate(string modPath)
        {
            Console.WriteLine(modPath);
            InitializeComponent();
            modPathTrue = modPath;
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(modPathTrue + "\\" + modName);
            if (Directory.Exists(modPathTrue + "\\" + modName))
            {
                MessageBox.Show("A mod called '" + modName + "' already exists.");
                return;
            }
            else
            {
                Directory.CreateDirectory(modPathTrue + "\\" + modName);
                using (Stream modINILocation = File.Open(modPathTrue + "\\" + modName + "\\mod.ini", FileMode.Create))
                using (StreamWriter modINI = new StreamWriter(modINILocation))
                {
                    modINI.WriteLine("Title=\"" + modName + "\"");
                    if (modVersion != "") { modINI.WriteLine("Version=\"" + modVersion + "\""); }
                    if (modDate != "") { modINI.WriteLine("Date=\"" + modDate + "\""); }
                    if (modAuthor != "") { modINI.WriteLine("Author=\"" + modAuthor + "\""); }
                    modINI.Close();
                }
            }
            this.Close();
        }
    }
}
