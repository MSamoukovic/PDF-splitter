namespace PDFsplitter
{
    partial class messageBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(messageBoxForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new Bunifu.Framework.UI.BunifuTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PDFsplitter.Properties.Resources.adobe_acrobat_pdf_file_512;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(168, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select a destination path !\r\n";
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.okButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.okButton.color = System.Drawing.Color.Silver;
            this.okButton.colorActive = System.Drawing.Color.Silver;
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.okButton.ForeColor = System.Drawing.Color.Black;
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImagePosition = 0;
            this.okButton.ImageZoom = 0;
            this.okButton.LabelPosition = 31;
            this.okButton.LabelText = "OK";
            this.okButton.Location = new System.Drawing.Point(209, 123);
            this.okButton.Margin = new System.Windows.Forms.Padding(6);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(115, 39);
            this.okButton.TabIndex = 2;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // messageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(433, 225);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "messageBoxForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF-splitter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuTileButton okButton;
    }
}
