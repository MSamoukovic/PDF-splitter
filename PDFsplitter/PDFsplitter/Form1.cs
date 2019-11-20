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
using System.Windows.Forms;



namespace PDFsplitter
{
    public partial class Form1 : Form
    {
        private List<pdfFile> pdfFiles = new List<pdfFile> { };
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
                    //Multiselect=true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {                   
                        foreach (string item in openFileDialog1.FileNames)
                        {
                            pdfFile file = new pdfFile(item);
                            pdfFiles.Add(file);

                        Panel panel1 = new Panel
                        {
                            BackColor = System.Drawing.Color.Gainsboro,
                            Location = new System.Drawing.Point(0, panel.Controls.Count * 70),
                            Name = "panel1",
                            TabIndex = 0,                       
                            Size = new System.Drawing.Size(725, 65)

                            };
                            Label nameLabel = new Label
                            {
                                AutoSize = true,
                                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
                                Location = new System.Drawing.Point(125, 15),
                                Size = new System.Drawing.Size(61, 17),
                                TabIndex = 0,
                                Text = file.getName()
                            };
                            BunifuProgressBar progressBar = new BunifuProgressBar
                            {
                                BackColor = System.Drawing.Color.Silver,
                                BorderRadius = 5,
                                Location = new System.Drawing.Point(125, 38),
                                MaximumValue = file.getNumberOfPages(file.getFileName()),
                                Name = "bunifuProgressBar1",
                                ProgressColor = System.Drawing.Color.MediumAquamarine,
                                Size = new System.Drawing.Size(330, 7),
                                TabIndex = 3
                            };
                            BunifuCheckbox bunifuCheckbox1 = new BunifuCheckbox
                            {
                                BackColor = System.Drawing.Color.Silver,
                                ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140))))),
                                Checked = true,
                                CheckedOnColor = System.Drawing.Color.Gainsboro,
                                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(5))),
                                ForeColor = System.Drawing.Color.MediumAquamarine,
                                Location = new System.Drawing.Point(470, 30),
                                Margin = new System.Windows.Forms.Padding(0, 0, 0, 0),
                                Name = "bunifuCheckbox1",
                                Size = new System.Drawing.Size(20, 20),
                                TabIndex = 0,
                                Enabled = false

                            };
                            Label processLabel = new Label
                            {
                                AutoSize = true,
                                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
                                Location = new System.Drawing.Point(510, 30),
                                Name = "nameLabel",
                                Size = new System.Drawing.Size(61, 50),
                                TabIndex = 0

                            };

                            if (file.getNumberOfPages(file.getFileName()) == 1)
                            {
                                processLabel.Text = file.getNumberOfPages(file.getFileName()).ToString() + " page";
                            }
                            else
                            {
                                processLabel.Text = file.getNumberOfPages(file.getFileName()).ToString() + " pages";
                            }


                        panel1.Controls.Add(nameLabel);
                        panel.Controls.Add(panel1);


                            panel1.Controls.Add(progressBar);




                            int i = 1;
                            for (i = 1; i < file.getNumberOfPages(file.getFileName()) + 1; i++)
                            {                               
                                progressBar.Value = i; 
                                progressBar.Update();

                            if (progressBar.Value == progressBar.MaximumValue)
                                {
                                    panel1.Controls.Add(bunifuCheckbox1);
                                    bunifuCheckbox1.Checked = true;
                                    panel1.Controls.Add(processLabel);
                                }
                            }
                     
                    }
                }
                //  renderList();
                for (int i = 0; i < pdfFiles.Count; i++)
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
                        if (mc.Count!= 0)
                        {
                            for (int count = 0; count < mc.Count- mc.Count+1; count++)
                            {                           
                                string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix + " " + mc[count].Value);
                                splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);                                                            
                            }
                        }
                        else
                        {
                            string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                            splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                        }                      
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
                pathTextBox.ForeColor = Color.Black;
                pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
        }

        private void button1_DragDrop_1(object sender, DragEventArgs e)
        {
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
                    pdfFile file = new pdfFile(item);
                    pdfFiles.Add(file);

                    Panel panel1 = new Panel
                    {
                        BackColor = System.Drawing.Color.Gainsboro,
                        Location = new System.Drawing.Point(0, panel.Controls.Count * 70),
                        Name = "panel1",
                        TabIndex = 0,
                        Size = new System.Drawing.Size(725, 65)

                    };
                    Label nameLabel = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
                        Location = new System.Drawing.Point(125, 15),
                        Size = new System.Drawing.Size(61, 17),
                        TabIndex = 0,
                        Text = file.getName()
                    };
                    BunifuProgressBar progressBar = new BunifuProgressBar
                    {
                        BackColor = System.Drawing.Color.Silver,
                        BorderRadius = 5,
                        Location = new System.Drawing.Point(125, 38),
                        MaximumValue = file.getNumberOfPages(file.getFileName()),
                        Name = "bunifuProgressBar1",
                        ProgressColor = System.Drawing.Color.MediumAquamarine,
                        Size = new System.Drawing.Size(330, 7),
                        TabIndex = 3
                    };
                    BunifuCheckbox bunifuCheckbox1 = new BunifuCheckbox
                    {
                        BackColor = System.Drawing.Color.Silver,
                        ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140))))),
                        Checked = true,
                        CheckedOnColor = System.Drawing.Color.Gainsboro,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(5))),
                        ForeColor = System.Drawing.Color.MediumAquamarine,
                        Location = new System.Drawing.Point(470, 30),
                        Margin = new System.Windows.Forms.Padding(0, 0, 0, 0),
                        Name = "bunifuCheckbox1",
                        Size = new System.Drawing.Size(20, 20),
                        TabIndex = 0,
                        Enabled = false

                    };
                    Label processLabel = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
                        Location = new System.Drawing.Point(510, 30),
                        Name = "nameLabel",
                        Size = new System.Drawing.Size(61, 50),
                        TabIndex = 0

                    };

                    if (file.getNumberOfPages(file.getFileName()) == 1)
                    {
                        processLabel.Text = file.getNumberOfPages(file.getFileName()).ToString() + " page";
                    }
                    else
                    {
                        processLabel.Text = file.getNumberOfPages(file.getFileName()).ToString() + " pages";
                    }

                    panel1.Controls.Add(nameLabel);



                    panel.Controls.Add(panel1);
                    panel1.Controls.Add(progressBar);

                    int i = 1;
                    for (i = 1; i < file.getNumberOfPages(file.getFileName()) + 1; i++)
                    {
                        progressBar.Value = i;
                        progressBar.Update();

                        if (progressBar.Value == progressBar.MaximumValue)
                        {
                            panel1.Controls.Add(bunifuCheckbox1);
                            bunifuCheckbox1.Checked = true;
                            panel1.Controls.Add(processLabel);
                        }

                    }
                }
                //  renderList();
                for (int i = 0; i < pdfFiles.Count; i++)
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
                                string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix + " " + mc[count].Value);
                                splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                            }
                        }
                        else
                        {
                            string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                            splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
                        }
                    }
                }
            }

            }

        private void button1_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

       
    }
}