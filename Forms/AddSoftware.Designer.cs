using System.Windows.Forms;

namespace vrchat_launcher.Forms
{
    partial class AddSoftware
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

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSoftware));
            this.ADDSOFTWARE_LABEL = new System.Windows.Forms.Label();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.AUTHOR_LABEL = new System.Windows.Forms.Label();
            this.DESCRIPTION_LABEL = new System.Windows.Forms.Label();
            this.NAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.AUTHOR_TEXTBOX = new System.Windows.Forms.TextBox();
            this.DESCRIPTION_TEXTBOX = new System.Windows.Forms.TextBox();
            this.CREATE_BUTTON = new System.Windows.Forms.Button();
            this.PATH_LABEL = new System.Windows.Forms.Label();
            this.PATH_TEXTBOX = new System.Windows.Forms.TextBox();
            this.RESET_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OPEN_BUTTON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ADDSOFTWARE_LABEL
            // 
            this.ADDSOFTWARE_LABEL.AutoSize = true;
            this.ADDSOFTWARE_LABEL.Location = new System.Drawing.Point(12, 9);
            this.ADDSOFTWARE_LABEL.Name = "ADDSOFTWARE_LABEL";
            this.ADDSOFTWARE_LABEL.Size = new System.Drawing.Size(149, 31);
            this.ADDSOFTWARE_LABEL.TabIndex = 0;
            this.ADDSOFTWARE_LABEL.Text = "Add Software";
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Location = new System.Drawing.Point(12, 56);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(73, 31);
            this.NAME_LABEL.TabIndex = 1;
            this.NAME_LABEL.Text = "Name";
            // 
            // AUTHOR_LABEL
            // 
            this.AUTHOR_LABEL.AutoSize = true;
            this.AUTHOR_LABEL.Location = new System.Drawing.Point(12, 101);
            this.AUTHOR_LABEL.Name = "AUTHOR_LABEL";
            this.AUTHOR_LABEL.Size = new System.Drawing.Size(80, 31);
            this.AUTHOR_LABEL.TabIndex = 2;
            this.AUTHOR_LABEL.Text = "Author";
            // 
            // DESCRIPTION_LABEL
            // 
            this.DESCRIPTION_LABEL.AutoSize = true;
            this.DESCRIPTION_LABEL.Location = new System.Drawing.Point(12, 150);
            this.DESCRIPTION_LABEL.Name = "DESCRIPTION_LABEL";
            this.DESCRIPTION_LABEL.Size = new System.Drawing.Size(123, 31);
            this.DESCRIPTION_LABEL.TabIndex = 3;
            this.DESCRIPTION_LABEL.Text = "Description";
            // 
            // NAME_TEXTBOX
            // 
            this.NAME_TEXTBOX.Location = new System.Drawing.Point(151, 56);
            this.NAME_TEXTBOX.Name = "NAME_TEXTBOX";
            this.NAME_TEXTBOX.Size = new System.Drawing.Size(482, 34);
            this.NAME_TEXTBOX.TabIndex = 4;
            // 
            // AUTHOR_TEXTBOX
            // 
            this.AUTHOR_TEXTBOX.Location = new System.Drawing.Point(151, 101);
            this.AUTHOR_TEXTBOX.Name = "AUTHOR_TEXTBOX";
            this.AUTHOR_TEXTBOX.Size = new System.Drawing.Size(482, 34);
            this.AUTHOR_TEXTBOX.TabIndex = 5;
            // 
            // DESCRIPTION_TEXTBOX
            // 
            this.DESCRIPTION_TEXTBOX.Location = new System.Drawing.Point(151, 147);
            this.DESCRIPTION_TEXTBOX.Name = "DESCRIPTION_TEXTBOX";
            this.DESCRIPTION_TEXTBOX.Size = new System.Drawing.Size(482, 34);
            this.DESCRIPTION_TEXTBOX.TabIndex = 6;
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Location = new System.Drawing.Point(175, 237);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(108, 45);
            this.CREATE_BUTTON.TabIndex = 7;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // PATH_LABEL
            // 
            this.PATH_LABEL.AutoSize = true;
            this.PATH_LABEL.Location = new System.Drawing.Point(12, 197);
            this.PATH_LABEL.Name = "PATH_LABEL";
            this.PATH_LABEL.Size = new System.Drawing.Size(58, 31);
            this.PATH_LABEL.TabIndex = 8;
            this.PATH_LABEL.Text = "Path";
            // 
            // PATH_TEXTBOX
            // 
            this.PATH_TEXTBOX.Location = new System.Drawing.Point(151, 197);
            this.PATH_TEXTBOX.Name = "PATH_TEXTBOX";
            this.PATH_TEXTBOX.Size = new System.Drawing.Size(401, 34);
            this.PATH_TEXTBOX.TabIndex = 9;
            // 
            // RESET_BUTTON
            // 
            this.RESET_BUTTON.Location = new System.Drawing.Point(391, 237);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(108, 45);
            this.RESET_BUTTON.TabIndex = 10;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 1);
            this.label1.TabIndex = 11;
            // 
            // OPEN_BUTTON
            // 
            this.OPEN_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.OPEN_BUTTON.Location = new System.Drawing.Point(558, 201);
            this.OPEN_BUTTON.Name = "OPEN_BUTTON";
            this.OPEN_BUTTON.Size = new System.Drawing.Size(75, 30);
            this.OPEN_BUTTON.TabIndex = 12;
            this.OPEN_BUTTON.Text = "Open";
            this.OPEN_BUTTON.UseVisualStyleBackColor = true;
            this.OPEN_BUTTON.Click += new System.EventHandler(this.OPEN_BUTTON_Click);
            // 
            // AddSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 294);
            this.Controls.Add(this.OPEN_BUTTON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RESET_BUTTON);
            this.Controls.Add(this.PATH_TEXTBOX);
            this.Controls.Add(this.PATH_LABEL);
            this.Controls.Add(this.CREATE_BUTTON);
            this.Controls.Add(this.DESCRIPTION_TEXTBOX);
            this.Controls.Add(this.AUTHOR_TEXTBOX);
            this.Controls.Add(this.NAME_TEXTBOX);
            this.Controls.Add(this.DESCRIPTION_LABEL);
            this.Controls.Add(this.AUTHOR_LABEL);
            this.Controls.Add(this.NAME_LABEL);
            this.Controls.Add(this.ADDSOFTWARE_LABEL);
            this.Font = new System.Drawing.Font(_mainForm.GuiFont, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "AddSoftware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Software";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label ADDSOFTWARE_LABEL;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.Label AUTHOR_LABEL;
        private System.Windows.Forms.Label DESCRIPTION_LABEL;
        private System.Windows.Forms.TextBox NAME_TEXTBOX;
        private System.Windows.Forms.TextBox AUTHOR_TEXTBOX;
        private System.Windows.Forms.TextBox DESCRIPTION_TEXTBOX;
        private System.Windows.Forms.Button CREATE_BUTTON;
        private System.Windows.Forms.Label PATH_LABEL;
        private System.Windows.Forms.TextBox PATH_TEXTBOX;
        private System.Windows.Forms.Button RESET_BUTTON;
        private System.Windows.Forms.Label label1;
        private Button OPEN_BUTTON;
    }
}