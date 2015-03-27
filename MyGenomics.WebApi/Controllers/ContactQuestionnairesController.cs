using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services;

namespace MyGenomics.Controllers
{
    public class ContactQuestionnairesController : ApiController
    {
        private readonly ContactQuestionnairesService _contactQuestionnairesService = new ContactQuestionnairesService();
        
        public ContactQuestionnaire Get(int id)
        {
            return _contactQuestionnairesService.Get(id);
        }
        
        public object Post([FromBody]SubmitContactQuestionnaire value)
        {                        
            var idInserted = _contactQuestionnairesService.Insert(value);

            Task.Factory.StartNew(() =>
            {
                //Send mail with result
                var mailTemplatePath = System.Configuration.ConfigurationManager.AppSettings.Get("mailTemplatePath");
                var mailSubject = System.Configuration.ConfigurationManager.AppSettings.Get("mailSubject");
                var mailTemplate = File.OpenText(System.Web.Hosting.HostingEnvironment.MapPath(mailTemplatePath)).ReadToEnd();
                var p = _contactQuestionnairesService.Get(idInserted);
                var htmlMail = mailTemplate.Replace("<%content%>",
                    _contactQuestionnairesService.GetHtmlResultOfContactQuestionnaire(p));

                OnlineServices.MailService.SendMail(value.Contact.Email, mailSubject, htmlMail);
            });            

            return new { idInserted };
        }
        
    }
}
