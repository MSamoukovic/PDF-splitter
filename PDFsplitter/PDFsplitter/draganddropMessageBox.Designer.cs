namespace PDFsplitter
{
    partial class draganddropMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(draganddropMessageBox));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notPDFFileButton = new ns1.BunifuTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(124, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select only pdf file !";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PDFsplitter.Properties.Resources.logopharmalink1;
            this.pictureBox1.Location = new System.Drawing.Point(165, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // notPDFFileButton
            // 
            this.notPDFFileButton.BackColor = System.Drawing.Color.Silver;
            this.notPDFFileButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notPDFFileButton.color = System.Drawing.Color.Silver;
            this.notPDFFileButton.colorActive = System.Drawing.Color.Silver;
            this.notPDFFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notPDFFileButton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notPDFFileButton.ForeColor = System.Drawing.Color.Black;
            this.notPDFFileButton.Image = ((System.Drawing.Image)(resources.GetObject("notPDFFileButton.Image")));
            this.notPDFFileButton.ImagePosition = 20;
            this.notPDFFileButton.ImageZoom = 50;
            this.notPDFFileButton.LabelPosition = 31;
            this.notPDFFileButton.LabelText = "OK";
            this.notPDFFileButton.Location = new System.Drawing.Point(148, 128);
            this.notPDFFileButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.notPDFFileButton.Name = "notPDFFileButton";
            this.notPDFFileButton.Size = new System.Drawing.Size(125, 39);
            this.notPDFFileButton.TabIndex = 5;
            this.notPDFFileButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // draganddropMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(413, 206);
            this.Controls.Add(this.notPDFFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "draganddropMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF-splitter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private ns1.BunifuTileButton okButton;
        private System.Windows.Forms.Label label1;
        private ns1.BunifuTileButton notPDFFileButton;
    }
}