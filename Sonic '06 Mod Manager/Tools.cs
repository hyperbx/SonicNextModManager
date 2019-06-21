using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tools
{
    class List
    {
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
}
