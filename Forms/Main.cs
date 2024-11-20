using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using vrchat_launcher.Classes;
using Profile = vrchat_launcher.Classes.Profile;
using static vrchat_launcher.Classes.Helper;

namespace vrchat_launcher.Forms
{
    public partial class Main : Form
    {
        public const string CurrentVersion = "v1.0.0-Release";

        // Data Values
        public JObject Data;

        // Profiles
        public IEnumerable<Profile> Profiles = Array.Empty<Profile>();

        // Softwares
        public IEnumerable<Software> Softwares = Array.Empty<Software>();

        // GUI Font
        public FontFamily GuiFont;

        // Text Font
        public FontFamily TextFont;

        // Desktop Mode
        public bool DesktopMode = true;

        // Current Profile
        public Profile CurrentProfile;

        // Last Selected Desktop Mode
        public bool LastSelectedDesktopMode = true;

        // Last Selected Profile
        public string LastSelectedProfile;

        // Form Font
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        // Constructor
        public Main()
        {
            try
            {
                Helper.InitializeCefSharp();
                Helper.ValidateRequiredFiles();
                AddFontFile();
                InitializeComponent();
                GithubUpdateChecker();
                InitializeDefaults();
                InitializeWebBrowser();
                LoadConfigFile();
                InitializeComboboxes();
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
            var webBrowser = new ChromiumWebBrowser("https://vrchat.com/home");
            TopTab.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
        }

        private void LoadConfigFile()
        {
            StreamReader streamReader = new StreamReader("./src/data.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            Data = JObject.Parse(str);
        }

        private void InitializeComboboxes()
        {
            InitializeProfiles();
        }

        private void InitializeProfiles()
        {
            if (Data["Profiles"] == null) Data["Profiles"] = new JArray();
            foreach (var userdata in Data["Profiles"])
            {
                var user = new Profile
                {
                    Name = userdata["Name"].ToString(),
                    Description = userdata["Description"].ToString(),
                    DesktopMode = userdata["DesktopMode"].ToObject<bool>(),
                    Index = userdata["Index"].ToObject<int>()
                };
                Helper.AddValueToArray(ref Profiles, user);
            }

            //Last Selected Profile
            if (Data["LastSelectedProfile"] == null) Data["LastSelectedProfile"] = string.Empty;
            LastSelectedProfile = Data["LastSelectedProfile"].ToString();

            //Last Selected Desktop Mode
            if (Data["LastSelectedDesktopMode"] == null) Data["LastSelectedDesktopMode"] = true;
            LastSelectedDesktopMode = Data["LastSelectedDesktopMode"].ToObject<bool>();
        }

        private void SetInitialProfile()
        {
            var enumerable = Profiles as Profile[] ?? Profiles.ToArray();

            if (!string.IsNullOrEmpty(LastSelectedProfile))
            {
                CurrentProfile = Profiles.FirstOrDefault(profile => profile.Name == LastSelectedProfile);
                if (CurrentProfile == null)
                {
                    if (enumerable.Length <= 0) return;
                    CurrentProfile = enumerable.First();
                    LastSelectedProfile = CurrentProfile.Name;
                }
                PROFILE_BUTTON.Text = CurrentProfile.Name;
                RefreshProfile();
            }
            else
            {
                if (enumerable.Length <= 0) return;
                CurrentProfile = enumerable.First();
                PROFILE_BUTTON.Text = CurrentProfile.Name;
                RefreshProfile();
            }
        }

        private void LoadSoftwares()
        {
            if (Data["Softwares"] == null) Data["Softwares"] = new JArray();
            foreach (var software in Data["Softwares"])
            {
                var soft = new Software
                {
                    Name = software["Name"].ToString(),
                    Author = software["Author"].ToString(),
                    Description = software["Description"].ToString(),
                    Path = software["Path"].ToString(),
                    Checked = software["Checked"].ToObject<bool>(),
                };
                Helper.AddValueToArray(ref Softwares, soft);
            }
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

                const string vrchatPath = "C:/Program Files (x86)/Steam/steamapps/common/VRChat";

                if (DesktopMode)
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
                            FileName = "steam://rungameid/438100//" + "--profile=" + CurrentProfile.Index
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
        public void SaveConfigData()
        {
            // Save the last selected profile
            Data["LastSelectedProfile"] = LastSelectedProfile;

            // Save the last selected desktop mode
            Data["LastSelectedDesktopMode"] = LastSelectedDesktopMode;

            Data["Profiles"] = new JArray();
            foreach (var profile in Profiles)
            {
                (Data["Profiles"] as JArray).Add(new JObject
                {
                    { "Name", profile.Name },
                    { "Description", profile.Description },
                    { "DesktopMode", profile.DesktopMode },
                    { "Index", profile.Index }
                });
            }

            Data["Softwares"] = new JArray();
            foreach (var software in Softwares)
            {
                (Data["Softwares"] as JArray).Add(new JObject
                {
                    { "Name", software.Name },
                    { "Author", software.Author },
                    { "Description", software.Description },
                    { "Path", software.Path },
                    { "Checked", software.Checked }
                });
            }

            StreamWriter streamWriter =
                new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
            streamWriter.WriteLine(Data.ToString());
            streamWriter.Close();
        }

        // Launch the software
        private void LaunchSoftwares()
        {
            foreach (var checkBox in SoftwareTab.Controls.OfType<CheckBox>())
            {
                try
                {
                    if (!checkBox.Checked) continue;
                    foreach (var software in Softwares)
                    {
                        if (software.Name != checkBox.Name) continue;
                        string softwarePath = software.Path;
                        string workingDirectory = Path.GetDirectoryName(softwarePath);
                        if (!File.Exists(softwarePath) || string.IsNullOrEmpty(workingDirectory))
                            throw new Exception("The software could not be found.");
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
                Softwares = Softwares.OrderBy(s => s.Name).ToArray();
                var enumerable = Softwares as Software[] ?? Softwares.ToArray();
                for (int i = 0; i < enumerable.Length; i++)
                {
                    GenerateSoftwaresTab(enumerable.ElementAt(i));
                }

                int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);
                var addSoftwareButton = new Button
                {
                    Text = "Add Software",
                    AutoSize = true,
                    Location = new Point(20, baseLocation - 60),
                    Name = "AddSoftwareButton",
                    Size = new Size(75, 23),
                    TabIndex = 0,
                    UseVisualStyleBackColor = true,
                    Font = new Font(_fontCollection.Families[1], 13F, FontStyle.Regular, GraphicsUnit.Point, 0)
                };

                addSoftwareButton.Click += (@object, @event) =>
                {
                    if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                    var addSoftwareForm = new AddSoftware(this);
                    addSoftwareForm.Show();

                    // Disable the form
                    Enabled = false;

                    addSoftwareForm.FormClosed += (object2, event2) =>
                    {
                        SoftwareTab.Controls.Clear();
                        LoadSoftwaresButton();
                        SaveConfigData();

                        // Enable the form
                        Enabled = true;
                    };
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
            var checkBox = new CheckBox
            {
                Text = string.Empty,
                AutoSize = true,
                Location = new Point(20, baseLocation - 44),
                Name = software.Name,
                Size = new Size(15, 14),
                TabIndex = 0,
                UseVisualStyleBackColor = true
            };

            checkBox.CheckedChanged += (@object, @event) =>
            {
                foreach (var soft in Softwares)
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
                Font = new Font(_fontCollection.Families[1], 15),
                ContextMenuStrip = new ContextMenuStrip()
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Edit").Click += (@object, @event) =>
            {
                if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                var editSoftwareForm = new EditSoftware(this, software);
                editSoftwareForm.Show();
                editSoftwareForm.FormClosed += (object2, event2) =>
                {
                    SoftwareTab.Controls.Clear();
                    LoadSoftwaresButton();
                };
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Delete").Click += (@object, @event) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected software?", "Delete Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                Softwares = Softwares.Where(s => s.Name != software.Name).ToArray();
                SoftwareTab.Controls.Clear();
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
                Font = new Font(_fontCollection.Families[1], 11)
            };

            var descriptionLabel = new Label
            {
                AutoSize = true,
                Location = new Point(41, baseLocation - 39),
                Name = "label3" + software.Name,
                TabIndex = 1,
                Text = "Description: " + software.Description,
                Font = new Font(_fontCollection.Families[1], 12)
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
            var profileForm = new ProfileForm(Profiles, this);
            profileForm.Show();

            // Disable the form
            Enabled = false;

            // if the form is closed, update the profile
            profileForm.FormClosed += (@object, @event) =>
            {
                RefreshProfile();

                // Enable the form
                Enabled = true;
            };
        }

        private void DESKTOP_BUTTON_Click(object sender, EventArgs e)
        {
            // Enabled <=> Disabled
            DESKTOP_BUTTON.Text = DESKTOP_BUTTON.Text == "Enabled" ? "Disabled" : "Enabled";
            DESKTOP_BUTTON.BackColor = DESKTOP_BUTTON.Text == "Enabled" ? Color.LightGreen : Color.LightPink;
            DesktopMode = DESKTOP_BUTTON.Text == "Enabled";
            LastSelectedDesktopMode = DesktopMode;
        }

        // Refresh the profile
        private void RefreshProfile()
        {
            Helper.SetControlText(PROFILE_BUTTON, CurrentProfile?.Name, "No Profile");
            if (CurrentProfile == null) return;
            DesktopMode = CurrentProfile.DesktopMode;
            DESKTOP_BUTTON.Text = DesktopMode ? "Enabled" : "Disabled";
            DESKTOP_BUTTON.BackColor = DesktopMode ? Color.LightGreen : Color.LightPink;

            LastSelectedProfile = CurrentProfile.Name;
        }

        public async void GithubUpdateChecker()
        {
            try
            {
                var latestRelease = await GetVersion(CurrentVersion);
                LATEST_VERSION_TEXT.Text = latestRelease;
                if (latestRelease == CurrentVersion)
                {
                    UPDATE_BUTTON.Enabled = false;
                    LATEST_VERSION_TEXT.ForeColor = Color.Black;
                    return;
                }
                UPDATE_BUTTON.Enabled = true;
                LATEST_VERSION_TEXT.ForeColor = Color.Green;
                MessageBox.Show("An update is available! You can update from the Settings tab!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!File.Exists("./Updater/Software Updater.exe"))
                {
                    MessageBox.Show("The updater was not found. Please download it manually.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string updaterPath = Path.GetFullPath("./Updater/Software Updater.exe");
                string latestVersion = LATEST_VERSION_TEXT.Text;
                const string author = "puk06";
                const string repository = "vrchat-Launcher";
                const string executableName = "vrchat-launcher";
                ProcessStartInfo args = new ProcessStartInfo()
                {
                    FileName = $"\"{updaterPath}\"",
                    Arguments = $"\"{latestVersion}\" \"{author}\" \"{repository}\" \"{executableName}\" \"data.json\"",
                    UseShellExecute = true
                };

                Process.Start(args);
            }
            catch (Exception exception)
            {
                MessageBox.Show("The updater could not be launched" + exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveConfigData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The configuration could not be saved. The reasons are as follows.\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
