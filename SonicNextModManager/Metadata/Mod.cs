using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace SonicNextModManager
{
    public class Mod : Metadata
    {
        public string? Version { get; set; }

        public string? Date { get; set; }

        public string? Description { get; set; }

        public ObservableCollection<string> RequiredPatches { get; set; } = new();

        public ObservableCollection<string> ReadOnly { get; set; } = new();

        public ObservableCollection<string> Custom { get; set; } = new();

        public bool Merge { get; set; }

        public ObservableCollection<string> DLLs { get; set; } = new();

        public ObservableCollection<string> Patches { get; set; } = new();

        public Mod Parse(string file)
        {
            Mod metadata = new() { Title = "Unknown" };

            switch (System.IO.Path.GetFileName(file))
            {
                // Deserialise new JSON format.
                case "mod.json":
                    metadata = JsonConvert.DeserializeObject<Mod>(File.ReadAllText(file));
                    break;

                // Use backwards compatibility converter.
                case "mod.ini":
                    metadata = SiS.MetadataConverter.Convert(file, false);
                    break;
            }

            // Set metadata path.
            metadata.Path = file;

            return metadata;
        }

        public void Write(Mod mod, string file)
            => File.WriteAllText(file, JsonConvert.SerializeObject(mod, Formatting.Indented));
    }
}
