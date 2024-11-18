using System.Windows.Forms;

namespace vrchat_launcher.Forms
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.ProfilesTab = new System.Windows.Forms.TabPage();
            this.SELECTUSER_LABEL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateTab = new System.Windows.Forms.TabPage();
            this.NAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RESET_BUTTON = new System.Windows.Forms.Button();
            this.CREATE_BUTTON = new System.Windows.Forms.Button();
            this.USERNAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.NEWUSER_LABEL = new System.Windows.Forms.Label();
            this.EditTab = new System.Windows.Forms.TabPage();
            this.PROFILEEDIT_LABEL = new System.Windows.Forms.Label();
            this.PROFILEEDIT_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.NAMEEDIT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAMEEDIT_LABEL = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.EDITRESET_BUTTON = new System.Windows.Forms.Button();
            this.EDIT_BUTTON = new System.Windows.Forms.Button();
            this.USERNAMEEDIT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.USERNAMEEDIT_LABEL = new System.Windows.Forms.Label();
            this.EDITPROFILE_LABEL = new System.Windows.Forms.Label();
            this.USERFORM_LABEL = new System.Windows.Forms.Label();
            this.DESKTOPMODE_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.DESKTOPMODEEDIT_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.MainTab.SuspendLayout();
            this.ProfilesTab.SuspendLayout();
            this.CreateTab.SuspendLayout();
            this.EditTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.ProfilesTab);
            this.MainTab.Controls.Add(this.CreateTab);
            this.MainTab.Controls.Add(this.EditTab);
            this.MainTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F);
            this.MainTab.Location = new System.Drawing.Point(12, 54);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(291, 384);
            this.MainTab.TabIndex = 0;
            // 
            // ProfilesTab
            // 
            this.ProfilesTab.AutoScroll = true;
            this.ProfilesTab.Controls.Add(this.SELECTUSER_LABEL);
            this.ProfilesTab.Controls.Add(this.label3);
            this.ProfilesTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilesTab.Location = new System.Drawing.Point(4, 27);
            this.ProfilesTab.Name = "ProfilesTab";
            this.ProfilesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProfilesTab.Size = new System.Drawing.Size(283, 353);
            this.ProfilesTab.TabIndex = 0;
            this.ProfilesTab.Text = "Profiles";
            // 
            // SELECTUSER_LABEL
            // 
            this.SELECTUSER_LABEL.AutoSize = true;
            this.SELECTUSER_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.SELECTUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.SELECTUSER_LABEL.Name = "SELECTUSER_LABEL";
            this.SELECTUSER_LABEL.Size = new System.Drawing.Size(143, 33);
            this.SELECTUSER_LABEL.TabIndex = 31;
            this.SELECTUSER_LABEL.Text = "Select Profile";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(14, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 1);
            this.label3.TabIndex = 21;
            // 
            // CreateTab
            // 
            this.CreateTab.AutoScroll = true;
            this.CreateTab.Controls.Add(this.DESKTOPMODE_CHECKBOX);
            this.CreateTab.Controls.Add(this.NAME_TEXTBOX);
            this.CreateTab.Controls.Add(this.NAME_LABEL);
            this.CreateTab.Controls.Add(this.label1);
            this.CreateTab.Controls.Add(this.RESET_BUTTON);
            this.CreateTab.Controls.Add(this.CREATE_BUTTON);
            this.CreateTab.Controls.Add(this.USERNAME_TEXTBOX);
            this.CreateTab.Controls.Add(this.USERNAME_LABEL);
            this.CreateTab.Controls.Add(this.NEWUSER_LABEL);
            this.CreateTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F);
            this.CreateTab.Location = new System.Drawing.Point(4, 27);
            this.CreateTab.Name = "CreateTab";
            this.CreateTab.Padding = new System.Windows.Forms.Padding(3);
            this.CreateTab.Size = new System.Drawing.Size(283, 353);
            this.CreateTab.TabIndex = 1;
            this.CreateTab.Text = "Create Profile";
            // 
            // NAME_TEXTBOX
            // 
            this.NAME_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.NAME_TEXTBOX.Location = new System.Drawing.Point(104, 45);
            this.NAME_TEXTBOX.Name = "NAME_TEXTBOX";
            this.NAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.NAME_TEXTBOX.TabIndex = 32;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.NAME_LABEL.Location = new System.Drawing.Point(11, 43);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(56, 24);
            this.NAME_LABEL.TabIndex = 31;
            this.NAME_LABEL.Text = "Name";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 1);
            this.label1.TabIndex = 30;
            // 
            // RESET_BUTTON
            // 
            this.RESET_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.RESET_BUTTON.Location = new System.Drawing.Point(156, 144);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.RESET_BUTTON.TabIndex = 29;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.CREATE_BUTTON.Location = new System.Drawing.Point(13, 144);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.CREATE_BUTTON.TabIndex = 28;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // USERNAME_TEXTBOX
            // 
            this.USERNAME_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.USERNAME_TEXTBOX.Location = new System.Drawing.Point(104, 82);
            this.USERNAME_TEXTBOX.Name = "USERNAME_TEXTBOX";
            this.USERNAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.USERNAME_TEXTBOX.TabIndex = 23;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.USERNAME_LABEL.Location = new System.Drawing.Point(11, 80);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(92, 24);
            this.USERNAME_LABEL.TabIndex = 22;
            this.USERNAME_LABEL.Text = "Description";
            // 
            // NEWUSER_LABEL
            // 
            this.NEWUSER_LABEL.AutoSize = true;
            this.NEWUSER_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.NEWUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.NEWUSER_LABEL.Name = "NEWUSER_LABEL";
            this.NEWUSER_LABEL.Size = new System.Drawing.Size(128, 33);
            this.NEWUSER_LABEL.TabIndex = 0;
            this.NEWUSER_LABEL.Text = "New Profile";
            // 
            // EditTab
            // 
            this.EditTab.AutoScroll = true;
            this.EditTab.Controls.Add(this.DESKTOPMODEEDIT_CHECKBOX);
            this.EditTab.Controls.Add(this.PROFILEEDIT_LABEL);
            this.EditTab.Controls.Add(this.PROFILEEDIT_COMBOBOX);
            this.EditTab.Controls.Add(this.NAMEEDIT_TEXTBOX);
            this.EditTab.Controls.Add(this.NAMEEDIT_LABEL);
            this.EditTab.Controls.Add(this.label28);
            this.EditTab.Controls.Add(this.EDITRESET_BUTTON);
            this.EditTab.Controls.Add(this.EDIT_BUTTON);
            this.EditTab.Controls.Add(this.USERNAMEEDIT_TEXTBOX);
            this.EditTab.Controls.Add(this.USERNAMEEDIT_LABEL);
            this.EditTab.Controls.Add(this.EDITPROFILE_LABEL);
            this.EditTab.Location = new System.Drawing.Point(4, 27);
            this.EditTab.Name = "EditTab";
            this.EditTab.Size = new System.Drawing.Size(283, 353);
            this.EditTab.TabIndex = 2;
            this.EditTab.Text = "Edit Profile";
            // 
            // PROFILEEDIT_LABEL
            // 
            this.PROFILEEDIT_LABEL.AutoSize = true;
            this.PROFILEEDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 13F);
            this.PROFILEEDIT_LABEL.Location = new System.Drawing.Point(16, 12);
            this.PROFILEEDIT_LABEL.Name = "PROFILEEDIT_LABEL";
            this.PROFILEEDIT_LABEL.Size = new System.Drawing.Size(65, 26);
            this.PROFILEEDIT_LABEL.TabIndex = 115;
            this.PROFILEEDIT_LABEL.Text = "Profile";
            // 
            // PROFILEEDIT_COMBOBOX
            // 
            this.PROFILEEDIT_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PROFILEEDIT_COMBOBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 10F);
            this.PROFILEEDIT_COMBOBOX.FormattingEnabled = true;
            this.PROFILEEDIT_COMBOBOX.Location = new System.Drawing.Point(100, 15);
            this.PROFILEEDIT_COMBOBOX.Name = "PROFILEEDIT_COMBOBOX";
            this.PROFILEEDIT_COMBOBOX.Size = new System.Drawing.Size(158, 27);
            this.PROFILEEDIT_COMBOBOX.TabIndex = 114;
            this.PROFILEEDIT_COMBOBOX.SelectedIndexChanged += new System.EventHandler(this.PROFILEEDIT_COMBOBOX_SelectedIndexChanged);
            // 
            // NAMEEDIT_TEXTBOX
            // 
            this.NAMEEDIT_TEXTBOX.Enabled = false;
            this.NAMEEDIT_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.NAMEEDIT_TEXTBOX.Location = new System.Drawing.Point(104, 92);
            this.NAMEEDIT_TEXTBOX.Name = "NAMEEDIT_TEXTBOX";
            this.NAMEEDIT_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.NAMEEDIT_TEXTBOX.TabIndex = 83;
            // 
            // NAMEEDIT_LABEL
            // 
            this.NAMEEDIT_LABEL.AutoSize = true;
            this.NAMEEDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.NAMEEDIT_LABEL.Location = new System.Drawing.Point(11, 90);
            this.NAMEEDIT_LABEL.Name = "NAMEEDIT_LABEL";
            this.NAMEEDIT_LABEL.Size = new System.Drawing.Size(56, 24);
            this.NAMEEDIT_LABEL.TabIndex = 82;
            this.NAMEEDIT_LABEL.Text = "Name";
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(14, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(250, 1);
            this.label28.TabIndex = 81;
            // 
            // EDITRESET_BUTTON
            // 
            this.EDITRESET_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.EDITRESET_BUTTON.Location = new System.Drawing.Point(156, 195);
            this.EDITRESET_BUTTON.Name = "EDITRESET_BUTTON";
            this.EDITRESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.EDITRESET_BUTTON.TabIndex = 80;
            this.EDITRESET_BUTTON.Text = "Reset";
            this.EDITRESET_BUTTON.UseVisualStyleBackColor = true;
            this.EDITRESET_BUTTON.Click += new System.EventHandler(this.EDITRESET_BUTTON_Click);
            // 
            // EDIT_BUTTON
            // 
            this.EDIT_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.EDIT_BUTTON.Location = new System.Drawing.Point(13, 195);
            this.EDIT_BUTTON.Name = "EDIT_BUTTON";
            this.EDIT_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.EDIT_BUTTON.TabIndex = 79;
            this.EDIT_BUTTON.Text = "Edit";
            this.EDIT_BUTTON.UseVisualStyleBackColor = true;
            this.EDIT_BUTTON.Click += new System.EventHandler(this.EDIT_BUTTON_Click);
            // 
            // USERNAMEEDIT_TEXTBOX
            // 
            this.USERNAMEEDIT_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.USERNAMEEDIT_TEXTBOX.Location = new System.Drawing.Point(104, 129);
            this.USERNAMEEDIT_TEXTBOX.Name = "USERNAMEEDIT_TEXTBOX";
            this.USERNAMEEDIT_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.USERNAMEEDIT_TEXTBOX.TabIndex = 74;
            // 
            // USERNAMEEDIT_LABEL
            // 
            this.USERNAMEEDIT_LABEL.AutoSize = true;
            this.USERNAMEEDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.USERNAMEEDIT_LABEL.Location = new System.Drawing.Point(11, 127);
            this.USERNAMEEDIT_LABEL.Name = "USERNAMEEDIT_LABEL";
            this.USERNAMEEDIT_LABEL.Size = new System.Drawing.Size(92, 24);
            this.USERNAMEEDIT_LABEL.TabIndex = 73;
            this.USERNAMEEDIT_LABEL.Text = "Description";
            // 
            // EDITPROFILE_LABEL
            // 
            this.EDITPROFILE_LABEL.AutoSize = true;
            this.EDITPROFILE_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.EDITPROFILE_LABEL.Location = new System.Drawing.Point(7, 47);
            this.EDITPROFILE_LABEL.Name = "EDITPROFILE_LABEL";
            this.EDITPROFILE_LABEL.Size = new System.Drawing.Size(121, 33);
            this.EDITPROFILE_LABEL.TabIndex = 72;
            this.EDITPROFILE_LABEL.Text = "Edit Profile";
            // 
            // USERFORM_LABEL
            // 
            this.USERFORM_LABEL.AutoSize = true;
            this.USERFORM_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERFORM_LABEL.Location = new System.Drawing.Point(10, 9);
            this.USERFORM_LABEL.Name = "USERFORM_LABEL";
            this.USERFORM_LABEL.Size = new System.Drawing.Size(239, 31);
            this.USERFORM_LABEL.TabIndex = 1;
            this.USERFORM_LABEL.Text = "Select or Create Profile";
            // 
            // DESKTOPMODE_CHECKBOX
            // 
            this.DESKTOPMODE_CHECKBOX.AutoSize = true;
            this.DESKTOPMODE_CHECKBOX.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.DESKTOPMODE_CHECKBOX.Location = new System.Drawing.Point(15, 110);
            this.DESKTOPMODE_CHECKBOX.Name = "DESKTOPMODE_CHECKBOX";
            this.DESKTOPMODE_CHECKBOX.Size = new System.Drawing.Size(136, 28);
            this.DESKTOPMODE_CHECKBOX.TabIndex = 33;
            this.DESKTOPMODE_CHECKBOX.Text = "Desktop Mode";
            this.DESKTOPMODE_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // DESKTOPMODEEDIT_CHECKBOX
            // 
            this.DESKTOPMODEEDIT_CHECKBOX.AutoSize = true;
            this.DESKTOPMODEEDIT_CHECKBOX.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.DESKTOPMODEEDIT_CHECKBOX.Location = new System.Drawing.Point(15, 161);
            this.DESKTOPMODEEDIT_CHECKBOX.Name = "DESKTOPMODEEDIT_CHECKBOX";
            this.DESKTOPMODEEDIT_CHECKBOX.Size = new System.Drawing.Size(136, 28);
            this.DESKTOPMODEEDIT_CHECKBOX.TabIndex = 116;
            this.DESKTOPMODEEDIT_CHECKBOX.Text = "Desktop Mode";
            this.DESKTOPMODEEDIT_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.USERFORM_LABEL);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfileForm";
            this.MainTab.ResumeLayout(false);
            this.ProfilesTab.ResumeLayout(false);
            this.ProfilesTab.PerformLayout();
            this.CreateTab.ResumeLayout(false);
            this.CreateTab.PerformLayout();
            this.EditTab.ResumeLayout(false);
            this.EditTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage ProfilesTab;
        private System.Windows.Forms.TabPage CreateTab;
        private System.Windows.Forms.Label USERFORM_LABEL;
        private System.Windows.Forms.Label NEWUSER_LABEL;
        private System.Windows.Forms.Button RESET_BUTTON;
        private System.Windows.Forms.Button CREATE_BUTTON;
        private System.Windows.Forms.TextBox USERNAME_TEXTBOX;
        private System.Windows.Forms.Label USERNAME_LABEL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SELECTUSER_LABEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NAME_TEXTBOX;
        private System.Windows.Forms.Label NAME_LABEL;
        private TabPage EditTab;
        private Label PROFILEEDIT_LABEL;
        private ComboBox PROFILEEDIT_COMBOBOX;
        private TextBox NAMEEDIT_TEXTBOX;
        private Label NAMEEDIT_LABEL;
        private Label label28;
        private Button EDITRESET_BUTTON;
        private Button EDIT_BUTTON;
        private TextBox USERNAMEEDIT_TEXTBOX;
        private Label USERNAMEEDIT_LABEL;
        private Label EDITPROFILE_LABEL;
        private CheckBox DESKTOPMODE_CHECKBOX;
        private CheckBox DESKTOPMODEEDIT_CHECKBOX;
    }
}