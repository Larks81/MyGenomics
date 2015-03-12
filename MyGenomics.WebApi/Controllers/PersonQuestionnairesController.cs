using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services;

namespace MyGenomics.Controllers
{
    public class PersonQuestionnairesController : ApiController
    {
        private readonly PersonQuestionnairesService _personQuestionnairesService = new PersonQuestionnairesService();
        
        public PersonQuestionnaire Get(int id)
        {
            return _personQuestionnairesService.Get(id);
        }
        
        public object Post([FromBody]SubmitPersonQuestionnaire value)
        {                        
            var idInserted = _personQuestionnairesService.Insert(value);

            Task.Factory.StartNew(() =>
            {
                //Send mail with result
                var mailTemplatePath = System.Configuration.ConfigurationManager.AppSettings.Get("mailTemplatePath");
                var mailSubject = System.Configuration.ConfigurationManager.AppSettings.Get("mailSubject");
                var mailTemplate = File.OpenText(System.Web.Hosting.HostingEnvironment.MapPath(mailTemplatePath)).ReadToEnd();
                var p = _personQuestionnairesService.Get(idInserted);
                var htmlMail = mailTemplate.Replace("<%content%>",
                    _personQuestionnairesService.GetHtmlResultOfPersonQuestionnaire(p));

                OnlineServices.MailService.SendMail(value.Person.Email, mailSubject, htmlMail);
            });            

            return new { idInserted };
        }
        
    }
}
