using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;

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

    public class Patch
    {
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

            if (X != 1280 ^ Y != 720)
            {
                string[] gamemodeLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub");
                for (int i = 0; i < gamemodeLines.Length; i++)
                {
                    if (gamemodeLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                        gamemodeLines[i] = $"  SetViewport(_ARG_0_, 0, 0, {X}, {Y})";
                }
                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", gamemodeLines);

                string[] titleLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub");
                for (int i = 0; i < titleLines.Length; i++)
                {
                    if (titleLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                        titleLines[i] = $"  SetViewport(_ARG_0_, 0, 0, {X}, {Y})";
                }
                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", titleLines);
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

                string[] titleLines = File.ReadAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub");
                for (int i = 0; i < titleLines.Length; i++)
                {
                    if (titleLines[i].Contains("SetViewport(_ARG_0_, 0, 0,"))
                        titleLines[i] = $"  SetViewport(_ARG_0_, 0, 0, SCREEN_W, SCREEN_H)";
                }
                File.WriteAllLines($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", titleLines);
            }
        }

        public static void Omega_Blur_Fix()
        {
            var originalFile = Path.Combine(Properties.Settings.Default.s06Path, "win32\\archives\\player_omega.arc");
            if (!File.Exists($"{originalFile}_orig")) { File.Move(originalFile, $"{originalFile}_orig"); }
            File.WriteAllBytes(originalFile, Properties.Resources.omegaBlurFix);
        }

        public static void Vulkan_API_Compatibility(string tempPath)
        {
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\render_title.lub", Properties.Resources.vulkanRenderTitle);
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\render_gamemode.lub", Properties.Resources.vulkanRenderGamemode);
            File.WriteAllBytes($"{tempPath}\\cache\\xenon\\scripts\\render\\core\\render_main.lub", Properties.Resources.vulkanRenderMain);
        }
    }
}
