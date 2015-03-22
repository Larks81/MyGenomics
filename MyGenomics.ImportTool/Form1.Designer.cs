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
            this.btnImportQuestionnaire = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPathExcel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.tbPathExcel.Location = new System.Drawing.Point(16, 30);
            this.tbPathExcel.Name = "tbPathExcel";
            this.tbPathExcel.Size = new System.Drawing.Size(687, 20);
            this.tbPathExcel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Path Excel";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Location = new System.Drawing.Point(709, 29);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(43, 22);
            this.btnSearchFile.TabIndex = 9;
            this.btnSearchFile.Text = "...";
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 328);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.tbPathExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnImportQuestionnaire);
            this.Name = "Form1";
            this.Text = "Import Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportQuestionnaire;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPathExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSearchFile;
    }
}

