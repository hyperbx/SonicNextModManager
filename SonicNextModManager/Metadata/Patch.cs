using System.IO;
using System.Linq;
using MoonSharp.Interpreter;
using SonicNextModManager.Callback;
using Sprint;

namespace SonicNextModManager
{
    public class Patch : Metadata
    {
        public string? Blurb { get; set; }

        private string? _Description;
        public string? Description
        {
            get => _Description;
            set
            {
                _Description = value;

                /* Set the blurb to the description so the
                   view model has something to display. */
                if (string.IsNullOrEmpty(Blurb))
                    Blurb = value;
            }
        }

        public static Patch Metadata { get; set; } = new Patch();

        /// <summary>
        /// Returns patch metadata parsed from the input file.
        /// </summary>
        /// <param name="file">Lua script to pull metadata from.</param>
        public Patch Parse(string file)
        {
            Metadata = new Patch();

            // Set up Lua interpreter.
            Script L = new Script().Initialise();
            L.PushExposedFunctions<MetadataFunctions>();

            /* Run only the first six lines of the current Lua script.
               Since this is just header information, the rest needs to be skipped.
            
               Figure out a better way to do this, because it could get bad. */
            L.DoString(string.Join("\r\n", File.ReadLines(file).Take(6)));

            // Set metadata path.
            Metadata.Path = file;

            return Metadata;
        }
    }
}
