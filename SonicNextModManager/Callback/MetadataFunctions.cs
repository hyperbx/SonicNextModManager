namespace SonicNextModManager.Callback
{
    public class MetadataFunctions
    {
        /// <summary>
        /// Returns the patch's title.
        /// </summary>
        public static string Title(string title)
            => Patch.Metadata.Title = title;

        /// <summary>
        /// Returns the patch's author.
        /// </summary>
        public static string Author(string author)
            => Patch.Metadata.Author = author;

        /// <summary>
        /// Returns the patch's platform.
        /// </summary>
        public static Platform Platform(string platform)
            => Patch.Metadata.Platform = SiS.PlatformConverter.Convert(platform);

        /// <summary>
        /// Returns the patch's blurb.
        /// </summary>
        public static string Blurb(string blurb)
            => Patch.Metadata.Blurb = blurb;

        /// <summary>
        /// Returns the patch's description.
        /// </summary>
        public static string Description(string description)
            => Patch.Metadata.Description = description;

        /// <summary>
        /// Returns the current platform as a string.
        /// </summary>
        public static string GetPlatform()
            => Patch.Metadata.Platform.ToString();
    }
}
