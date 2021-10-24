using System.Threading.Tasks;
using SonicNextModManager.Networking.API.GitHub;

namespace SonicNextModManager
{
    public class GitHub
    {
        private const string API = "https://api.github.com";
        private const string Repositories = "repos";

        /// <summary>
        /// Gets the latest release from the input repository.
        /// </summary>
        /// <param name="username">GitHub username.</param>
        /// <param name="repository">GitHub repository name.</param>
        public static Task<ReleaseInfo> GetLatestRelease(string username, string repository)
        {
            return JsonExtensions.DeserializeWebObjectAsync<ReleaseInfo>
            (
                StringExtensions.URLCombine(API, Repositories, username, repository, "releases", "latest")
            );
        }

        /// <summary>
        /// Gets the latest release from the default repository.
        /// </summary>
        public static Task<ReleaseInfo> GetLatestRelease()
            => GetLatestRelease(Properties.Resources.GitHub_User, Properties.Resources.GitHub_Repository);
    }
}
