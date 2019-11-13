using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFsplitter.Models;


namespace PDFsplitter
{
    public partial class Form1 : Form
    {
        private List<pdfFile> pdfFiles = new List<pdfFile> { };
        private void renderList()
        {
            textBox1.Text = String.Join(Environment.NewLine, pdfFiles);
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF|*.PDF";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.Multiselect == true)
                {

                    foreach (string item in openFileDialog1.FileNames)
                    {
                        pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);
                    }
                }
            }
            renderList();

            for (int i = 0; i < pdfFiles.Count; i++)
            {
                string pdfFilePath = pdfFiles.ElementAt(i).getFileName();
                string outputPath = pathTextBox.Text;

                int interval = 1;
                int pageNameSuffix = 0;

                PdfReader reader = new PdfReader(pdfFilePath);

                FileInfo file = new FileInfo(pdfFilePath);
                string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";

                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
                {
                    pageNameSuffix++;
                    string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                    //Console.WriteLine(newPdfFileName);

                    splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                }
            }
        }
        public void splitAndSave(string pdfFilePath, string outputPath, int startPage, int interval, string pdfFileName)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                Document document = new Document();
                PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "\\" + pdfFileName + ".pdf", FileMode.Create));
                document.Open();

                for (int pagenumber = startPage; pagenumber < (startPage + interval); pagenumber++)
                {
                    if (reader.NumberOfPages >= pagenumber)
                    {
                        copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                    }
                    else
                    {
                        break;
                    }
                }
                document.Close();
            }
        }

        private void pathTextBox_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                pathTextBox.Text = folderName;
                pathTextBox.ForeColor = Color.Black;
            }
        }

    }
}