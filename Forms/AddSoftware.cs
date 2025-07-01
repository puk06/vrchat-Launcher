using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using vrchat_launcher.Classes;

namespace vrchat_launcher.Forms
{
    public partial class AddSoftware : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        private readonly List<Software> _softwareList = new List<Software>();

        internal List<Software> Softwares
            => _softwareList;

        public AddSoftware(Main mainForm, List<Software> softwareList)
        {
            _mainForm = mainForm;
            _softwareList = softwareList;
            InitializeComponent();
        }

        // This is the event handler for the CREATE_BUTTON
        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValue();
            if (reasons.Any())
            {
                MessageBox.Show("The software could not be saved. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the software already exists
            if (_softwareList.Any(s => s.Name == NAME_TEXTBOX.Text))
            {
                MessageBox.Show("The software name alread exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save the software
            var software = new Software
            {
                Name = NAME_TEXTBOX.Text,
                Author = AUTHOR_TEXTBOX.Text == string.Empty ? "Unknown" : AUTHOR_TEXTBOX.Text,
                Description = DESCRIPTION_TEXTBOX.Text == string.Empty ? "No description" : DESCRIPTION_TEXTBOX.Text,
                Path = PATH_TEXTBOX.Text,
                Checked = false
            };

            _softwareList.Add(software);
            MessageBox.Show("New software created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            NAME_TEXTBOX.Text = string.Empty;
            AUTHOR_TEXTBOX.Text = string.Empty;
            DESCRIPTION_TEXTBOX.Text = string.Empty;
            PATH_TEXTBOX.Text = string.Empty;
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
