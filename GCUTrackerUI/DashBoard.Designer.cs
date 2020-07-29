namespace GCUTrackerUI
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.headerLabel = new System.Windows.Forms.Label();
            this.loadTournamentComboBox = new System.Windows.Forms.ComboBox();
            this.loadTournamentLabel = new System.Windows.Forms.Label();
            this.loadTournamentButton = new System.Windows.Forms.Button();
            this.createNewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            resources.ApplyResources(this.headerLabel, "headerLabel");
            this.headerLabel.BackColor = System.Drawing.Color.Maroon;
            this.headerLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.headerLabel.Name = "headerLabel";
            // 
            // loadTournamentComboBox
            // 
            this.loadTournamentComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.loadTournamentComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.loadTournamentComboBox, "loadTournamentComboBox");
            this.loadTournamentComboBox.Name = "loadTournamentComboBox";
            // 
            // loadTournamentLabel
            // 
            resources.ApplyResources(this.loadTournamentLabel, "loadTournamentLabel");
            this.loadTournamentLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.loadTournamentLabel.Name = "loadTournamentLabel";
            // 
            // loadTournamentButton
            // 
            this.loadTournamentButton.BackColor = System.Drawing.Color.White;
            this.loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.loadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.loadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.loadTournamentButton, "loadTournamentButton");
            this.loadTournamentButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.loadTournamentButton.Name = "loadTournamentButton";
            this.loadTournamentButton.UseVisualStyleBackColor = false;
            this.loadTournamentButton.Click += new System.EventHandler(this.loadTournamentButton_Click);
            // 
            // createNewButton
            // 
            this.createNewButton.BackColor = System.Drawing.Color.White;
            this.createNewButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.createNewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.createNewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.createNewButton, "createNewButton");
            this.createNewButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.UseVisualStyleBackColor = false;
            this.createNewButton.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // DashBoard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.loadTournamentButton);
            this.Controls.Add(this.loadTournamentComboBox);
            this.Controls.Add(this.loadTournamentLabel);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox loadTournamentComboBox;
        private System.Windows.Forms.Label loadTournamentLabel;
        private System.Windows.Forms.Button loadTournamentButton;
        private System.Windows.Forms.Button createNewButton;
    }
}