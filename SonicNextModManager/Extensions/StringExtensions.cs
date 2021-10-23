using System.IO;

namespace SonicNextModManager
{
    public class StringExtensions
    {
        /// <summary>
        /// Returns a new path with the specified filename.
        /// </summary>
        public static string ReplaceFilename(string path, string newFile)
            => Path.Combine(Path.GetDirectoryName(path), Path.GetFileName(newFile));

        /// <summary>
        /// Returns whether or not the directory is safe to perform actions with.
        /// </summary>
        /// <param name="directory">Directory to check validity.</param>
        public static bool IsDirectorySafe(string directory)
            => Directory.Exists(directory);

        /// <summary>
        /// Removes the source directory from the input path.
        /// </summary>
        /// <param name="path">Path to remove source from.</param>
        /// <param name="source">Source directory to remove.</param>
        public static string OmitSourceDirectory(string path, string source)
            => path.Remove(0, source.Length + 1);
    }
}
