using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Data.Context;
using MyGenomics.Model;
using System.Data.Entity;

namespace MyGenomics.Data.Services
{
    public class QuestionnairesService
    {
        public Questionnaire Get(int id)
        {
            using (var context = new MyGenomicsContext())
            {
                var result = context.Questionnaires
                    .Include(i=>i.Questions.Select(a=>a.Anwers))
                    .Include(i => i.Questions.Select(a => a.Category))
                    .Include(i => i.Questions.Select(q => q.Anwers.Select(a => a.AnswerWeight)))                    
                    .FirstOrDefault(q=>q.Id==id);

                result.Questions = result.Questions.OrderBy(q => q.StepNumber).ToList();
                return result;
            }
        }

        public List<Questionnaire> GetAll()
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Questionnaires
                    .ToList();
            }
        }
    }
}
