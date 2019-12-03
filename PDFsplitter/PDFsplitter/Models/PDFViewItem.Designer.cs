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
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.itemPagesLabel = new System.Windows.Forms.Label();
            this.progressBar = new ns1.BunifuProgressBar();
            this.checkbox = new ns1.BunifuCheckbox();
            this.SuspendLayout();
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.itemNameLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.itemNameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.itemNameLabel.Location = new System.Drawing.Point(3, 11);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(46, 16);
            this.itemNameLabel.TabIndex = 4;
            this.itemNameLabel.Text = "label1";
            // 
            // itemPagesLabel
            // 
            this.itemPagesLabel.AutoSize = true;
            this.itemPagesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemPagesLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.itemPagesLabel.Location = new System.Drawing.Point(504, 25);
            this.itemPagesLabel.Name = "itemPagesLabel";
            this.itemPagesLabel.Size = new System.Drawing.Size(109, 16);
            this.itemPagesLabel.TabIndex = 6;
            this.itemPagesLabel.Text = "itemPagesLabel";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Silver;
            this.progressBar.BorderRadius = 5;
            this.progressBar.Location = new System.Drawing.Point(6, 35);
            this.progressBar.MaximumValue = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.DarkOrange;
            this.progressBar.Size = new System.Drawing.Size(393, 6);
            this.progressBar.TabIndex = 7;
            this.progressBar.Value = 0;
            // 
            // checkbox
            // 
            this.checkbox.BackColor = System.Drawing.Color.Gainsboro;
            this.checkbox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.checkbox.Checked = true;
            this.checkbox.CheckedOnColor = System.Drawing.Color.Gainsboro;
            this.checkbox.Enabled = false;
            this.checkbox.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkbox.Location = new System.Drawing.Point(426, 26);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(20, 20);
            this.checkbox.TabIndex = 8;
            // 
            // PDFViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.checkbox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.itemPagesLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Name = "PDFViewItem";
            this.Size = new System.Drawing.Size(616, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      //  private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label itemPagesLabel;
        private ns1.BunifuProgressBar progressBar;
        private ns1.BunifuCheckbox checkbox;
    }
}
