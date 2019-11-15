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
using Bunifu.Framework.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFsplitter.Models;


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

            if (pathTextBox.Text=="")
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
                if (openFileDialog1.Multiselect == true)
                {

                    foreach (string item in openFileDialog1.FileNames)
                    {
                        pdfFile file = new pdfFile(item);
                        pdfFiles.Add(file);

                        Panel panel1 = new Panel
                        {
                            BackColor = System.Drawing.Color.Silver,
                            Location = new System.Drawing.Point(0, panel.Controls.Count * 55),
                            Name = "panel1",
                            Size = new System.Drawing.Size(484, 50),
                            TabIndex = 0
                        };                     
                        Label nameLabel = new Label
                        {
                            AutoSize = true,
                            Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F),
                            Location = new System.Drawing.Point(12, 10),
                            Size = new System.Drawing.Size(61, 17),
                            TabIndex = 0,
                            Text = file.getName()
                        };            
                        BunifuProgressBar progressBar = new BunifuProgressBar
                        {
                            BackColor = System.Drawing.Color.Silver,
                            BorderRadius = 5,
                            Location = new System.Drawing.Point(12, 30),
                            MaximumValue = file.getNumberOfPages(file.getFileName()),
                            Name = "bunifuProgressBar1",
                            ProgressColor = System.Drawing.Color.Red,
                            Size = new System.Drawing.Size(290, 7),
                            TabIndex = 3
                    };   
                        BunifuCheckbox bunifuCheckbox1 = new BunifuCheckbox
                        {
                            BackColor = System.Drawing.Color.Silver,
                            ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140))))),
                            Checked = true,
                            CheckedOnColor = System.Drawing.Color.Silver,
                            Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                            ForeColor = System.Drawing.Color.Red,
                            Location = new System.Drawing.Point(320, 20),
                            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4),
                            Name = "bunifuCheckbox1",
                            Size = new System.Drawing.Size(17, 17),
                            TabIndex = 0
                        };

                        Label processLabel = new Label
                        {
                            AutoSize = true,
                            Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F),
                            Location = new System.Drawing.Point(350, 21),
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

                            int i =1;
                        for ( i=1; i < file.getNumberOfPages(file.getFileName()) + 1; i++)
                        {
                            //Thread.Sleep(5);
                          //  processLabel.Text = "" + i; // prikaze samo progresBar.Maximum, na kraju, kad se fajl ucita
                            progressBar.Value = i;

                            progressBar.Update();


                            if (progressBar.Value==progressBar.MaximumValue)
                            {
                                panel1.Controls.Add(bunifuCheckbox1);
                                bunifuCheckbox1.Checked = true;
                                panel1.Controls.Add(processLabel);
                            }
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

                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
                {
                    pageNameSuffix++;
                    string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
                    //Console.WriteLine(newPdfFileName);

                    splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
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
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                pathTextBox.Text = folderName;
                pathTextBox.ForeColor = Color.Black;


                pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);


           //     pathTextBox.Font.FontFamily= "Microsoft Sans Serif";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
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
                        BackColor = System.Drawing.Color.Silver,
                        Location = new System.Drawing.Point(0, panel.Controls.Count * 55),
                        Name = "panel1",
                        Size = new System.Drawing.Size(484, 50),
                        TabIndex = 0
                    };
                    Label nameLabel = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F),
                        Location = new System.Drawing.Point(12, 10),
                        Size = new System.Drawing.Size(61, 17),
                        TabIndex = 0,
                        Text = file.getName()
                    };
                    BunifuProgressBar progressBar = new BunifuProgressBar
                    {
                        BackColor = System.Drawing.Color.Silver,
                        BorderRadius = 5,
                        Location = new System.Drawing.Point(12, 30),
                        MaximumValue = file.getNumberOfPages(file.getFileName()),
                        Name = "bunifuProgressBar1",
                        ProgressColor = System.Drawing.Color.Red,
                        Size = new System.Drawing.Size(290, 7),
                        TabIndex = 3
                    };
                    BunifuCheckbox bunifuCheckbox1 = new BunifuCheckbox
                    {
                        BackColor = System.Drawing.Color.Silver,
                        ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140))))),
                        Checked = true,
                        CheckedOnColor = System.Drawing.Color.Silver,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        ForeColor = System.Drawing.Color.Red,
                        Location = new System.Drawing.Point(320, 20),
                        Margin = new System.Windows.Forms.Padding(4, 4, 4, 4),
                        Name = "bunifuCheckbox1",
                        Size = new System.Drawing.Size(17, 17),
                        TabIndex = 0
                    };

                    Label processLabel = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F),
                        Location = new System.Drawing.Point(350, 21),
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
                        //Thread.Sleep(5);
                        //  processLabel.Text = "" + i; // prikaze samo progresBar.Maximum, na kraju, kad se fajl ucita
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
            


        }           
    }
}