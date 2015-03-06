using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Data.Context;
using MyGenomics.Model;

namespace MyGenomics.Data.Services
{
    public class PersonQuestionnairesService
    {
        public PersonQuestionnaire Get(int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.PersonQuestionnaires.FirstOrDefault(q=>q.Id==id);                
            }
        }

        public int Insert(PersonQuestionnaire personQuestionnaire)
        {
            using (var context = new MyGenomicsContext())
            {
                context.PersonQuestionnaires.Add(personQuestionnaire);
                context.SaveChanges();
                return personQuestionnaire.Id;
            }
        }

    }
}
