using CefSharp;
using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using vrchat_launcher.Classes;

namespace vrchat_launcher.Forms
{
    public partial class Main : Form
    {
        public const string CurrentVersion = "v1.0.1-Release";
        private const string CustomVRChatPathFile = "custom_vrchat_path.txt";

        // Data Values
        private Database Data = new Database();

        // CurrentProfile
        private Profile CurrentProfile;

        // GUI Font
        public FontFamily GuiFont;

        // Text Font
        public FontFamily TextFont;

        // Form Font
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        // Constructor
        public Main()
        {
            try
            {
                Helper.ValidateRequiredFiles();
                AddFontFile();

                InitializeComponent();

                InitializeWebBrowser();
                GithubUpdateChecker();
                InitializeDefaults();
                LoadConfigFile();
                SetInitialProfile();
                LoadSoftwares();
            }
            catch (Exception ex)
            {
                Helper.ShowErrorMessage("vrchat-Launcher could not be launched. The reasons are as follows.\n" + ex);
            }
        }

        private void InitializeDefaults()
        {
            CURRENT_VERSION_TEXT.Text = CurrentVersion;
        }

        private void InitializeWebBrowser()
        {
            var result = Helper.InitializeCefSharp();
            if (result)
            {
                var webBrowser = new ChromiumWebBrowser("https://vrchat.com/home");
                TopTab.Controls.Add(webBrowser);
                webBrowser.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("CefSharp could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConfigFile()
        {
            try
            {
                Data = JsonSerializer.Deserialize<Database>(File.ReadAllText("./src/data.json", Encoding.GetEncoding("Shift-JIS")));
            } 
            catch 
            {
                Data = new Database();
            }
        }

        private void SetInitialProfile()
        {
            if (!string.IsNullOrEmpty(Data.LastSelectedProfile))
            {
                CurrentProfile = Data.Profiles.FirstOrDefault(profile => profile.Name == Data.LastSelectedProfile);
                if (CurrentProfile == null)
                {
                    CurrentProfile = Data.Profiles.FirstOrDefault();
                    Data.LastSelectedProfile = CurrentProfile?.Name ?? string.Empty;
                }

                RefreshProfile();
            }
            else
            {
                CurrentProfile = Data.Profiles.FirstOrDefault();
                RefreshProfile();
            }
        }

        private void LoadSoftwares()
        {
            LoadSoftwaresButton();
        }

        // Add the font file
        private void AddFontFile()
        {
            // Add the font files
            _fontCollection.AddFontFile("./src/Fonts/Quicksand-Light.ttf");
            _fontCollection.AddFontFile("./src/Fonts/NotoSansJP-Light.ttf");

            // Set the font
            foreach (FontFamily font in _fontCollection.Families)
            {
                switch (font.Name)
                {
                    case "Quicksand Light":
                        GuiFont = font;
                        break;
                    case "Noto Sans JP Light":
                        TextFont = font;
                        break;
                }
            }
        }

        // Launch VRChat
        private void LAUNCH_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Save the config data
                SaveConfigData();

                string vrchatPath = "C:/Program Files (x86)/Steam/steamapps/common/VRChat";

                bool SetCustomPath()
                {
                    var result = MessageBox.Show("VRChat Folder not found. Do you want to set the custom path?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        var folderBrowserDialog = new FolderBrowserDialog()
                        {
                            Description = "Select the VRChat folder"
                        };

                        if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return false;

                        if (!File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "start_protected_game.exe")))
                        {
                            MessageBox.Show("The selected folder does not contain start_protected_game.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        vrchatPath = folderBrowserDialog.SelectedPath;
                        File.WriteAllText(CustomVRChatPathFile, vrchatPath);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("VRChat could not be launched. The reasons are as follows.\n" + "VRChat Folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (File.Exists(CustomVRChatPathFile))
                {
                    string customPath = File.ReadAllText(CustomVRChatPathFile);
                    if (Directory.Exists(customPath))
                    {
                        vrchatPath = customPath;
                    }
                    else
                    {
                        var result = SetCustomPath();
                        if (!result) return;
                    }
                }

                if (!Directory.Exists(vrchatPath))
                {
                    var result = SetCustomPath();
                    if (!result) return;
                }

                if (Data.LastSelectedDesktopMode)
                {
                    if (CurrentProfile == null)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = Path.Combine(vrchatPath, "start_protected_game.exe"),
                            WorkingDirectory = vrchatPath,
                            Arguments = "--no-vr"
                        };

                        Process.Start(startInfo);
                    }
                    else
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = Path.Combine(vrchatPath, "start_protected_game.exe"),
                            WorkingDirectory = vrchatPath,
                            Arguments = "--no-vr --profile=" + CurrentProfile.Index
                        };

                        Process.Start(startInfo);
                    }
                }
                else
                {
                    if (CurrentProfile == null)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = "steam://rungameid/438100//"
                        };

                        Process.Start(startInfo);
                    }
                    else
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = "steam://rungameid/438100//" + " --profile=" + CurrentProfile.Index
                        };

                        Process.Start(startInfo);
                    }
                }

                // Launch the software
                LaunchSoftwares();
            }
            catch (Exception ex)
            {
                Helper.ShowErrorMessage("VRChat could not be launched. The reasons are as follows.\n" + ex);
            }
        }

        // Save the config data
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        private void SaveConfigData()
        {
            var json = JsonSerializer.Serialize(Data, JsonSerializerOptions);
            File.WriteAllText("./src/data.json", json, Encoding.GetEncoding("Shift-JIS"));
        }

        // Launch the software
        private void LaunchSoftwares()
        {
            foreach (var checkBox in SoftwareTab.Controls.OfType<CheckBox>())
            {
                try
                {
                    if (!checkBox.Checked) continue;
                    foreach (var software in Data.Softwares)
                    {
                        if (software.Name != checkBox.Name) continue;
                        string softwarePath = software.Path;
                        string workingDirectory = Path.GetDirectoryName(softwarePath);
                        if (!File.Exists(softwarePath) || string.IsNullOrEmpty(workingDirectory))
                        {
                            throw new Exception("The software could not be found.");
                        }

                        ProcessStartInfo softwareStartInfo = new ProcessStartInfo
                        {
                            FileName = softwarePath,
                            WorkingDirectory = workingDirectory
                        };

                        Process.Start(softwareStartInfo);
                    }
                }
                catch
                {
                    MessageBox.Show($"The \"{checkBox.Name}\" could not be launched.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Load the software
        private void LoadSoftwaresButton()
        {
            try
            {
                SoftwareTab.Controls.Clear();

                foreach (var software in Data.Softwares.OrderBy(s => s.Name))
                {
                    GenerateSoftwaresTab(software);
                }

                int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);

                Size size = new Size(75, 23);
                Font font = new Font(GuiFont, 13F, FontStyle.Regular, GraphicsUnit.Point, 0);

                var addSoftwareButton = new Button
                {
                    Text = "Add Software",
                    AutoSize = true,
                    Location = new Point(20, baseLocation - 60),
                    Name = "AddSoftwareButton",
                    Size = size,
                    UseVisualStyleBackColor = true,
                    Font = font
                };

                addSoftwareButton.Click += (@object, @event) =>
                {
                    if (Application.OpenForms.OfType<AddSoftware>().Any()) return;

                    var addSoftwareForm = new AddSoftware(this, Data.Softwares);
                    addSoftwareForm.ShowDialog();

                    Data.Softwares = addSoftwareForm.Softwares;

                    LoadSoftwaresButton();
                    SaveConfigData();
                };

                SoftwareTab.Controls.Add(addSoftwareButton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The software could not be loaded. The reasons are as follows.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Generate the software tab
        private void GenerateSoftwaresTab(Software software)
        {
            int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);

            Size size = new Size(15, 14);

            var checkBox = new CheckBox
            {
                Text = string.Empty,
                AutoSize = true,
                Location = new Point(20, baseLocation - 44),
                Name = software.Name,
                Size = size,
                UseVisualStyleBackColor = true
            };

            checkBox.CheckedChanged += (@object, @event) =>
            {
                foreach (var soft in Data.Softwares)
                {
                    if (soft.Name != checkBox.Name) continue;
                    soft.Checked = checkBox.Checked;
                    break;
                }
            };

            var softwareNameLabel = new Label
            {
                AutoSize = true,
                Location = new Point(41, baseLocation - 66),
                Name = "label" + software.Name,
                TabIndex = 1,
                Text = software.Name,
                Font = new Font(GuiFont, 15),
                ContextMenuStrip = new ContextMenuStrip()
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Edit").Click += (@object, @event) =>
            {
                if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                var editSoftwareForm = new EditSoftware(this, software);
                editSoftwareForm.ShowDialog();

                Data.Softwares.Remove(software);
                Data.Softwares.Add(editSoftwareForm.Software);
                
                LoadSoftwaresButton();
                SaveConfigData();
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Delete").Click += (@object, @event) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected software?", "Delete Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                Data.Softwares.Remove(software);

                LoadSoftwaresButton();
                SaveConfigData();
            };

            // Get the width of the label
            int labelWidth = TextRenderer.MeasureText(softwareNameLabel.Text, softwareNameLabel.Font).Width;
            int label2Right = softwareNameLabel.Location.X + labelWidth - 3;

            var authorLabel = new Label
            {
                AutoSize = true,
                Location = new Point(label2Right, baseLocation - 60),
                Name = "label2" + software.Name,
                TabIndex = 1,
                Text = "by " + software.Author,
                Font = new Font(GuiFont, 11)
            };

            var descriptionLabel = new Label
            {
                AutoSize = true,
                Location = new Point(41, baseLocation - 39),
                Name = "label3" + software.Name,
                TabIndex = 1,
                Text = "Description: " + software.Description,
                Font = new Font(GuiFont, 12)
            };

            SoftwareTab.Controls.Add(checkBox);
            if (software.Checked) checkBox.Checked = true;
            SoftwareTab.Controls.Add(softwareNameLabel);
            SoftwareTab.Controls.Add(authorLabel);
            SoftwareTab.Controls.Add(descriptionLabel);
        }

        // Open Profile Manager
        private void PROFILE_BUTTON_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<ProfileForm>().Any()) return;
            var profileForm = new ProfileForm(this, Data.Profiles, CurrentProfile);
            profileForm.ShowDialog();

            Data.Profiles = profileForm.Profiles;
            CurrentProfile = profileForm.Profile;

            RefreshProfile();
            SaveConfigData();
        }

        private void DESKTOP_BUTTON_Click(object sender, EventArgs e)
        {
            // Enabled <=> Disabled
            DESKTOP_BUTTON.Text = DESKTOP_BUTTON.Text == "Enabled" ? "Disabled" : "Enabled";
            DESKTOP_BUTTON.BackColor = DESKTOP_BUTTON.Text == "Enabled" ? Color.LightGreen : Color.LightPink;
            Data.LastSelectedDesktopMode = DESKTOP_BUTTON.Text == "Enabled";
        }

        // Refresh the profile
        private void RefreshProfile()
        {
            Helper.SetControlText(PROFILE_BUTTON, CurrentProfile?.Name, "No Profile");
            if (CurrentProfile == null) return;

            Data.LastSelectedDesktopMode = CurrentProfile.DesktopMode;
            DESKTOP_BUTTON.Text = CurrentProfile.DesktopMode ? "Enabled" : "Disabled";
            DESKTOP_BUTTON.BackColor = CurrentProfile.DesktopMode ? Color.LightGreen : Color.LightPink;

            Data.LastSelectedProfile = CurrentProfile.Name;
        }

        public async void GithubUpdateChecker()
        {
            try
            {
                var latestRelease = await Helper.GetVersion(CurrentVersion);

                if (latestRelease == CurrentVersion)
                {
                    UPDATE_BUTTON.Enabled = false;
                    LATEST_VERSION_TEXT.ForeColor = Color.Black;
                    return;
                }

                UPDATE_BUTTON.Enabled = true;
                LATEST_VERSION_TEXT.ForeColor = Color.Green;

                MessageBox.Show("An update is available! You can update from the Settings tab!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LATEST_VERSION_TEXT.Text = latestRelease;
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occurred while checking for updates: " + exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UPDATE_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = "https://github.com/puk06/vrchat-Launcher/releases/latest"
                };
                Process.Start(processStartInfo);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to open the update page. The reasons are as follows.\n" + exception, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveConfigData();
                Cef.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The configuration could not be saved. The reasons are as follows.\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
