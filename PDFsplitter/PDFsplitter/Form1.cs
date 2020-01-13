using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PDFsplitter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            int numberOfSelectedFiles = 0;
            if (destinationFolderTextBox.Text == "")
                showMessageBox();
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

        private void chooseFileButton_DragDrop_1(object sender, DragEventArgs e)
        {
            int numberOfSelectedFiles = 0;

            if (destinationFolderTextBox.Text == "")
                showMessageBox();
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                bool found = false;
                foreach (string item in files)
                {
                    if (System.IO.Path.GetExtension(item) != ".pdf")
                    {
                        showDragAndDropMessageBox();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    foreach (string item in files)
                    {
                        if (System.IO.Path.GetExtension(item) != ".pdf")
                            showDragAndDropMessageBox();
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
        private void isBackgroundWorkerBusy()
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

        private void selectedFiles(int numberOfSelectedFiles)
        {
            for (int i = pdfFiles.Count - numberOfSelectedFiles; i < pdfFiles.Count; i++)
                createBackgroundWorker(i);
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

        private void pdfReader_DoWork(int selectedFile)
        {
            string outputPath = destinationFolderTextBox.Text;
            Reader reader = new Reader();
            reader.readFile(pdfFiles,backgroundWorkersList,viewItems,selectedFile,outputPath);
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

        private void chooseFileButton_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (destinationFolderTextBox.Text == "")
                showMessageBox();
            else
                System.Diagnostics.Process.Start(destinationFolderTextBox.Text);
        }
      
        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string filePath = @"blank.pdf";

            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
            Process.Start(startInfo);
        }

        private static void showMessageBox()
        {
            messageBoxForm messageBoxForm = new messageBoxForm();
            messageBoxForm.ShowDialog();
        }
        private static void showDragAndDropMessageBox()
        {
            draganddropMessageBox draganddropMessageBox = new draganddropMessageBox();
            draganddropMessageBox.ShowDialog();
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
        private void createItem(pdfFile file)
        {
            PDFViewItem viewItem = new PDFViewItem();
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
    }
}