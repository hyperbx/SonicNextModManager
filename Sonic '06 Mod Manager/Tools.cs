using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

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

namespace Sonic_06_Mod_Manager.Tools
{
    class List
    {
        public static List<string> root()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Xbox 360
        public static List<string> xenonarchives()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}xenon/archives/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> xenonsound()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}xenon/sound/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> xenonsoundevent()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}xenon/sound/event/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> xenonsoundvoicee()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}xenon/sound/voice/e/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> xenonsoundvoicej()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}xenon/sound/voice/j/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region PlayStation 3
        public static List<string> ps3archives()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}ps3/archives/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> ps3sound()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}ps3/sound/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<string> ps3soundevent()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}ps3/sound/event/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> ps3soundvoicee()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}ps3/sound/voice/e/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> ps3soundvoicej()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}ps3/sound/voice/j/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static List<string> win32archives()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}win32/archives/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Sonic_06_Mod_Manager.ModManager.username, Sonic_06_Mod_Manager.ModManager.password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    class Notification
    {
        public static void Dispose()
        {
            Sonic_06_Mod_Manager.ModStatus statusForm = Application.OpenForms["ModStatus"] != null ? (Sonic_06_Mod_Manager.ModStatus)Application.OpenForms["ModStatus"] : null;

            if (statusForm != null)
            {
                try
                {
                    statusForm = (Sonic_06_Mod_Manager.ModStatus)Application.OpenForms["ModStatus"];
                    statusForm.Close();
                }
                catch { }
            }
        }
    }

    public class TimedWebClient : WebClient
    {
        public int Timeout { get; set; }

        public TimedWebClient()
        {
            Timeout = 100000;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = Timeout;
            return objWebRequest;
        }
    }

    public class XeniaException
    {
        public static void GetErrors()
        {
            var errors = new StringBuilder();
            if (Properties.Settings.Default.api == 0)
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.vkXeniaPath), "xenia.log")))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line.IndexOf("!>", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            errors.Append($"{line.Substring(3)}\n");
                        }
                    }
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.dx12XeniaPath), "xenia.log")))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line.IndexOf("!>", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            errors.Append($"{line.Substring(3)}\n");
                        }
                    }
                }
            }

            if (errors.ToString() != string.Empty) MessageBox.Show(errors.ToString(), "Xenia Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void GetWarnings()
        {
            var warnings = new StringBuilder();
            if (Properties.Settings.Default.api == 0)
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.vkXeniaPath), "xenia.log")))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line.IndexOf("w>", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            warnings.Append($"{line.Substring(3)}\n");
                        }
                    }
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.dx12XeniaPath), "xenia.log")))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line.IndexOf("w>", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            warnings.Append($"{line.Substring(3)}\n");
                        }
                    }
                }
            }

            if (warnings.ToString() != string.Empty)
            {
                MessageBox.Show(warnings.ToString(), "Xenia Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("For more information, see the log in your Xenia directory.", "Xenia Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class ARC_Manager
    {
        public static bool Check_ARC_For_Patch(string type)
        {
            if (type == "dynamic_bones")
            {
                byte[] bytes;
                bytes = File.ReadAllBytes($"{Properties.Settings.Default.s06Path}\\xenon\\archives\\player.arc").ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                if (hexString.Contains("73 6E 6F 77 5F 62 6F 61 72 64 2E 6C 75 62 5F 73 6F 6E 69 63 30 36 6D 6D") ||
                    hexString.Contains("73 6E 6F 77 5F 62 6F 61 72 64 5F 77 61 70 2E 6C 75 62 5F 73 6F 6E 69 63 30 36 6D 6D"))
                {
                    return true;
                }
                else { return false; }
            }
            else if (type == "mid-air")
            {
                byte[] bytes;
                bytes = File.ReadAllBytes($"{Properties.Settings.Default.s06Path}\\xenon\\archives\\player.arc").ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                if (hexString.Contains("73 6F 6E 69 63 5F 6E 65 77 2E 6C 75 62 5F 73 6F 6E 69 63 30 36 6D 6D"))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }

    public class Patch
    {
        public static bool JavaCheck()
        {
            try
            {
                var javaArg = new ProcessStartInfo("java", "-version");
                javaArg.WindowStyle = ProcessWindowStyle.Hidden;
                javaArg.RedirectStandardOutput = true;
                javaArg.RedirectStandardError = true;
                javaArg.UseShellExecute = false;
                javaArg.CreateNoWindow = true;
                var javaProcess = new Process();
                javaProcess.StartInfo = javaArg;
                javaProcess.Start();

                return true;
            }
            catch { return false; }
        }

        public static void Camera_Distance(string tempPath, int distance)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\game\\xenon\\cameraparam.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\game\\xenon\\cameraparam.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\game\\xenon\\cameraparam.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\cameraparam.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\cameraparam.lub", $"{tempPath}\\game\\xenon\\cameraparam.lub", true);
                }
            }

            string[] distanceLines = File.ReadAllLines($"{tempPath}\\game\\xenon\\cameraparam.lub");
            for (int i = 0; i < distanceLines.Length; i++)
            {
                if (distanceLines[i].Contains("distance ="))
                    distanceLines[i] = $"distance = {decimal.Divide(distance, 100)} * meter";
            }
            File.WriteAllLines($"{tempPath}\\game\\xenon\\cameraparam.lub", distanceLines);
        }

        public static void Disable_HUD(string tempPath)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_gamemode.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_gamemode.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", true);
                }
            }

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_gamemode_multi.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_gamemode_multi.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub", true);
                }
            }

            string[] gamemodeLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub");
            for (int i = 0; i < gamemodeLines.Length; i++)
            {
                if (gamemodeLines[i].Contains("Render2D(_ARG_0_)"))
                    gamemodeLines[i] = "  --Render2D(_ARG_0_)";
            }
            File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", gamemodeLines);

            string[] gamemodeMultiLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub");
            for (int i = 0; i < gamemodeMultiLines.Length; i++)
            {
                if (gamemodeMultiLines[i].Contains("Render2D(_ARG_0_)"))
                    gamemodeMultiLines[i] = "  --Render2D(_ARG_0_)";
            }
            File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode_multi.lub", gamemodeMultiLines);
        }

        public static void Disable_Midair_Momentum(string tempPath, string file)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\player\\xenon\\player\\{file}"))
            {
                if (File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\{file}")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\player\\xenon\\player\\{file}", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\{file}", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\{file}", $"{tempPath}\\player\\xenon\\player\\{file}", true);
                }
            }

            if (!File.Exists($"{tempPath}\\player\\xenon\\player\\{file}_sonic06mm")) File.Copy($"{tempPath}\\player\\xenon\\player\\{file}", $"{tempPath}\\player\\xenon\\player\\{file}_sonic06mm");

            string[] midairLines = File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\{file}");
            for (int i = 0; i < midairLines.Length; i++)
            {
                if (midairLines[i].Contains("c_jump_brake = "))
                    midairLines[i] = "c_jump_brake = 20 * (meter / sec)";
                if (midairLines[i].Contains("c_jump_speed_acc = "))
                    midairLines[i] = "c_jump_speed_acc = 2.5 * meter";
                if (midairLines[i].Contains("c_jump_speed_brake = "))
                    midairLines[i] = "c_jump_speed_brake = 20 * meter";
                if (midairLines[i].Contains("c_jump_speed = "))
                    midairLines[i] = "c_jump_speed = 9 * (meter / sec)";
                if (midairLines[i].Contains("c_jump_walk = "))
                    midairLines[i] = "c_jump_walk = 9 * (meter / sec)";
                if (midairLines[i].Contains("c_jump_run = "))
                    midairLines[i] = "c_jump_run = 9 * (meter / sec)";
            }
            File.WriteAllLines($"{tempPath}\\player\\xenon\\player\\{file}", midairLines);
        }

        public static void Disable_Shadows(string tempPath)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_gamemode.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_gamemode.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", true);
                }
            }

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_title.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_title.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", true);
                }
            }

            string[] gamemodeLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub");
            for (int i = 0; i < gamemodeLines.Length; i++)
            {
                if (gamemodeLines[i].Contains("RenderCSM(_ARG_0_, GenerateCSMLevels, GenerateCSMObjects)"))
                    gamemodeLines[i] = "  --RenderCSM(_ARG_0_, GenerateCSMLevels, GenerateCSMObjects)";
            }
            File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", gamemodeLines);

            string[] titleLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub");
            for (int i = 0; i < titleLines.Length; i++)
            {
                if (titleLines[i].Contains("CreateCSM(_ARG_0_)"))
                    titleLines[i] = "  --CreateCSM(_ARG_0_)";
            }
            File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", titleLines);
        }

        public static void Omega_Blur_Fix()
        {
            var originalFile = Path.Combine(Properties.Settings.Default.s06Path, "win32\\archives\\player_omega.arc");
            if (!File.Exists($"{originalFile}_orig")) { File.Move(originalFile, $"{originalFile}_orig"); }
            File.WriteAllBytes(originalFile, Properties.Resources.omegaBlurFix);
        }

        public static void Use_Dynamic_Bones(string tempPath)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\player\\xenon\\player\\snow_board.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\snow_board.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\player\\xenon\\player\\snow_board.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\snow_board.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\snow_board.lub", $"{tempPath}\\player\\xenon\\player\\snow_board.lub", true);
                }
            }

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\snow_board_wap.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\snow_board_wap.lub", $"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub", true);
                }
            }

            if (!File.Exists($"{tempPath}\\player\\xenon\\player\\snow_board.lub_sonic06mm")) File.Copy($"{tempPath}\\player\\xenon\\player\\snow_board.lub", $"{tempPath}\\player\\xenon\\player\\snow_board.lub_sonic06mm");
            if (!File.Exists($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub_sonic06mm")) File.Copy($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub", $"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub_sonic06mm");

            string[] snowboardLines = File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\snow_board.lub");
            for (int i = 0; i < snowboardLines.Length; i++)
            {
                if (snowboardLines[i].Contains("c_module_impulse = "))
                    snowboardLines[i] = "c_module_impulse = impulse_module_snowboard\nc_hair = {\n\"TopHair\",\n\"HighLeftHair\",\n\"HighRightHair\",\n\"LowLeftHair\",\n\"LowRightHair\",\n\"MiddleHair\"\n}";
            }
            File.WriteAllLines($"{tempPath}\\player\\xenon\\player\\snow_board.lub", snowboardLines);

            string[] snowboardWapLines = File.ReadAllLines($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub");
            for (int i = 0; i < snowboardWapLines.Length; i++)
            {
                if (snowboardWapLines[i].Contains("c_module_impulse = "))
                    snowboardWapLines[i] = "c_module_impulse = impulse_module_snowboard\nc_hair = {\n\"TopHair\",\n\"HighLeftHair\",\n\"HighRightHair\",\n\"LowLeftHair\",\n\"LowRightHair\",\n\"MiddleHair\"\n}";
            }
            File.WriteAllLines($"{tempPath}\\player\\xenon\\player\\snow_board_wap.lub", snowboardWapLines);
        }

        public static void Viewport(string tempPath, int X, int Y)
        {
            ProcessStartInfo patch;

            //Checks the header for each file to ensure that it can be safely decompiled.
            if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub"))
            {
                if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub")[0].Contains("LuaP"))
                {
                    File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_gamemode.lub", true);

                    patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
                    {
                        WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    var Patch1 = Process.Start(patch);
                    Patch1.WaitForExit();
                    Patch1.Close();

                    File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_gamemode.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", true);
                }
            }

            ////Checks the header for each file to ensure that it can be safely decompiled.
            //if (File.Exists($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub"))
            //{
            //    if (File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub")[0].Contains("LuaP"))
            //    {
            //        File.Copy($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\lubs\\render_title.lub", true);

            //        patch = new ProcessStartInfo($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.bat")
            //        {
            //            WorkingDirectory = $"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\",
            //            WindowStyle = ProcessWindowStyle.Hidden
            //        };

            //        var Patch1 = Process.Start(patch);
            //        Patch1.WaitForExit();
            //        Patch1.Close();

            //        File.Copy($"{ModManager.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\luas\\render_title.lub", $"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", true);
            //    }
            //}

            if ((X == 1280 && Y == 720) == false)
            {
                string[] gamemodeLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub");
                for (int i = 0; i < gamemodeLines.Length; i++)
                {
                    if (gamemodeLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                        gamemodeLines[i] = $"  SetViewport(_ARG_0_, 0, 0, {X}, {Y})";
                }
                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", gamemodeLines);

                //string[] titleLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub");
                //for (int i = 0; i < titleLines.Length; i++)
                //{
                //    if (titleLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                //        titleLines[i] = $"  SetViewport(_ARG_0_, 0, 0, {X}, {Y})";
                //}
                //File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", titleLines);
            }
            else
            {
                string[] gamemodeLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub");
                for (int i = 0; i < gamemodeLines.Length; i++)
                {
                    if (gamemodeLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                        gamemodeLines[i] = $"  SetViewport(_ARG_0_, 0, 0, GetSurfaceWidth(_ARG_0_, \"framebuffer0\"), (GetSurfaceHeight(_ARG_0_, \"framebuffer0\")))";
                }
                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", gamemodeLines);

                //string[] titleLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub");
                //for (int i = 0; i < titleLines.Length; i++)
                //{
                //    if (titleLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                //        titleLines[i] = $"  SetViewport(_ARG_0_, 0, 0, SCREEN_W, SCREEN_H)";
                //}
                //File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", titleLines);
            }
        }

        public static void Vulkan_API_Compatibility(string tempPath)
        {
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", Properties.Resources.vulkanRenderTitle);
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", Properties.Resources.vulkanRenderGamemode);
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", Properties.Resources.vulkanRenderMain);
        }
    }

    public class Global
    {
        public static bool Java = false;
    }
}
