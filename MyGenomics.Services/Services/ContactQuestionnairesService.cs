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
using SugarCRM = MyGenomics.Data.SugarCRM;
using System.Threading.Tasks;

namespace MyGenomics.Services
{
    public class ContactQuestionnairesService
    {
        private readonly ContactService _contactService = new ContactService();
        private readonly QuestionnairesService _questionnairesService = new QuestionnairesService();
        public DomainModel.ContactQuestionnaire Get(int id)
        {
            DataModel.ContactQuestionnaire contactQuestionnaire;
            var retContactQuestionnaire = new DomainModel.ContactQuestionnaire();
            using (var context = new MyGenomicsContext())
            {
                contactQuestionnaire = context.ContactQuestionnaires
                    .Include(i => i.Questionnaire)
                    .Include(i => i.Questionnaire.Questions.Select(q => q.Anwers))
                    .Include(i => i.Answers)
                    .Include(i => i.Results.Select(r => r.Product))
                    .Include(i => i.Contact.ContactType)
                    .FirstOrDefault(q => q.Id == id);
            }
            if (contactQuestionnaire != null)
            {
                retContactQuestionnaire = Mapper.Map<DataModel.ContactQuestionnaire, DomainModel.ContactQuestionnaire>(contactQuestionnaire);
            }

            return retContactQuestionnaire;
        }

        public int Insert(SubmitContactQuestionnaire contactQuestionnaire)
        {
            var contactQuestionnaireToInsert = new DataModel.ContactQuestionnaire();
            var contactTypeId = 0;
            var password = "";

            ContactService contactService = new ContactService();

            //Prelevo la password che perderei nel caso abbia a che fare con 
            //un utente registrato, così da poterla reimpostare
            if (contactQuestionnaire.ContactId > 0)
            {
                using (var context = new MyGenomicsContext())
                {
                    password = context.Contacts.FirstOrDefault(p => p.Id == contactQuestionnaire.Contact.Id).Password;
                }
            }

            //Calcolo il contactTypeId
            var contactType = _contactService.GetContactTypeByContact(contactQuestionnaire.Contact);
            if (contactType != null)
            {
                contactQuestionnaire.Contact.ContactTypeId = contactType.Id;
                contactTypeId = contactType.Id;
            }

            //Rimappo in DataModel
            contactQuestionnaireToInsert = Mapper.Map<DomainModel.SubmitContactQuestionnaire, DataModel.ContactQuestionnaire>(contactQuestionnaire);
            contactQuestionnaireToInsert.CreatedDate = DateTime.Now;
            contactQuestionnaireToInsert.Results = CalculateQuestionnaireResult(contactQuestionnaireToInsert, contactTypeId);


            using (var context = new MyGenomicsContext())
            {
                //Se gia presente aggiorno la contacta
                //altrimenti verra inserita nuova
                if (contactQuestionnaireToInsert.ContactId > 0 &&
                    contactQuestionnaireToInsert.Contact.Id == contactQuestionnaireToInsert.ContactId)
                {
                    Task t = new Task(() =>
                        { contactService.UpdateCrmContact(contactQuestionnaire.Contact); });

                    t.Start();


                    contactQuestionnaireToInsert.Contact.Password = password;
                    context.Entry(contactQuestionnaireToInsert.Contact).State = EntityState.Modified;
                    contactQuestionnaireToInsert.Contact = null;
                }

                context.ContactQuestionnaires.Add(contactQuestionnaireToInsert);
                context.SaveChanges();

                Task t1 = new Task(() =>
                    { SetResultInCrm(contactQuestionnaire.Contact, contactQuestionnaireToInsert.Results); });

                t1.Start();

                return contactQuestionnaireToInsert.Id;
            }
        }

        private List<DataModel.QuestionnaireResult> CalculateQuestionnaireResult(DataModel.ContactQuestionnaire contactQuestionnaire, int contactTypeId)
        {
            var questionnaireResult = new List<DataModel.QuestionnaireResult>();
            var products = _questionnairesService.GetProducts();

            foreach (var product in products)
            {
                questionnaireResult.Add(
                    new DataModel.QuestionnaireResult()
                    {
                        ProductId = product.Id,
                        Result = 0
                    }
                );
            }


            var questions = new List<DataModel.Question>();

            foreach (var contactAnswer in contactQuestionnaire.Answers)
            {
                var answer = _questionnairesService.GetAnswerAndWeightsByAnswerId(contactAnswer.AnswerId, contactTypeId);
                var possibleAnswers = _questionnairesService.GetAnswersAndWeightsByQuestionId(answer.QuestionId, contactTypeId);

                //Type of answer -> numeric
                if (answer.HasAdditionalInfo && answer.AdditionalInfoType == AdditionalInfoType.Numeric && !string.IsNullOrEmpty(contactAnswer.AdditionalInfo))
                {
                    double valueOfNumericAnswer = Convert.ToDouble(contactAnswer.AdditionalInfo);

                    foreach (var answerWeightsForCategory in answer.AnswerWeight.GroupBy(aw => aw.ProductId))
                    {
                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                            .ContactTotal += answerWeightsForCategory
                            .Where(awc => valueOfNumericAnswer >= awc.FromNumericAdditionalInfo && valueOfNumericAnswer <= awc.ToNumericAdditionalInfo)
                            .Sum(aw => aw.Value) - 1;

                        // Get the worse possible answer
                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                            .WorseCaseTotal += possibleAnswers
                            .Select(a => a.AnswerWeight.Where(w => w.ProductId == answerWeightsForCategory.Key).Max(w => w.Value)).Max() - 1;

                        questionnaireResult
                            .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                            .NumberOfAnswer++;
                    }
                }
                //Text or Boolean answer
                else
                {
                    if (answer.Question.QuestionType == QuestionType.MultipleExclusive)
                    {
                        foreach (var answerWeightsForCategory in answer.AnswerWeight.GroupBy(aw => aw.ProductId))
                        {
                            questionnaireResult
                                .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                .ContactTotal += answerWeightsForCategory.Sum(aw => aw.Value) - 1;

                            // Get the worst possible answer
                            questionnaireResult
                                .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                .WorseCaseTotal += possibleAnswers
                                .Select(a => a.AnswerWeight.Where(w => w.ProductId == answerWeightsForCategory.Key).Max(w => w.Value)).Max() - 1;

                            questionnaireResult
                                .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                .NumberOfAnswer++;
                        }
                    }
                    else if (answer.Question.QuestionType == QuestionType.MultipleNotExclusive)
                    {
                        foreach (var answerWeightsForCategory in answer.AnswerWeight.GroupBy(aw => aw.ProductId))
                        {
                            questionnaireResult
                                .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                .ContactTotal += answerWeightsForCategory.Sum(aw => aw.Value) - 1;


                            if (!questions.Any(q => q.Id == answer.QuestionId))
                            {
                                // Get the worst possible answers for the specific question
                                questionnaireResult
                                    .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                    .WorseCaseTotal += possibleAnswers
                                    .Sum(a => a.AnswerWeight.Where(w => w.ProductId == answerWeightsForCategory.Key).Max(w => w.Value) - 1);

                                questions.Add(answer.Question);
                            }

                            questionnaireResult
                                .FirstOrDefault(qr => qr.ProductId == answerWeightsForCategory.Key)
                                .NumberOfAnswer++;
                        }
                    }
                }
            }

            questionnaireResult = questionnaireResult
                .Where(q => q.NumberOfAnswer > 0)
                .ToList();



            foreach (var item in questionnaireResult)
            {
                double tmpRes = ((double)item.ContactTotal / (double)item.WorseCaseTotal) * 8 + 1;
                if (tmpRes <= 2)
                    item.Result = 1;
                else if (tmpRes <= 5)
                    item.Result = 2;
                else
                    item.Result = 3;
            }

            return questionnaireResult;

        }

        public string GetHtmlResultOfContactQuestionnaire(DomainModel.ContactQuestionnaire contactQuestionnaire)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("<h3>Grazie " + contactQuestionnaire.Contact.FirstName + "</h3>");
            strBuilder.AppendLine("<p>Queste sono le risposte che hai dato</p>");
            strBuilder.AppendLine("<ul>");

            foreach (var answer in contactQuestionnaire.Answers)
            {
                strBuilder.AppendLine("<li>" + answer.QuestionText + " <b>" + answer.AnswerText + "</b> " + answer.AdditionalInfo + "</li>");
            }

            strBuilder.AppendLine("</ul><br/>");
            strBuilder.AppendLine("<p>Questi sono i risultati:</p>");
            strBuilder.AppendLine("<ul>");

            foreach (var result in contactQuestionnaire.Results)
            {
                if (result.Result <= 3)
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductName + ":</b> Non necessario</li>");
                }
                else if (result.Result > 3 && result.Result <= 6)
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductName + ":</b> Consigliato</li>");
                }
                else
                {
                    strBuilder.AppendLine("<li><b>" + result.ProductName + ":</b> Altamente Consigliato</li>");
                }
            }

            strBuilder.AppendLine("</ul><br/>");

            return strBuilder.ToString();
        }

        public void SetResultInCrm(DomainModel.Contact contact, List<DomainModel.QuestionnaireResult> result)
        {
            SetResultInCrm(contact, result.Select(r => Mapper.Map<DomainModel.QuestionnaireResult, DataModel.QuestionnaireResult>(r)).ToList());
        }

        private void SetResultInCrm(DomainModel.Contact contact, List<DataModel.QuestionnaireResult> result)
        {
            SugarCRM.Client sugarClient = new SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();
            List<DataModel.Product> products = new List<DataModel.Product>();
            using (var context = new MyGenomicsContext())
            {
                products = context.Products.ToList()
                    .Where(p => result.Where(r => r.Result > 1).Select(r => r.ProductId).Contains(p.Id)).ToList();
            }

            sugarClient.SetQuestionnaireResult(Mapper.Map<DomainModel.Contact, DataModel.Contact>(contact), products, sugarSession);
        }

    }
}
