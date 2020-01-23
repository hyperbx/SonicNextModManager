using System.Net;
using System.Threading.Tasks;

namespace Unify.Networking
{
    class Client
    {
        /// <summary>
        /// Asynchronously grabs a string from the specified URI.
        /// </summary>
        public static async Task<string> RequestString(string uri) { return await new WebClient().DownloadStringTaskAsync(uri); }
    }
}
