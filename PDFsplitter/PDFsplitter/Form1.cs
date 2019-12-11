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

        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;

            if (pdfFiles.Count == 0)
            {
                clearButton.Enabled = false;
            }
        }
        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            int numberOfSelectedFiles = 0;

            if (destinationFolderTextBox.Text == "")
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
                    destinationFolderTextBox.Enabled = false;

                    foreach (string item in openFileDialog1.FileNames)
                    {
                        pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);
                        numberOfSelectedFiles++;
                        createItem(file);
                    }
                }
                selectedFiles(numberOfSelectedFiles);
            }
        }

        private void selectedFiles(int numberOfSelectedFiles)
        {
            for (int i = pdfFiles.Count - numberOfSelectedFiles; i < pdfFiles.Count; i++)
            {
                //  createViewItem(i);
                createBackgroundWorker(i);
            }
        }
        private void createItem(pdfFile file) //ako pozivam na click
        {
            PDFViewItem viewItem = new PDFViewItem(file.getName(), file.getNumberOfPages(file.getFileName()));
            viewItem.Width = panel.Width - 29;
            viewItem.drawItems(panel.Width);
            viewItems.Add(viewItem);

            viewItem.Width = panel.Width - 33;
            panel.Controls.Add(viewItem);
        }       
        private void createBackgroundWorker(int i)
        {
            BackgroundWorker pdfReader = new BackgroundWorker();
            backgroundWorkersList.Add(pdfReader);
            pdfReader.DoWork += (obj, e) => pdfReader_DoWork(i);
            pdfReader.ProgressChanged += PdfReader_ProgressChanged;
            pdfReader.WorkerReportsProgress = true;
            pdfReader.RunWorkerCompleted += pdfReader_RunWorkerCompleted;
            pdfReader.RunWorkerAsync();
            isBackgroundWorkerBusy();

        }
        public void isBackgroundWorkerBusy()
        {
            for (int j = 0; j < backgroundWorkersList.Count; j++)
            {
                if (backgroundWorkersList[j].IsBusy == true)
                {
                    clearButton.Enabled = false;
                    return;
                }
            }
            clearButton.Enabled = true;
        }
        private void PdfReader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            isBackgroundWorkerBusy();
            destinationFolderTextBox.Enabled = false;

        }
        private void pdfReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clearButton.Enabled = true;
            destinationFolderTextBox.Enabled = true;

        }
        private void pdfReader_DoWork(int i)
        {
            string pdfFilePath = pdfFiles.ElementAt(i).getFileName();
            string outputPath = destinationFolderTextBox.Text;
            int interval = 1;
            int pageNameSuffix = 0;

            PdfReader reader = new PdfReader(pdfFilePath);
            FileInfo file = new FileInfo(pdfFilePath);

            string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";
            string pattern = @"\b[A-Z]{2,4}[0-9]{5,7}([A-Z]{1,2})?([0-9]{3,4})?(.\S)?(-)?(.\n)?(.\S)?[0-9]{3,4}";

            Regex rg = new Regex(pattern);

            for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
            {
                StringBuilder text = new StringBuilder();
                pageNameSuffix++;

                text.Append(PdfTextExtractor.GetTextFromPage(reader, pageNumber));
                // Console.WriteLine(text);

                MatchCollection mc = rg.Matches(text.ToString());
                if (mc.Count != 0)
                {
                    for (int count = 0; count < mc.Count - mc.Count + 1; count++)
                    {

                        string newPdfFileName = string.Format(Regex.Replace(mc[count].Value, @"\s+", " "));
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
                backgroundWorkersList[i].ReportProgress(reportValue);

                viewItems[i].progressValue(pageNumber, reader.NumberOfPages, pdfFiles.ElementAt(i).getName());
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
                destinationFolderTextBox.Text = folderName;
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.VerticalScroll.Visible = false;
            viewItems.Clear();
            pdfFiles.Clear();
            backgroundWorkersList.Clear();
            clearButton.Enabled = false;
            destinationFolderTextBox.SelectionLength = 0; ;
        }
        private void chooseFileButton_DragDrop_1(object sender, DragEventArgs e)
        {
            int numberOfSelectedFiles = 0;

            if (destinationFolderTextBox.Text == "")
            {
                messageBoxForm messageBoxForm = new messageBoxForm();
                messageBoxForm.ShowDialog();
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                bool found = false;

                foreach (string item in files)
                {
                    if (System.IO.Path.GetExtension(item) != ".pdf")
                    {
                        draganddropMessageBox draganddropMessageBox = new draganddropMessageBox();
                        draganddropMessageBox.ShowDialog();
                        found = true;
                        break;
                    }                
                }
                if (!found)
                {
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
                            createItem(file);
                        }
                    }
                } 
                selectedFiles(numberOfSelectedFiles);
            }
        }
        private void chooseFileButton_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (destinationFolderTextBox.Text == "")
            {
                messageBoxForm messageBoxForm = new messageBoxForm();
                messageBoxForm.ShowDialog();
            }
            else
            {
                System.Diagnostics.Process.Start(destinationFolderTextBox.Text);
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            destinationFolderTextBox.Width = panel.Width - 30;
            for (int j = 0; j < viewItems.Count; j++)
            {
                viewItems[j].Width = panel.Width - 33;
                viewItems[j].drawItems(panel.Width);
                panel.HorizontalScroll.Enabled = false;
                panel.HorizontalScroll.Maximum = 0;
                panel.AutoScroll = false;
                panel.AutoScroll = true;
                destinationFolderTextBox.Width = panel.Width - 30;
            }
        }        
    }
}