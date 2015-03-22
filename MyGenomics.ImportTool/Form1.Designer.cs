namespace MyGenomics.ImportTool
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuestionnaireName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImportQuestionnaire = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPathExcel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbQuestionnaires = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice Questionario";
            // 
            // tbQuestionnaireName
            // 
            this.tbQuestionnaireName.Location = new System.Drawing.Point(171, 30);
            this.tbQuestionnaireName.Name = "tbQuestionnaireName";
            this.tbQuestionnaireName.Size = new System.Drawing.Size(198, 20);
            this.tbQuestionnaireName.TabIndex = 3;
            this.tbQuestionnaireName.Text = "Test da import";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome Questionario";
            // 
            // btnImportQuestionnaire
            // 
            this.btnImportQuestionnaire.Location = new System.Drawing.Point(16, 57);
            this.btnImportQuestionnaire.Name = "btnImportQuestionnaire";
            this.btnImportQuestionnaire.Size = new System.Drawing.Size(736, 23);
            this.btnImportQuestionnaire.TabIndex = 4;
            this.btnImportQuestionnaire.Text = "Importa";
            this.btnImportQuestionnaire.UseVisualStyleBackColor = true;
            this.btnImportQuestionnaire.Click += new System.EventHandler(this.btnImportQuestionnaire_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(16, 109);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(736, 207);
            this.tbLog.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log";
            // 
            // tbPathExcel
            // 
            this.tbPathExcel.Location = new System.Drawing.Point(378, 30);
            this.tbPathExcel.Name = "tbPathExcel";
            this.tbPathExcel.Size = new System.Drawing.Size(374, 20);
            this.tbPathExcel.TabIndex = 8;
            this.tbPathExcel.Text = "c:/Questionario Data Entry.xlsx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Path Excel";
            // 
            // cbQuestionnaires
            // 
            this.cbQuestionnaires.FormattingEnabled = true;
            this.cbQuestionnaires.Location = new System.Drawing.Point(16, 28);
            this.cbQuestionnaires.Name = "cbQuestionnaires";
            this.cbQuestionnaires.Size = new System.Drawing.Size(149, 21);
            this.cbQuestionnaires.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 328);
            this.Controls.Add(this.cbQuestionnaires);
            this.Controls.Add(this.tbPathExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnImportQuestionnaire);
            this.Controls.Add(this.tbQuestionnaireName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQuestionnaireName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportQuestionnaire;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPathExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbQuestionnaires;
    }
}

