namespace GCUTrackerUI
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            this.teamNameValue = new System.Windows.Forms.TextBox();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.selectTeamMemberComboBox = new System.Windows.Forms.ComboBox();
            this.selectTeamMemberLabel = new System.Windows.Forms.Label();
            this.addMemberButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.createMemberButton = new System.Windows.Forms.Button();
            this.mobileNumberValue = new System.Windows.Forms.TextBox();
            this.mobileNumberLabel = new System.Windows.Forms.Label();
            this.emailValue = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNameValue = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameValue = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.teamMembersListBox = new System.Windows.Forms.ListBox();
            this.removeSelectedMembersButton = new System.Windows.Forms.Button();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamNameValue
            // 
            this.teamNameValue.BackColor = System.Drawing.Color.DarkGray;
            this.teamNameValue.Location = new System.Drawing.Point(32, 173);
            this.teamNameValue.Name = "teamNameValue";
            this.teamNameValue.Size = new System.Drawing.Size(368, 43);
            this.teamNameValue.TabIndex = 12;
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamNameLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.teamNameLabel.Location = new System.Drawing.Point(24, 103);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(192, 45);
            this.teamNameLabel.TabIndex = 11;
            this.teamNameLabel.Text = "Team Name";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Maroon;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.headerLabel.Location = new System.Drawing.Point(21, 25);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(298, 65);
            this.headerLabel.TabIndex = 10;
            this.headerLabel.Text = "Create Team";
            // 
            // selectTeamMemberComboBox
            // 
            this.selectTeamMemberComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.selectTeamMemberComboBox.FormattingEnabled = true;
            this.selectTeamMemberComboBox.Location = new System.Drawing.Point(32, 313);
            this.selectTeamMemberComboBox.Name = "selectTeamMemberComboBox";
            this.selectTeamMemberComboBox.Size = new System.Drawing.Size(374, 45);
            this.selectTeamMemberComboBox.TabIndex = 14;
            // 
            // selectTeamMemberLabel
            // 
            this.selectTeamMemberLabel.AutoSize = true;
            this.selectTeamMemberLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamMemberLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.selectTeamMemberLabel.Location = new System.Drawing.Point(24, 250);
            this.selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            this.selectTeamMemberLabel.Size = new System.Drawing.Size(322, 45);
            this.selectTeamMemberLabel.TabIndex = 13;
            this.selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // addMemberButton
            // 
            this.addMemberButton.BackColor = System.Drawing.Color.White;
            this.addMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.addMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.addMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.addMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMemberButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMemberButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.addMemberButton.Location = new System.Drawing.Point(140, 405);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(213, 57);
            this.addMemberButton.TabIndex = 15;
            this.addMemberButton.Text = "Add Member";
            this.addMemberButton.UseVisualStyleBackColor = false;
            this.addMemberButton.Click += new System.EventHandler(this.addMemberButton_Click);
            // 
            // addNewMemberGroupBox
            // 
            this.addNewMemberGroupBox.Controls.Add(this.createMemberButton);
            this.addNewMemberGroupBox.Controls.Add(this.mobileNumberValue);
            this.addNewMemberGroupBox.Controls.Add(this.mobileNumberLabel);
            this.addNewMemberGroupBox.Controls.Add(this.emailValue);
            this.addNewMemberGroupBox.Controls.Add(this.emailLabel);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameValue);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameLabel);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameValue);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameLabel);
            this.addNewMemberGroupBox.ForeColor = System.Drawing.Color.Goldenrod;
            this.addNewMemberGroupBox.Location = new System.Drawing.Point(474, 46);
            this.addNewMemberGroupBox.Name = "addNewMemberGroupBox";
            this.addNewMemberGroupBox.Size = new System.Drawing.Size(527, 416);
            this.addNewMemberGroupBox.TabIndex = 16;
            this.addNewMemberGroupBox.TabStop = false;
            this.addNewMemberGroupBox.Text = "Add New Member";
            // 
            // createMemberButton
            // 
            this.createMemberButton.BackColor = System.Drawing.Color.White;
            this.createMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.createMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.createMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.createMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createMemberButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createMemberButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.createMemberButton.Location = new System.Drawing.Point(127, 323);
            this.createMemberButton.Name = "createMemberButton";
            this.createMemberButton.Size = new System.Drawing.Size(226, 57);
            this.createMemberButton.TabIndex = 21;
            this.createMemberButton.Text = "Create Member";
            this.createMemberButton.UseVisualStyleBackColor = false;
            this.createMemberButton.Click += new System.EventHandler(this.createMemberButton_Click);
            // 
            // mobileNumberValue
            // 
            this.mobileNumberValue.BackColor = System.Drawing.Color.DarkGray;
            this.mobileNumberValue.Location = new System.Drawing.Point(195, 248);
            this.mobileNumberValue.Name = "mobileNumberValue";
            this.mobileNumberValue.Size = new System.Drawing.Size(326, 43);
            this.mobileNumberValue.TabIndex = 20;
            // 
            // mobileNumberLabel
            // 
            this.mobileNumberLabel.AutoSize = true;
            this.mobileNumberLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileNumberLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.mobileNumberLabel.Location = new System.Drawing.Point(15, 248);
            this.mobileNumberLabel.Name = "mobileNumberLabel";
            this.mobileNumberLabel.Size = new System.Drawing.Size(148, 38);
            this.mobileNumberLabel.TabIndex = 19;
            this.mobileNumberLabel.Text = "Mobile No";
            // 
            // emailValue
            // 
            this.emailValue.BackColor = System.Drawing.Color.DarkGray;
            this.emailValue.Location = new System.Drawing.Point(195, 187);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(326, 43);
            this.emailValue.TabIndex = 18;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.emailLabel.Location = new System.Drawing.Point(15, 187);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(83, 38);
            this.emailLabel.TabIndex = 17;
            this.emailLabel.Text = "Email";
            // 
            // lastNameValue
            // 
            this.lastNameValue.BackColor = System.Drawing.Color.DarkGray;
            this.lastNameValue.Location = new System.Drawing.Point(195, 127);
            this.lastNameValue.Name = "lastNameValue";
            this.lastNameValue.Size = new System.Drawing.Size(326, 43);
            this.lastNameValue.TabIndex = 16;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.lastNameLabel.Location = new System.Drawing.Point(15, 127);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(147, 38);
            this.lastNameLabel.TabIndex = 15;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameValue
            // 
            this.firstNameValue.BackColor = System.Drawing.Color.DarkGray;
            this.firstNameValue.Location = new System.Drawing.Point(195, 67);
            this.firstNameValue.Name = "firstNameValue";
            this.firstNameValue.Size = new System.Drawing.Size(326, 43);
            this.firstNameValue.TabIndex = 14;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.firstNameLabel.Location = new System.Drawing.Point(15, 67);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(151, 38);
            this.firstNameLabel.TabIndex = 13;
            this.firstNameLabel.Text = "First Name";
            // 
            // teamMembersListBox
            // 
            this.teamMembersListBox.BackColor = System.Drawing.Color.DarkGray;
            this.teamMembersListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamMembersListBox.FormattingEnabled = true;
            this.teamMembersListBox.ItemHeight = 31;
            this.teamMembersListBox.Location = new System.Drawing.Point(32, 494);
            this.teamMembersListBox.Name = "teamMembersListBox";
            this.teamMembersListBox.Size = new System.Drawing.Size(374, 252);
            this.teamMembersListBox.TabIndex = 18;
            // 
            // removeSelectedMembersButton
            // 
            this.removeSelectedMembersButton.BackColor = System.Drawing.Color.White;
            this.removeSelectedMembersButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.removeSelectedMembersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.removeSelectedMembersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.removeSelectedMembersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeSelectedMembersButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSelectedMembersButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.removeSelectedMembersButton.Location = new System.Drawing.Point(427, 494);
            this.removeSelectedMembersButton.Name = "removeSelectedMembersButton";
            this.removeSelectedMembersButton.Size = new System.Drawing.Size(303, 57);
            this.removeSelectedMembersButton.TabIndex = 22;
            this.removeSelectedMembersButton.Text = "Remove Selected";
            this.removeSelectedMembersButton.UseVisualStyleBackColor = false;
            this.removeSelectedMembersButton.Click += new System.EventHandler(this.removeSelectedMembersButton_Click);
            // 
            // createTeamButton
            // 
            this.createTeamButton.BackColor = System.Drawing.Color.White;
            this.createTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.createTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.createTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.createTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTeamButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTeamButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.createTeamButton.Location = new System.Drawing.Point(539, 640);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(367, 57);
            this.createTeamButton.TabIndex = 23;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = false;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1056, 758);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.removeSelectedMembersButton);
            this.Controls.Add(this.teamMembersListBox);
            this.Controls.Add(this.addNewMemberGroupBox);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.selectTeamMemberComboBox);
            this.Controls.Add(this.selectTeamMemberLabel);
            this.Controls.Add(this.teamNameValue);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "CreateTeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Team";
            this.addNewMemberGroupBox.ResumeLayout(false);
            this.addNewMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamNameValue;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox selectTeamMemberComboBox;
        private System.Windows.Forms.Label selectTeamMemberLabel;
        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.GroupBox addNewMemberGroupBox;
        private System.Windows.Forms.TextBox firstNameValue;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Button createMemberButton;
        private System.Windows.Forms.TextBox mobileNumberValue;
        private System.Windows.Forms.Label mobileNumberLabel;
        private System.Windows.Forms.TextBox emailValue;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox lastNameValue;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.ListBox teamMembersListBox;
        private System.Windows.Forms.Button removeSelectedMembersButton;
        private System.Windows.Forms.Button createTeamButton;
    }
}