using System.Collections.Generic;
using System.Linq;
using MyGenomics.Common.enums;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using System.Data.Entity;
using Datamodel = MyGenomics.DataModel;
using Domainmodel = MyGenomics.DomainModel;

namespace MyGenomics.Services
{
    public class QuestionnairesService
    {
        public Domainmodel.Questionnaire Get(int id)
        {
            Datamodel.Questionnaire questionnaireDataModel;
            var retQuestionnaire = new Domainmodel.Questionnaire();

            using (var context = new MyGenomicsContext())
            {
                questionnaireDataModel = context.Questionnaires
                    .Include(i => i.Questions.Select(a=>a.Anwers))
                    .Include(i => i.Questions.Select(a => a.Category))
                    .Include(i => i.Questions.Select(q => q.Anwers.Select(a => a.AnswerWeight)))                    
                    .FirstOrDefault(q=>q.Id==id);

                questionnaireDataModel.Questions = questionnaireDataModel.Questions.OrderBy(q => q.StepNumber).ToList();                
            }

            retQuestionnaire.Id = questionnaireDataModel.Id;
            retQuestionnaire.QuestionsCategories = new List<Domainmodel.QuestionCategory>();

            foreach (var category in questionnaireDataModel.Questions.GroupBy(c=>c.CategoryId))
            {
                retQuestionnaire.QuestionsCategories.Add(new Domainmodel.QuestionCategory()
                {
                    Name = category.Max(n=>n.Category.Name),
                    Questions = questionnaireDataModel.Questions
                    .Where(q => q.CategoryId == category.Key)
                    .Select(q => new Domainmodel.Question()
                        {
                            Id = q.Id,
                            Text = q.Text,
                            IsRequired = q.IsRequired,
                            Anwers = q.Anwers.Select(a => new Domainmodel.Answer()
                            {
                                Id = a.Id,
                                Text = a.Text,
                                AdditionalInfoType = a.AdditionalInfoType,
                                HasAdditionalInfo = a.HasAdditionalInfo,    
                                MinValueNumericAdditionalInfo = a.AnswerWeight.Any() ? a.AnswerWeight.Min(w => w.FromNumericAdditionalInfo) : (int?) null,
                                MaxValueNumericAdditionalInfo = a.AnswerWeight.Any() ? a.AnswerWeight.Max(w => w.ToNumericAdditionalInfo) : (int?)null
                            }).ToList()
                        }).ToList()
                });
            }
            return retQuestionnaire;
        }

        public List<Domainmodel.Questionnaire> GetAll()
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Questionnaires
                    .Select(q=> new Domainmodel.Questionnaire()
                                {
                                    Id = q.Id,
                                    Name = q.Name
                                })
                    .ToList();
            }
        }

        public Answer GetAnswerAndWeightsByAnswerId(int answerId, int personTypeId)
        {
            using (var context = new MyGenomicsContext())
            {
                var answer = context.Answers
                    .FirstOrDefault(a => a.Id == answerId);

                answer.AnswerWeight = context.AnswerWeights
                    .Where(aw => aw.AnswerId == answerId && aw.PersonTypeId == personTypeId)
                    .ToList();

                return answer;
            }
        }
        public List<ProductCategory> GetProductCategories()
        {
            using (var context = new MyGenomicsContext())
            {
                return context.ProductCategories.ToList();                    
            }
        }



    }
}
