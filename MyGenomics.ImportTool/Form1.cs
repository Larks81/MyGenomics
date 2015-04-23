using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using MyGenomics.Common.enums;
using MyGenomics.Common.extensions;
using MyGenomics.DomainModel;
using OfficeOpenXml;

namespace MyGenomics.ImportTool
{
    public partial class Form1 : Form
    {        
        
        public Form1()
        {
            InitializeComponent();                        
        }

        private void btnImportQuestionnaire_Click(object sender, EventArgs e)
        {
            try
            {
                tbLog.Text = "Inizio Import" + Environment.NewLine;
                tbLog.Text += "Carico File excel..." + Environment.NewLine;
                Application.DoEvents();
                var questionnaireImport = GetImportQuestionnaireFromExcel(tbPathExcel.Text);
                tbLog.Text += "Import in corso..." + Environment.NewLine;
                Application.DoEvents();
                var questionnaireImportModified = ImportQuestionnaire(questionnaireImport);
                tbLog.Text += "Salvo su excel le modifiche..." + Environment.NewLine;
                Application.DoEvents();
                SaveIdsInExcel(tbPathExcel.Text, questionnaireImportModified);
                tbLog.Text += "Import terminato con successo" + Environment.NewLine;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                tbLog.Text += "ERRORE!" + Environment.NewLine;
                tbLog.Text += ex.Message;
            }
        }

        public ImportQuestionnaire ImportQuestionnaire(ImportQuestionnaire questionnaire)
        {
            string webapiUrl = ConfigurationManager.AppSettings.Get("WebapiUrl");
            string webapiPassword = ConfigurationManager.AppSettings.Get("WebapiPassword");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webapiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync("api/Questionnaire?password=" + webapiPassword, questionnaire).Result;
                if (response.IsSuccessStatusCode)
                {                    
                    return response.Content.ReadAsAsync<ImportQuestionnaire>().Result;                                        
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        private void SaveIdsInExcel(string excelPath, ImportQuestionnaire questionnaire)
        {
            var excelFile = new FileInfo(excelPath);
            var pck = new ExcelPackage(excelFile);
            var wsDomande = pck.Workbook.Worksheets["Domande"];

            foreach (var detail in questionnaire.Details)
            {
                wsDomande.SetValue(detail.RowNumber, (int)Cell.QuestionCategoryId, detail.QuestionCategoryId);
                wsDomande.SetValue(detail.RowNumber, (int)Cell.QuestionId, detail.QuestionId);
                wsDomande.SetValue(detail.RowNumber, (int)Cell.AnswerId, detail.AnswerId);
                wsDomande.SetValue(detail.RowNumber, (int)Cell.WeightId, detail.AnswerWeightId);
            }

            pck.Save();
        }

        private ImportQuestionnaire GetImportQuestionnaireFromExcel(string excelPath)
        {
            var questionnaireImport = new ImportQuestionnaire();

            var excelFile = new FileInfo(excelPath);
            var pck = new ExcelPackage(excelFile);
            var wsQuestionario = pck.Workbook.Worksheets["Questionario"];

            var questionnaireCode = wsQuestionario.GetValue(2, 1).ConvertToString();
            var languageCode = wsQuestionario.GetValue(2, 2).ConvertToInt();
            var questionnaireName = wsQuestionario.GetValue(2, 3).ConvertToString();

            questionnaireImport.LanguageCode = languageCode;
            questionnaireImport.QuestionnaireCode = questionnaireCode;
            questionnaireImport.QuestionnaireName = questionnaireName;

            questionnaireImport.Details = new List<ImportQuestionnaireDetail>();

            var wsDomande = pck.Workbook.Worksheets["Domande"];
            var totalRows = wsDomande.Dimension.Rows;
            int numRowExcel = 0;
            
            for (int i = 2; i <= totalRows; i++)
            {
                var detail = new ImportQuestionnaireDetail(); 

                detail.RowNumber = i;
                detail.QuestionCategory = wsDomande.GetValue(i, (int) Cell.CategoriaDomanda).ConvertToString();
                detail.QuestionText = wsDomande.GetValue(i, (int) Cell.TestoDomanda).ConvertToString();
                detail.Required = (wsDomande.GetValue(i, (int) Cell.Obbligatorio).ConvertToString()=="SI" ? true : false );
                detail.QuestionType = GetQuestionTypeFromCode(wsDomande.GetValue(i, (int) Cell.TipoDomanda).ConvertToString());
                detail.AnswerText = wsDomande.GetValue(i, (int)Cell.TestoRisposta).ConvertToString();
                detail.AnswerType = GetAnswerTypeFromCode(wsDomande.GetValue(i, (int) Cell.TipoRisposta).ConvertToString());
                detail.ContactTypeCode = GetContactTypeCode(wsDomande.GetValue(i, (int)Cell.TipoContacta).ConvertToString());
                detail.ProductCode = wsDomande.GetValue(i, (int) Cell.Prodotto).ConvertToString();
                detail.FromValue = wsDomande.GetValue(i, (int) Cell.DaValore).ConvertToInt();
                detail.ToValue = wsDomande.GetValue(i, (int) Cell.AValore).ConvertToInt();
                detail.Weight = wsDomande.GetValue(i, (int) Cell.Peso).ConvertToInt();
                detail.QuestionCategoryId = wsDomande.GetValue(i, (int) Cell.QuestionCategoryId).ConvertToInt();
                detail.QuestionId = wsDomande.GetValue(i, (int) Cell.QuestionId).ConvertToInt();
                detail.AnswerId = wsDomande.GetValue(i, (int) Cell.AnswerId).ConvertToInt();
                detail.AnswerWeightId = wsDomande.GetValue(i, (int) Cell.WeightId).ConvertToInt();

                questionnaireImport.Details.Add(detail);
            }

            pck.Dispose();
            return questionnaireImport;
        }

        private QuestionType GetQuestionTypeFromCode(string code)
        {
            switch (code)
            {
                case "MULTIPLA-ESCLUSIVA":
                    return QuestionType.MultipleExclusive;
                case "MULTIPLA-NON-ESCLUSIVA":
                    return QuestionType.MultipleNotExclusive;
                case "SOLO-VALORE":
                    return QuestionType.ValueOnly;
                default:
                    return 0;
            }
        }

        private string GetContactTypeCode(string code)
        {
            switch (code)
            {
                case "TUTTI":
                    return "";                
                default:
                    return code;
            }
        }

        private AdditionalInfoType? GetAnswerTypeFromCode(string code)
        {
            switch (code)
            {
                case "VEROFALSO":
                    return 0;
                case "NUMERICO":
                    return AdditionalInfoType.Numeric;
                case "TESTO":
                    return AdditionalInfoType.Text;
                default:
                    return null;
            }
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbPathExcel.Text = openFileDialog1.FileName;
        }


    }
}
