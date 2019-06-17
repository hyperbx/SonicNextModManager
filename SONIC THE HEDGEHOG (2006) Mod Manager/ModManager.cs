using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONIC_THE_HEDGEHOG__2006__Mod_Manager
{
    public partial class ModManager : Form
    {
        string[] modArray;
        string modsPath;
        string s06Path;
        string xeniaPath;
        string arcPath;
        string origArcPath;
        string targetArcPath;

        public ModManager()
        {
            InitializeComponent();

            modsPath = Properties.Settings.Default.modsPath;
            modsBox.Text = Properties.Settings.Default.modsPath;
            s06Path = Properties.Settings.Default.s06Path;
            s06PathBox.Text = Properties.Settings.Default.s06Path;
            xeniaPath = Properties.Settings.Default.xeniaPath;
            xeniaBox.Text = Properties.Settings.Default.xeniaPath;

            RefreshMods();
        }

        private void RefreshMods()
        {
            if (modArray != null)
            {
                Array.Clear(modArray, 0, modArray.Length);
            }
            if (modsPath == "")
            {
                MessageBox.Show("No Mods folder specified, select your SONIC THE HEDGEHOG (2006) mods folder");
                FolderBrowserDialog modPathBrowser = new FolderBrowserDialog();
                if (modPathBrowser.ShowDialog() == DialogResult.OK)
                {
                    modsPath = modPathBrowser.SelectedPath;
                    modsBox.Text = modsPath;
                }
                else
                {
                    return;
                }
            }
            if (!Directory.Exists(modsPath))
            {
                modList.Items.Clear();
                return;
            }
            modArray = Directory.GetDirectories(modsPath);
            modList.Items.Clear();
            foreach (string mod in modArray)
            {
                var modName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                modName = modName.Replace("\\", "");
                modList.Items.Add(modName);
            }
            Properties.Settings.Default.modsPath = modsPath;
            Properties.Settings.Default.Save();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshMods();
        }

        private void S06PathBox_TextChanged(object sender, EventArgs e)
        {
            s06Path = s06PathBox.Text;
            Properties.Settings.Default.s06Path = s06Path;
            Properties.Settings.Default.Save();
        }

        private void XeniaBox_TextChanged(object sender, EventArgs e)
        {
            xeniaPath = xeniaBox.Text;
            Properties.Settings.Default.xeniaPath = xeniaPath;
            Properties.Settings.Default.Save();
        }

        private void XeniaButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog xeniaBrowser = new OpenFileDialog();
            xeniaBrowser.Title = "Select Xenia Executable";
            xeniaBrowser.Filter = "Xenia Emulator (*.exe)|*.exe";
            xeniaBrowser.FilterIndex = 1;
            xeniaBrowser.RestoreDirectory = true;
            if (xeniaBrowser.ShowDialog() == DialogResult.OK)
            {
                xeniaPath = xeniaBrowser.FileName;
                xeniaBox.Text = xeniaPath;
                Properties.Settings.Default.xeniaPath = xeniaPath;
                Properties.Settings.Default.Save();
            }
        }

        private void S06PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s06PathBrowser = new FolderBrowserDialog();
            if (s06PathBrowser.ShowDialog() == DialogResult.OK)
            {
                s06Path = s06PathBrowser.SelectedPath;
                s06PathBox.Text = s06Path;
                Properties.Settings.Default.s06Path = s06Path;
                Properties.Settings.Default.Save();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ModCreate ModCreateWindow = new ModCreate(modsPath);
            ModCreateWindow.ShowDialog();

            RefreshMods();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            CleanUpMods();
            CopyMods();
            Console.WriteLine("\nStarting Xenia.\n");
            var xenia = Process.Start(xeniaPath);
            xenia.WaitForExit();
            CleanUpMods();
        }

        private void CleanUpMods()
        {
            var mods = Directory.GetFiles(s06Path, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".arc_back") || s.EndsWith(".wmv_back") || s.EndsWith(".xma_back"));

            foreach (var mod in mods)
            {
                if (File.Exists(mod.ToString().Remove(mod.Length - 5)))
                {
                    File.Delete(mod.ToString().Remove(mod.Length - 5));
                }
                File.Move(mod.ToString(), mod.ToString().Remove(mod.Length - 5));
                Console.WriteLine("Removing: " + mod.ToString().Remove(mod.Length - 5));
            }
        }

        private void CopyMods()
        {
            int[] indexes = modList.CheckedIndices.Cast<int>().ToArray();
            foreach (var item in indexes)
            {
                var mods = Directory.GetFiles(modArray[item], "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".arc") || s.EndsWith(".wmv") || s.EndsWith(".xma"));

                foreach (var mod in mods)
                {
                    arcPath = mod.Remove(0, modArray[item].Length);
                    var arcName = mod.Remove(0, Path.GetDirectoryName(mod).Length);
                    arcName = arcName.Replace("\\", "");
                    Console.WriteLine("Copying " + mod);
                    origArcPath = s06Path + arcPath;
                    targetArcPath = origArcPath + "_back";

                    if (!File.Exists(targetArcPath))
                    {
                        File.Move(origArcPath, targetArcPath);
                        File.Copy(mod, origArcPath);
                    }
                    else
                    {
                        Console.WriteLine("Skipped " + mod);
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (modList.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (File.Exists(modArray[modList.SelectedIndex] + "\\mod.ini"))
                {
                    var modDetails = "";
                    using (StreamReader configFile = new StreamReader(modArray[modList.SelectedIndex] + "\\mod.ini"))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.Contains("Title=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Mod Title: " + entryValue + "\n";
                            }
                            if (line.Contains("Version=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Mod Version Number: " + entryValue + "\n";
                            }
                            if (line.Contains("Date=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Mod Creation Date: " + entryValue + "\n";
                            }
                            if (line.Contains("Author=\""))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                modDetails = modDetails + "Mod Author: " + entryValue + "\n";
                            }
                        }
                    }
                    MessageBox.Show(modDetails, "Mod Information for " + modList.Items[modList.SelectedIndex]);
                }
                else
                {
                    MessageBox.Show("No mod.ini found for selected mod.");
                }
            }
        }
        private void ModsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog modPathBrowser = new FolderBrowserDialog();
            if (modPathBrowser.ShowDialog() == DialogResult.OK)
            {
                modsPath = modPathBrowser.SelectedPath;
                modsBox.Text = modsPath;
                RefreshMods();
            }
        }

        private void ModsBox_TextChanged(object sender, EventArgs e)
        {
            modsPath = modsBox.Text;
            RefreshMods();
        }
    }
}
