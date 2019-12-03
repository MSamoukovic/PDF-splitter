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

        public PDFViewItem(string fileName, int filePages)
        {
            InitializeComponent();
            PDFName = fileName;
            PDFPages = filePages;

        }

        #region Properties

        private string pdfName;
        private int pdfPages;

        public string PDFName
        {
            get 
            {
                return pdfName; 
            }
            set 
            {
                pdfName = value; 
                itemNameLabel.Text = value; 
            }
        }

        public int PDFPages
        {
            get 
            {
                return pdfPages; 
            }
            set 
            {
                pdfPages = value; 
                itemPagesLabel.Text = value.ToString() + pageOrPages(PDFName); 
            }
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
            progressBar.Value = Convert.ToInt32(m);
            Console.WriteLine(progressBar.Value);

            //percentLabel.Text = progressBar.Value.ToString() + " %";

            if (progressBar.Value == progressBar.MaximumValue)
            checkbox.Checked = true;
        }           
        #endregion
    }
}