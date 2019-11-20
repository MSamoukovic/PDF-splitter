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
            this.pathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonColorButton1 = new ComponentFactory.Krypton.Toolkit.KryptonColorButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.Color.White;
            this.pathTextBox.CustomForeColor = true;
            this.pathTextBox.ForeColor = System.Drawing.Color.Black;
            this.pathTextBox.Location = new System.Drawing.Point(270, 41);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(725, 23);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.Click += new System.EventHandler(this.pathTextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(267, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select a destination folder :";
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel.Location = new System.Drawing.Point(270, 78);
            this.panel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel.Size = new System.Drawing.Size(742, 371);
            this.panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 464);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.panel2.Location = new System.Drawing.Point(273, 572);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 189);
            this.panel2.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(43, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(171, 159);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.TabIndex = 0;
            // 
            // kryptonColorButton1
            // 
            this.kryptonColorButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonColorButton1.Name = "kryptonColorButton1";
            this.kryptonColorButton1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.panel3.Location = new System.Drawing.Point(1029, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(133, 652);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.panel4.Location = new System.Drawing.Point(273, 572);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(863, 189);
            this.panel4.TabIndex = 15;
            // 
            // clearButton
            // 
            this.clearButton.BackgroundImage = global::PDFsplitter.Properties.Resources.clearr;
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearButton.Location = new System.Drawing.Point(873, 462);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(122, 35);
            this.clearButton.TabIndex = 20;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackgroundImage = global::PDFsplitter.Properties.Resources.but;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(380, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(487, 129);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            this.button2.DragDrop += new System.Windows.Forms.DragEventHandler(this.button1_DragDrop_1);
            this.button2.DragEnter += new System.Windows.Forms.DragEventHandler(this.button1_DragEnter_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1237, 654);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF-splitter";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonColorButton kryptonColorButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clearButton;
    }
}

