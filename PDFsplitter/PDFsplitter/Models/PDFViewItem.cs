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
        public PDFViewItem()
        {
            InitializeComponent();

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
   
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // bunifuProgressBar1.MaximumValue = PDFPages;
            for (int i = 1; i < 101; i++)
            {
                Thread.Sleep(80);
                //  backgroundWorker1.ReportProgress(i);
                backgroundWorker1.ReportProgress(i);

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //bunifuProgressBar1.Value = e.ProgressPercentage / PDFPages * 100;
            bunifuProgressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage != 100)
                label1.Text = e.ProgressPercentage.ToString() + "%";
            else
                label1.Text = "";

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bunifuCheckbox1.Checked = true;
            itemPagesLabel.Visible = true;

        }
        #endregion

        private void PDFViewItem_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

        }
    }
}