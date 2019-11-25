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
            this.itemPagesLabel = new System.Windows.Forms.Label();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // itemPagesLabel
            // 
            this.itemPagesLabel.AutoSize = true;
            this.itemPagesLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.itemPagesLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.itemPagesLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.itemPagesLabel.Location = new System.Drawing.Point(504, 24);
            this.itemPagesLabel.Name = "itemPagesLabel";
            this.itemPagesLabel.Size = new System.Drawing.Size(46, 16);
            this.itemPagesLabel.TabIndex = 1;
            this.itemPagesLabel.Text = "label2";
            this.itemPagesLabel.Visible = false;
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.Gainsboro;
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.Gainsboro;
            this.bunifuCheckbox1.Enabled = false;
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(431, 20);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 2;
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(5, 30);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.DarkOrange;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(385, 7);
            this.bunifuProgressBar1.TabIndex = 3;
            this.bunifuProgressBar1.Value = 0;
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.itemNameLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.itemNameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.itemNameLabel.Location = new System.Drawing.Point(13, 9);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(46, 16);
            this.itemNameLabel.TabIndex = 4;
            this.itemNameLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(416, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // PDFViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.itemPagesLabel);
            this.Name = "PDFViewItem";
            this.Size = new System.Drawing.Size(616, 50);
            this.Load += new System.EventHandler(this.PDFViewItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label itemPagesLabel;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
