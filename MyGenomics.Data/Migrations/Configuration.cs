using System.Collections.Generic;
using MyGenomics.Model;

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
                Gender = Gender.Male,
                AgeFrom = 0,
                AgeTo = 40,
                Description = "Uomo giovane (1-40)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 2,
                Gender = Gender.Male,
                AgeFrom = 41,
                AgeTo = 120,
                Description = "Uomo anziano (41-120)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 3,
                Gender = Gender.Female,
                AgeFrom = 0,
                AgeTo = 40,
                Description = "Donna giovane (1-40)"
            });

            context.PersonTypes.AddOrUpdate(new PersonType()
            {
                Id = 4,
                Gender = Gender.Female,
                AgeFrom = 41,
                AgeTo = 120,
                Description = "Donna anziana (41-120)"
            });

            context.ProductCategories.AddOrUpdate(new ProductCategory()
            {
                Id = 1,
                Name = "GenoTest"
            });
            context.ProductCategories.AddOrUpdate(new ProductCategory()
            {
                Id = 2,
                Name = "AltroTest"
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 1, //Young Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 4
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 4, //From 1
                                                                                                    ToNumericAdditionalInfo = 10, //To 3
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    FromNumericAdditionalInfo = 1, //From 1
                                                                                                    ToNumericAdditionalInfo = 3, //To 3
                                                                                                    Value = 4
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Old Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 1
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 2, //Old Man
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 2
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 3, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
                                                                                                    Value = 3
                                                                                                },
                                                                                                new AnswerWeight()
                                                                                                {
                                                                                                    PersonTypeId = 4, //Young Woman
                                                                                                    ProductCategoryId = 1, //Genotest
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
