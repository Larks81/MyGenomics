using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Excel;

using MyGenomics.Common.enums;
using MyGenomics.Common.extensions;
using MyGenomics.DataModel;
using MyGenomics.Services;
using OfficeOpenXml;


namespace MyGenomics.ImportTool
{
    public partial class Form1 : Form
    {
        private QuestionnairesService _questionnaireService = new QuestionnairesService();
        private PersonsService _personsService = new PersonsService();
        private List<Product> _products;
        private List<PersonType> _personTypes;
        private List<DomainModel.Questionnaire> _questionnaires;

        public Form1()
        {
            InitializeComponent();            
            
        }

        private void btnImportQuestionnaire_Click(object sender, EventArgs e)
        {
            tbLog.Text += "Inizio Import"+Environment.NewLine;
            tbLog.Text += "Carico dati base..." + Environment.NewLine;
            Application.DoEvents();
            _questionnaires = _questionnaireService.GetAll();
            _products = _questionnaireService.GetProducts();
            _personTypes = _personsService.GetPersonTypes();
            tbLog.Text += "Import in corso..." + Environment.NewLine;
            Application.DoEvents();
            tbLog.Text += InsertQuestionnaireFromExcel(tbPathExcel.Text);            
        }

        private string InsertQuestionnaireFromExcel(string excelPath)
        {
            var transOpts = new TransactionOptions();
            transOpts.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

            using (var transation = new TransactionScope(TransactionScopeOption.Required, transOpts))
            {
                DateTime initDate = DateTime.Now;
                int numRowExcel = 0;
                try
                {
                    
                    FileInfo excelFile = new FileInfo(excelPath);
                    ExcelPackage pck = new ExcelPackage(excelFile);

                    string questionnaireCode = "";
                    int questionnaireId=0;
                    int languageId = 0;
                    string questionnaireName = "";

                    var wsQuestionario = pck.Workbook.Worksheets["Questionario"];

                    questionnaireCode = wsQuestionario.GetValue(2, 1).ConvertToString();
                    languageId = wsQuestionario.GetValue(2, 2).ConvertToInt();
                    questionnaireName = wsQuestionario.GetValue(2, 3).ConvertToString();

                    var questionnaireFound = _questionnaires.FirstOrDefault(q => q.Code == questionnaireCode);
                    if (questionnaireFound != null)
                    {
                        questionnaireId = questionnaireFound.Id;
                    }

                    var questionnaire = new Questionnaire()
                                        {
                                            Id = questionnaireId,
                                            Code = questionnaireCode,
                                            Name = questionnaireName,
                                            LanguageId = languageId
                                        };
                    questionnaireId = _questionnaireService.AddOrUpdateQuestionnaire(questionnaire);                    
                    var wsDomande = pck.Workbook.Worksheets["Domande"];
                    var totalRows = wsDomande.Dimension.Rows;
                    
                    string categoriaDomandaCorrente = "";
                    int categoriaDomandaCorrenteId = -1;
                    string domandaCorrente = "";
                    int domandaCorrenteId = -1;
                    string rispostaCorrente = "";
                    int rispostaCorrenteId = -1;

                    for (int i = 2; i <= totalRows; i++)
                    {
                        numRowExcel = i;
                        string categoriaDomanda = wsDomande.GetValue(i, (int)Cell.CategoriaDomanda).ConvertToString();
                        string testoDomanda = wsDomande.GetValue(i, (int)Cell.TestoDomanda).ConvertToString();
                        string obbligatorio = wsDomande.GetValue(i, (int)Cell.Obbligatorio).ConvertToString();
                        string tipoDomanda = wsDomande.GetValue(i, (int)Cell.TipoDomanda).ConvertToString();
                        string testoRisposta = wsDomande.GetValue(i, (int)Cell.TestoRisposta).ConvertToString();
                        string tipoRisposta = wsDomande.GetValue(i, (int)Cell.TipoRisposta).ConvertToString();
                        string tipoPersona = wsDomande.GetValue(i, (int)Cell.TipoPersona).ConvertToString();
                        string prodotto = wsDomande.GetValue(i, (int)Cell.Prodotto).ConvertToString();
                        string daValore = wsDomande.GetValue(i, (int)Cell.DaValore).ConvertToString();
                        string aValore = wsDomande.GetValue(i, (int)Cell.AValore).ConvertToString();
                        string peso = wsDomande.GetValue(i, (int)Cell.Peso).ConvertToString();
                        int questionCategoryId = wsDomande.GetValue(i, (int)Cell.QuestionCategoryId).ConvertToInt();
                        int questionId = wsDomande.GetValue(i, (int)Cell.QuestionId).ConvertToInt();
                        int answerId = wsDomande.GetValue(i, (int)Cell.AnswerId).ConvertToInt();
                        int weightId = wsDomande.GetValue(i, (int)Cell.WeightId).ConvertToInt();

                        //Rottura Categoria domanda
                        if (!string.IsNullOrWhiteSpace(categoriaDomanda))
                        {
                            var questionCategory = new QuestionCategory()
                                                   {
                                                       Id = questionCategoryId,
                                                       Name = categoriaDomanda
                                                   };
                            categoriaDomandaCorrenteId = AddOrUpdateQuestionCategory(questionCategory);
                            wsDomande.SetValue(i, (int)Cell.QuestionCategoryId, categoriaDomandaCorrenteId);
                            categoriaDomandaCorrente = categoriaDomanda;
                        }

                        //Rottura domanda
                        if (!string.IsNullOrWhiteSpace(testoDomanda))
                        {
                            var question = new Question()
                                           {
                                               Id = questionId,
                                               QuestionnaireId = questionnaireId,
                                               CategoryId = categoriaDomandaCorrenteId,
                                               IsRequired = obbligatorio == "SI" ? true : false,
                                               QuestionType =
                                                   tipoDomanda == "MULTIPLA-ESCLUSIVA"
                                                       ? QuestionType.MultipleExclusive
                                                       : (tipoDomanda == "MULTIPLA-NON-ESCLUSIVA"
                                                           ? QuestionType.MultipleNotExclusive
                                                           : QuestionType.ValueOnly),
                                               StepNumber = 1,
                                               Text = testoDomanda
                                           };
                            domandaCorrenteId = AddOrUpdateQuestion(question);
                            wsDomande.SetValue(i, (int) Cell.QuestionId, domandaCorrenteId);
                            domandaCorrente = testoDomanda;
                        }
                        
                        //Rottura risposta
                        if (!string.IsNullOrWhiteSpace(testoRisposta + tipoRisposta))
                        {
                            var answer = new Answer()
                                         {
                                             Id = answerId,
                                             QuestionId = domandaCorrenteId,
                                             Text = testoRisposta,
                                             AdditionalInfoType =
                                                 tipoRisposta == "NUMERICO"
                                                     ? AdditionalInfoType.Numeric
                                                     : (tipoRisposta == "TESTO"
                                                         ? AdditionalInfoType.Text
                                                         : (AdditionalInfoType) 0),
                                             HasAdditionalInfo = tipoRisposta != "VEROFALSO"
                                         };

                            rispostaCorrenteId = AddOrUpdateAnswer(answer);
                            wsDomande.SetValue(i, (int)Cell.AnswerId, rispostaCorrenteId);
                            rispostaCorrente = testoRisposta + tipoRisposta;
                        }

                        if (!string.IsNullOrEmpty(peso) && !string.IsNullOrWhiteSpace(prodotto))
                        {
                            var answerWeight = new AnswerWeight()
                                               {
                                                   Id = weightId,
                                                   AnswerId = rispostaCorrenteId,
                                                   FromNumericAdditionalInfo =
                                                       !string.IsNullOrEmpty(daValore) ? Convert.ToInt16(daValore) : 0,
                                                   ToNumericAdditionalInfo =
                                                       !string.IsNullOrEmpty(aValore) ? Convert.ToInt16(aValore) : 0,
                                                   PersonTypeId = GetPersonTypeIdByCode(tipoPersona),
                                                   ProductId = GetProductIdByCode(prodotto),
                                                   Value = Convert.ToInt16(peso)
                                               };

                            var pesoCorrenteId = AddOrUpdateAnswerWeight(answerWeight);
                            wsDomande.SetValue(i, (int)Cell.WeightId, pesoCorrenteId);
                        }
                    }
                    pck.Save();
                    _questionnaireService.RemoveQuestionnaireItemsBefore(questionnaireId, initDate);
                    transation.Complete();
                    return "Importazione eseguita con successo";
                                        
                }
                catch(Exception ex)
                {
                    return "Import Annullato! Errore nella riga " + numRowExcel + Environment.NewLine + Environment.NewLine + ex.ToString();
                }
            }

        }

        private int AddOrUpdateQuestionCategory(QuestionCategory questionCategory)
        {
            return _questionnaireService.AddOrUpdateQuestionCategory(questionCategory);
        }

        private int AddOrUpdateQuestion(Question question)
        {
            return _questionnaireService.AddOrUpdateQuestion(question);
        }
        private int AddOrUpdateAnswer(Answer answer)
        {
            return _questionnaireService.AddOrUpdateAnswer(answer);
        }

        private int AddOrUpdateAnswerWeight(AnswerWeight answerWeight)
        {
            return _questionnaireService.AddOrUpdateAnswerWeight(answerWeight);
        }

        private int GetProductIdByCode(string productCode)
        {
            return _products.FirstOrDefault(p => p.Code == productCode).Id;
        }

        private int? GetPersonTypeIdByCode(string personTypeCode)
        {
            if (string.IsNullOrEmpty(personTypeCode))
                return null;
            return _personTypes.FirstOrDefault(p => p.Code == personTypeCode).Id;
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbPathExcel.Text = openFileDialog1.FileName;
        }


    }
}
