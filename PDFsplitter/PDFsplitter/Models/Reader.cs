using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PDFsplitter.Models
{
    class Reader
    {
        SplitAndSave splitSave = new SplitAndSave(); 

        public void readFile(List<pdfFile> pdfFiles, List<BackgroundWorker> backgroundWorkersList, List<PDFViewItem> viewItems, int selectedFile,string outputPath)
        {
            string pdfFilePath = pdfFiles.ElementAt(selectedFile).getFileName();
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
                MatchCollection mc = rg.Matches(text.ToString());

                if (mc.Count != 0)
                    setPatternAsFileNameAndSaveFile(outputPath, pdfFilePath, interval, pageNumber, mc);
                else
                    addNumberOfPageOnFileNameAndSaveFile(outputPath, pdfFilePath, interval, pageNameSuffix, pdfFileName, pageNumber);

                changeProgressBarValue(pdfFiles, backgroundWorkersList, viewItems, selectedFile, reader, pageNumber);
            }
        }

        private static void changeProgressBarValue(List<pdfFile> pdfFiles, List<BackgroundWorker> backgroundWorkersList, List<PDFViewItem> viewItems, int selectedFile, PdfReader reader, int pageNumber)
        {
            int percent = pageNumber * 100;
            double value = percent / reader.NumberOfPages;
            int reportValue = Convert.ToInt32(value);
            backgroundWorkersList[selectedFile].ReportProgress(reportValue);
            viewItems[selectedFile].progressValue(pageNumber, reader.NumberOfPages, pdfFiles.ElementAt(selectedFile).getName());
        }

        private void addNumberOfPageOnFileNameAndSaveFile(string outputPath, string pdfFilePath, int interval, int pageNameSuffix, string pdfFileName, int pageNumber)
        {
            string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
            splitSave.splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
        }

        private void setPatternAsFileNameAndSaveFile(string outputPath, string pdfFilePath, int interval, int pageNumber, MatchCollection mc)
        {
            for (int count = 0; count < mc.Count - mc.Count + 1; count++)
            {
                string newPdfFileName = string.Format(Regex.Replace(mc[count].Value, @"\s+", " "));
                splitSave.splitAndSave(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
            }
        }
    }
}
