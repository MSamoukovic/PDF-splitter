namespace PDFsplitter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(158, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pathTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.pathTextBox.Location = new System.Drawing.Point(12, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(467, 23);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.Text = "select the path";
            this.pathTextBox.Click += new System.EventHandler(this.pathTextBox_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel.Location = new System.Drawing.Point(12, 41);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(0, 100, 0, 0);
            this.panel.Size = new System.Drawing.Size(467, 402);
            this.panel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 523);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF-splitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Panel panel;
    }
}

