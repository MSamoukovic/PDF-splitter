using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsplitter.Models
{
    class pdfFile
    {
        private string fileName;
        private int numberOfPages;
        private string name;

        public pdfFile(string fileName)
        {
            FileName = fileName;
            NumberOfPages = numberOfPages;
            Name = name;
        }

        public string FileName
        {
            get
            {
                return getFileName();
            }
            set
            {
                fileName = value;
            }
        }
        public int NumberOfPages
        {
            get
            {
                return getNumberOfPages(fileName);
            }
            set
            {
                numberOfPages = value;
            }
        }

        public string Name
        {
            get
            {
                return getName();
            }
            set
            {
                name = value;
            }
        }
        public string getFileName()
        {
            return fileName;
        }

        public int getNumberOfPages(string fileName)
        {

            PdfReader pdfReader = new PdfReader(fileName);
            int numberOfPages = pdfReader.NumberOfPages;
            return numberOfPages;
        }

        public string getName()
        {
            return Path.GetFileName(fileName); ;
        }

        public override string ToString()
        {
            return "Naziv fajla: " + fileName + ",broj stranica: " + NumberOfPages;
        }
    }

}