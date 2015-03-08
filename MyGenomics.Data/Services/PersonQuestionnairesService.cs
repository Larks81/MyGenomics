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
    public class PersonQuestionnairesService
    {
        private readonly PersonsService _personService = new PersonsService();
        private readonly QuestionnairesService _questionnairesService = new QuestionnairesService();
        public PersonQuestionnaire Get(int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.PersonQuestionnaires
                    //.Include(i => i.Person)
                    .Include(i => i.Questionnaire)
                    .Include(i => i.Questionnaire.Questions.Select(q=>q.Anwers))
                    .Include(i => i.Answers)
                    .Include(i => i.Results.Select(r=>r.ProductCategory))
                    .Include(i => i.Person.PersonType)
                    .FirstOrDefault(q=>q.Id==id);                
            }
        }

        public int Insert(PersonQuestionnaire personQuestionnaire)
        {
            var personType = _personService.GetPersonTypeByPerson(personQuestionnaire.Person);

            if (personType != null)
            {
                personQuestionnaire.Person.PersonTypeId = personType.Id;
            }

            personQuestionnaire.Results = CalculateQuestionnaireResult(personQuestionnaire);

            using (var context = new MyGenomicsContext())
            {
                context.PersonQuestionnaires.Add(personQuestionnaire);
                context.SaveChanges();
                return personQuestionnaire.Id;
            }
        }

        public List<QuestionnaireResult> CalculateQuestionnaireResult(PersonQuestionnaire personQuestionnaire)
        {
            var questionnaireResult = new List<QuestionnaireResult>();            
            int personTypeId = personQuestionnaire.Person.PersonTypeId;
            var productcategories = _questionnairesService.GetProductCategories();

            foreach (var productcategory in productcategories)
            {
                questionnaireResult.Add(                
                    new QuestionnaireResult()
                    {
                        ProductCategoryId = productcategory.Id,
                        Result = 0
                    }
                );
            }            

            foreach (var personAnswer in personQuestionnaire.Answers)
            {
                var answer = _questionnairesService.GetAnswerAndWeightsByAnswerId(personAnswer.AnswerId, personTypeId);                

                //Type of answer -> numeric
                if (answer.HasAdditionalInfo && answer.AdditionalInfoType == AdditionalInfoType.Numeric)
                {
                    double valueOfNumericAnswer = Convert.ToDouble(personAnswer.AdditionalInfo);

                    foreach (var answerWeightsForCategory in answer.AnswerWeight.GroupBy(aw => aw.ProductCategoryId))
                    {
                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductCategoryId == answerWeightsForCategory.Key)
                            .Result += answerWeightsForCategory
                            .Where(awc => valueOfNumericAnswer >= awc.FromNumericAdditionalInfo && valueOfNumericAnswer <= awc.ToNumericAdditionalInfo)
                            .Sum(aw => aw.Value);

                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductCategoryId == answerWeightsForCategory.Key)
                            .NumberOfAnswer++;
                    }
                }
                //Text or Boolean answer
                else
                {
                    foreach (var answerWeightsForCategory in answer.AnswerWeight.GroupBy(aw => aw.ProductCategoryId))
                    {
                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductCategoryId == answerWeightsForCategory.Key)
                            .Result += answerWeightsForCategory.Sum(aw => aw.Value);

                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductCategoryId == answerWeightsForCategory.Key)
                            .NumberOfAnswer++;
                    }
                }                

            }

            questionnaireResult
                .Where(q=>q.NumberOfAnswer>0)
                .ToList()
                .ForEach(q => q.Result = q.Result/q.NumberOfAnswer);
            return questionnaireResult;
        }

    }
}
