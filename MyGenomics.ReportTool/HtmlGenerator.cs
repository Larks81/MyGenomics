using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace MyGenomics.ReportTool
{
    public class HtmlGenerator
    {
        public HtmlGenerator()
        {
            
        }

        public string GenerateHtml<T>(T model, string template)
        {
            string result="";
            var config = new TemplateServiceConfiguration();            
            config.BaseTemplateType = typeof(HtmlSupportTemplateBase<>);
            using (var service = RazorEngineService.Create(config))
            {
                result = service.RunCompile(template, "htmlTemplate", null, model);                
            }
            return result;
        }

    }


    public class MyHtmlHelper
    {
        public IEncodedString Raw(string rawString)
        {
            return new RawString(rawString);
        }
    }

    public abstract class HtmlSupportTemplateBase<T> : TemplateBase<T>
    {
        public HtmlSupportTemplateBase()
        {
            Html = new MyHtmlHelper();
        }

        public MyHtmlHelper Html { get; set; }
    }
}
