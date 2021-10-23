using System.IO;

namespace SonicNextModManager.SiS
{
    public class MetadataConverter
    {
        /// <summary>
        /// Converts older metadata to the new format.
        /// </summary>
        /// <param name="file">File to parse metadata from.</param>
        /// <param name="rewrite">Determines if the mod's configuration should be rewritten as JSON.</param>
        public static Mod Convert(string file, bool rewrite = false)
        {
            Mod mod = new()
            {
                Title = DeserialiseKey(file, "Title"),
                Version = DeserialiseKey(file, "Version"),
                Date = DeserialiseKey(file, "Date"),
                Author = DeserialiseKey(file, "Author"),
                Platform = PlatformConverter.Convert(DeserialiseKey(file, "Platform")),
                Description = DeserialiseKey(file, "Description"),

                Merge = bool.Parse(DeserialiseKey(file, "Merge")),
                Path = file
            };

            string requiredPatchesCSV = DeserialiseKey(file, "RequiredPatches");
            string readOnlyCSV = DeserialiseKey(file, "Read-only");
            string customCSV = DeserialiseKey(file, "Custom");

            if (!string.IsNullOrEmpty(requiredPatchesCSV))
                mod.RequiredPatches.AddRange(requiredPatchesCSV.Split(','));

            if (!string.IsNullOrEmpty(readOnlyCSV))
                mod.ReadOnly.AddRange(readOnlyCSV.Split(','));

            if (!string.IsNullOrEmpty(customCSV))
                mod.Custom.AddRange(customCSV.Split(','));

            if (rewrite)
                mod.Write(mod, StringExtensions.ReplaceFilename(file, "mod.json"));

            return mod;
        }

        /// <summary>
        /// A dirty way of deserialising an INI key.
        /// <para><see href="https://github.com/Big-Endian-32/Sonic-06-Mod-Manager/blob/Project-Rush/Sonic-06-Mod-Manager/src/UnifySerialisers.cs#L48">Learn more...</see></para>
        /// </summary>
        /// <param name="file">Input file.</param>
        /// <param name="key">Key to deserialise.</param>
        private static string DeserialiseKey(string file, string key)
        {
            string line, entryValue = string.Empty;

            using (StreamReader streamReader = new(file))
            {
                try
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Split('=')[0] == key)
                        {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                        }
                    }
                }
                catch
                {
                    // Ignored...
                }
            }

            return entryValue;
        }
    }
}
