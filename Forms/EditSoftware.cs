using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using vrchat_launcher.Classes;
using Helper = vrchat_launcher.Helper;

namespace vrchat_launcher.Forms
{
    public partial class EditSoftware : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // Edit the software
        private readonly Software _software;

        public EditSoftware(Main mainForm, Software software)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _software = software;
            NAME_TEXTBOX.Text = software.Name;
            AUTHOR_TEXTBOX.Text = software.Author;
            DESCRIPTION_TEXTBOX.Text = software.Description;
            PATH_TEXTBOX.Text = software.Path;
        }

        // This is the event handler for the EDIT_BUTTON
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValue();
            if (reasons.Any())
            {
                MessageBox.Show("The software could not be saved. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Overwrite the software
            var software = new Software
            {
                Name = NAME_TEXTBOX.Text,
                Author = AUTHOR_TEXTBOX.Text == string.Empty ? "Unknown" : AUTHOR_TEXTBOX.Text,
                Description = DESCRIPTION_TEXTBOX.Text == string.Empty ? "No description" : DESCRIPTION_TEXTBOX.Text,
                Path = PATH_TEXTBOX.Text,
                Checked = _software.Checked
            };

            _mainForm.Softwares = _mainForm.Softwares.Where(s => s.Name != _software.Name).ToArray();
            _mainForm.Softwares = _mainForm.Softwares.Append(software);
            MessageBox.Show("Software edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        // This is the event handler for the OPEN_BUTTON
        private void OPEN_BUTTON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select the software"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PATH_TEXTBOX.Text = openFileDialog.FileName;
            }
        }

        // This is the event handler for the RESET_BUTTON
        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            NAME_TEXTBOX.Text = _software.Name;
            AUTHOR_TEXTBOX.Text = _software.Author;
            DESCRIPTION_TEXTBOX.Text = _software.Description;
            PATH_TEXTBOX.Text = _software.Path;
        }

        // Check if the values are valid
        private IEnumerable<string> CheckValue()
        {
            IEnumerable<string> reasons = Array.Empty<string>();
            if (string.IsNullOrEmpty(NAME_TEXTBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Name is empty");
            }

            if (!Helper.IsEnglish(NAME_TEXTBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Name is not in English");
            }

            if (string.IsNullOrEmpty(PATH_TEXTBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Path is empty");
            }

            if (!File.Exists(PATH_TEXTBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Path does not exist");
            }

            if (PATH_TEXTBOX.Text.Contains("ㅤ"))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Path contains invalid characters");
            }

            return reasons;
        }
    }
}
