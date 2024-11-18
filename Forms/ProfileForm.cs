using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using vrchat_launcher.Classes;
using Helper = vrchat_launcher.Helper;

namespace vrchat_launcher.Forms
{
    public partial class ProfileForm : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // This is the constructor for the ProfileForm
        public ProfileForm(IEnumerable<Profile> profiles, Main mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            var enumerable = profiles as Profile[] ?? profiles.ToArray();
            for (int i = 0; i < enumerable.Length; i++)
            {
                GenerateButton(enumerable.ElementAt(i));
                PROFILEEDIT_COMBOBOX.Items.Add(enumerable.ElementAt(i).Name);
            }

            // Highlight the current profile
            HightLightCurrentProfile();

            if (PROFILEEDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                PROFILEEDIT_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }
        }

        // Change the status of the edit form
        private void ChangeEditFormStatus(bool value)
        {
            USERNAMEEDIT_TEXTBOX.Enabled = value;
            EDIT_BUTTON.Enabled = value;
            EDITRESET_BUTTON.Enabled = value;
        }

        // Generate a button for each profile
        private void GenerateButton(Profile profile)
        {
            Button button = new Button
            {
                Text = profile.Name,
                Location = new Point(14, 45 * (ProfilesTab.Controls.OfType<Button>().Count() + 1)),
                Size = new Size(250, 42),
                Font = new Font(_mainForm.GuiFont, 15.75F)
            };
            button.Click += (@object, @event) =>
            {
                _mainForm.CurrentProfile = profile;
                Close();
            };
            button.ContextMenuStrip = new ContextMenuStrip();
            button.ContextMenuStrip.Items.Add("Delete").Click += (@object, @event) =>
            {
                // Ask the user if they are sure they want to delete the profile
                var result = MessageBox.Show("Are you sure you want to delete this profile?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                _mainForm.Profiles = _mainForm.Profiles.Where(u => u.Name != profile.Name);
                ProfilesTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                PROFILEEDIT_COMBOBOX.Items.Clear();
                foreach (var p in _mainForm.Profiles)
                {
                    GenerateButton(p);
                    PROFILEEDIT_COMBOBOX.Items.Add(p.Name);
                }

                if (PROFILEEDIT_COMBOBOX.Items.Count > 0)
                {
                    ChangeEditFormStatus(true);
                    PROFILEEDIT_COMBOBOX.SelectedIndex = 0;
                }
                else
                {
                    ResetValueEdit();
                    ChangeEditFormStatus(false);
                }

                _mainForm.SaveConfigData();
                _mainForm.CurrentProfile = null;
            };
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(button, profile.Description);
            ProfilesTab.Controls.Add(button);
        }

        // This is the event handler for the CREATE_BUTTON
        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            if (IsAnyFieldEmpty())
            {
                Helper.ShowErrorMessage("Please fill in all fields");
                return;
            }

            if (IsProfileNameDuplicate())
            {
                Helper.ShowErrorMessage("The profile name already exists");
                NAME_TEXTBOX.Text = string.Empty;
                return;
            }

            var profile = CreateProfile();

            _mainForm.Profiles = _mainForm.Profiles.Append(profile);
            MessageBox.Show("New profile created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentProfile = profile;
            _mainForm.SaveConfigData();
            UpdateProfile();
            ResetValue();
        }

        // This is the event handler for the EDIT_BUTTON
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            if (IsAnyFieldEmptyEdit())
            {
                Helper.ShowErrorMessage("Please fill in all fields");
                return;
            }

            var profile = EditProfile();
            _mainForm.Profiles = _mainForm.Profiles.Where(u => u.Name != profile.Name);
            _mainForm.Profiles = _mainForm.Profiles.Append(profile);
            MessageBox.Show("Profile edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentProfile = profile;
            _mainForm.SaveConfigData();
            UpdateProfile();

            if (PROFILEEDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                var index = PROFILEEDIT_COMBOBOX.Items.IndexOf(profile.Name);
                PROFILEEDIT_COMBOBOX.SelectedIndex = index != -1 ? index : 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }
        }

        // Check if any required field is empty
        private bool IsAnyFieldEmpty()
        {
            return string.IsNullOrEmpty(NAME_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(USERNAME_TEXTBOX.Text);
        }

        // Check if any required field is empty for editing
        private bool IsAnyFieldEmptyEdit()
        {
            return string.IsNullOrEmpty(NAMEEDIT_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(USERNAMEEDIT_TEXTBOX.Text);
        }

        // Check if the profile name already exists
        private bool IsProfileNameDuplicate()
        {
            return _mainForm.Profiles.Any(userdata => userdata.Name == NAME_TEXTBOX.Text);
        }

        // Create a new profile based on form input
        private Profile CreateProfile()
        {
            var profile = new Profile
            {
                Name = NAME_TEXTBOX.Text,
                Description = USERNAME_TEXTBOX.Text,
                Index = GenerateIndex(_mainForm.Profiles.ToArray()),
            };

            // Add optional parameters
            AddOptionalParameters(profile);

            return profile;
        }

        private static int GenerateIndex(Profile[] profiles)
        {
            int currentIndex = 1;
            while (true)
            {
                if (profiles.All(p => p.Index != currentIndex))
                {
                    return currentIndex;
                }
                currentIndex++;
            }
        }

        // Edit a profile based on form input
        private Profile EditProfile()
        {
            var profile = new Profile
            {
                Name = NAMEEDIT_TEXTBOX.Text,
                Description = USERNAMEEDIT_TEXTBOX.Text,
                Index = _mainForm.Profiles.First(p => p.Name == PROFILEEDIT_COMBOBOX.Text).Index
            };

            // Add optional parameters
            AddOptionalParametersEdit(profile);

            return profile;
        }

        // Add optional parameters to the profile
        private void AddOptionalParameters(Profile profile)
        {
            profile.DesktopMode = DESKTOPMODE_CHECKBOX.Checked;
        }

        // Add optional parameters to the profile for editing
        private void AddOptionalParametersEdit(Profile profile)
        {
            profile.DesktopMode = DESKTOPMODEEDIT_CHECKBOX.Checked;
        }

        // Update the profile on the Users tab and edit combobox
        private void UpdateProfile()
        {
            ProfilesTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
            PROFILEEDIT_COMBOBOX.Items.Clear();
            foreach (var p in _mainForm.Profiles)
            {
                GenerateButton(p);
                PROFILEEDIT_COMBOBOX.Items.Add(p.Name);
            }

            if (PROFILEEDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                PROFILEEDIT_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }

            // Highlight the current profile
            HightLightCurrentProfile();
        }

        // Highlight the current profile
        private void HightLightCurrentProfile()
        {
            if (_mainForm.CurrentProfile == null) return;
            foreach (Button button in ProfilesTab.Controls.OfType<Button>())
            {
                if (button.Text == _mainForm.CurrentProfile.Name)
                {
                    button.BackColor = Color.LightGreen;
                }
            }
        }

        // This is the event handler for the RESET_BUTTON
        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        // This is the event handler for the EDITRESET_BUTTON
        private void EDITRESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetValueEdit();
        }

        // Reset the values of the form
        private void ResetValue()
        {
            NAME_TEXTBOX.Text = string.Empty;
            USERNAME_TEXTBOX.Text = string.Empty;
            DESKTOPMODE_CHECKBOX.Checked = false;
        }

        private void ResetValueEdit()
        {
            NAMEEDIT_TEXTBOX.Text = string.Empty;
            USERNAMEEDIT_TEXTBOX.Text = string.Empty;
            DESKTOPMODEEDIT_CHECKBOX.Checked = false;
        }

        // This is the event handler for the PROFILEEDIT_COMBOBOX
        private void PROFILEEDIT_COMBOBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = _mainForm.Profiles.FirstOrDefault(p => p.Name == PROFILEEDIT_COMBOBOX.Text);
            if (profile == null) return;
            NAMEEDIT_TEXTBOX.Text = profile.Name;
            USERNAMEEDIT_TEXTBOX.Text = profile.Description;
            DESKTOPMODEEDIT_CHECKBOX.Checked = profile.DesktopMode;
        }
    }
}
