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

            context.Languages.AddOrUpdate( new Language()
            {
                Id = 1,
                Name = "IT"
            });
            context.QuestionCategories.AddOrUpdate(new QuestionCategory()
            {
                Id = 1,
                Name = "ANALISI PARODONTALE"
            });
            context.QuestionCategories.AddOrUpdate(new QuestionCategory()
            {
                Id = 2,
                Name = "ANALISI GENERALE"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 1,
                Gender = Enums.Male,
                AgeFrom = 0,
                AgeTo = 40,
                Description = "Uomo giovane (1-40)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 2,
                Gender = Enums.Male,
                AgeFrom = 41,
                AgeTo = 120,
                Description = "Uomo anziano (41-120)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 3,
                Gender = Enums.Female,
                AgeFrom = 0,
                AgeTo = 40,
                Description = "Donna giovane (1-40)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 4,
                Gender = Enums.Female,
                AgeFrom = 41,
                AgeTo = 120,
                Description = "Donna anziana (41-120)"
            });

            context.Packages.AddOrUpdate(new Package()
            {
                Id = 1,
                Name = "Nutrizione e Sport",
                Products = new List<Product>()
                        {
                            new Product()
                            {
                                    Id = 1,
                                    Name = "Nutrigenomica",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/nutrigenomica",
                                    Price = 400,
                                    ShortDescription = "Nutrigenomica"                                                                 
                            },
                            new Product()
                            {
                                    Id = 2,
                                    Name = "Sport Endurance",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/sport-endurance",
                                    Price = 400,
                                    ShortDescription = "Marcia, corsa, pattinaggio, ciclismo, sci di fondo ecc"
                            },
                            new Product()
                            {
                                    Id = 3,
                                    Name = "Intolleranze e Dipendenze",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/intolleranze-e-dipendenze",
                                    Price = 350,
                                    ShortDescription = "Intolleranze e Dipendenze"
                            },
                            new Product()
                            {
                                    Id = 4,
                                    Name = "Sport Potenza",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/sport-potenza",
                                    Price = 400,
                                    ShortDescription = "sollevamento pesi, salti e lanci dell’atletica legge ecc"
                            },
                            new Product()
                            {
                                    Id = 5,
                                    Name = "Sport Situazione",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/sport-situazione",
                                    Price = 400,
                                    ShortDescription = "Calcio, pallacanestro, pallavolo, pallamano, tennis ecc"
                            }
                        }
            });

            context.Packages.AddOrUpdate(new Package()
            {
                Id = 2,
                Name = "Medicina Personalizzata",
                Products = new List<Product>()
                        {
                            new Product()
                            {
                                    Id = 6,
                                    Name = "Metabolismo energetico e osseo",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/metabolismo-energetico-e-osseo",
                                    Price = 350,
                                    ShortDescription = "Diabete 2, iperTG, HDL/LDL, osteoporosi"                                                                 
                            },
                            new Product()
                            {
                                    Id = 7,
                                    Name = "Alzheimer",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/alzheimer",
                                    Price = 500,
                                    ShortDescription = "Alzheimer"
                            },
                            new Product()
                            {
                                    Id = 8,
                                    Name = "Oncologia: mammella",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/oncologia-mammella",
                                    Price = 500,
                                    ShortDescription = "Tumore alla mammella"
                            },
                            new Product()
                            {
                                    Id = 9,
                                    Name = "Oncologia: colon-retto",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/oncologia-colon-retto",
                                    Price = 500,
                                    ShortDescription = "Tumore a colon-retto"
                            },
                            new Product()
                            {
                                    Id = 10,
                                    Name = "Oncologia: prostata",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/oncologia-prostata",
                                    Price = 500,
                                    ShortDescription = "Tumore alla prostata"
                            },
                            new Product()
                            {
                                    Id = 10,
                                    Name = "Parkinson",
                                    UrlDetail = "http://www.mygenomics.eu/genotest/parkinson",
                                    Price = 500,
                                    ShortDescription = "Parkinson"
                            }
                        }
            });

            context.Questionnaires.AddOrUpdate(new Questionnaire()
                                               {
                                                   Id = 1,
                                                   Name = "Test",
                                                   LanguageId = 1,
                                                   Questions = new List<Question>(){
                                                        new Question()
                                                        {                                                            
                                                            CategoryId = 1,
                                                            StepNumber = 1,
                                                            Text = "Le sue gengive sanguinano?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "SI",   
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",                                                                             
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }                                                                                
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "A VOLTE",   
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }                                                                         
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {                                                            
                                                            CategoryId = 1,
                                                            StepNumber = 2,
                                                            Text = "I suoi denti si muovono?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "POCO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "MOLTO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {
                                                            CategoryId = 1,
                                                            StepNumber = 3,
                                                            Text = "Le sue gengive si sono ritirate e i denti sono più “lunghi”?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "POCO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "MOLTO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {
                                                            CategoryId = 1,
                                                            StepNumber = 4,
                                                            Text = "Qualcuno dei suoi parenti ha sofferto di parodontite (piorrea)?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "SI",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NON SO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {
                                                            CategoryId = 2,
                                                            StepNumber = 5,
                                                            Text = "Soffre di qualche patologia cronica (es. diabete, ipertensione arteriosa, asma, bronchite cronica, cardiopatia ischemica, angina, infarto miocardico, colon irritabile, malattie autoimmuni, etc.)?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "SI",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "SE SI QUANTE",
                                                                             HasAdditionalInfo = true,
                                                                             AdditionalInfoType = AdditionalInfoType.Numeric,
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 4
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 4
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 5
                                                                                                }
                                                                                            }          
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {
                                                            CategoryId = 2,
                                                            StepNumber = 6,
                                                            Text = "Assume farmaci abitualmente?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "SI",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>()
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            }          
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "SE SI QUALE",
                                                                             AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            },
                                                                             HasAdditionalInfo = true,
                                                                             AdditionalInfoType = AdditionalInfoType.Text 
                                                                         }
                                                                     }
                                                        },
                                                        new Question()
                                                        {
                                                            CategoryId = 2,
                                                            StepNumber = 7,
                                                            Text = "Ha allergie a farmaci?",
                                                            IsRequired = true,
                                                            Anwers = new List<Answer>()
                                                                     {
                                                                         new Answer()
                                                                         {
                                                                             Text = "SI",
                                                                             AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            },
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "NO",
                                                                             AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            },
                                                                         },
                                                                         new Answer()
                                                                         {
                                                                             Text = "SE SI QUALE",
                                                                             AnswerWeight = new List<AnswerWeight>() //Additional Info Text no need of ranges
                                                                                            {
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductId = 1, //Genotest
                                                                                                    Value = 4
                                                                                                }
                                                                                            },
                                                                             HasAdditionalInfo = true,
                                                                             AdditionalInfoType = AdditionalInfoType.Text
                                                                         }
                                                                     }
                                                        } 
                                                   }
                                               });
            
        }
    }
}
