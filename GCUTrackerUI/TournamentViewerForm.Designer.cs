namespace GCUTrackerUI
{
    partial class TournamentViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.tournamentName = new System.Windows.Forms.Label();
            this.roundLabel = new System.Windows.Forms.Label();
            this.roundComboBox = new System.Windows.Forms.ComboBox();
            this.unplayedCheckBox = new System.Windows.Forms.CheckBox();
            this.roundsListBox = new System.Windows.Forms.ListBox();
            this.teamOneLabel = new System.Windows.Forms.Label();
            this.teamOneScoreLabel = new System.Windows.Forms.Label();
            this.teamOneScoreValue = new System.Windows.Forms.TextBox();
            this.teamTwoScoreValue = new System.Windows.Forms.TextBox();
            this.teamTwoScoreLabel = new System.Windows.Forms.Label();
            this.teamTwoLabel = new System.Windows.Forms.Label();
            this.scoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Maroon;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.headerLabel.Location = new System.Drawing.Point(35, 54);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(303, 65);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Tournament:";
            // 
            // tournamentName
            // 
            this.tournamentName.AutoSize = true;
            this.tournamentName.BackColor = System.Drawing.Color.Maroon;
            this.tournamentName.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentName.ForeColor = System.Drawing.Color.Goldenrod;
            this.tournamentName.Location = new System.Drawing.Point(344, 54);
            this.tournamentName.Name = "tournamentName";
            this.tournamentName.Size = new System.Drawing.Size(205, 65);
            this.tournamentName.TabIndex = 1;
            this.tournamentName.Text = "<none>";
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.roundLabel.Location = new System.Drawing.Point(39, 160);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(115, 45);
            this.roundLabel.TabIndex = 2;
            this.roundLabel.Text = "Round";
            // 
            // roundComboBox
            // 
            this.roundComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.roundComboBox.FormattingEnabled = true;
            this.roundComboBox.Location = new System.Drawing.Point(156, 161);
            this.roundComboBox.Name = "roundComboBox";
            this.roundComboBox.Size = new System.Drawing.Size(374, 45);
            this.roundComboBox.TabIndex = 3;
            this.roundComboBox.SelectedIndexChanged += new System.EventHandler(this.roundComboBox_SelectedIndexChanged);
            // 
            // unplayedCheckBox
            // 
            this.unplayedCheckBox.AutoSize = true;
            this.unplayedCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.unplayedCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unplayedCheckBox.ForeColor = System.Drawing.Color.Goldenrod;
            this.unplayedCheckBox.Location = new System.Drawing.Point(156, 224);
            this.unplayedCheckBox.Name = "unplayedCheckBox";
            this.unplayedCheckBox.Size = new System.Drawing.Size(218, 42);
            this.unplayedCheckBox.TabIndex = 4;
            this.unplayedCheckBox.Text = "Unplayed Only";
            this.unplayedCheckBox.UseVisualStyleBackColor = true;
            this.unplayedCheckBox.CheckedChanged += new System.EventHandler(this.unplayedCheckBox_CheckedChanged);
            // 
            // roundsListBox
            // 
            this.roundsListBox.BackColor = System.Drawing.Color.DarkGray;
            this.roundsListBox.FormattingEnabled = true;
            this.roundsListBox.ItemHeight = 37;
            this.roundsListBox.Location = new System.Drawing.Point(46, 281);
            this.roundsListBox.Name = "roundsListBox";
            this.roundsListBox.Size = new System.Drawing.Size(541, 300);
            this.roundsListBox.TabIndex = 5;
            this.roundsListBox.SelectedIndexChanged += new System.EventHandler(this.roundsListBox_SelectedIndexChanged);
            // 
            // teamOneLabel
            // 
            this.teamOneLabel.AutoSize = true;
            this.teamOneLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.teamOneLabel.Location = new System.Drawing.Point(624, 281);
            this.teamOneLabel.Name = "teamOneLabel";
            this.teamOneLabel.Size = new System.Drawing.Size(200, 45);
            this.teamOneLabel.TabIndex = 6;
            this.teamOneLabel.Text = "<teamOne>";
            // 
            // teamOneScoreLabel
            // 
            this.teamOneScoreLabel.AutoSize = true;
            this.teamOneScoreLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneScoreLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.teamOneScoreLabel.Location = new System.Drawing.Point(951, 281);
            this.teamOneScoreLabel.Name = "teamOneScoreLabel";
            this.teamOneScoreLabel.Size = new System.Drawing.Size(146, 45);
            this.teamOneScoreLabel.TabIndex = 7;
            this.teamOneScoreLabel.Text = "<Score>";
            // 
            // teamOneScoreValue
            // 
            this.teamOneScoreValue.BackColor = System.Drawing.Color.DarkGray;
            this.teamOneScoreValue.Location = new System.Drawing.Point(1113, 283);
            this.teamOneScoreValue.Name = "teamOneScoreValue";
            this.teamOneScoreValue.Size = new System.Drawing.Size(163, 43);
            this.teamOneScoreValue.TabIndex = 8;
            // 
            // teamTwoScoreValue
            // 
            this.teamTwoScoreValue.BackColor = System.Drawing.Color.DarkGray;
            this.teamTwoScoreValue.Location = new System.Drawing.Point(1114, 409);
            this.teamTwoScoreValue.Name = "teamTwoScoreValue";
            this.teamTwoScoreValue.Size = new System.Drawing.Size(163, 43);
            this.teamTwoScoreValue.TabIndex = 11;
            // 
            // teamTwoScoreLabel
            // 
            this.teamTwoScoreLabel.AutoSize = true;
            this.teamTwoScoreLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoScoreLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.teamTwoScoreLabel.Location = new System.Drawing.Point(951, 407);
            this.teamTwoScoreLabel.Name = "teamTwoScoreLabel";
            this.teamTwoScoreLabel.Size = new System.Drawing.Size(146, 45);
            this.teamTwoScoreLabel.TabIndex = 10;
            this.teamTwoScoreLabel.Text = "<Score>";
            // 
            // teamTwoLabel
            // 
            this.teamTwoLabel.AutoSize = true;
            this.teamTwoLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.teamTwoLabel.Location = new System.Drawing.Point(624, 407);
            this.teamTwoLabel.Name = "teamTwoLabel";
            this.teamTwoLabel.Size = new System.Drawing.Size(197, 45);
            this.teamTwoLabel.TabIndex = 9;
            this.teamTwoLabel.Text = "<teamTwo>";
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.Color.White;
            this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.scoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.scoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.scoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.scoreButton.Location = new System.Drawing.Point(792, 496);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(206, 57);
            this.scoreButton.TabIndex = 12;
            this.scoreButton.Text = "Score";
            this.scoreButton.UseVisualStyleBackColor = false;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1342, 607);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.teamTwoScoreValue);
            this.Controls.Add(this.teamTwoScoreLabel);
            this.Controls.Add(this.teamTwoLabel);
            this.Controls.Add(this.teamOneScoreValue);
            this.Controls.Add(this.teamOneScoreLabel);
            this.Controls.Add(this.teamOneLabel);
            this.Controls.Add(this.roundsListBox);
            this.Controls.Add(this.unplayedCheckBox);
            this.Controls.Add(this.roundComboBox);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.tournamentName);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label tournamentName;
        private System.Windows.Forms.Label roundLabel;
        private System.Windows.Forms.ComboBox roundComboBox;
        private System.Windows.Forms.CheckBox unplayedCheckBox;
        private System.Windows.Forms.ListBox roundsListBox;
        private System.Windows.Forms.Label teamOneLabel;
        private System.Windows.Forms.Label teamOneScoreLabel;
        private System.Windows.Forms.TextBox teamOneScoreValue;
        private System.Windows.Forms.TextBox teamTwoScoreValue;
        private System.Windows.Forms.Label teamTwoScoreLabel;
        private System.Windows.Forms.Label teamTwoLabel;
        private System.Windows.Forms.Button scoreButton;
    }
}

