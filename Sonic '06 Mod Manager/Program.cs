using System;
using System.IO;
using GameBanana;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Principal;

// Sonic '06 Mod Manager is licensed under the MIT License:
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

namespace Sonic_06_Mod_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            WritePrerequisites();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                if (args[0] == "-banana")
                {
                    int downloadID = 0;
                    string modType = string.Empty;
                    int modID = 0;
                    string[] getIDs = args[1].Remove(0, 40).Split(',');
                    int i = 0;

                    foreach (var item in getIDs)
                    {
                        if (i == 0)
                        {
                            int.TryParse(item, out downloadID);
                            { i++; }
                        }
                        else if (i == 1)
                        {
                            modType = item;
                            i++;
                        }
                        else if (i == 2)
                        {
                            int.TryParse(item, out modID);
                            { i++; }
                        }
                    }

                    var mod = new GBAPIItemDataBasic(modType, modID);
                    if (GBAPI.RequestItemData(mod))
                    {
                        new ModOneClickInstall(mod, args[1], downloadID, modID).ShowDialog();

                        if (PriorProcess() == null)
                        {
                            try
                            {
                                Application.Run(new ModManager(args));
                            }
                            catch
                            {
                                WritePrerequisites();
                            }
                        }
                    }
                }
            }
            else
            {
                if (PriorProcess() == null)
                {
                    try
                    {
                        Application.Run(new ModManager(args));
                    }
                    catch
                    {
                        WritePrerequisites();
                    }
                }
            }
        }

        public static void WritePrerequisites()
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll")))
            {
                try
                {
                    File.WriteAllBytes(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"), Properties.Resources.Newtonsoft_Json);
                    MessageBox.Show("Newtonsoft.Json.dll was written to the application path.", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show($"Failed to write Newtonsoft.Json.dll. Please reinstall Sonic '06 Mod Manager.\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); }
            }

            if (!File.Exists(Path.Combine(Application.StartupPath, "Ookii.Dialogs.dll")))
            {
                try
                {
                    File.WriteAllBytes(Path.Combine(Application.StartupPath, "Ookii.Dialogs.dll"), Properties.Resources.Ookii_Dialogs);
                    MessageBox.Show("Ookii.Dialogs.dll was written to the application path.", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show($"Failed to write Ookii.Dialogs.dll. Please reinstall Sonic '06 Mod Manager.\n\n{ex}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); }
            }

            Application.Exit();
        }

        public static bool RunningAsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static Process PriorProcess()
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }
    }
}
