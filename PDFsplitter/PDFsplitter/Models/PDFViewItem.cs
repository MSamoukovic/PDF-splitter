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
        }
        public void progressValue(int pageNumber,int max,string name)
        {
            int percent = pageNumber * 100;
            double m = percent / max;

            this.BeginInvoke(new MethodInvoker(delegate
            {
                nameLabel.Text = name;
                progressBar.Value = Convert.ToInt32(m);
                percentLabel.Text = progressBar.Value.ToString() + " %";
                pagesLabel.Text = max.ToString() + pageOrPages(max);
                if (progressBar.Value == progressBar.MaximumValue)
                {
                    checkBox.Checked = true;
                    checkBox.Enabled = false;
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
        public void drawItems(int widthOfPanel)
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

