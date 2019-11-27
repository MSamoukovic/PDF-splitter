using Bunifu.Framework.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PDFsplitter.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;



namespace PDFsplitter
{
    public partial class Form1 : Form
    {
        private List<pdfFile> pdfFiles = new List<pdfFile> { };
        private List<PDFViewItem> viewItems = new List<PDFViewItem> { };

        /* private void renderList()
         {
             textBox1.Text = String.Join(Environment.NewLine, pdfFiles);
         }
         */

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int listCount = 0;

            if (pathTextBox.Text == "")
            {
                messageBoxForm messageBoxForm = new messageBoxForm();
                messageBoxForm.ShowDialog();
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "PDF|*.PDF",
                    Multiselect = true
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string item in openFileDialog1.FileNames)
                    {
                       pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);                     
                        listCount++;
                    }
                }
                Console.WriteLine(listCount);

                for (int i=pdfFiles.Count - listCount; i < pdfFiles.Count; i++)
            {
                string pdfFilePath = pdfFiles.ElementAt(i).getFileName();
                string outputPath = pathTextBox.Text;
                int interval = 1;
                int pageNameSuffix = 0;
                PdfReader reader = new PdfReader(pdfFilePath);
                FileInfo file = new FileInfo(pdfFilePath);
                string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";
                string pattern = @"\b[A-Z]{2,4}[0-9]{5,7}([A-Z]{1,2})?([0-9]{3,4})?(-)?[0-9]{3,4}";
                // string pattern = @"\b[A-Z]{2,4}[0-9]{5,7}([A-Z]{1,2})?([0-9]{3,4})?\s?(-)?\s?[0-9]{3,4}"; with space
                Regex rg = new Regex(pattern);

                    PDFViewItem viewItem = new PDFViewItem();

                    viewItem.PDFName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + ".pdf"; 
                    viewItem.PDFPages = reader.NumberOfPages;
                    viewItems.Add(viewItem);
                    panel.Controls.Add(viewItem);
                
                    for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
                    {

                    StringBuilder text = new StringBuilder();
                    pageNameSuffix++;

                    text.Append(PdfTextExtractor.GetTextFromPage(reader, pageNumber));

                    MatchCollection mc = rg.Matches(text.ToString());
                    if (mc.Count != 0)
                    {
                        for (int count = 0; count < mc.Count - mc.Count + 1; count++)
                        {
                            string newPdfFileName = string.Format(mc[count].Value);
                            splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                        }
                    }
                    else
                    {
                        string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                        splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                    }
                        viewItem.progressValue(pageNumber);
                    }                
                }
            }
        }
      
        public void splitAndSave(string pdfFilePath, string outputPath, int startPage, int interval, string pdfFileName)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                Document document = new Document();
                using (PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "\\" + pdfFileName + ".pdf", FileMode.Create)))
                {
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
                }
                document.Close();
            }
        }
        private void pathTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                pathTextBox.Text = folderName;
                
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            viewItems.Clear();
            pdfFiles.Clear();
        }

        private void button1_DragDrop_1(object sender, DragEventArgs e)
        {
            int listCount = 0;

            if (pathTextBox.Text == "")
            {
                messageBoxForm messageBoxForm = new messageBoxForm();
                messageBoxForm.ShowDialog();
            }
          
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (string item in files)
                {                   
                    if (System.IO.Path.GetExtension(item)!=".pdf")
                    {
                         draganddropMessageBox draganddropMessageBox = new draganddropMessageBox();
                         draganddropMessageBox.ShowDialog();
                    }
                    else
                    {
                        pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);                    
                        listCount++;
                    }
                }
                //  renderList();
                for (int i = pdfFiles.Count - listCount; i < pdfFiles.Count; i++)
                {
                    string pdfFilePath = pdfFiles.ElementAt(i).getFileName();
                    string outputPath = pathTextBox.Text;
                    int interval = 1;
                    int pageNameSuffix = 0;
                    PdfReader reader = new PdfReader(pdfFilePath);
                    FileInfo file = new FileInfo(pdfFilePath);
                    string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";
                    string pattern = @"\b[A-Z]{2,4}[0-9]{5,7}([A-Z]{1,2})?([0-9]{3,4})?(-)?[0-9]{3,4}";
                    // string pattern = @"\b[A-Z]{2,4}[0-9]{5,7}([A-Z]{1,2})?([0-9]{3,4})?\s?(-)?\s?[0-9]{3,4}"; with space
                    Regex rg = new Regex(pattern);

                    PDFViewItem viewItem = new PDFViewItem();
                    viewItem.PDFName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + ".pdf"; ;
                    viewItem.PDFPages = reader.NumberOfPages;
                    viewItems.Add(viewItem);
                    panel.Controls.Add(viewItem);

                    for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
                    {
                        StringBuilder text = new StringBuilder();
                        pageNameSuffix++;

                        text.Append(PdfTextExtractor.GetTextFromPage(reader, pageNumber));

                        MatchCollection mc = rg.Matches(text.ToString());
                        if (mc.Count != 0)
                        {
                            for (int count = 0; count < mc.Count - mc.Count + 1; count++)
                            {
                                string newPdfFileName = string.Format(mc[count].Value);
                                splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                            }
                        }
                        else
                        {
                            string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                            splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                        }

                        viewItem.progressValue(pageNumber);   
                    }
                   

                }
            }

            }

        private void button1_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pathTextBox.Text == "")
            {
                messageBoxForm messageBoxForm = new messageBoxForm();
                messageBoxForm.ShowDialog();
            }
            else
            {
                System.Diagnostics.Process.Start(pathTextBox.Text);
            }
        }
    }
}