using System.Windows.Forms;

namespace vrchat_launcher.Forms
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LAUNCH_BUTTON = new System.Windows.Forms.Button();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.TopTab = new System.Windows.Forms.TabPage();
            this.SoftwareTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.LATEST_VERSION_TEXT = new System.Windows.Forms.Label();
            this.CURRENT_VERSION_TEXT = new System.Windows.Forms.Label();
            this.LATEST_VERSION_LABEL = new System.Windows.Forms.Label();
            this.UPDATE_BUTTON = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CURRENT_VERSION_LABEL = new System.Windows.Forms.Label();
            this.SERVER_LABEL = new System.Windows.Forms.Label();
            this.PROFILE_LABEL = new System.Windows.Forms.Label();
            this.PROFILE_BUTTON = new System.Windows.Forms.Button();
            this.DESKTOP_BUTTON = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // LAUNCH_BUTTON
            // 
            this.LAUNCH_BUTTON.Font = new System.Drawing.Font(GuiFont, 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAUNCH_BUTTON.Location = new System.Drawing.Point(281, 418);
            this.LAUNCH_BUTTON.Name = "LAUNCH_BUTTON";
            this.LAUNCH_BUTTON.Size = new System.Drawing.Size(269, 69);
            this.LAUNCH_BUTTON.TabIndex = 0;
            this.LAUNCH_BUTTON.Text = "LAUNCH";
            this.LAUNCH_BUTTON.UseVisualStyleBackColor = true;
            this.LAUNCH_BUTTON.Click += new System.EventHandler(this.LAUNCH_BUTTON_Click);
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.TopTab);
            this.MainTab.Controls.Add(this.SoftwareTab);
            this.MainTab.Controls.Add(this.SettingsTab);
            this.MainTab.Font = new System.Drawing.Font(GuiFont, 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(816, 397);
            this.MainTab.TabIndex = 2;
            // 
            // TopTab
            // 
            this.TopTab.Font = new System.Drawing.Font(GuiFont, 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopTab.Location = new System.Drawing.Point(4, 40);
            this.TopTab.Name = "TopTab";
            this.TopTab.Padding = new System.Windows.Forms.Padding(3);
            this.TopTab.Size = new System.Drawing.Size(808, 353);
            this.TopTab.TabIndex = 0;
            this.TopTab.Text = "Top";
            this.TopTab.UseVisualStyleBackColor = true;
            // 
            // SoftwareTab
            // 
            this.SoftwareTab.AutoScroll = true;
            this.SoftwareTab.Location = new System.Drawing.Point(4, 40);
            this.SoftwareTab.Name = "SoftwareTab";
            this.SoftwareTab.Size = new System.Drawing.Size(808, 353);
            this.SoftwareTab.TabIndex = 2;
            this.SoftwareTab.Text = "Softwares";
            this.SoftwareTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTab
            // 
            this.SettingsTab.AutoScroll = true;
            this.SettingsTab.Controls.Add(this.LATEST_VERSION_TEXT);
            this.SettingsTab.Controls.Add(this.CURRENT_VERSION_TEXT);
            this.SettingsTab.Controls.Add(this.LATEST_VERSION_LABEL);
            this.SettingsTab.Controls.Add(this.UPDATE_BUTTON);
            this.SettingsTab.Controls.Add(this.label14);
            this.SettingsTab.Controls.Add(this.label15);
            this.SettingsTab.Controls.Add(this.CURRENT_VERSION_LABEL);
            this.SettingsTab.Location = new System.Drawing.Point(4, 40);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(808, 353);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            // 
            // LATEST_VERSION_TEXT
            // 
            this.LATEST_VERSION_TEXT.AutoSize = true;
            this.LATEST_VERSION_TEXT.Location = new System.Drawing.Point(177, 96);
            this.LATEST_VERSION_TEXT.Name = "LATEST_VERSION_TEXT";
            this.LATEST_VERSION_TEXT.Size = new System.Drawing.Size(53, 33);
            this.LATEST_VERSION_TEXT.TabIndex = 88;
            this.LATEST_VERSION_TEXT.Text = "Null";
            // 
            // CURRENT_VERSION_TEXT
            // 
            this.CURRENT_VERSION_TEXT.AutoSize = true;
            this.CURRENT_VERSION_TEXT.Location = new System.Drawing.Point(192, 62);
            this.CURRENT_VERSION_TEXT.Name = "CURRENT_VERSION_TEXT";
            this.CURRENT_VERSION_TEXT.Size = new System.Drawing.Size(53, 33);
            this.CURRENT_VERSION_TEXT.TabIndex = 87;
            this.CURRENT_VERSION_TEXT.Text = "Null";
            // 
            // LATEST_VERSION_LABEL
            // 
            this.LATEST_VERSION_LABEL.AutoSize = true;
            this.LATEST_VERSION_LABEL.Location = new System.Drawing.Point(21, 95);
            this.LATEST_VERSION_LABEL.Name = "LATEST_VERSION_LABEL";
            this.LATEST_VERSION_LABEL.Size = new System.Drawing.Size(159, 33);
            this.LATEST_VERSION_LABEL.TabIndex = 86;
            this.LATEST_VERSION_LABEL.Text = "Latest Version:";
            // 
            // UPDATE_BUTTON
            // 
            this.UPDATE_BUTTON.Enabled = false;
            this.UPDATE_BUTTON.Font = new System.Drawing.Font(GuiFont, 12F);
            this.UPDATE_BUTTON.Location = new System.Drawing.Point(621, 78);
            this.UPDATE_BUTTON.Name = "UPDATE_BUTTON";
            this.UPDATE_BUTTON.Size = new System.Drawing.Size(138, 38);
            this.UPDATE_BUTTON.TabIndex = 85;
            this.UPDATE_BUTTON.Text = "Update Now!";
            this.UPDATE_BUTTON.UseVisualStyleBackColor = true;
            this.UPDATE_BUTTON.Click += new System.EventHandler(this.UPDATE_BUTTON_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font(GuiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(21, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 35);
            this.label14.TabIndex = 84;
            this.label14.Text = "Update";
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(27, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(750, 1);
            this.label15.TabIndex = 83;
            // 
            // CURRENT_VERSION_LABEL
            // 
            this.CURRENT_VERSION_LABEL.AutoSize = true;
            this.CURRENT_VERSION_LABEL.Location = new System.Drawing.Point(21, 62);
            this.CURRENT_VERSION_LABEL.Name = "CURRENT_VERSION_LABEL";
            this.CURRENT_VERSION_LABEL.Size = new System.Drawing.Size(174, 33);
            this.CURRENT_VERSION_LABEL.TabIndex = 82;
            this.CURRENT_VERSION_LABEL.Text = "Current Version:";
            // 
            // SERVER_LABEL
            // 
            this.SERVER_LABEL.AutoSize = true;
            this.SERVER_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.SERVER_LABEL.Font = new System.Drawing.Font(GuiFont, 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER_LABEL.Location = new System.Drawing.Point(47, 408);
            this.SERVER_LABEL.Name = "SERVER_LABEL";
            this.SERVER_LABEL.Size = new System.Drawing.Size(169, 34);
            this.SERVER_LABEL.TabIndex = 4;
            this.SERVER_LABEL.Text = "Desktop Mode";
            // 
            // PROFILE_LABEL
            // 
            this.PROFILE_LABEL.AutoSize = true;
            this.PROFILE_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.PROFILE_LABEL.Font = new System.Drawing.Font(GuiFont, 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PROFILE_LABEL.Location = new System.Drawing.Point(671, 405);
            this.PROFILE_LABEL.Name = "PROFILE_LABEL";
            this.PROFILE_LABEL.Size = new System.Drawing.Size(80, 34);
            this.PROFILE_LABEL.TabIndex = 5;
            this.PROFILE_LABEL.Text = "Profile";
            // 
            // PROFILE_BUTTON
            // 
            this.PROFILE_BUTTON.Font = new System.Drawing.Font(TextFont, 15.75F);
            this.PROFILE_BUTTON.Location = new System.Drawing.Point(622, 442);
            this.PROFILE_BUTTON.Name = "PROFILE_BUTTON";
            this.PROFILE_BUTTON.Size = new System.Drawing.Size(173, 38);
            this.PROFILE_BUTTON.TabIndex = 8;
            this.PROFILE_BUTTON.Text = "No Profile";
            this.PROFILE_BUTTON.UseVisualStyleBackColor = true;
            this.PROFILE_BUTTON.Click += new System.EventHandler(this.PROFILE_BUTTON_Click);
            // 
            // DESKTOP_BUTTON
            // 
            this.DESKTOP_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DESKTOP_BUTTON.Font = new System.Drawing.Font(TextFont, 15.75F);
            this.DESKTOP_BUTTON.Location = new System.Drawing.Point(43, 442);
            this.DESKTOP_BUTTON.Name = "DESKTOP_BUTTON";
            this.DESKTOP_BUTTON.Size = new System.Drawing.Size(173, 38);
            this.DESKTOP_BUTTON.TabIndex = 9;
            this.DESKTOP_BUTTON.Text = "Enabled";
            this.DESKTOP_BUTTON.UseVisualStyleBackColor = false;
            this.DESKTOP_BUTTON.Click += new System.EventHandler(this.DESKTOP_BUTTON_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 499);
            this.Controls.Add(this.DESKTOP_BUTTON);
            this.Controls.Add(this.PROFILE_BUTTON);
            this.Controls.Add(this.PROFILE_LABEL);
            this.Controls.Add(this.SERVER_LABEL);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.LAUNCH_BUTTON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRChat Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.MainTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabPage TopTab;

        #endregion

        private System.Windows.Forms.Button LAUNCH_BUTTON;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Label SERVER_LABEL;
        private System.Windows.Forms.Label PROFILE_LABEL;
        private Button PROFILE_BUTTON;
        private TabPage SoftwareTab;
        private Button DESKTOP_BUTTON;
        private Label label14;
        private Label label15;
        private Label CURRENT_VERSION_LABEL;
        private Button UPDATE_BUTTON;
        private Label LATEST_VERSION_LABEL;
        private Label LATEST_VERSION_TEXT;
        private Label CURRENT_VERSION_TEXT;
        private ContextMenuStrip contextMenuStrip1;
    }
}

