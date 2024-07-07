namespace JavaToJSTranslator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtJavaCode = new TextBox();
            txtTranslatedCode = new TextBox();
            btnTranslate = new Button();
            cmbTargetLanguage = new ComboBox();
            SuspendLayout();
            // 
            // txtJavaCode
            // 
            txtJavaCode.Location = new Point(12, 12);
            txtJavaCode.Multiline = true;
            txtJavaCode.Name = "txtJavaCode";
            txtJavaCode.Size = new Size(339, 210);
            txtJavaCode.TabIndex = 0;
            // 
            // txtTranslatedCode
            // 
            txtTranslatedCode.Location = new Point(449, 12);
            txtTranslatedCode.Multiline = true;
            txtTranslatedCode.Name = "txtTranslatedCode";
            txtTranslatedCode.Size = new Size(339, 210);
            txtTranslatedCode.TabIndex = 1;
            // 
            // btnTranslate
            // 
            btnTranslate.Location = new Point(357, 128);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(86, 23);
            btnTranslate.TabIndex = 2;
            btnTranslate.Text = "Traducir";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += btnTranslate_Click;
            // 
            // cmbTargetLanguage
            // 
            cmbTargetLanguage.FormattingEnabled = true;
            cmbTargetLanguage.Location = new Point(12, 239);
            cmbTargetLanguage.Name = "cmbTargetLanguage";
            cmbTargetLanguage.Size = new Size(121, 23);
            cmbTargetLanguage.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbTargetLanguage);
            Controls.Add(btnTranslate);
            Controls.Add(txtTranslatedCode);
            Controls.Add(txtJavaCode);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtJavaCode;
        private TextBox txtTranslatedCode;
        private Button btnTranslate;
        private ComboBox cmbTargetLanguage;
    }
}
