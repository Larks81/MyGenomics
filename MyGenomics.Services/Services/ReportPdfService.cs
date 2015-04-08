using System.Drawing.Printing;
using System.Text;
using Pechkin;

namespace MyGenomics.Services.Services
{
    public class ReportPdfService
    {
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
        
    }
}
