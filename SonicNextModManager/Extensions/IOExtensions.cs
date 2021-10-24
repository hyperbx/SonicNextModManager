using System.IO;

namespace SonicNextModManager
{
    public class IOExtensions
    {
        /// <summary>
        /// Returns whether or not the directory is safe to perform actions with.
        /// </summary>
        /// <param name="directory">Directory to check validity.</param>
        public static bool IsDirectorySafe(string directory)
            => Directory.Exists(directory);
    }
}
