using System.IO;

namespace Unify.Globalisation
{
    class Literal
    {
        /// <summary>
        /// Translates a Boolean value to 'Yes' or 'No'
        /// </summary>
        public static string Bool(string value) {
            if (value == "True") return "Yes";
            else if (value == "False") return "No";
            else return "N/A";
        }

        /// <summary>
        /// Translates a file extension to 'Xbox 360' or 'PlayStation 3'
        /// </summary>
        public static string System() {
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".xex") return "Xbox 360";
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".bin") return "PlayStation 3";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'Xenia' or 'RPCS3'
        /// </summary>
        public static string Emulator() {
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".xex") return "Xenia";
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".bin") return "RPCS3";
            else return "unspecified";
        }
    }
}
