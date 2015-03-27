using System;
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
                            QuestionType = q.QuestionType,
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
                                    Name = q.Name,
                                    Code = q.Code
                                })
                    .ToList();
            }
        }

        public Answer GetAnswerAndWeightsByAnswerId(int answerId, int contactTypeId)
        {
            using (var context = new MyGenomicsContext())
            {
                var answer = context.Answers
                    .FirstOrDefault(a => a.Id == answerId);

                answer.AnswerWeight = context.AnswerWeights
                    .Where(aw => aw.AnswerId == answerId && aw.ContactTypeId == contactTypeId)
                    .ToList();

                // If it's not specified the contactTypeId get the default
                if (answer.AnswerWeight.Count() == 0)
                {
                    answer.AnswerWeight = context.AnswerWeights
                        .Where(aw => aw.AnswerId == answerId && aw.ContactTypeId == null)
                        .ToList();
                }

                answer.Question = context.Questions
                    .FirstOrDefault(q => q.Id == answer.QuestionId);

                return answer;
            }
        }

        public List<Answer> GetAnswersAndWeightsByQuestionId(int questionId, int contactTypeId)
        {
            using (var context = new MyGenomicsContext())
            {
                var answers = context.Answers
                    .Where(a => a.QuestionId == questionId)
                    .ToList();

                foreach (var answer in answers)
                {
                    answer.AnswerWeight = context.AnswerWeights
                        .Where(aw => aw.AnswerId == answer.Id && aw.ContactTypeId == contactTypeId)
                        .ToList();

                    // If it's not specified the contactTypeId get the default
                    if (answer.AnswerWeight.Count() == 0)
                    {
                        answer.AnswerWeight = context.AnswerWeights
                            .Where(aw => aw.AnswerId == answer.Id && aw.ContactTypeId == null)
                            .ToList();
                    }

                    answer.Question = context.Questions
                        .FirstOrDefault(q => q.Id == answer.QuestionId);
                }

                return answers;
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Products.ToList();                    
            }
        }


        public int AddOrUpdateQuestionnaire(Questionnaire questionnaire)
        {
            questionnaire.UpdateDate = DateTime.Now;

            bool idFound = false;
            using (var context = new MyGenomicsContext())
            {
                idFound = context.Questionnaires.FirstOrDefault(qc => qc.Id == questionnaire.Id) != null;
            }

            using (var context = new MyGenomicsContext())
            {
                if (questionnaire.Id > 0 && idFound)
                {
                    context.Entry(questionnaire).State = EntityState.Modified;
                }
                else
                {
                    questionnaire.InsertDate = DateTime.Now;
                    context.Questionnaires.Add(questionnaire);
                }
                
                context.SaveChanges();
                return questionnaire.Id;
            }
        }

        public void RemoveQuestionnaire(int questionnaireId)
        {
            using (var context = new MyGenomicsContext())
            {
                var questionnaire = context.Questionnaires.FirstOrDefault(q => q.Id == questionnaireId);
                if (questionnaire != null)
                {                    
                    context.ContactQuestionnaires.RemoveRange(context.ContactQuestionnaires.Where(pq => pq.QuestionnaireId == questionnaire.Id));
                    context.Questionnaires.Remove(questionnaire);
                    context.SaveChanges();
                }                                
            }
        }

        public int AddOrUpdateQuestionCategory(QuestionCategory questionCategory)
        {
            questionCategory.UpdateDate = DateTime.Now;
            bool idFound=false;
            using (var context = new MyGenomicsContext())
            {
                idFound = context.QuestionCategories.FirstOrDefault(qc => qc.Id == questionCategory.Id) != null;
            }

            using (var context = new MyGenomicsContext())
            {
                if (questionCategory.Id > 0 && idFound)
                {
                    context.Entry(questionCategory).State = EntityState.Modified;
                }
                else
                {
                    questionCategory.InsertDate = DateTime.Now;
                    context.QuestionCategories.Add(questionCategory);    
                }

                context.SaveChanges();
                return questionCategory.Id;
            }            
        }

        public int AddOrUpdateQuestion(Question question)
        {
            question.UpdateDate = DateTime.Now;
            bool idFound = false;
            using (var context = new MyGenomicsContext())
            {
                idFound = context.Questions.FirstOrDefault(q => q.Id == question.Id) != null;
            }

            using (var context = new MyGenomicsContext())
            {
                if (question.Id > 0 && idFound)
                {
                    context.Entry(question).State = EntityState.Modified;
                }
                else
                {
                    question.InsertDate = DateTime.Now;
                    context.Questions.Add(question);
                }
                
                context.SaveChanges();
                return question.Id;
            }     
        }
        public int AddOrUpdateAnswer(Answer answer)
        {
            answer.UpdateDate = DateTime.Now;
            bool idFound = false;
            using (var context = new MyGenomicsContext())
            {
                idFound = context.Answers.FirstOrDefault(a => a.Id == answer.Id) != null;
            }

            using (var context = new MyGenomicsContext())
            {
                if (answer.Id > 0 && idFound)
                {
                    context.Entry(answer).State = EntityState.Modified;
                }
                else
                {
                    answer.InsertDate = DateTime.Now;
                    context.Answers.Add(answer);
                }                
                context.SaveChanges();
                return answer.Id;
            }     
        }

        public int AddOrUpdateAnswerWeight(AnswerWeight answerWeight)
        {
            answerWeight.UpdateDate = DateTime.Now;
            bool idFound = false;
            using (var context = new MyGenomicsContext())
            {
                idFound = context.AnswerWeights.FirstOrDefault(a => a.Id == answerWeight.Id) != null;
            }

            using (var context = new MyGenomicsContext())
            {
                if (answerWeight.Id > 0 && idFound)
                {
                    context.Entry(answerWeight).State = EntityState.Modified;
                }
                else
                {
                    answerWeight.InsertDate = DateTime.Now;
                    context.AnswerWeights.Add(answerWeight);
                }                      
                context.SaveChanges();
                return answerWeight.Id;
            }  
        }


        public void RemoveQuestionnaireItemsBefore(int questionnaireId, DateTime beforedate)
        {            
            using (var context = new MyGenomicsContext())
            {
                context.ContactAnswers.RemoveRange(context.ContactAnswers.Where(pa => pa.Question.QuestionnaireId == questionnaireId && pa.Question.UpdateDate < beforedate));
                context.ContactAnswers.RemoveRange(context.ContactAnswers.Where(pa => pa.Question.QuestionnaireId == questionnaireId && pa.Answer.UpdateDate < beforedate));                
                context.AnswerWeights.RemoveRange(context.AnswerWeights.Where(aw => aw.Answer.Question.QuestionnaireId == questionnaireId && aw.UpdateDate < beforedate));
                context.Answers.RemoveRange(context.Answers.Where(a => a.Question.QuestionnaireId == questionnaireId && a.UpdateDate < beforedate));
                context.Questions.RemoveRange(context.Questions.Where(a => a.QuestionnaireId == questionnaireId && a.UpdateDate < beforedate));
                context.SaveChanges();
            }
        }

    }
}
