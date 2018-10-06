using Octokit;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordPresenceUI.Core
{

    /// <summary>
    /// Helper class for interacting with Github.
    /// </summary>
    internal static class GithubHelper
    {

        /// <summary>
        /// Gets the latest release.
        /// </summary>
        private static async Task<Release> GetLatest()
        {
            if (_release == null)
            {
                ReleasesClient releases = new ReleasesClient(new ApiConnection(new Connection(new ProductHeaderValue("DiscordPresenceUI"))));
                _release = await releases.GetLatest("hawezo", "DiscordPresenceUI");
            }
            return _release;
        }
        private static Release _release;

        /// <summary>
        /// Gets an object wich contains data about the latest release.
        /// <seealso cref="GithubRelease"/>
        /// </summary>
        internal static async Task<GithubRelease> GetLatestRelease()
        {
            Release release = await GithubHelper.GetLatest();
            Version releaseVersion = new Version(release.TagName);
            Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            return new GithubRelease()
            {
                Url = release.HtmlUrl,
                IsLatest = (releaseVersion > assemblyVersion),
                Version = releaseVersion,
                Current = assemblyVersion
            };
        }
        
    }

    /// <summary>
    /// Simple class containing data about the latest release.
    /// </summary>
    internal class GithubRelease
    {
        public Version Version { get; set; }
        public Version Current { get; set; }
        public bool IsLatest { get; set; }
        public string Url { get; set; }
    }
}
