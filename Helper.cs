using CefSharp;
using CefSharp.WinForms;
using Octokit;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vrchat_launcher
{
    internal static class Helper
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

        public static void SetControlText(Control control, string text, string defaultText = "")
        {
            control.Text = text ?? defaultText;
        }

        public static bool InitializeCefSharp()
        {
            var settings = new CefSettings
            {
                RootCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };

            return Cef.Initialize(settings);
        }

        public static void ValidateRequiredFiles()
        {
            if (!File.Exists("./src/Fonts/Quicksand-Light.ttf") || !File.Exists("./src/Fonts/NotoSansJP-Light.ttf"))
            {
                ShowErrorMessage("The font file was not found. Download this software again.");
                Environment.Exit(1);
            }

            if (!File.Exists("./src/data.json"))
            {
                ShowErrorMessage("The data file was not found. Download this software again.");
                Environment.Exit(1);
            }
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool IsEnglish(string text)
        {
            return text.All(c => c < 128);
        }
    }
}
