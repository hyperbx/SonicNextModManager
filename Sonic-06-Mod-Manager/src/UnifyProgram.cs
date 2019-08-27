using System;
using System.IO;
using Unify.Messages;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Principal;
using Unify.Networking.GameBanana;

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

namespace Sonic_06_Mod_Manager
{
    static class Program
    {
        public static string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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
                    string[] getIDs = args[1].Remove(0, 40).Split(',');
                    string modType = string.Empty;
                    int downloadID = 0;
                    int modID = 0;
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
                    if (GBAPI.RequestItemData(mod)) {
                        new src.ModOneClickInstall(mod, args[1], downloadID, modID).ShowDialog();

                        if (PriorProcess() == null)
                            try {  Application.Run(new ModManager(args)); } catch { WritePrerequisites(); }
                    }
                }
            } else {
                if (PriorProcess() == null) {
                    try { Application.Run(new ModManager(args)); } catch { WritePrerequisites(); }
                }
            }
        }

        public static void WritePrerequisites()
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"))) {
                try {
                    File.WriteAllBytes(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"), Properties.Resources.Newtonsoft_Json);
                    MessageBox.Show(SystemMessages.msg_Prereq_Newtonsoft, SystemMessages.tl_DefaultTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(SystemMessages.ex_Prereq_Newtonsoft_WriteFailure(ex), SystemMessages.tl_FatalError, MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); }
            }

            if (!File.Exists(Path.Combine(Application.StartupPath, "Ookii.Dialogs.dll"))) {
                try {
                    File.WriteAllBytes(Path.Combine(Application.StartupPath, "Ookii.Dialogs.dll"), Properties.Resources.Ookii_Dialogs);
                    MessageBox.Show(SystemMessages.msg_Prereq_Ookii, SystemMessages.tl_DefaultTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(SystemMessages.ex_Prereq_Ookii_WriteFailure(ex), SystemMessages.tl_FatalError, MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); }
            }

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool"))
                Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool");

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub"))
                Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub");

            if (!Directory.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs"))
                Directory.CreateDirectory($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs");

            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php"))
                File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arctool.php", Properties.Resources.arctoolphp);

            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php"))
                File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\unarc.php", Properties.Resources.unarcphp);

            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php"))
                File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool\\arcc.php", Properties.Resources.arccphp);

            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe"))
                File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", Properties.Resources.arctool);

            if (!File.Exists($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar"))
                File.WriteAllBytes($"{applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar", Properties.Resources.unlub);

            Application.Exit();
        }

        public static bool RunningAsAdmin() {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static Process PriorProcess() {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs) {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }
    }
}
