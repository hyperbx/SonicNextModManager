using System.IO;

namespace Unify.Serialisers
{
    class INISerialiser
    {
        public static string DeserialiseKey(string key, string ini) {
            //If the specified key is found in the specified ini, return its value as a string, if it's not found, return N/A.
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
