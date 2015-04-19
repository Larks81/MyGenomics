﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using AutoMapper;
using MyGenomics.DomainModel;
using MyGenomics.ReportTool;
using Pechkin;

namespace MyGenomics.Services.Services
{
    public class ReportPdfService
    {
        public ReportTemplate GetReportTemplateModel(int languageId, int reportId)
        {
            var _reportService = new ReportService();
            var _reportHeaderService = new ReportHeaderService();

            var reportTemplate = new ReportTemplate();

            //Report
            var reportDetail = _reportService.GetReportDetail(languageId, reportId);
            reportTemplate.ReportDetail = Mapper.Map<DomainModel.ReportDetail, DomainModel.ReportPrintable>(reportDetail);

            //ReportHeader
            var reportHeaderDetail = _reportHeaderService.GetReportHeaderDetail(languageId, reportDetail.ReportHeaderId);
            reportTemplate.ReportDetail.ReportHeaderDetail = Mapper.Map<DomainModel.ReportHeaderDetail, DomainModel.ReportHeaderPrintable>(reportHeaderDetail); 

            //Chapters
            var chaptersToInsert = new List<ChapterPrintable>();
            foreach (var chapter in reportDetail.Chapters)
            {
                var chapterDetail = _reportService.GetChapterDetail(languageId, chapter.Id);
                var currentChapter = Mapper.Map<DomainModel.ChapterDetail, DomainModel.ChapterPrintable>(chapterDetail);

                //Panels
                var panelsToInsert = new List<PanelPrintable>();
                foreach (var panel in chapterDetail.Panels)
                {
                    var panelDetail = _reportService.GetPanelDetail(languageId, panel.Id);
                    var currentPanel = Mapper.Map<DomainModel.PanelDetail, DomainModel.PanelPrintable>(panelDetail);                    
                    currentChapter.PanelsDetail = new List<PanelPrintable>();
                    currentChapter.PanelsDetail.Add(currentPanel);
                }

                chaptersToInsert.Add(currentChapter);
            }            
            
            reportTemplate.ReportDetail.ChaptersDetail = chaptersToInsert;

            return reportTemplate;
        }

        public void HtmlToPdf(string pdfOutputLocation,string tocFilePath, string html)
        {
            var gc = new GlobalConfig();
            gc.SetMargins(new Margins(50, 50, 50, 50))
              .SetDocumentTitle("Test document")
              .SetPaperSize(PaperKind.A4);
            IPechkin pechkin = new SimplePechkin(gc);

            var oc = new ObjectConfig();
            oc.SetCreateExternalLinks(false);
            oc.SetFallbackEncoding(Encoding.ASCII);
            oc.SetLoadImages(false);
            oc.Footer.SetCenterText("I'm a footer!");
            oc.Footer.SetLeftText("[page]");
            oc.Header.SetCenterText("I'm a header!");
            //oc.SetTocXsl(tocFilePath);
            oc.SetCreateToc(true);
            byte[] result = pechkin.Convert(oc, html);
            System.IO.File.WriteAllBytes(pdfOutputLocation, result);            

        }

        public string GenerateHtml<T>(string template,T model)
        {
            var htmlGenerator = new HtmlGenerator();
            return htmlGenerator.GenerateHtml<T>(model, template);
        }


        public void WritePDF(string HTML,string headerPath, string pdfOutputLocation, string tocFilePath)
        {
            string inFileName,
                    outFileName,
                    tempPath;
            Process p;
            System.IO.StreamWriter stdin;
            ProcessStartInfo psi = new ProcessStartInfo();

            tempPath = pdfOutputLocation;            
            //outFileName = Session.SessionID + ".pdf";

            // run the conversion utility
            psi.UseShellExecute = false;
            psi.FileName = "c:\\wkhtmltopdf.exe";
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            

            // note that we tell wkhtmltopdf to be quiet and not run scripts
            // NOTE: I couldn't figure out a way to get both stdin and stdout redirected so we have to write to a file and then clean up afterwards            
            psi.Arguments = string.Format("--header-html \"file:///{1}\" -q toc --xsl-style-sheet {2} -n - {0} ", pdfOutputLocation, headerPath, tocFilePath);

            p = Process.Start(psi);

            try
            {
                StreamWriter utf8Writer = new StreamWriter(p.StandardInput.BaseStream, Encoding.UTF8);
                utf8Writer.AutoFlush = true;

                utf8Writer.Write(HTML);
                utf8Writer.Close();     


                //stdin = p.StandardInput;
                
                //stdin.AutoFlush = true;
                
                //stdin.Write(HTML,Encoding.UTF8);
                //stdin.Close();               
            }
            finally
            {
                p.Close();
                p.Dispose();
            }
            
        }


    }
}
