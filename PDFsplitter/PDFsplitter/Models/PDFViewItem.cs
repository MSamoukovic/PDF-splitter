using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PDFsplitter.Models
{
    public partial class PDFViewItem : UserControl
    {
            public PDFViewItem(string pdfName, int pdfPages)
        {
            InitializeComponent();
           

            PDFName = pdfName;
            PDFPages = pdfPages;
            // Invalidate();      
            // this.pdfName = pdfName;
            // this.pdfPages = pdfPages;
            // this.itemNameLabel.Text = pdfName;
            // this.itemPagesLabel.Text = pdfPages.ToString();

        }
        #region Properties

        private string pdfName;
        private int pdfPages;

        public string PDFName
        {
            get { return pdfName; }
            set { pdfName = value; itemNameLabel.Text = value; }       
        }

        public int PDFPages
        {
            get { return pdfPages; }
            set { pdfPages = value; itemPagesLabel.Text = value.ToString() + pageOrPages(PDFName); }
        }

        public string pageOrPages(string PDFName)
        {
            if (pdfPages == 1)
                return " page";
            else
                return " pages";
        }
        public void progressValue(int pageNumber)
        {
            int percent = pageNumber * 100;
            double m = percent / PDFPages;

            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar.Value = Convert.ToInt32(m);
                percentLabel.Text = progressBar.Value.ToString() + " %";
                if (progressBar.Value == progressBar.MaximumValue)
                {
                    checkbox.Checked = true;
                    percentLabel.Visible = false;         
                }
            }));
        }


        public void drawItem(int widthOfPanel)
        {
            int x = widthOfPanel * 60;
            double y = x / 100;
            progressBar.Width = Convert.ToInt32(y);

            percentLabel.Location= new System.Drawing.Point(progressBar.Width+20, 26);
            checkbox.Location = new System.Drawing.Point(progressBar.Width + 30, 25);
            itemPagesLabel.Location = new System.Drawing.Point(progressBar.Width+65, 26);
        }
        #endregion
    }
}

    

  