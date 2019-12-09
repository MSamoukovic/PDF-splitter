using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFsplitter.Models
{
    public partial class PDFViewItem : UserControl
    {
        public PDFViewItem(string fileName, int filePages)
        {
            InitializeComponent();
            nameLabel.Text = fileName;
            pagesLabel.Text = filePages.ToString() + pageOrPages(filePages);
        }
        public void progressValue(int pageNumber,int max)
        {
            int percent = pageNumber * 100;
            double m = percent / max;

            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar.Value = Convert.ToInt32(m);
                percentLabel.Text = progressBar.Value.ToString() + " %";
                if (progressBar.Value == progressBar.MaximumValue)
                {
                    checkBox.Checked = true;
                    percentLabel.Visible = false;
                }
            }));
        }
        public string pageOrPages(int filePages)
        {
            if (filePages == 1)
                return " page";
            else
                return " pages";
        }
        public void drawItem(int widthOfPanel)
        {
            int x = widthOfPanel * 60;
            double y = x / 100;
            progressBar.Width = Convert.ToInt32(y);

            percentLabel.Location = new System.Drawing.Point(progressBar.Width + 20, 26);
            checkBox.Location = new System.Drawing.Point(progressBar.Width + 30, 25);
            pagesLabel.Location = new System.Drawing.Point(progressBar.Width + 65, 26);
        }
    }
}
