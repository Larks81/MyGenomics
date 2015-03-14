using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MyGenomics.Common.enums;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using System.Data.Entity;
using MyGenomics.DomainModel;

namespace MyGenomics.Services
{
    public class PersonQuestionnairesService
    {
        private readonly PersonsService _personService = new PersonsService();
        private readonly QuestionnairesService _questionnairesService = new QuestionnairesService();
        public DomainModel.PersonQuestionnaire Get(int id)
        {
            DataModel.PersonQuestionnaire personQuestionnaire;
            var retPersonQuestionnaire = new DomainModel.PersonQuestionnaire();
            using (var context = new MyGenomicsContext())
            {
                personQuestionnaire = context.PersonQuestionnaires                    
                    .Include(i => i.Questionnaire)
                    .Include(i => i.Questionnaire.Questions.Select(q=>q.Anwers))
                    .Include(i => i.Answers)
                    .Include(i => i.Results.Select(r=>r.ProductCategory))
                    .Include(i => i.Person.PersonType)
                    .FirstOrDefault(q=>q.Id==id);                
            }
            if (personQuestionnaire != null)
            {                
                retPersonQuestionnaire = Mapper.Map<DataModel.PersonQuestionnaire, DomainModel.PersonQuestionnaire>(personQuestionnaire);                
            }
            
            return retPersonQuestionnaire;
        }

        public int Insert(SubmitPersonQuestionnaire personQuestionnaire)
        {
            var personQuestionnaireToInsert = new DataModel.PersonQuestionnaire();
            var personTypeId=0;

            if (personQuestionnaire.PersonId > 0)
            {
                personTypeId = _personService.Get(personQuestionnaire.PersonId).PersonTypeId;
            }
            else
            {
                var personType = _personService.GetPersonTypeByPerson(personQuestionnaire.Person);
                if (personType != null)
                {
                    personQuestionnaire.Person.PersonTypeId = personType.Id;
                    personTypeId = personType.Id;
                }
            }

            personQuestionnaireToInsert = Mapper.Map<DomainModel.SubmitPersonQuestionnaire, DataModel.PersonQuestionnaire>(personQuestionnaire);
            personQuestionnaireToInsert.CreatedDate = DateTime.Now;
            personQuestionnaireToInsert.Results = CalculateQuestionnaireResult(personQuestionnaireToInsert, personTypeId);

            using (var context = new MyGenomicsContext())
            {
                context.PersonQuestionnaires.Add(personQuestionnaireToInsert);
                context.SaveChanges();
                return personQuestionnaireToInsert.Id;
            }            
        }

        private List<DataModel.QuestionnaireResult> CalculateQuestionnaireResult(DataModel.PersonQuestionnaire personQuestionnaire, int personTypeId)
        {
            var questionnaireResult = new List<DataModel.QuestionnaireResult>();            
            var productcategories = _questionnairesService.GetProductCategories();

            foreach (var productcategory in productcategories)
            {
                questionnaireResult.Add(
                    new DataModel.QuestionnaireResult()
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
                .Where(q => q.NumberOfAnswer > 0)
                .ToList()
                .ForEach(q => q.Result = q.Result / q.NumberOfAnswer);

            return questionnaireResult;
            
        }

        public string GetHtmlResultOfPersonQuestionnaire(DomainModel.PersonQuestionnaire personQuestionnaire)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("<h3>Grazie " + personQuestionnaire.Person.FirstName + "</h3>");
            strBuilder.AppendLine("<p>Queste sono le risposte che hai dato</p>");
            strBuilder.AppendLine("<ul>");

            foreach (var answer in personQuestionnaire.Answers)
            {
                strBuilder.AppendLine("<li>" + answer.QuestionText + " <b>" + answer.AnswerText + "</b> " + answer.AdditionalInfo + "</li>");
            }

            strBuilder.AppendLine("</ul><br/>");
            strBuilder.AppendLine("<p>Questi sono i risultati:</p>");
            strBuilder.AppendLine("<ul>");

            foreach (var result in personQuestionnaire.Results)
            {
                if (result.Result <= 3)
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductCategoryName + ":</b> Non necessario</li>");
                }
                else if (result.Result > 3 && result.Result <= 6)
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductCategoryName + ":</b> Consigliato</li>");
                }
                else
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductCategoryName + ":</b> Altamente Consigliato</li>");
                }
            }

            strBuilder.AppendLine("</ul><br/>");

            return strBuilder.ToString();            
        }

    }
}
