using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using vrchat_launcher.Classes;

namespace vrchat_launcher.Forms
{
    public partial class EditSoftware : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // Edit the software
        private Software _software;
        internal Software Software
            => _software;


        internal EditSoftware(Main mainForm, Software software)
        {
            _mainForm = mainForm;
            _software = software;

            InitializeComponent();

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

            _software = software;
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
            List<string> reasons = new List<string>();
            if (string.IsNullOrEmpty(NAME_TEXTBOX.Text))
            {
                reasons.Add("❌️ Name is empty");
            }

            if (!Helper.IsEnglish(NAME_TEXTBOX.Text))
            {
                reasons.Add("❌️ Name is not in English");
            }

            if (string.IsNullOrEmpty(PATH_TEXTBOX.Text))
            {
                reasons.Add("❌️ Path is empty");
            }

            if (!File.Exists(PATH_TEXTBOX.Text))
            {
                reasons.Add("❌️ Path does not exist");
            }

            if (PATH_TEXTBOX.Text.Contains("ㅤ"))
            {
                reasons.Add("❌️ Path contains invalid characters");
            }

            return reasons;
        }
    }
}
