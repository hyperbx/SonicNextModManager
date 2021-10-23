using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SonicNextModManager
{
    public class Database : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// A collection of mods with their relevant information.
        /// </summary>
        public ObservableCollection<Mod> Mods { get; set; } = new();

        /// <summary>
        /// A collection of patches with their relevant information.
        /// </summary>
        public ObservableCollection<Patch> Patches { get; set; } = new();

        /// <summary>
        /// Active content data for JSON serialisation.
        /// </summary>
        public class ActiveContentData
        {
            /// <summary>
            /// A collection of relative paths to active mods.
            /// </summary>
            public List<string> Mods { get; set; } = new();

            /// <summary>
            /// A collection of relative paths to active patches.
            /// </summary>
            public List<string> Patches { get; set; } = new();
        }

        /// <summary>
        /// Instance of active content data.
        /// </summary>
        public ActiveContentData ActiveContent { get; set; } = new();

        /// <summary>
        /// Location of the content database.
        /// </summary>
        private string Location { get; } = StringExtensions.IsDirectorySafe(Properties.Settings.Default.Path_ModsDirectory)
                                           ? Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "content.json")
                                           : "content.json";

        public Database(bool loadActiveContent = true)
        {
            // Initialise content data upon construction.
            Mods = InitialiseMods();
            Patches = InitialisePatches();

            // Load database and set up checked content.
            if (loadActiveContent)
                Load();
        }

        /// <summary>
        /// Load all mods from the mods directory.
        /// </summary>
        public ObservableCollection<Mod> InitialiseMods()
        {
            if (!StringExtensions.IsDirectorySafe(Properties.Settings.Default.Path_ModsDirectory))
                goto Finish;

            // Clear mods list before writing to it.
            Mods.Clear();

            // Parse all mods from the mods directory.
            foreach (string config in new[] { "mod.json", "mod.ini" })
            {
                foreach (string mod in Directory.GetFiles(Properties.Settings.Default.Path_ModsDirectory, config, SearchOption.AllDirectories))
                    Mods.Add(new Mod().Parse(mod));
            }

        Finish:
            return Mods;
        }

        /// <summary>
        /// Load all patches from the patches directory.
        /// </summary>
        public ObservableCollection<Patch> InitialisePatches()
        {
            if (!StringExtensions.IsDirectorySafe(App.Directories["Patches"]))
                goto Finish;

            // Clear patches list before writing to it.
            Patches.Clear();

            // Parse all patches from the patches directory.
            foreach (string patch in Directory.GetFiles(App.Directories["Patches"], "Patch_*.lua", SearchOption.AllDirectories))
                Patches.Add(new Patch().Parse(patch));

        Finish:
            return Patches;
        }

        /// <summary>
        /// Load and restore all enabled content from the database.
        /// </summary>
        public void Load()
        {
            if
            (
                !File.Exists(Location) &&
                !StringExtensions.IsDirectorySafe(Properties.Settings.Default.Path_ModsDirectory) &&
                !StringExtensions.IsDirectorySafe(App.Directories["Patches"])
            )
            {
                return;
            }

            // Deserialise JSON to content.
            ActiveContent = JsonConvert.DeserializeObject<ActiveContentData>(File.ReadAllText(Location));

            foreach (var modRelativePath in ActiveContent.Mods.AsEnumerable().Reverse())
            {
                Mod mod = Mods.SingleOrDefault
                (
                    // Combine with mods directory with the relative path to get the full path.
                    mod => mod.Path == Path.Combine(Properties.Settings.Default.Path_ModsDirectory, modRelativePath.ToString())
                );

                SetMetadataEnabledState(mod, Mods);
            }

            foreach (var patchRelativePath in ActiveContent.Patches.AsEnumerable().Reverse())
            {
                Patch patch = Patches.SingleOrDefault
                (
                    // Combine with patches directory with the relative path to get the full path.
                    patch => patch.Path == Path.Combine(App.Directories["Patches"], patchRelativePath.ToString())
                );

                SetMetadataEnabledState(patch, Patches);
            }

            void SetMetadataEnabledState<T>(T metadata, ObservableCollection<T> collection) where T : Metadata
            {
                if (metadata != null)
                {
                    // Set enabled state.
                    metadata.Enabled = true;

                    // Insert to the beginning of the collection.
                    collection.Remove(metadata);
                    collection.Insert(0, metadata);
                }
            }
        }

        /// <summary>
        /// Save all enabled content to the database.
        /// </summary>
        public void Save()
        {
            // Clear active content lists.
            ActiveContent.Mods.Clear();
            ActiveContent.Patches.Clear();

            foreach (var mod in Mods)
            {
                if (mod.Enabled)
                {
                    ActiveContent.Mods.Add
                    (
                        StringExtensions.OmitSourceDirectory(mod.Path, Properties.Settings.Default.Path_ModsDirectory)
                    );
                }
            }

            foreach (var patch in Patches)
            {
                if (patch.Enabled)
                {
                    ActiveContent.Patches.Add
                    (
                        StringExtensions.OmitSourceDirectory(patch.Path, App.Directories["Patches"])
                    );
                }
            }

            File.WriteAllText(Location, JsonConvert.SerializeObject(ActiveContent, Formatting.Indented));
        }
    }
}
