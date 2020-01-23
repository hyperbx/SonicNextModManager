using System.IO;

namespace Unify.Serialisers
{
    class INISerialiser
    {
        /// <summary>
        /// If the specified key is found in the specified INI, return its value as a string. If it's not found, return N/A.
        /// </summary>
        public static string DeserialiseKey(string key, string ini) {
            string line, entryValue = string.Empty;

            using (StreamReader configFile = new StreamReader(ini))
                try {
                    while ((line = configFile.ReadLine()) != null) {
                        if (line.StartsWith(key)) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                        }
                    }
                } catch { }

            if (entryValue == string.Empty) return "N/A";
            else return entryValue;
        }
    }
}
