namespace GCUTrackerUI
{
    partial class CreatePrizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.percentageValue = new System.Windows.Forms.TextBox();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.amountValue = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.placeNameValue = new System.Windows.Forms.TextBox();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.placeNumberValue = new System.Windows.Forms.TextBox();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.orLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Maroon;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.headerLabel.Location = new System.Drawing.Point(12, 23);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(290, 65);
            this.headerLabel.TabIndex = 11;
            this.headerLabel.Text = "Create Prize";
            // 
            // percentageValue
            // 
            this.percentageValue.BackColor = System.Drawing.Color.DarkGray;
            this.percentageValue.Location = new System.Drawing.Point(226, 345);
            this.percentageValue.Name = "percentageValue";
            this.percentageValue.Size = new System.Drawing.Size(248, 43);
            this.percentageValue.TabIndex = 28;
            this.percentageValue.Text = "0";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.percentageLabel.Location = new System.Drawing.Point(28, 345);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(155, 38);
            this.percentageLabel.TabIndex = 27;
            this.percentageLabel.Text = "Percentage";
            // 
            // amountValue
            // 
            this.amountValue.BackColor = System.Drawing.Color.DarkGray;
            this.amountValue.Location = new System.Drawing.Point(226, 223);
            this.amountValue.Name = "amountValue";
            this.amountValue.Size = new System.Drawing.Size(248, 43);
            this.amountValue.TabIndex = 26;
            this.amountValue.Text = "0";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.amountLabel.Location = new System.Drawing.Point(28, 223);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(116, 38);
            this.amountLabel.TabIndex = 25;
            this.amountLabel.Text = "Amount";
            // 
            // placeNameValue
            // 
            this.placeNameValue.BackColor = System.Drawing.Color.DarkGray;
            this.placeNameValue.Location = new System.Drawing.Point(226, 163);
            this.placeNameValue.Name = "placeNameValue";
            this.placeNameValue.Size = new System.Drawing.Size(248, 43);
            this.placeNameValue.TabIndex = 24;
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeNameLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.placeNameLabel.Location = new System.Drawing.Point(28, 163);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(172, 38);
            this.placeNameLabel.TabIndex = 23;
            this.placeNameLabel.Text = "Place Name ";
            // 
            // placeNumberValue
            // 
            this.placeNumberValue.BackColor = System.Drawing.Color.DarkGray;
            this.placeNumberValue.Location = new System.Drawing.Point(226, 103);
            this.placeNumberValue.Name = "placeNumberValue";
            this.placeNumberValue.Size = new System.Drawing.Size(248, 43);
            this.placeNumberValue.TabIndex = 22;
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeNumberLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.placeNumberLabel.Location = new System.Drawing.Point(28, 103);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(192, 38);
            this.placeNumberLabel.TabIndex = 21;
            this.placeNumberLabel.Text = "Place Number";
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
            this.createPrizeButton.Location = new System.Drawing.Point(60, 430);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(367, 57);
            this.createPrizeButton.TabIndex = 29;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = false;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.orLabel.Location = new System.Drawing.Point(202, 288);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(77, 38);
            this.orLabel.TabIndex = 30;
            this.orLabel.Text = "-OR-";
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(512, 586);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.percentageValue);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.amountValue);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.placeNameValue);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeNumberValue);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Goldenrod;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "CreatePrizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreatePrizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox percentageValue;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.TextBox amountValue;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox placeNameValue;
        private System.Windows.Forms.Label placeNameLabel;
        private System.Windows.Forms.TextBox placeNumberValue;
        private System.Windows.Forms.Label placeNumberLabel;
        private System.Windows.Forms.Button createPrizeButton;
        private System.Windows.Forms.Label orLabel;
    }
}