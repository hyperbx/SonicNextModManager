using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Unify.Patcher;
using Unify.Messages;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

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

namespace Unify.Networking
{
    class Updater
    {
        public static string serverStatus = string.Empty;

        public static void CheckForUpdates(string currentVersion, string newVersionDownloadLink, string versionInfoLink, string updateState)
        {
            try
            {
                string latestVersion = string.Empty;
                string changeLogs = string.Empty;

                try { latestVersion = new TimedWebClient { Timeout = 100000 }.DownloadString(versionInfoLink); }
                catch { return; }

                try {
                    changeLogs = new TimedWebClient { Timeout = 100000 }.DownloadString("https://segacarnival.com/hyper/updates/sonic-06-mod-manager/changelogs.txt");
                    if (Sonic_06_Mod_Manager.ModManager.dreamcastDay) changeLogs += "\n\nHappy birthday, Dreamcast!";
                }
                catch { changeLogs = "► Allan please add details"; }

                if (latestVersion.Contains("Version")) {
                    if (latestVersion != currentVersion) {
                        string confirmUpdate = UnifyMessages.UnifyMessage.Show(SystemMessages.msg_UpdateAvailable(latestVersion, changeLogs), SystemMessages.tl_Update, "YesNo", "Question", true);
                        switch (confirmUpdate) {
                            case "Yes":
                                var exists = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1;
                                if (exists) { UnifyMessages.UnifyMessage.Show(SystemMessages.warn_CloseProcesses, SystemMessages.tl_ProcessError, "OK", "Error", true); }
                                else {
                                    try {
                                        if (File.Exists(Application.ExecutablePath)) new Sonic_06_Mod_Manager.src.UnifyUpdater(latestVersion, newVersionDownloadLink, true).ShowDialog();
                                        else return;
                                    }
                                    catch { UnifyMessages.UnifyMessage.Show(SystemMessages.ex_UpdateFailedUnknown, SystemMessages.tl_FatalError, "OK", "Error", true); }
                                }
                                break;
                        }
                    } else if (updateState == "user") UnifyMessages.UnifyMessage.Show(SystemMessages.msg_NoUpdates, SystemMessages.tl_DefaultTitle, "OK", "Information", false);
                } else { serverStatus = "down"; }
            } catch { serverStatus = "offline"; } updateState = null;
        }
    }

    class FTP
    {
        public static string targetArcPath = string.Empty; //Modded ARC File
        public static string origArcPath = string.Empty; //Original Game ARC File
        public static string arcPath = string.Empty; //Paths to ARC in the game files

        public static void InstallMods(string server, string modPath, string username, string password) {
            bool merge = false;
            string[] read_only = { };
            string title = string.Empty;
            string platform = string.Empty;
            ARC.skippedMods.Clear();

            //Check if Mod is a Merge Mod and if it contains any read-only files.
            using (Stream configRead = File.Open(Path.Combine(modPath, "mod.ini"), FileMode.Open))
            using (StreamReader configFile = new StreamReader(configRead, Encoding.Default)) {
                string line;
                string entryValue;
                while ((line = configFile.ReadLine()) != null) {
                    if (line.StartsWith("Title")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        title = entryValue;
                    }
                    if (line.StartsWith("Merge")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        merge = bool.Parse(entryValue);
                    }
                    if (line.StartsWith("Read-only")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        read_only = entryValue.Split(',');
                    }
                }
            }

            var files = Directory.GetFiles(modPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".arc") ||
                        s.EndsWith(".wmv") ||
                        s.EndsWith(".xma") ||
                        s.EndsWith(".xex") ||
                        s.EndsWith(".bin") ||
                        s.EndsWith(".pam") ||
                        s.EndsWith(".at3"));

            foreach (var file in files) {
                arcPath = file.Remove(0, modPath.Length);
                if (arcPath.StartsWith(@"\")) //Needed due to Microsoft fucking Path.Combine when the string begins with a \
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath.Substring(1));
                else
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath);
                targetArcPath = $"{origArcPath}_back";

                try
                {
                    using (WebClient client = new WebClient()) {
                        client.UseDefaultCredentials = true;
                        client.Credentials = new NetworkCredential(username, password);

                        if (file.EndsWith(".arc")) {
                            if (merge && !read_only.Contains(Path.GetFileName(file))) {
                                //Pass off to MergeARCs
                                Console.WriteLine("Merging: " + file);
                                byte[] downloadFile = client.DownloadData((server + arcPath).Replace(@"\", "/"));
                                string tempPath = $"{Sonic_06_Mod_Manager.Program.applicationData}\\Temp\\{Path.GetRandomFileName()}";
                                Directory.CreateDirectory(tempPath);

                                using (FileStream downloadedFile = File.Create(Path.Combine(tempPath, Path.GetFileName(arcPath)))) {
                                    downloadedFile.Write(downloadFile, 0, downloadFile.Length);
                                    downloadedFile.Close();
                                }

                                ARC.MergeARCs(Path.Combine(tempPath, Path.GetFileName(arcPath)), file, Path.Combine(tempPath, Path.GetFileName(arcPath)), true, tempPath);

                                if (!CheckIfFileExistsOnServer((server + $"{arcPath}_back").Replace(@"\", "/"), username, password)) {
                                    var renameFileRequest = (FtpWebRequest)WebRequest.Create((server + arcPath).Replace(@"\", "/"));
                                    renameFileRequest.Method = WebRequestMethods.Ftp.Rename;
                                    renameFileRequest.Credentials = new NetworkCredential(username, password);
                                    renameFileRequest.RenameTo = $"{Path.GetFileName(arcPath)}_back";
                                    renameFileRequest.UseBinary = false;
                                    renameFileRequest.UsePassive = true;
                                    var renameFileResponse = (FtpWebResponse)renameFileRequest.GetResponse();
                                }

                                client.UploadFile((server + arcPath).Replace(@"\", "/"), WebRequestMethods.Ftp.UploadFile, Path.Combine(tempPath, Path.GetFileName(arcPath)));
                            } else {
                                if (!CheckIfFileExistsOnServer((server + $"{arcPath}_back").Replace(@"\", "/"), username, password)) {
                                    var renameFileRequest = (FtpWebRequest)WebRequest.Create((server + arcPath).Replace(@"\", "/"));
                                    renameFileRequest.Method = WebRequestMethods.Ftp.Rename;
                                    renameFileRequest.Credentials = new NetworkCredential(username, password);
                                    renameFileRequest.RenameTo = $"{Path.GetFileName(arcPath)}_back";
                                    renameFileRequest.UseBinary = false;
                                    renameFileRequest.UsePassive = true;
                                    var renameFileResponse = (FtpWebResponse)renameFileRequest.GetResponse();
                                } else {
                                    //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                                    ARC.skippedMods.Add(ModsMessages.ex_SkippedMod(title, Path.GetFileName(file)));
                                    return;
                                }

                                client.UploadFile((server + arcPath).Replace(@"\", "/"), WebRequestMethods.Ftp.UploadFile, file);
                            }
                        } else {
                            if (!CheckIfFileExistsOnServer((server + $"{arcPath}_back").Replace(@"\", "/"), username, password)) {
                                var renameFileRequest = (FtpWebRequest)WebRequest.Create((server + arcPath).Replace(@"\", "/"));
                                renameFileRequest.Method = WebRequestMethods.Ftp.Rename;
                                renameFileRequest.Credentials = new NetworkCredential(username, password);
                                renameFileRequest.RenameTo = $"{Path.GetFileName(arcPath)}_back";
                                renameFileRequest.UseBinary = false;
                                renameFileRequest.UsePassive = true;
                                var renameFileResponse = (FtpWebResponse)renameFileRequest.GetResponse();
                            } else {
                                //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                                ARC.skippedMods.Add(ModsMessages.ex_SkippedMod(title, Path.GetFileName(file)));
                                return;
                            }

                            client.UploadFile((server + arcPath).Replace(@"\", "/"), WebRequestMethods.Ftp.UploadFile, file);
                        }
                    }
                }
                catch (Exception ex) { UnifyMessages.UnifyMessage.Show($"{ModsMessages.ex_FTPError}\n\n{ex}", SystemMessages.tl_NetworkError, "OK", "Error", false); break; }
            }
        }

        public static void CleanupMods(string server, string username, string password, int state)
        {
            List<string> fileSystem = new List<string>() {
                "xenon/",
                "xenon/archives/",
                "xenon/event/",
                "xenon/event/eboss/",
                "xenon/sound/",
                "xenon/sound/event/",
                "xenon/sound/voice/e/",
                "xenon/sound/voice/j/",
                "ps3/",
                "ps3/archives/",
                "ps3/elf/",
                "ps3/event/",
                "ps3/event/eboss/",
                "ps3/sound/",
                "ps3/sound/event/",
                "ps3/sound/voice/e/",
                "ps3/sound/voice/j/",
                "win32/",
                "win32/archives/"
            };

            for (int i = 0; i < 10; i++) {
                fileSystem.Add($"xenon/event/e000{i}/");
                fileSystem.Add($"ps3/event/e000{i}/");
            }
            for (int i = 10; i <= 31; i++) {
                fileSystem.Add($"xenon/event/e00{i}/");
                fileSystem.Add($"ps3/event/e00{i}/");
            }
            for (int i = 100; i <= 130; i++) {
                fileSystem.Add($"xenon/event/e0{i}/");
                fileSystem.Add($"ps3/event/e0{i}/");
            }
            for (int i = 200; i <= 228; i++) {
                fileSystem.Add($"xenon/event/e0{i}/");
                fileSystem.Add($"ps3/event/e0{i}/");
            }
            for (int i = 301; i < 310; i++) {
                fileSystem.Add($"xenon/event/e0{i}/");
                fileSystem.Add($"ps3/event/e0{i}/");
            }

            for (int i = 0; i < fileSystem.Count; i++) {
                Console.WriteLine(fileSystem[i]);
                try {
                    foreach (var item in GetFiles(server, fileSystem[i], username, password)) {
                        if (item.EndsWith("_back") && state == 0) {
                            if (CheckIfFileExistsOnServer(server + fileSystem[i] + item.Substring(item.Length - 5), username, password)) {
                                var deleteFileRequest = (FtpWebRequest)WebRequest.Create(server + fileSystem[i] + item.Substring(item.Length - 5));
                                deleteFileRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                                deleteFileRequest.Credentials = new NetworkCredential(username, password);
                                deleteFileRequest.UseBinary = false;
                                deleteFileRequest.UsePassive = true;
                                var deleteFileResponse = (FtpWebResponse)deleteFileRequest.GetResponse();
                                deleteFileResponse.Close();
                            }

                            var renameFileRequest = (FtpWebRequest)WebRequest.Create(server + fileSystem[i] + item);
                            renameFileRequest.Method = WebRequestMethods.Ftp.Rename;
                            renameFileRequest.Credentials = new NetworkCredential(username, password);
                            renameFileRequest.RenameTo = item.Substring(item.Length - 5);
                            renameFileRequest.UseBinary = false;
                            renameFileRequest.UsePassive = true;
                            var renameFileResponse = (FtpWebResponse)renameFileRequest.GetResponse();
                            renameFileResponse.Close();
                        }
                        if (item.EndsWith("_orig") && state == 1) {
                            if (CheckIfFileExistsOnServer(server + fileSystem[i] + item.Substring(item.Length - 5), username, password)) {
                                var deleteFileRequest = (FtpWebRequest)WebRequest.Create(server + fileSystem[i] + item.Substring(item.Length - 5));
                                deleteFileRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                                deleteFileRequest.Credentials = new NetworkCredential(username, password);
                                deleteFileRequest.UseBinary = false;
                                deleteFileRequest.UsePassive = true;
                                var deleteFileResponse = (FtpWebResponse)deleteFileRequest.GetResponse();
                                deleteFileResponse.Close();
                            }

                            var renameFileRequest = (FtpWebRequest)WebRequest.Create(server + fileSystem[i] + item);
                            renameFileRequest.Method = WebRequestMethods.Ftp.Rename;
                            renameFileRequest.Credentials = new NetworkCredential(username, password);
                            renameFileRequest.RenameTo = item.Substring(item.Length - 5);
                            renameFileRequest.UseBinary = false;
                            renameFileRequest.UsePassive = true;
                            var renameFileResponse = (FtpWebResponse)renameFileRequest.GetResponse();
                            renameFileResponse.Close();
                        }
                    }
                } catch { }
            }
        }

        public static string DownloadFileToTemp(string filename, string username, string password) {
            using (WebClient client = new WebClient()) {
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(username, password);

                byte[] downloadFile = client.DownloadData(filename.Replace(@"\", "/"));
                string tempPath = $"{Sonic_06_Mod_Manager.Program.applicationData}\\Temp\\{Path.GetRandomFileName()}";
                Directory.CreateDirectory(tempPath);

                using (FileStream downloadedFile = File.Create(Path.Combine(tempPath, Path.GetFileName(filename))))
                {
                    downloadedFile.Write(downloadFile, 0, downloadFile.Length);
                    downloadedFile.Close();
                }

                var unpack = new ProcessStartInfo($"{Sonic_06_Mod_Manager.Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(filename))}\"")
                {
                    WorkingDirectory = $"{Sonic_06_Mod_Manager.Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                var Unpack = Process.Start(unpack);
                Unpack.WaitForExit();
                Unpack.Close();

                return tempPath;
            }
        }

        public static bool CheckIfFileExistsOnServer(string fileName, string username, string password) {
            var request = (FtpWebRequest)WebRequest.Create(fileName);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex) {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public static List<string> GetFiles(string server, string location, string username, string password)
        {
            try {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + location);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch { throw; }
        }
    }

    public class TimedWebClient : WebClient
    {
        public int Timeout { get; set; }

        public TimedWebClient() { Timeout = 100000; }

        protected override WebRequest GetWebRequest(Uri address) {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = Timeout;
            return objWebRequest;
        }
    }
}

// GameBanana API code is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2017 thesupersonic16

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

namespace Unify.Networking.GameBanana
{
    public class GBAPI
    {

        // TODO: Add Core/List support
        public enum GBAPIRequestType
        {
            COREITEMDATA
        }

        public class GBAPIRequestHandler
        {
            public List<KeyValuePair<string, FieldInfo>> Fields = new List<KeyValuePair<string, FieldInfo>>();
            public string ItemType = "";
            public int ItemID = 0;
            public string Suffix = "&format=xml";
            public GBAPIRequestType APIType = GBAPIRequestType.COREITEMDATA;

            public void ProcessItemData(GBAPIItemData item)
            {
                ItemType = item.ItemType;
                ItemID = item.ItemID;
                APIType = GBAPIRequestType.COREITEMDATA;

                var type = item.GetType();
                foreach (var field in type.GetFields())
                {
                    var GBField = (GBAPIField)field.GetCustomAttributes(typeof(GBAPIField), true).FirstOrDefault();
                    if (GBField != null)
                    {
                        Fields.Add(new KeyValuePair<string, FieldInfo>(GBField.FieldName, field));
                    }
                }
            }

            /// <summary>
            /// Creates Request URL to GameBanana's API.
            ///  - Core/Item/Data
            ///      Calls Core/Item/Data with the specified item type, id and fields
            /// </summary>
            /// <returns>Request URL</returns>
            public string Build()
            {
                if (APIType == GBAPIRequestType.COREITEMDATA)
                {
                    string URL = $"https://api.gamebanana.com/Core/Item/Data?itemtype={ItemType}&itemid={ItemID}&fields=";
                    foreach (var field in Fields)
                    {
                        if (URL.Last() != '=')
                            URL += ',';
                        URL += field.Key;
                    }
                    return URL + Suffix;
                }
                return "";
            }

            /// <summary>
            /// Parses the response data(XML) and writes all data into parameter "item".
            /// </summary>
            /// <param name="response">The Response data from GameBanana API in XML string format</param>
            /// <param name="item">Reference to a GBAPIItemData to write the data to</param>
            /// <returns>If Parse completed with no errors</returns>
            public bool ParseResponse(string response, GBAPIItemData item)
            {
                var responseXML = XDocument.Parse(response).Root;
                var elements = responseXML.Elements().ToList();
                if (elements.Count() != Fields.Count)
                {
                    var list = Fields.Select(t => t.Key).ToList();
                    list.Insert(0, response);
                    return false;
                }

                foreach (var field in Fields)
                {
                    var element = elements.First();
                    var GBFieldKey = (GBAPIFieldKeyArray)field.Value.GetCustomAttributes(typeof(GBAPIFieldKeyArray), true).FirstOrDefault();
                    if (GBFieldKey != null)
                    {
                        var arrayElements = element.Elements().ToArray();
                        var array = Array.CreateInstance(field.Value.FieldType.GetElementType(), arrayElements.Length);
                        var keyInfo = field.Value.FieldType.GetElementType().GetField(GBFieldKey.KeyName);
                        var arrayInfo = field.Value.FieldType.GetElementType().GetField(GBFieldKey.ArrayName);
                        for (int i = 0; i < array.Length; ++i)
                        {
                            object obj = Activator.CreateInstance(field.Value.FieldType.GetElementType());
                            // Key
                            object value = TryConvert(arrayElements[i].Attribute("key").Value, keyInfo.FieldType);
                            if (value != null)
                                keyInfo.SetValue(obj, value);
                            // Array
                            var subElements = arrayElements[i].Elements().ToArray();
                            var array2 = Array.CreateInstance(arrayInfo.FieldType.GetElementType(), subElements.Length);
                            for (int ii = 0; ii < array2.Length; ++ii)
                                array2.SetValue(XMLtoObject(arrayInfo.FieldType.GetElementType(), subElements[ii]), ii);
                            arrayInfo.SetValue(obj, array2);


                            array.SetValue(obj, i);
                        }
                        field.Value.SetValue(item, array);
                    }
                    else if (element.Name == "value")
                    {
                        field.Value.SetValue(item, XMLtoObject(field.Value.FieldType, elements.First()));
                    }
                    else
                    {
                        var arrayElements = element.Elements().ToArray();
                        var array = Array.CreateInstance(field.Value.FieldType.GetElementType(), arrayElements.Length);
                        for (int i = 0; i < array.Length; ++i)
                            array.SetValue(XMLtoObject(field.Value.FieldType.GetElementType(), arrayElements[i]), i);
                        field.Value.SetValue(item, array);
                    }
                    elements.RemoveAt(0);
                }
                return true;
            }

        }

        /// <summary>
        /// A normal Convert.ChangeType but returns null if fails
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object TryConvert(object obj, Type type)
        {
            try
            {
                return Convert.ChangeType(obj, type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ProcessCredits(GBAPICreditGroup[] groups)
        {
            string s = "";
            foreach (var group in groups)
            {
                s += $"{group.GroupName}\n";
                for (int i = 0; i < group.Credits.Length; ++i)
                {
                    s += $"  - {group.Credits[i].MemberName}\n     {group.Credits[i].Role}\n";
                }
            }
            return s;
        }

        public static object XMLtoObject(Type type, XElement element)
        {
            object obj = TryConvert(element.Value, type);
            if (obj != null)
                return obj;
            obj = Activator.CreateInstance(type);
            var fields = type.GetFields();
            var elements = new List<XElement>(element.Elements());
            if (element.Name == "value")
            {
                return XMLtoObject(type, elements.First());
            }
            foreach (var field in fields)
            {
                var curElement = elements.First();
                if (field.IsLiteral)
                {
                    return obj;
                }
                else if (field.FieldType.IsArray)
                {
                    var arrayElements = curElement.Elements().ToArray();
                    var array = Array.CreateInstance(field.FieldType.GetElementType(), arrayElements.Length);
                    for (int i = 0; i < array.Length; ++i)
                        array.SetValue(XMLtoObject(field.FieldType.GetElementType(), arrayElements[i]), i);
                    field.SetValue(obj, array);
                }
                else
                {
                    object value = TryConvert(curElement.Value, field.FieldType);

                    if (value != null)
                        field.SetValue(obj, value);
                    else
                        field.SetValue(obj, XMLtoObject(field.FieldType, curElement));
                }
                elements.RemoveAt(0);
            }
            return obj;
        }

        public static bool RequestItemData(GBAPIItemData item)
        {
            var handler = new GBAPIRequestHandler();
            handler.ProcessItemData(item);
            string request = handler.Build();
            string response = new WebClient().DownloadString(request);
            return handler.ParseResponse(response, item);
        }

    }
    public class GBAPIItemData
    {
        public string ItemType;
        public int ItemID;

        public GBAPIItemData(string itemType, int itemID)
        {
            ItemType = itemType;
            ItemID = itemID;
        }
    }


    public class GBAPIField : Attribute
    {
        public string FieldName;

        public GBAPIField(string fieldName)
        {
            FieldName = fieldName;
        }
    }

    public class GBAPIFieldKeyArray : Attribute
    {
        public string KeyName;
        public string ArrayName;

        public GBAPIFieldKeyArray(string keyName, string arrayName)
        {
            KeyName = keyName;
            ArrayName = arrayName;
        }
    }


    public class GBAPICredit
    {
        public string MemberName;
        public string Role;
        public int MemberID;
    }

    public class GBAPICreditGroup
    {
        public string GroupName;
        public GBAPICredit[] Credits;
    }


    public class GBAPIItemDataBasic : GBAPIItemData
    {
        [GBAPIField("name")]
        public string ModName;
        [GBAPIField("userid")]
        public int OwnerID;
        [GBAPIField("Owner().name")]
        public string OwnerName;
        [GBAPIField("Preview().sStructuredDataFullsizeUrl()")]
        public string ScreenshotURL;
        [GBAPIField("text")]
        public string Body;
        [GBAPIField("description")]
        public string Subtitle;
        [GBAPIField("Credits().aAuthorsAndGroups()")]
        [GBAPIFieldKeyArray("GroupName", "Credits")]
        public GBAPICreditGroup[] Credits;

        public GBAPIItemDataBasic(string itemType, int itemID) : base(itemType, itemID)
        {
        }

    }
}
