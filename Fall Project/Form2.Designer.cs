namespace Fall_Project
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxStId = new System.Windows.Forms.ComboBox();
            this.comboBoxCId = new System.Windows.Forms.ComboBox();
            this.comboBoxProgId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStName = new System.Windows.Forms.TextBox();
            this.textBoxCName = new System.Windows.Forms.TextBox();
            this.textBoxProgName = new System.Windows.Forms.TextBox();
            this.textBoxFinalGrade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxStId
            // 
            this.comboBoxStId.FormattingEnabled = true;
            this.comboBoxStId.Location = new System.Drawing.Point(42, 59);
            this.comboBoxStId.Name = "comboBoxStId";
            this.comboBoxStId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStId.TabIndex = 0;
            this.comboBoxStId.SelectedValueChanged += new System.EventHandler(this.comboBoxStId_SelectedValueChanged);
            // 
            // comboBoxCId
            // 
            this.comboBoxCId.FormattingEnabled = true;
            this.comboBoxCId.Location = new System.Drawing.Point(264, 59);
            this.comboBoxCId.Name = "comboBoxCId";
            this.comboBoxCId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCId.TabIndex = 1;
            this.comboBoxCId.SelectedValueChanged += new System.EventHandler(this.comboBoxCId_SelectedValueChanged);
            // 
            // comboBoxProgId
            // 
            this.comboBoxProgId.FormattingEnabled = true;
            this.comboBoxProgId.Location = new System.Drawing.Point(485, 59);
            this.comboBoxProgId.Name = "comboBoxProgId";
            this.comboBoxProgId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProgId.TabIndex = 2;
            this.comboBoxProgId.SelectedValueChanged += new System.EventHandler(this.comboBoxProgId_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Progam ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Program Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Course Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Student Name";
            // 
            // textBoxStName
            // 
            this.textBoxStName.Location = new System.Drawing.Point(42, 136);
            this.textBoxStName.Name = "textBoxStName";
            this.textBoxStName.Size = new System.Drawing.Size(121, 20);
            this.textBoxStName.TabIndex = 9;
            // 
            // textBoxCName
            // 
            this.textBoxCName.Location = new System.Drawing.Point(264, 136);
            this.textBoxCName.Name = "textBoxCName";
            this.textBoxCName.Size = new System.Drawing.Size(121, 20);
            this.textBoxCName.TabIndex = 10;
            // 
            // textBoxProgName
            // 
            this.textBoxProgName.Location = new System.Drawing.Point(485, 136);
            this.textBoxProgName.Name = "textBoxProgName";
            this.textBoxProgName.Size = new System.Drawing.Size(121, 20);
            this.textBoxProgName.TabIndex = 11;
            // 
            // textBoxFinalGrade
            // 
            this.textBoxFinalGrade.Location = new System.Drawing.Point(265, 210);
            this.textBoxFinalGrade.Name = "textBoxFinalGrade";
            this.textBoxFinalGrade.Size = new System.Drawing.Size(121, 20);
            this.textBoxFinalGrade.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Final Grade";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(42, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 305);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxFinalGrade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxProgName);
            this.Controls.Add(this.textBoxCName);
            this.Controls.Add(this.textBoxStName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProgId);
            this.Controls.Add(this.comboBoxCId);
            this.Controls.Add(this.comboBoxStId);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStId;
        private System.Windows.Forms.ComboBox comboBoxCId;
        private System.Windows.Forms.ComboBox comboBoxProgId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStName;
        private System.Windows.Forms.TextBox textBoxCName;
        private System.Windows.Forms.TextBox textBoxProgName;
        private System.Windows.Forms.TextBox textBoxFinalGrade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}