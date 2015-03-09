using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyGenomics.Data.Services;
using MyGenomics.Model;

namespace MyGenomics.Controllers
{
    public class PersonQuestionnairesController : ApiController
    {
        private readonly PersonQuestionnairesService _personQuestionnairesService = new PersonQuestionnairesService();

        // GET api/personquestionnaires
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/personquestionnaires/5
        public PersonQuestionnaire Get(int id)
        {
            return _personQuestionnairesService.Get(id);
        }

        // POST api/personquestionnaires
        public PersonQuestionnaire Post([FromBody]PersonQuestionnaire value)
        {
            value.CreatedDate = DateTime.Now;            
            _personQuestionnairesService.Insert(value);

            Task.Factory.StartNew(() =>
                                  {
                                      //Send mail with result
                                      var mailTemplatePath = System.Configuration.ConfigurationManager.AppSettings.Get("mailTemplatePath");
                                      var mailSubject = System.Configuration.ConfigurationManager.AppSettings.Get("mailSubject");
                                      var mailTemplate = File.OpenText(System.Web.Hosting.HostingEnvironment.MapPath(mailTemplatePath)).ReadToEnd();
                                      var p = _personQuestionnairesService.Get(value.Id);
                                      var htmlMail = mailTemplate.Replace("<%content%>",
                                          _personQuestionnairesService.GetHtmlResultOfPersonQuestionnaire(p));

                                      OnlineServices.MailService.SendMail(value.Person.Email, mailSubject, htmlMail); 
                                  });            

            return value;
        }

        // PUT api/personquestionnaires/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/personquestionnaires/5
        public void Delete(int id)
        {
        }
    }
}
