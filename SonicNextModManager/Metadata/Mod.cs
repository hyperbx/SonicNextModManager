using System.Collections.ObjectModel;

namespace SonicNextModManager
{
    public class Mod : Metadata
    {
        /// <summary>
        /// The version string for this mod.
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// A collection of patches required by this mod.
        /// </summary>
        public ObservableCollection<string> RequiredPatches { get; set; } = new();

        /// <summary>
        /// A collection of archives that shouldn't be merged in this mod.
        /// </summary>
        public ObservableCollection<string> ReadOnly { get; set; } = new();

        /// <summary>
        /// A collection of custom files that should be loaded for this mod.
        /// </summary>
        public ObservableCollection<string> Custom { get; set; } = new();

        /// <summary>
        /// Determines if this mod can merge with others.
        /// </summary>
        public bool Merge { get; set; }

        /// <summary>
        /// Determines if this mod uses the DLC system.
        /// </summary>
        public bool DLC { get; set; }

        /// <summary>
        /// A collection of DLLs used by this mod.
        /// </summary>
        public ObservableCollection<string> DLLs { get; set; } = new();

        /// <summary>
        /// A collection of hybrid patches used by this mod.
        /// </summary>
        public ObservableCollection<string> Patches { get; set; } = new();

        /// <summary>
        /// The path to the thumbnail used by this mod.
        /// </summary>
        public string? Thumbnail { get; set; }

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

            // Get single thumbnail and use that as the path.
            string thumbnail;
            if (DirectoryExtensions.Contains(System.IO.Path.GetDirectoryName(file), "thumbnail.*", out thumbnail))
                metadata.Thumbnail = thumbnail;

            return metadata;
        }

        public void Write(Mod mod, string file)
            => File.WriteAllText(file, JsonConvert.SerializeObject(mod, Formatting.Indented));

        public void Write(string file)
            => Write(this, file);
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class Thumbnail2WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => string.IsNullOrEmpty((string)value) ? 0 : 320;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
