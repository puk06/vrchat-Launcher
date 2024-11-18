using System;
using System.Threading.Tasks;
using Octokit;

namespace vrchat_launcher.Classes
{
    internal class Helper
    {
        public static async Task<string> GetVersion(string currentVersion)
        {
            try
            {
                var releaseType = currentVersion.Split('-')[1];
                var githubClient = new GitHubClient(new ProductHeaderValue("vrchat-Launcher"));
                var tags = await githubClient.Repository.GetAllTags("puk06", "vrchat-Launcher");
                string latestVersion = currentVersion;
                foreach (var tag in tags)
                {
                    if (releaseType == "Release")
                    {
                        if (tag.Name.Split('-')[1] != "Release") continue;
                        latestVersion = tag.Name;
                        break;
                    }

                    latestVersion = tag.Name;
                    break;
                }

                return latestVersion;
            }
            catch
            {
                throw new Exception("Failed to get latest version");
            }
        }
    }
}
