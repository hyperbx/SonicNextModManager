using System.Windows.Forms;

namespace SonicNextModManager
{
    public class DirectoryQueries
    {
        private static string BasicDirectoryQuery(string title)
        {
            FolderBrowserDialog fbd = new()
            {
                Description = title,
                UseDescriptionForTitle = true,
            };

            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;

            return string.Empty;
        }

        public static string QueryModsDirectory()
            => BasicDirectoryQuery(Language.Localise("Query_ModsDirectory"));
    }
}
