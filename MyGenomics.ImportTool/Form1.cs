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
using MyGenomics.DataModel;
using MyGenomics.Services;

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
            _questionnaires = _questionnaireService.GetAll();
            FillQuestionnairesCombo(_questionnaires);
        }

        private void FillQuestionnairesCombo(List<DomainModel.Questionnaire> questionnaires)
        {
            cbQuestionnaires.Items.Clear();

            foreach (var questionnaire in questionnaires)
            {
                cbQuestionnaires.Items.Add(questionnaire);
            }
        }

        private void btnImportQuestionnaire_Click(object sender, EventArgs e)
        {
            _products = _questionnaireService.GetProducts();
            _personTypes = _personsService.GetPersonTypes();

            if (string.IsNullOrWhiteSpace(cbQuestionnaires.Text) || string.IsNullOrWhiteSpace(tbQuestionnaireName.Text))
            {
                MessageBox.Show("è necessario dare un codice e un titolo al Questionario", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            tbLog.Text = "Import in corso";
            Application.DoEvents();
            tbLog.Text = InsertQuestionnaireFromExcel(tbPathExcel.Text);
        }

        private string InsertQuestionnaireFromExcel(string excelPath)
        {
            using (var transation = new TransactionScope())
            {
                try
                {

                    var selectedQuestionnaire = (DomainModel.Questionnaire)cbQuestionnaires.SelectedItem;

                    if (selectedQuestionnaire!=null && selectedQuestionnaire.Id > 0)
                    {
                        _questionnaireService.RemoveQuestionnaire(Convert.ToInt16(selectedQuestionnaire.Id));    
                    }
                    

                    var questionnaire = new Questionnaire()
                                        {
                                            Code = cbQuestionnaires.Text,
                                            Name = tbQuestionnaireName.Text,
                                            LanguageId = 1
                                        };
                    int questionnaireId = _questionnaireService.AddQuestionnaire(questionnaire);

                    FileStream stream = File.Open(excelPath, FileMode.Open, FileAccess.Read);

                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    //4. DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet result = excelReader.AsDataSet();

                    string categoriaDomandaCorrente = "";
                    int categoriaDomandaCorrenteId = -1;
                    string domandaCorrente = "";
                    int domandaCorrenteId = -1;
                    string rispostaCorrente = "";
                    int rispostaCorrenteId = -1;

                    foreach (DataRow row in result.Tables[1].Rows)
                    {
                        var categoriaDomanda = row[(int) Cell.CategoriaDomanda].ToString();
                        var testoDomanda = row[(int) Cell.TestoDomanda].ToString();
                        var obbligatorio = row[(int) Cell.Obbligatorio].ToString();
                        var tipoDomanda = row[(int) Cell.TipoDomanda].ToString();
                        var testoRisposta = row[(int) Cell.TestoRisposta].ToString();
                        var tipoRisposta = row[(int) Cell.TipoRisposta].ToString();
                        var tipoPersona = row[(int) Cell.TipoPersona].ToString();
                        var prodotto = row[(int) Cell.Prodotto].ToString();
                        var daValore = row[(int) Cell.DaValore].ToString();
                        var aValore = row[(int) Cell.AValore].ToString();
                        var peso = row[(int) Cell.Peso].ToString();

                        //Rottura Categoria domanda
                        if (!string.IsNullOrWhiteSpace(categoriaDomanda))
                        {
                            var questionCategory = new QuestionCategory()
                                                   {
                                                       Name = categoriaDomanda
                                                   };
                            categoriaDomandaCorrenteId = AddQuestionCategory(questionCategory);
                            categoriaDomandaCorrente = categoriaDomanda;
                        }

                        //Rottura domanda
                        if (!string.IsNullOrWhiteSpace(testoDomanda))
                        {
                            var question = new Question()
                                           {
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
                            domandaCorrenteId = AddQuestion(question);
                            domandaCorrente = testoDomanda;
                        }
                        
                        //Rottura risposta
                        if (!string.IsNullOrWhiteSpace(testoRisposta + tipoRisposta))
                        {
                            var answer = new Answer()
                                         {
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

                            rispostaCorrenteId = AddAnswer(answer);
                            rispostaCorrente = testoRisposta + tipoRisposta;
                        }

                        if (!string.IsNullOrEmpty(peso) && !string.IsNullOrWhiteSpace(prodotto))
                        {
                            var answerWeight = new AnswerWeight()
                                               {
                                                   AnswerId = rispostaCorrenteId,
                                                   FromNumericAdditionalInfo =
                                                       !string.IsNullOrEmpty(daValore) ? Convert.ToInt16(daValore) : 0,
                                                   ToNumericAdditionalInfo =
                                                       !string.IsNullOrEmpty(aValore) ? Convert.ToInt16(aValore) : 0,
                                                   PersonTypeId = GetPersonTypeIdByCode(tipoPersona),
                                                   ProductId = GetProductIdByCode(prodotto),
                                                   Value = Convert.ToInt16(peso)
                                               };

                            AddAnswerWeight(answerWeight);
                        }
                    }
                    excelReader.Close();
                    transation.Complete();
                    return "Importazione eseguita con successo";
                }
                catch(Exception ex)
                {
                    return "Errore! "+ex.Message;
                }
            }

        }

        private int AddQuestionCategory(QuestionCategory questionCategory)
        {
            return _questionnaireService.AddQuestionCategory(questionCategory);
        }

        private int AddQuestion(Question question)
        {
            return _questionnaireService.AddQuestion(question);
        }
        private int AddAnswer(Answer answer)
        {
            return _questionnaireService.AddAnswer(answer);
        }

        private int AddAnswerWeight(AnswerWeight answerWeight)
        {
            return _questionnaireService.AddAnswerWeight(answerWeight);
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


    }
}
