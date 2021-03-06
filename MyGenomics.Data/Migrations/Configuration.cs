using System.Collections.Generic;
using MyGenomics.Common.enums;
using MyGenomics.DataModel;

namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MyGenomics.Data.Context.MyGenomicsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(MyGenomics.Data.Context.MyGenomicsContext context)
        {

            context.Languages.AddOrUpdate(new Language()
                                          {
                                              Id = 1,
                                              Code = "IT",
                                              InsertDate = DateTime.Now,
                                              UpdateDate = DateTime.Now
                                          });
            

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 1,
                                                Gender = Enums.Male,
                                                AgeFrom = 0,
                                                AgeTo = 12,
                                                Description = "Bambino (1-12)",
                                                Code = "BAMBINO_MASCHIO",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 2,
                                                Gender = Enums.Female,
                                                AgeFrom = 0,
                                                AgeTo = 12,
                                                Description = "Bambina (1-12)",
                                                Code = "BAMBINO_FEMMINA",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 3,
                                                Gender = Enums.Male,
                                                AgeFrom = 13,
                                                AgeTo = 17,
                                                Description = "Adolescente (13-17)",
                                                Code = "ADOLESCENTE_MASCHIO",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 4,
                                                Gender = Enums.Female,
                                                AgeFrom = 13,
                                                AgeTo = 17,
                                                Description = "Adolescente (13-17)",
                                                Code = "ADOLESCENTE_FEMMINA",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 5,
                                                Gender = Enums.Male,
                                                AgeFrom = 18,
                                                AgeTo = 55,
                                                Description = "Adulto (18-55)",
                                                Code = "ADULTO_MASCHIO",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 6,
                                                Gender = Enums.Female,
                                                AgeFrom = 18,
                                                AgeTo = 55,
                                                Description = "Adulta (18-55)",
                                                Code = "ADULTO_FEMMINA",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });


            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 7,
                                                Gender = Enums.Male,
                                                AgeFrom = 56,
                                                AgeTo = 120,
                                                Description = "Uomo anziano (56+)",
                                                Code = "ANZIANO_MASCHIO",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.ContactTypes.AddOrUpdate(new ContactType()
                                            {
                                                Id = 8,
                                                Gender = Enums.Female,
                                                AgeFrom = 56,
                                                AgeTo = 120,
                                                Description = "Donna anziana (56+)",
                                                Code = "ANZIANO_FEMMINA",
                                                InsertDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            });

            context.Packages.AddOrUpdate(new Package()
                                         {
                                             Id = 1,
                                             Name = "Nutrizione e Sport",
                                              InsertDate = DateTime.Now,
                                              UpdateDate = DateTime.Now,
                                             Products = new List<Product>()
                                                        {
                                                            new Product()
                                                            {
                                                                Id = 1,
                                                                Name = "Nutrigenomica",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/nutrigenomica",
                                                                Price = 400,
                                                                ShortDescription = "Nutrigenomica",
                                                                Code = "NUTRIGENOMICA",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 2,
                                                                Name = "Sport Endurance",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/sport-endurance",
                                                                Price = 400,
                                                                ShortDescription =
                                                                    "Marcia, corsa, pattinaggio, ciclismo, sci di fondo ecc",
                                                                Code = "SPORT-ENDURANCE",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 3,
                                                                Name = "Intolleranze e Dipendenze",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/intolleranze-e-dipendenze",
                                                                Price = 350,
                                                                ShortDescription = "Intolleranze e Dipendenze",
                                                                Code = "INTOLLERANZE-DIPENDENZE",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 4,
                                                                Name = "Sport Potenza",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/sport-potenza",
                                                                Price = 400,
                                                                ShortDescription =
                                                                    "sollevamento pesi, salti e lanci dell�atletica legge ecc",
                                                                Code = "SPORT-POTENZA",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 5,
                                                                Name = "Sport Situazione",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/sport-situazione",
                                                                Price = 400,
                                                                ShortDescription =
                                                                    "Calcio, pallacanestro, pallavolo, pallamano, tennis ecc",
                                                                Code = "SPORT-SITUAZIONE",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            }
                                                        }
                                         });

            context.Packages.AddOrUpdate(new Package()
                                         {
                                             Id = 2,
                                             Name = "Medicina Contactalizzata",
                                             InsertDate = DateTime.Now,
                                             UpdateDate = DateTime.Now,
                                             Products = new List<Product>()
                                                        {
                                                            new Product()
                                                            {
                                                                Id = 6,
                                                                Name = "Metabolismo energetico e osseo",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/metabolismo-energetico-e-osseo",
                                                                Price = 350,
                                                                ShortDescription =
                                                                    "Diabete 2, iperTG, HDL/LDL, osteoporosi",
                                                                Code = "METABOLISMO-ENERGETICO-OSSEO",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 7,
                                                                Name = "Alzheimer",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/alzheimer",
                                                                Price = 500,
                                                                ShortDescription = "ALZHEIMER",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 8,
                                                                Name = "Oncologia: mammella",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/oncologia-mammella",
                                                                Price = 500,
                                                                ShortDescription = "TUMORE-MAMMELLA",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 9,
                                                                Name = "Oncologia: colon-retto",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/oncologia-colon-retto",
                                                                Price = 500,
                                                                ShortDescription = "Tumore a colon-retto",
                                                                Code = "TUMORE-COLON-RETTO",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 10,
                                                                Name = "Oncologia: prostata",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/oncologia-prostata",
                                                                Price = 500,
                                                                ShortDescription = "Tumore alla prostata",
                                                                Code = "TUMORE-PROSTATA",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            },
                                                            new Product()
                                                            {
                                                                Id = 10,
                                                                Name = "Parkinson",
                                                                UrlDetail =
                                                                    "http://www.mygenomics.eu/genotest/parkinson",
                                                                Price = 500,
                                                                ShortDescription = "Parkinson",
                                                                Code = "PARKINSON",
                                                                InsertDate = DateTime.Now,
                                                                UpdateDate = DateTime.Now
                                                            }
                                                        }
                                         });

//            context.Questionnaires.AddOrUpdate(new Questionnaire()
//                                               {
//                                                   Id = 1,
//                                                   Name = "Test",
//                                                   LanguageId = 1,
//                                                   Code = "MYGENOMICS_IT",
//                                                   Questions = new List<Question>()
//                                                   {

//#region Domande sui denti
//                                                        //new Question()
//                                                        //{                                                            
//                                                        //    CategoryId = 1,
//                                                        //    StepNumber = 1,
//                                                        //    Text = "Le sue gengive sanguinano?",
//                                                        //    IsRequired = true,
//                                                        //    Anwers = new List<Answer>()
//                                                        //             {
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "SI",   
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Old Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NO",                                                                             
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Old Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }                                                                                
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "A VOLTE",   
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Old Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }                                                                         
//                                                        //                 }
//                                                        //             }
//                                                        //},
//                                                        //new Question()
//                                                        //{                                                            
//                                                        //    CategoryId = 1,
//                                                        //    StepNumber = 2,
//                                                        //    Text = "I suoi denti si muovono?",
//                                                        //    IsRequired = true,
//                                                        //    Anwers = new List<Answer>()
//                                                        //             {
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "POCO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "MOLTO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 }
//                                                        //             }
//                                                        //},
//                                                        //new Question()
//                                                        //{
//                                                        //    CategoryId = 1,
//                                                        //    StepNumber = 3,
//                                                        //    Text = "Le sue gengive si sono ritirate e i denti sono pi� �lunghi�?",
//                                                        //    IsRequired = true,
//                                                        //    Anwers = new List<Answer>()
//                                                        //             {
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "POCO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "MOLTO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 }
//                                                        //             }
//                                                        //},
//                                                        //new Question()
//                                                        //{
//                                                        //    CategoryId = 1,
//                                                        //    StepNumber = 4,
//                                                        //    Text = "Qualcuno dei suoi parenti ha sofferto di parodontite (piorrea)?",
//                                                        //    IsRequired = true,
//                                                        //    Anwers = new List<Answer>()
//                                                        //             {
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "SI",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NON SO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>()
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    }          
//                                                        //                 }
//                                                        //             }
//                                                        //},
//#endregion


//#region Analisi Generale

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 2,
//                                                            StepNumber = 5,
//                                                            Text = "Soffre di qualche patologia cronica",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.MultipleNotExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text = "DIABETE",                                                                    
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1, // Nutrigenomica
//                                                                            Value = 9
//                                                                        },
//                                                                    }    
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "IPERTENSIONE ARTERIOSA",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 1, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 2, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 3, 
//                                                                            ProductId = 1, 
//                                                                            Value = 3
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 4, 
//                                                                            ProductId = 1, 
//                                                                            Value = 3
//                                                                        },
//                                                                        new AnswerWeight()                                                                     
//                                                                        {
//                                                                            ContactTypeId = 5, 
//                                                                            ProductId = 1, 
//                                                                            Value = 8
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 6, 
//                                                                            ProductId = 1, 
//                                                                            Value = 8
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 7, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 8, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        }
//                                                                    }  
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "ANGINA",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 1, 
//                                                                            ProductId = 1, 
//                                                                            Value = 1
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 2, 
//                                                                            ProductId = 1, 
//                                                                            Value = 1
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 3, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 4, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()                                                                                 
//                                                                        {
//                                                                            ContactTypeId = 5, 
//                                                                            ProductId = 1, 
//                                                                            Value = 7
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 6, 
//                                                                            ProductId = 1, 
//                                                                            Value = 7
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 7, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 8, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        }
//                                                                    }          
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "INFARTO MIOCARDICO",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 1, 
//                                                                            ProductId = 1, 
//                                                                            Value = 1
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 2, 
//                                                                            ProductId = 1, 
//                                                                            Value = 1
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 3, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 4, 
//                                                                            ProductId = 1, 
//                                                                            Value = 2
//                                                                        },
//                                                                        new AnswerWeight()                                                                              
//                                                                        {
//                                                                            ContactTypeId = 5, 
//                                                                            ProductId = 1, 
//                                                                            Value = 7
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 6, 
//                                                                            ProductId = 1, 
//                                                                            Value = 7
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 7, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 8, 
//                                                                            ProductId = 1, 
//                                                                            Value = 9
//                                                                        }
//                                                                    }          
//                                                                },
//                                                            }
//                                                        }, 


//                                                        new Question()
//                                                        {
//                                                            CategoryId = 2,
//                                                            StepNumber = 6,
//                                                            Text = "Assume farmaci abitualmente?",
//                                                            IsRequired = true,
//                                                            QuestionType = QuestionType.MultipleExclusive,
//                                                            Anwers = new List<Answer>()
//                                                                     {
//                                                                         new Answer()
//                                                                         {
//                                                                             Text = "NO",
//                                                                             AnswerWeight = new List<AnswerWeight>()
//                                                                                            {
//                                                                                                new AnswerWeight()
//                                                                                                {
//                                                                                                    ProductId = 1, 
//                                                                                                    Value = 1
//                                                                                                },
//                                                                                            }          
//                                                                         },
//                                                                         new Answer()
//                                                                         {
//                                                                             Text = "Statine/anti-ipertensivo/anticoagulanti/beta-bloccanti ",
//                                                                             AnswerWeight = new List<AnswerWeight>()
//                                                                             {
//                                                                                 new AnswerWeight()
//                                                                                 {
//                                                                                     ProductId = 1, 
//                                                                                     Value = 9
//                                                                                 },
//                                                                             }          
//                                                                         },
//                                                                         new Answer()
//                                                                         {
//                                                                             Text = "Farmaci ipoglicemizzanti (es. Metformina), psicofarmaci, cortisone, anticoncezionali ",
//                                                                             AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need 
//                                                                             {
//                                                                                 new AnswerWeight()
//                                                                                 {
//                                                                                     ProductId = 1, 
//                                                                                     Value = 9
//                                                                                 },
//                                                                             }     
//                                                                         }
//                                                                     }
//                                                        }, 

//                                                        //new Question()
//                                                        //{
//                                                        //    CategoryId = 2,
//                                                        //    StepNumber = 7,
//                                                        //    Text = "Ha allergie a farmaci?",
//                                                        //    IsRequired = true,
//                                                        //    Anwers = new List<Answer>()
//                                                        //             {
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "SI",
//                                                        //                     AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    },
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "NO",
//                                                        //                     AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    },
//                                                        //                 },
//                                                        //                 new Answer()
//                                                        //                 {
//                                                        //                     Text = "SE SI QUALE",
//                                                        //                     AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
//                                                        //                                    {
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 1, //Young Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 1
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 2, //Old Man
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 2
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 3, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 3
//                                                        //                                        },
//                                                        //                                        new AnswerWeight()
//                                                        //                                        {
//                                                        //                                            ContactTypeId = 4, //Young Woman
//                                                        //                                            ProductId = 1, //Genotest
//                                                        //                                            Value = 4
//                                                        //                                        }
//                                                        //                                    },
//                                                        //                     HasAdditionalInfo = true,
//                                                        //                     AdditionalInfoType = AdditionalInfoType.Text
//                                                        //                 }
//                                                        //             }
//                                                        //} 
//#endregion


//#region ANALISI ALIMENTARE
//                                                        new Question()
//                                                        {
//                                                            CategoryId = 3,
//                                                            StepNumber = 7,
//                                                            Text = "Ha alcune delle seguenti problematiche",
//                                                            IsRequired = true,
//                                                            QuestionType = QuestionType.MultipleNotExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text = "INTOLLERANZE ALIMENTARI",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                               },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "DISTURBI INTESTINALI",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                               },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "COLON IRRITABILE",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                               },
//                                                            }
//                                                        },

//#endregion


//#region ANALISI COMPORTAMENTALE
//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 8,
//                                                            Text = "Quanti caff� assume al giorno?",
//                                                            IsRequired = true,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 0,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 1,
//                                                                            ToNumericAdditionalInfo = 3,
//                                                                            ProductId = 1,
//                                                                            Value = 3,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 4,
//                                                                            ToNumericAdditionalInfo = 5,
//                                                                            ProductId = 1,
//                                                                            Value = 6,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 6,
//                                                                            ToNumericAdditionalInfo = 30,
//                                                                            ProductId = 1,
//                                                                            Value = 8,
//                                                                        }
//                                                                   }
//                                                               },
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 9,
//                                                            Text = "Indichi la sua abitudine al fumo",
//                                                            IsRequired = true,
//                                                            QuestionType = QuestionType.MultipleExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Non fumo",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Ho smesso da pi� di un anno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Ho smesso da meno di un anno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Fumo meno di 5 sigarette al giorno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Fumo tra 5 e 10 sigarette al giorno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 7,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Fumo tra 10 e 20 sigarette al giorno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Fumo pi� di 20 sigarette al giorno",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 10,
//                                                            Text = "Nel caso fosse fumatore vorrebbe smettere di fumare?",
//                                                            QuestionType = QuestionType.MultipleExclusive,
//                                                            IsRequired = false,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Entro 3 mesi",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Oltre 3 mesi",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Non intendo smettere",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                    }
//                                                                },
//                                                            }
//                                                        },


//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 11,
//                                                            Text = " In una settimana tipo, quanti minuti cammina in totale, sia per lavoro che per spostamenti o momenti ricreativi (considerando solo quando cammina per almeno 10 minuti consecutivi)",
//                                                            IsRequired = true,
//                                                            QuestionType = QuestionType.MultipleExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text = "20/30 minuti",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 1,
//                                                                            ProductId = 1,
//                                                                            Value = 2,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 2,
//                                                                            ProductId = 1,
//                                                                            Value = 2,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 3,
//                                                                            ProductId = 1,
//                                                                            Value = 3,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 4,
//                                                                            ProductId = 1,
//                                                                            Value =3,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 5,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 6,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 7,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ContactTypeId = 8,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                    }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text = "Fino a 60 minuti al giorno a giorni alterni ",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 2,
//                                                                        },
//                                                                    }
//                                                                },
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 12,
//                                                            Text = " Quanti bicchieri di alcolici (vino/birramisurati in bicchieri da 200 ml)assume mediamente durante una settimana?",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 0,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 1,
//                                                                            ToNumericAdditionalInfo = 2,
//                                                                            ProductId = 1,
//                                                                            Value = 2,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 3,
//                                                                            ToNumericAdditionalInfo = 30,
//                                                                            ProductId = 1,
//                                                                            Value = 8,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 5,
//                                                            StepNumber = 13,
//                                                            Text = " Quanti bicchieri di superalcolici assume in media in una settimana?",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,                                                                    
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 0,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 1,
//                                                                            ToNumericAdditionalInfo = 100,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//#endregion


//#region Analisi Stress Psico-Fisico
//                                                        new Question()
//                                                        {
//                                                            CategoryId = 6,
//                                                            StepNumber = 14,
//                                                            Text = "Mi sento stressato (indicare con un valore da 0 a 10)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 5,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 6,
//                                                                            ToNumericAdditionalInfo = 10,
//                                                                            ProductId = 1,
//                                                                            Value = 8,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 6,
//                                                            StepNumber = 15,
//                                                            Text = "Mi sento stanco (indicare con un valore da 0 a 10)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 5,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 6,
//                                                                            ToNumericAdditionalInfo = 10,
//                                                                            ProductId = 1,
//                                                                            Value = 5,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },


//                                                        new Question()
//                                                        {
//                                                            CategoryId = 6,
//                                                            StepNumber = 16,
//                                                            Text = "Posso controllare la situazione (indicare con un valore da 0 a 10)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 5,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 6,
//                                                                            ToNumericAdditionalInfo = 10,
//                                                                            ProductId = 1,
//                                                                            Value = 7,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 6,
//                                                            StepNumber = 17,
//                                                            Text = "Lo scorso anno ho perso molti giorni di lavoro/studio per motivi di salute quali",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.MultipleNotExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Influenza",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 7,
//                                                                        }
//                                                                   }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Raffreddore",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 7,
//                                                                        }
//                                                                   }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Malattie Respiratorie",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },


//                                                        new Question()
//                                                        {
//                                                            CategoryId = 6,
//                                                            StepNumber = 18,
//                                                            Text = "In quale tra i seguenti stili di vita le piacerebbe di pi� migliorare? ",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.MultipleNotExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Avere una alimentazione pi� corretta",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Fare attivit� fisica con maggiore regolarit�",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Smettere di fumare",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                },
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Gestire lo stress",
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },
//    #endregion


//#region Esami Ematochimici

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 19,
//                                                            Text = " Colesterolo totale (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 200,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 201,
//                                                                            ToNumericAdditionalInfo = 1000,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 20,
//                                                            Text = "Valore di HDL (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 40,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 41,
//                                                                            ToNumericAdditionalInfo = 200,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 21,
//                                                            Text = "Valore di HDL (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 40,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 41,
//                                                                            ToNumericAdditionalInfo = 200,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 22,
//                                                            Text = "Valore di LDL (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 150,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 151,
//                                                                            ToNumericAdditionalInfo = 400,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 23,
//                                                            Text = "Valore di trigliceridi (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 150,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 151,
//                                                                            ToNumericAdditionalInfo = 300,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 24,
//                                                            Text = "Valore di Glicemia (mg/dl)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 100,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 101,
//                                                                            ToNumericAdditionalInfo = 500,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },
//    #endregion


//#region Parametri biometrici

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 25,
//                                                            Text = "Pressione Arteriosa Minima (mmHg)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 80,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 81,
//                                                                            ToNumericAdditionalInfo = 200,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 26,
//                                                            Text = "Frequesnza cardiaca a riposo",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 79,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 80,
//                                                                            ToNumericAdditionalInfo = 200,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                        new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 26,
//                                                            Text = "Circonferenza addominale (cm)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 100,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 101,
//                                                                            ToNumericAdditionalInfo = 300,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },

//                                                         new Question()
//                                                        {
//                                                            CategoryId = 7,
//                                                            StepNumber = 24,
//                                                            Text = "Body Mass Index (BMI = massa corporea in kg/statura in m)",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.ValueOnly,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    AdditionalInfoType = Common.enums.AdditionalInfoType.Numeric,
//                                                                    HasAdditionalInfo = true,
//                                                                    AnswerWeight = new List<AnswerWeight>()
//                                                                    {
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 0,
//                                                                            ToNumericAdditionalInfo = 24,
//                                                                            ProductId = 1,
//                                                                            Value = 1,
//                                                                        },
//                                                                        new AnswerWeight()
//                                                                        {
//                                                                            FromNumericAdditionalInfo = 25,
//                                                                            ToNumericAdditionalInfo = 100,
//                                                                            ProductId = 1,
//                                                                            Value = 9,
//                                                                        }
//                                                                   }
//                                                                }
//                                                            }
//                                                        },
//    #endregion
//                                                   }	
//                                               });



//        }
        }
    }
}
