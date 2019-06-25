using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

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

namespace Tools
{
    class List
    {
        public static List<string> root()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;

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
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{Sonic_06_Mod_Manager.Properties.Settings.Default.ftpPath}win32/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;

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
}
