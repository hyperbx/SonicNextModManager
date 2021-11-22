namespace SonicNextModManager.SiS
{
    public class PlatformConverter
    {
        /// <summary>
        /// Converts the platform from older metadata.
        /// </summary>
        /// <param name="platform">Platform by name.</param>
        public static Platform Convert(string platform)
        {
            if (!Enum.TryParse(platform, out Platform parsed))
            {
                parsed = platform switch
                {
                    "Xbox 360" => Platform.Xbox,
                    "PlayStation 3" => Platform.PlayStation,
                    _ => Platform.Any,
                };
            }

            return parsed;
        }
    }
}
