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
            context.Users.AddOrUpdate(new User() { 
                Id = 1,
                UserName = "demo",
                Password = "demo",
                UserType = UserType.Administrator
            });

            context.Languages.AddOrUpdate(new Language()
                                          {
                                              Id = 1,
                                              Code = "IT",
                                              InsertDate = DateTime.Now,
                                              UpdateDate = DateTime.Now
                                          });

            context.Languages.AddOrUpdate(new Language()
                                        {
                                            Id = 2,
                                            Code = "EN",
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
                                                                    "sollevamento pesi, salti e lanci dell’atletica legge ecc",
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

            //Livelli
            context.Levels.AddOrUpdate(new Level()
            {   
                Id = 1,
                InsertDate = DateTime.Now,
                Name = "Level 1",
                UpdateDate = DateTime.Now,
                Value = 1,                
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 1,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il livello di suscettibilità individuato dal test è pari a quello della popolazione normale di riferimento"            
                    }                                    
                }                        
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 2,
                InsertDate = DateTime.Now,
                Name = "Level 2",
                UpdateDate = DateTime.Now,
                Value = 2,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 2,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità moderatamente superiore a quello della popolazione di riferimento"            
                    }                                    
                }
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 3,
                InsertDate = DateTime.Now,
                Name = "Level 3",
                UpdateDate = DateTime.Now,
                Value = 3,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 3,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità particolarmente elevato rispetto a quello della popolazione di riferimento, il livello di attenzione da prestare alle raccomandazioni fornite a corredo di questo risultato è molto elevato"            
                    }                                    
                }
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 4,
                InsertDate = DateTime.Now,
                Name = "Level 4",
                UpdateDate = DateTime.Now,
                Value = 4,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 4,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità particolarmente elevato rispetto a quello della popolazione di riferimento, il livello di attenzione da prestare alle raccomandazioni fornite a corredo di questo risultato è molto elevato"            
                    }                                    
                }
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 5,
                InsertDate = DateTime.Now,
                Name = "Level 5",
                UpdateDate = DateTime.Now,
                Value = 5,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 5,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità particolarmente elevato rispetto a quello della popolazione di riferimento, il livello di attenzione da prestare alle raccomandazioni fornite a corredo di questo risultato è molto elevato"            
                    }                                    
                }
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 6,
                InsertDate = DateTime.Now,
                Name = "Level 6",
                UpdateDate = DateTime.Now,
                Value = 6,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 6,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità particolarmente elevato rispetto a quello della popolazione di riferimento, il livello di attenzione da prestare alle raccomandazioni fornite a corredo di questo risultato è molto elevato"            
                    }                                    
                }
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = 7,
                InsertDate = DateTime.Now,
                Name = "Level 7",
                UpdateDate = DateTime.Now,
                Value = 7,
                Translations = new List<LevelTranslation>()
                {
                    new LevelTranslation()
                    {
                        Id = 7,
                        ImageUri = "",
                        LanguageId = 1,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Text = "Il test indica un livello di suscettibilità particolarmente elevato rispetto a quello della popolazione di riferimento, il livello di attenzione da prestare alle raccomandazioni fornite a corredo di questo risultato è molto elevato"            
                    }                                    
                }
            });

            context.ReportHeaders.AddOrUpdate(new ReportHeader()
                                              {
                                                  Id = 1,
                                                  BaseColor = "#FFFFFF",
                                                  TextColor = "#FFFFFF",
                                                  InsertDate = DateTime.Now,
                                                  UpdateDate = DateTime.Now,
                                                  Translations = new List<ReportHeaderTranslation>()
                                                                 {
                                                                     new ReportHeaderTranslation()
                                                                     {
                                                                         Id = 1,
                                                                         FirstPage = "Text of first page",
                                                                         LanguageId = 1,
                                                                         ReportHeaderId = 1,
                                                                         SecondPage = "Text of second page",                                                                         
                                                                         InsertDate = DateTime.Now,
                                                                         UpdateDate = DateTime.Now
                                                                     }
                                                                 }
                                              });

            context.ReportTranslations.AddOrUpdate(new ReportTranslation()
                {
                    Id = 1,
                    LanguageId = 1,
                    ReportId = 1,
                    Text = "Genomica",
                    Title = "Genomica",
                    Report = new Report()
                             {
                                 Id = 1,
                                 ProductId = 1,
                                 ReportHeaderId = 1,
                                 Chapters = new List<ReportsChapters>()
                                            {
                                                new ReportsChapters(){
                                                    ReportId = 1,
                                                    Chapter = new Chapter()
                                                    {
                                                        Color = "#FFFFFF",
                                                        Id = 1,
                                                        Translations = new List<ChapterTranslation>()
                                                                       {
                                                                           new ChapterTranslation()
                                                                           {
                                                                               Id = 1,
                                                                               LanguageId = 1,
                                                                               Text = "Testp capitolo in italiano",
                                                                               Title = "Capitolo 1",
                                                                               InsertDate = DateTime.Now,
                                                                               UpdateDate = DateTime.Now
                                                                           }
                                                                       },
                                                        Panels = new List<ChaptersPanels>()
                                                                 {
                                                                     new ChaptersPanels(){
                                                                     Panel = new Panel()
                                                                     {
                                                                         Id = 1,
                                                                         InsertDate = DateTime.Now,
                                                                         UpdateDate = DateTime.Now,
                                                                         PanelContents = new List<PanelContent>()
                                                                                         {
                                                                                             new PanelContent()
                                                                                             {
                                                                                                 Translations= new List<PanelContentTranslation>()
                                                                                                               {
                                                                                                                   new PanelContentTranslation()
                                                                                                                   {
                                                                                                                       LanguageId = 1,
                                                                                                                       Title = "Testo introduzione pannello",
                                                                                                                       ShortText = "La celiachia è una patologia su base alimentare che si manifesta sotto forma di una reazione immunitaria anche grave del tratto gastro-intestinale e sistemica. Questa reazione è provocata da proteine alimentari, contenute in diverse proporzioni in varie specie di frumento, quali: grano, orzo e segale. Queste proteine sono identificate col termine di “glutine” e la gliadina è la proteina glutinica che è ritenuta avere il ruolo maggiore nell’eziopatogenesi della celiachia. La malattia è caratterizzata da un’intolleranza permanente al glutine che, una volta ingerito, produce un’attivazione del sistema immunitario con conseguente risposta infiammatoria che può causare danni alla mucosa intestinale a livello del tenue. Le cause del morbo celiaco sono state definitivamente chiarite solo in epoche recenti e per lungo tempo questa condizione è stata significativamente sotto-diagnosticata. Gli sviluppi diagnostici e clinici hanno rivelato una prevalenza della sindrome celiaca superiore all’effettivo riscontro clinico che era basato essenzialmente sulla sola sintomatologia intestinale. Ciò è dovuto a numerosi fattori, tra i quali la presenza di situazioni iniziali equivoche o non conclamate e di difficile comprensione clinica, la genericità di alcuni sintomi che possono creare un quadro fuorviante o destare scarsa attenzione del clinico. Per questo l’indagine genetica ha un ruolo rilevante sia nelle indagini precliniche utili a aumentare l’attenzione sul rischio di sviluppare questa malattia, sia nelle indagini di significato diagnostico e prognostico per contribuire a identificare e chiarire quadri e disturbi gastroenterici e/o sistemici di non facile comprensione clinica. Se non adeguatamente e tempestivamente trattata, questa condizione predispone a una serie di patologie gravi, tra le quali figurano malassorbimento, infertilità, tendenza agli aborti spontanei, osteoporosi, disfunzioni immunitarie e alcuni tumori. Questa patologia può presentarsi a qualsiasi età, con diverse manifestazioni cliniche: stanchezza, dolore addominale e gonfiore addominale, diarrea intermittente, perdita di peso e nausea. In alcune persone tuttavia non si verificano sintomi aperti. Nei bambini e negli adolescenti possono presentare sintomi extraintestinali, tra cui la bassa statura, pubertà ritardata, anemia e sintomi neurologici causati da malassorbimento di sostanze nutritive. E’ stato dimostrato che i geni del complesso di istocompatibilità HLA II sono fortemente associati alla malattia: il 95% dei pazienti presenta l’eterodimero HLA-DQ2. La celiachia può colpire chiunque; tuttavia, tende ad essere più comune in soggetti con almeno un membro della famiglia affetto da malattia celiaca o dermatite erpetiforme, diabete di tipo 1, sindrome di Down o la sindrome di Turner, malattie autoimmuni della tiroide, sindrome di Sjogren e colite microscopica. Questa associazione tra condizioni che si manifestano a livello famigliare sottende a un interessamento del sistema immunitario e di sorveglianza tissutale (risposta tollero genica e di riconoscimento del “self”) che è trasmissibile sulla base degli stessi meccanismi di altri tratti somatici autosomici.",
                                                                                                                   }
                                                                                                               },
                                                                                                OrderPosition = 1,    
                                                                                                InsertDate = DateTime.Now,
                                                                                                UpdateDate = DateTime.Now,
                                                                                             },
                                                                                             new PanelContent()
                                                                                             {
                                                                                                 Translations= new List<PanelContentTranslation>()
                                                                                                               {
                                                                                                                   new PanelContentTranslation()
                                                                                                                   {
                                                                                                                       LanguageId = 1,
                                                                                                                       Title = "Livello suscettibilita 1",
                                                                                                                       ShortText = "In base ai polimorfismi saggiati, non si riscontra una suscettibilità aumentata a manifestare sintomi da sensibilità o intolleranza al glutine. Ciò, comunque, non esclude del tutto che ciò possa verificarsi in futuro e quindi, in caso di sintomi gastro-intestinali o di altro genere ascrivibili al quadro del morbo celiaco descritti nelle altre sezioni del referto, consigliamo di confrontarsi con uno specialista gastroenterologo per verificarne l‟origine. Raccomandiamo comunque l‟impostazione di un piano di stili di vita e alimentare idoneo a mantenere integra la funzione del tratto gastro-intestinale e immunitaria in genere. Evitare sovraccarichi metabolici da eccesso alimentare e abuso di alcol, farmaci e droghe e praticare regolarmente attività fisica, sono i primi presidi da mettere in atto per proteggere l‟integrità di queste funzioni. Curare l'integrità della microflora intestinale in particolare negli stati di disbiosi causati da stili di vita errati, malattie o terapie con antibiotici. In questi casi, è opportuno rivolgersi a uno specialista per verificare la diagnosi del problema e eventualmente si può ricorrere all'uso di pre e pro-biotici abbinato a opportuni regimi alimentari.",
                                                                                                                       Text = "Non si riscontra una suscettibilità aumentata a manifestare sintomi da sensibilità o intolleranza al glutine. Ciò, comunque, non esclude del tutto che ciò possa verificarsi in futuro e quindi, sia in assenza sia in presenza di sintomi gastro-intestinali o di altro genere ascrivibili al quadro del morbo celiaco descritti nelle altre sezioni del referto, consigliamo di confrontarsi con uno specialista gastroenterologo per svolgere le opportune verifiche cliniche e eventualmente una prova di esclusione alimentare del glutine.Anche nei soggetti asintomatici si raccomanda l'impostazione di un piano di stili di vita e alimentare idoneo a mantenere integra la funzione del tratto gastro-intestinale e immunitaria in genere. Evitare sovraccarichi metabolici da eccesso alimentare e abuso di alcol, farmaci e droghe e praticare regolarmente attività fisica, sono i primi presidi da mettere in atto per proteggere l'integrità di queste funzioni. Curare l'integrità della microflora intestinale in particolare negli stati di disbiosi causati da stili di vita errati, malattie o terapie con antibiotici. In questi casi, è opportuno rivolgersi a uno specialista per verificare la diagnosi del problema e eventualmente si può ricorrere all''uso di pre e pro-biotici abbinato a opportuni regimi alimentari.",
                                                                                                                   }
                                                                                                               },
                                                                                                 LevelId = 1,
                                                                                                 OrderPosition = 2,
                                                                                                 InsertDate = DateTime.Now,
                                                                                                 UpdateDate = DateTime.Now
                                                                                             }
                                                                                         },
                                                                         Translations = new List<PanelTranslation>(){
                                                                            new PanelTranslation()
                                                                            {
                                                                                LanguageId = 1,
                                                                                Title = "Pannello 1",                                                                            
                                                                                InsertDate = DateTime.Now,
                                                                                UpdateDate = DateTime.Now
                                                                            }
                                                                         }
                                                                     }

                                                                 }
                                                            }
                                                        }
                                                }  
                                            },
                                 InsertDate = DateTime.Now,
                                 UpdateDate = DateTime.Now
                             },

                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });



            


            #region Seed Questionario

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
//                                                        //    Text = "Le sue gengive si sono ritirate e i denti sono più “lunghi”?",
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
//                                                            Text = "Quanti caffè assume al giorno?",
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
//                                                                    Text = "Ho smesso da più di un anno",
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
//                                                                    Text = "Fumo più di 20 sigarette al giorno",
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
//                                                            Text = "In quale tra i seguenti stili di vita le piacerebbe di più migliorare? ",
//                                                            IsRequired = false,
//                                                            QuestionType = QuestionType.MultipleNotExclusive,
//                                                            Anwers = new List<Answer>()
//                                                            {
//                                                                new Answer()
//                                                                {
//                                                                    Text ="Avere una alimentazione più corretta",
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
//                                                                    Text ="Fare attività fisica con maggiore regolarità",
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

            #endregion
        }
    }
}
