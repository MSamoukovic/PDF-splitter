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
            //textBox1.Text = String.Join(Environment.NewLine, pdfFiles);
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

                        //  ProgressBar progresBar = new ProgressBar();
                        // Label nameLabel = new Label();

                        Panel panel1 = new Panel();
                        ProgressBar progressBar = new ProgressBar();
                        Label nameLabel = new Label();
                        Label processLabel = new Label();


                        panel1.BackColor = System.Drawing.Color.Silver;
                        panel1.Location = new System.Drawing.Point(5, panel.Controls.Count * 75);
                        panel1.Name = "panel1";
                        panel1.Size = new System.Drawing.Size(459, 70);
                        panel1.TabIndex = 0;
                        panel.Controls.Add(panel1);

                        nameLabel.AutoSize = true;
                        nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                        Location = new System.Drawing.Point(16, 15);
                        nameLabel.Name = "nameLabel";
                        nameLabel.Size = new System.Drawing.Size(61, 17);
                        nameLabel.TabIndex = 0;
                        nameLabel.Text = file.getName();
                        panel1.Controls.Add(nameLabel);

                        progressBar.Location = new System.Drawing.Point(2, 25);
                        progressBar.Name = "progressBar";
                        progressBar.Size = new System.Drawing.Size(240, 33);
                        progressBar.TabIndex = 1;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = file.getNumberOfPages(file.getFileName());
                        panel1.Controls.Add(progressBar);


                        processLabel.AutoSize = true;
                        processLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
                        processLabel.Location = new System.Drawing.Point(245, 35);
                        processLabel.Size = new System.Drawing.Size(35, 13);
                        processLabel.TabIndex = 0;
                        panel1.Controls.Add(processLabel);

                        CheckBox checkBox = new CheckBox();
                        checkBox.AutoSize = true;
                        checkBox.Location = new System.Drawing.Point(245,36);
                        checkBox.Name = "checkBox2";
                        checkBox.Size = new System.Drawing.Size(80, 17);
                        checkBox.TabIndex = 1;
                        checkBox.UseVisualStyleBackColor = true;
                        checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);



                        /* progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                         progressBar.ForeColor = Color.AliceBlue;
                         progressBar.BackColor = Color.AliceBlue;*/

                        int i = 0;
                        for ( i=0; i < file.getNumberOfPages(file.getFileName()) + 1; i++)
                        {
                            Thread.Sleep(5);
                            progressBar.Value = i;
                            progressBar.Update();

                            //     label1.Text = "" + progressBar.Value; // prikaze samo progresBar.Maximum, na kraju, kad se fajl ucita
                            if (i== file.getNumberOfPages(file.getFileName()))
                            {
                                checkBox.Checked = true;
                                panel1.Controls.Add(checkBox);
                            }

                        }




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