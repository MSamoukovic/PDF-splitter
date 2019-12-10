namespace PDFsplitter.Models
{
    partial class PDFViewItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.progressBar = new ns1.BunifuProgressBar();
            this.checkBox = new ns1.BunifuCheckbox();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.nameLabel.Location = new System.Drawing.Point(16, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 16);
            this.nameLabel.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.progressBar.BackColor = System.Drawing.Color.Silver;
            this.progressBar.BorderRadius = 3;
            this.progressBar.Location = new System.Drawing.Point(19, 37);
            this.progressBar.MaximumValue = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.DarkOrange;
            this.progressBar.Size = new System.Drawing.Size(401, 6);
            this.progressBar.TabIndex = 12;
            this.progressBar.Value = 0;
            // 
            // checkBox
            // 
            this.checkBox.BackColor = System.Drawing.Color.Gainsboro;
            this.checkBox.ChechedOffColor = System.Drawing.Color.Gainsboro;
            this.checkBox.Checked = false;
            this.checkBox.CheckedOnColor = System.Drawing.Color.Gainsboro;
            this.checkBox.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkBox.Location = new System.Drawing.Point(445, 27);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(20, 20);
            this.checkBox.TabIndex = 13;
            // 
            // pagesLabel
            // 
            this.pagesLabel.AutoSize = true;
            this.pagesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagesLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.pagesLabel.Location = new System.Drawing.Point(518, 31);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(0, 16);
            this.pagesLabel.TabIndex = 14;
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.percentLabel.Location = new System.Drawing.Point(442, 27);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(0, 16);
            this.percentLabel.TabIndex = 15;
            // 
            // PDFViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.pagesLabel);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.nameLabel);
            this.Name = "PDFViewItem";
            this.Size = new System.Drawing.Size(616, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private ns1.BunifuProgressBar progressBar;
        private ns1.BunifuCheckbox checkBox;
        private System.Windows.Forms.Label pagesLabel;
        private System.Windows.Forms.Label percentLabel;
    }
}
