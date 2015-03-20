using AutoMapper;
using MyGenomics.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question = MyGenomics.DataModel.Question;

namespace MyGenomics.ServicesOnData
{
    public class QuestionService
    {
        public DomainModel.Question Get(int id)
        {
            Question dataQuestion;
            using (var context = new MyGenomicsContext())
            {
                dataQuestion = context.Questions
                    .FirstOrDefault(p =>
                        p.Id == id);
            }

            if (dataQuestion != null)
            {
                return Mapper.Map<Question, DomainModel.Question>(dataQuestion);
            }
            return null;
        }

        public List<DomainModel.Question> GetAll()
        {
            List<DomainModel.Question> result = new List<DomainModel.Question>();
            using (var context = new MyGenomicsContext())
            {
                context.Questions
                    .ToList()
                    .ForEach(p => result.Add(Mapper.Map<DataModel.Question, DomainModel.Question>(p)));
            }
            return result;
        }

        public List<DomainModel.QuestionCategory> GetAllCategories()
        {
            List<DomainModel.QuestionCategory> result = new List<DomainModel.QuestionCategory>();
            using (var context = new MyGenomicsContext())
            {
                context.QuestionCategories
                    .ToList()
                    .ForEach(p => result.Add(Mapper.Map<DataModel.QuestionCategory, DomainModel.QuestionCategory>(p)));
            }
            return result;
        }

        public List<DomainModel.Question> GetAll(int questionaireId)
        {
            List<DomainModel.Question> result = new List<DomainModel.Question>();
            using (var context = new MyGenomicsContext())
            {
                context.Questions
                    .ToList()
                    .ForEach(p => result.Add(Mapper.Map<DataModel.Question, DomainModel.Question>(p)));
            }
            return result;
        }

        public DomainModel.Question Insert(DomainModel.Question question)
        {
            Question dataQuestion;
            using (var context = new MyGenomicsContext())
            {
                dataQuestion = context.Questions.Add(Mapper.Map<DomainModel.Question, DataModel.Question>(question));
                context.SaveChanges();
            }

            if (dataQuestion != null)
            {
                return Mapper.Map<Question, DomainModel.Question>(dataQuestion);
            }
            return null;
        }
    }
}
