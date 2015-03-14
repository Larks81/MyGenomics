using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using MyGenomics.DomainModel;
using Person = MyGenomics.DataModel.Person;

namespace MyGenomics.Services
{
    public class PersonsService
    {
        public DomainModel.Person GetPersonByLogin(string username, string password)
        {
            Person dataPerson;
            string cryptedPassword = CryptPassword(password);
            using (var context = new MyGenomicsContext())
            {
                dataPerson = context.People
                    .FirstOrDefault(p=>
                        p.UserName.ToUpper()==username.ToUpper() &&
                        p.Password == cryptedPassword);
            }

            if (dataPerson != null)
            {
                return Mapper.Map<DataModel.Person, DomainModel.Person>(dataPerson);
            }
            return null;
        }

        public DomainModel.Person Get(int id)
        {
            Person dataPerson;            
            using (var context = new MyGenomicsContext())
            {
                dataPerson = context.People
                    .FirstOrDefault(p =>
                        p.Id == id);
            }

            if (dataPerson != null)
            {
                return Mapper.Map<DataModel.Person, DomainModel.Person>(dataPerson);
            }
            return null;
        }

        private string CryptPassword(string password)
        {
            return password;
        }

        public DomainModel.PersonType GetPersonTypeByPerson(DomainModel.Person person)
        {
            var retPersonType = new DomainModel.PersonType();
            DataModel.PersonType personType;
            var today = DateTime.Today;
            int personAge = today.Year - person.BirthDate.Year;
            if (person.BirthDate > today.AddYears(-personAge))
            {
                personAge--;
            }

            using (var context = new MyGenomicsContext())
            {
                personType = context.PersonTypes
                    .FirstOrDefault(t => t.AgeFrom <= personAge && t.AgeTo >= personAge && t.Gender == person.Gender);
            }

            if (personType != null)
            {
                retPersonType.Id = personType.Id;
                retPersonType.AgeFrom = personType.AgeFrom;
                retPersonType.AgeTo = personType.AgeTo;
                retPersonType.Gender = personType.Gender;
                retPersonType.Description = personType.Description;
            }

            return retPersonType;
        }
    }
}
