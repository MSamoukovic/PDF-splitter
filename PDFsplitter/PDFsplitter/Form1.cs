using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PDFsplitter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFsplitter
{
    public partial class Form1 : Form
    {
        private List<pdfFile> pdfFiles = new List<pdfFile> { };
        private List<PDFViewItem> viewItems = new List<PDFViewItem> { };
        private List<BackgroundWorker> backgroundWorkersList = new List<BackgroundWorker> { };
     //   private List<Thread> threadsList = new List<Thread> { };
        public Form1()
        {
            InitializeComponent();


            
             

        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            int numberOfSelectedFiles = 0;

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
                        numberOfSelectedFiles++;
                    }
                }
                readFile(numberOfSelectedFiles);
            }
        }

        private void readFile(int numberOfSelectedFiles)
        {
            for (int i = pdfFiles.Count - numberOfSelectedFiles; i < pdfFiles.Count; i++)
            {
                // createViewItem(i);
                int j = i;
                createBackgroundWorker( j);
            }
        }
        
        private void createViewItem(int i)
        {
         //   this.BeginInvoke(new MethodInvoker(delegate
          //  {
                string itemName = pdfFiles.ElementAt(i).getName();
            int itemPages = pdfFiles.ElementAt(i).getNumberOfPages(pdfFiles.ElementAt(i).getFileName());
            PDFViewItem viewItem = new PDFViewItem(itemName, itemPages);
            viewItems.Add(viewItem);
            panel.Controls.Add(viewItem);
          //  }));

        }

        private void createBackgroundWorker(int i)
        {
            createViewItem(i);
            BackgroundWorker pdfReader = new BackgroundWorker();
            backgroundWorkersList.Add(pdfReader);
            pdfReader.DoWork += (obj, e) => pdfReader_DoWork(i);
            pdfReader.ProgressChanged += PdfReader_ProgressChanged;
            pdfReader.WorkerReportsProgress = true;
            pdfReader.RunWorkerAsync();
        }

        private void PdfReader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { 

        }

        private void pdfReader_DoWork(int i)
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

                int percent = pageNumber * 100;
                double value = percent / reader.NumberOfPages;
                int reportValue = Convert.ToInt32(value);

                viewItems[i].progressValue(pageNumber); 
                

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
            backgroundWorkersList.Clear();
        }
        private void chooseFileButton_DragDrop_1(object sender, DragEventArgs e)
        {
            int numberOfSelectedFiles = 0;

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
                    if (System.IO.Path.GetExtension(item) != ".pdf")
                    {
                        draganddropMessageBox draganddropMessageBox = new draganddropMessageBox();
                        draganddropMessageBox.ShowDialog();
                    }
                    else
                    {
                        pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);
                        numberOfSelectedFiles++;

                        /*   PDFViewItem viewItem = new PDFViewItem();
                       /   viewItem.PDFName = file.getName();
                           viewItem.PDFPages = file.getNumberOfPages(file.getFileName());
                           viewItems.Add(viewItem);
                           panel.Controls.Add(viewItem);
                           */
                    }
                }
                //  renderList();

                readFile(numberOfSelectedFiles);
            }
        }

        private void chooseFileButton_DragEnter_1(object sender, DragEventArgs e)
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

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}