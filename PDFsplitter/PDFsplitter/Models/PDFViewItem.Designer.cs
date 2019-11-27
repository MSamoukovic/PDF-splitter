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
            this.checkbox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.progressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.itemPagesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkbox
            // 
            this.checkbox.BackColor = System.Drawing.Color.Gainsboro;
            this.checkbox.ChechedOffColor = System.Drawing.Color.Gainsboro;
            this.checkbox.Checked = false;
            this.checkbox.CheckedOnColor = System.Drawing.Color.Gainsboro;
            this.checkbox.Enabled = false;
            this.checkbox.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkbox.Location = new System.Drawing.Point(431, 20);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(20, 20);
            this.checkbox.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Silver;
            this.progressBar.BorderRadius = 5;
            this.progressBar.Location = new System.Drawing.Point(5, 30);
            this.progressBar.MaximumValue = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.DarkOrange;
            this.progressBar.Size = new System.Drawing.Size(385, 7);
            this.progressBar.TabIndex = 3;
            this.progressBar.Value = 0;
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
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.percentLabel.Location = new System.Drawing.Point(418, 11);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(46, 16);
            this.percentLabel.TabIndex = 5;
            this.percentLabel.Text = "label1";
            // 
            // itemPagesLabel
            // 
            this.itemPagesLabel.AutoSize = true;
            this.itemPagesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemPagesLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.itemPagesLabel.Location = new System.Drawing.Point(515, 21);
            this.itemPagesLabel.Name = "itemPagesLabel";
            this.itemPagesLabel.Size = new System.Drawing.Size(109, 16);
            this.itemPagesLabel.TabIndex = 6;
            this.itemPagesLabel.Text = "itemPagesLabel";
            // 
            // PDFViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.itemPagesLabel);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkbox);
            this.Name = "PDFViewItem";
            this.Size = new System.Drawing.Size(616, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      //  private System.Windows.Forms.Label nameLabel;
        private Bunifu.Framework.UI.BunifuCheckbox checkbox;
        private Bunifu.Framework.UI.BunifuProgressBar progressBar;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label itemPagesLabel;
    }
}
