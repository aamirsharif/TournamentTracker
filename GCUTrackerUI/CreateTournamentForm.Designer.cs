namespace GCUTrackerUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.tournamentNameLabel = new System.Windows.Forms.Label();
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.tournamentNameValue = new System.Windows.Forms.TextBox();
            this.entryFeeValue = new System.Windows.Forms.TextBox();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.selectTeamComboBox = new System.Windows.Forms.ComboBox();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.tournamentPlayersLabel = new System.Windows.Forms.Label();
            this.tournamentPlayersListBox = new System.Windows.Forms.ListBox();
            this.removePlayersButton = new System.Windows.Forms.Button();
            this.removePrizesButton = new System.Windows.Forms.Button();
            this.tournamentPrizesListBox = new System.Windows.Forms.ListBox();
            this.prizesLabel = new System.Windows.Forms.Label();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Maroon;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.headerLabel.Location = new System.Drawing.Point(46, 35);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(446, 65);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Create Tournament";
            // 
            // tournamentNameLabel
            // 
            this.tournamentNameLabel.AutoSize = true;
            this.tournamentNameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentNameLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.tournamentNameLabel.Location = new System.Drawing.Point(58, 123);
            this.tournamentNameLabel.Name = "tournamentNameLabel";
            this.tournamentNameLabel.Size = new System.Drawing.Size(290, 45);
            this.tournamentNameLabel.TabIndex = 3;
            this.tournamentNameLabel.Text = "Tournament Name";
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryFeeLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.entryFeeLabel.Location = new System.Drawing.Point(58, 272);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(160, 45);
            this.entryFeeLabel.TabIndex = 4;
            this.entryFeeLabel.Text = "Entry Fee:";
            // 
            // tournamentNameValue
            // 
            this.tournamentNameValue.BackColor = System.Drawing.Color.DarkGray;
            this.tournamentNameValue.Location = new System.Drawing.Point(66, 186);
            this.tournamentNameValue.Name = "tournamentNameValue";
            this.tournamentNameValue.Size = new System.Drawing.Size(368, 57);
            this.tournamentNameValue.TabIndex = 9;
            // 
            // entryFeeValue
            // 
            this.entryFeeValue.BackColor = System.Drawing.Color.DarkGray;
            this.entryFeeValue.Location = new System.Drawing.Point(224, 265);
            this.entryFeeValue.Name = "entryFeeValue";
            this.entryFeeValue.Size = new System.Drawing.Size(124, 57);
            this.entryFeeValue.TabIndex = 10;
            this.entryFeeValue.Text = "0";
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.selectTeamLabel.Location = new System.Drawing.Point(58, 357);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(191, 45);
            this.selectTeamLabel.TabIndex = 11;
            this.selectTeamLabel.Text = "Select Team";
            // 
            // selectTeamComboBox
            // 
            this.selectTeamComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.selectTeamComboBox.FormattingEnabled = true;
            this.selectTeamComboBox.Location = new System.Drawing.Point(66, 420);
            this.selectTeamComboBox.Name = "selectTeamComboBox";
            this.selectTeamComboBox.Size = new System.Drawing.Size(374, 58);
            this.selectTeamComboBox.TabIndex = 12;
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
            this.createTeamButton.Location = new System.Drawing.Point(261, 357);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(179, 57);
            this.createTeamButton.TabIndex = 13;
            this.createTeamButton.Text = "Create New";
            this.createTeamButton.UseVisualStyleBackColor = false;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // addTeamButton
            // 
            this.addTeamButton.BackColor = System.Drawing.Color.White;
            this.addTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.addTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.addTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.addTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeamButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.addTeamButton.Location = new System.Drawing.Point(66, 497);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(179, 57);
            this.addTeamButton.TabIndex = 14;
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.UseVisualStyleBackColor = false;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.BackColor = System.Drawing.Color.White;
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPrizeButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.createPrizeButton.Location = new System.Drawing.Point(261, 497);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(179, 57);
            this.createPrizeButton.TabIndex = 15;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = false;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // tournamentPlayersLabel
            // 
            this.tournamentPlayersLabel.AutoSize = true;
            this.tournamentPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentPlayersLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.tournamentPlayersLabel.Location = new System.Drawing.Point(597, 81);
            this.tournamentPlayersLabel.Name = "tournamentPlayersLabel";
            this.tournamentPlayersLabel.Size = new System.Drawing.Size(242, 45);
            this.tournamentPlayersLabel.TabIndex = 16;
            this.tournamentPlayersLabel.Text = "Teams / Players";
            // 
            // tournamentPlayersListBox
            // 
            this.tournamentPlayersListBox.BackColor = System.Drawing.Color.DarkGray;
            this.tournamentPlayersListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentPlayersListBox.FormattingEnabled = true;
            this.tournamentPlayersListBox.ItemHeight = 31;
            this.tournamentPlayersListBox.Location = new System.Drawing.Point(605, 148);
            this.tournamentPlayersListBox.Name = "tournamentPlayersListBox";
            this.tournamentPlayersListBox.Size = new System.Drawing.Size(304, 252);
            this.tournamentPlayersListBox.TabIndex = 17;
            // 
            // removePlayersButton
            // 
            this.removePlayersButton.BackColor = System.Drawing.Color.White;
            this.removePlayersButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.removePlayersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.removePlayersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.removePlayersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removePlayersButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePlayersButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.removePlayersButton.Location = new System.Drawing.Point(949, 202);
            this.removePlayersButton.Name = "removePlayersButton";
            this.removePlayersButton.Size = new System.Drawing.Size(179, 131);
            this.removePlayersButton.TabIndex = 18;
            this.removePlayersButton.Text = "Remove Selected";
            this.removePlayersButton.UseVisualStyleBackColor = false;
            this.removePlayersButton.Click += new System.EventHandler(this.removePlayersButton_Click);
            // 
            // removePrizesButton
            // 
            this.removePrizesButton.BackColor = System.Drawing.Color.White;
            this.removePrizesButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.removePrizesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.removePrizesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.removePrizesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removePrizesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePrizesButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.removePrizesButton.Location = new System.Drawing.Point(949, 528);
            this.removePrizesButton.Name = "removePrizesButton";
            this.removePrizesButton.Size = new System.Drawing.Size(179, 131);
            this.removePrizesButton.TabIndex = 21;
            this.removePrizesButton.Text = "Remove Selected";
            this.removePrizesButton.UseVisualStyleBackColor = false;
            this.removePrizesButton.Click += new System.EventHandler(this.removePrizesButton_Click);
            // 
            // tournamentPrizesListBox
            // 
            this.tournamentPrizesListBox.BackColor = System.Drawing.Color.DarkGray;
            this.tournamentPrizesListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentPrizesListBox.FormattingEnabled = true;
            this.tournamentPrizesListBox.ItemHeight = 31;
            this.tournamentPrizesListBox.Location = new System.Drawing.Point(605, 474);
            this.tournamentPrizesListBox.Name = "tournamentPrizesListBox";
            this.tournamentPrizesListBox.Size = new System.Drawing.Size(304, 252);
            this.tournamentPrizesListBox.TabIndex = 20;
            // 
            // prizesLabel
            // 
            this.prizesLabel.AutoSize = true;
            this.prizesLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prizesLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.prizesLabel.Location = new System.Drawing.Point(597, 407);
            this.prizesLabel.Name = "prizesLabel";
            this.prizesLabel.Size = new System.Drawing.Size(103, 45);
            this.prizesLabel.TabIndex = 19;
            this.prizesLabel.Text = "Prizes";
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.BackColor = System.Drawing.Color.White;
            this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournamentButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.createTournamentButton.Location = new System.Drawing.Point(66, 623);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(374, 57);
            this.createTournamentButton.TabIndex = 22;
            this.createTournamentButton.Text = "Create Tournament";
            this.createTournamentButton.UseVisualStyleBackColor = false;
            this.createTournamentButton.Click += new System.EventHandler(this.createTournamentButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 50F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1185, 747);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.removePrizesButton);
            this.Controls.Add(this.tournamentPrizesListBox);
            this.Controls.Add(this.prizesLabel);
            this.Controls.Add(this.removePlayersButton);
            this.Controls.Add(this.tournamentPlayersListBox);
            this.Controls.Add(this.tournamentPlayersLabel);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.selectTeamComboBox);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeValue);
            this.Controls.Add(this.tournamentNameValue);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.tournamentNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "CreateTournamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label tournamentNameLabel;
        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.TextBox tournamentNameValue;
        private System.Windows.Forms.TextBox entryFeeValue;
        private System.Windows.Forms.Label selectTeamLabel;
        private System.Windows.Forms.ComboBox selectTeamComboBox;
        private System.Windows.Forms.Button createTeamButton;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Button createPrizeButton;
        private System.Windows.Forms.Label tournamentPlayersLabel;
        private System.Windows.Forms.ListBox tournamentPlayersListBox;
        private System.Windows.Forms.Button removePlayersButton;
        private System.Windows.Forms.Button removePrizesButton;
        private System.Windows.Forms.ListBox tournamentPrizesListBox;
        private System.Windows.Forms.Label prizesLabel;
        private System.Windows.Forms.Button createTournamentButton;
    }
}