using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Pechkin;

namespace MyGenomics.Services.Services
{
    public class ReportService
    {
        public void HtmlToPdf(string pdfOutputLocation, string html)
        {
            GlobalConfig gc = new GlobalConfig();
            gc.SetMargins(new Margins(50, 50, 50, 50))
              .SetDocumentTitle("Test document")
              .SetPaperSize(PaperKind.A4);
            IPechkin pechkin = new SimplePechkin(gc);

            ObjectConfig oc = new ObjectConfig();
            oc.SetCreateExternalLinks(false);
            oc.SetFallbackEncoding(Encoding.ASCII);
            oc.SetLoadImages(false);
            oc.Footer.SetCenterText("I'm a footer!");
            oc.Footer.SetLeftText("[page]");
            oc.Header.SetCenterText("I'm a header!");

            byte[] result = pechkin.Convert(oc, html);
            System.IO.File.WriteAllBytes(pdfOutputLocation, result);

            //var pdfData = HtmlToXConverter.ConvertToPdf(html);
            //GeneratePdf("", html, pdfOutputLocation,180,277);    
            //var configs = new GlobalConfig();


            //byte[] pdfBuf = new SimplePechkin(configs).Convert(html);
            //var fileStream = new System.IO.FileStream(pdfOutputLocation, FileMode.Create,FileAccess.Write);
            //// Writes a block of bytes to this stream using data from
            //// a byte array.
            //fileStream.Write(pdfBuf, 0, pdfBuf.Length);

            //// close file stream
            //fileStream.Close();

        }

        


        public const string HtmlToPdfExePath = "wkhtmltopdf.exe";

        public static bool GeneratePdf(string commandLocation, string html, string pdfOutputPath, int pageSizeWidth, int pageSizeHeight)
        {
            Process p;
            StreamWriter stdin;
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = Path.Combine(commandLocation, HtmlToPdfExePath);
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);

            // run the conversion utility
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // note: that we tell wkhtmltopdf to be quiet and not run scripts
            psi.Arguments = "-q -n --disable-smart-shrinking -H --default-header " + 
                "--page-width " + pageSizeWidth + 
                "mm --page-height " + pageSizeHeight + "mm" +
                " - -";

            p = Process.Start(psi);

            try
            {
                stdin = p.StandardInput;
                stdin.AutoFlush = true;
                stdin.Write(html);
                stdin.Dispose();
                CopyStreamToFile(p.StandardOutput.BaseStream, pdfOutputPath);
                p.StandardOutput.Close();
                //pdf.Position = 0;
                
                p.WaitForExit(10000);

                return true;
            }
            catch
            {
                return false;

            }
            finally
            {
                p.Dispose();
            }
        }

        public static void CopyStreamToFile(Stream input, string outputPath)
        {
            byte[] buffer = new byte[32768];
            var file = File.Create(outputPath);
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                file.Write(buffer, 0, read);
            }
            file.Close();
        }
    }
}
