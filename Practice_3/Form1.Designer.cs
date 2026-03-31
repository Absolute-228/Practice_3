namespace Practice_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textGroupName = new System.Windows.Forms.TextBox();
            this.textSubjectName = new System.Windows.Forms.TextBox();
            this.textTeacherName = new System.Windows.Forms.TextBox();
            this.textTotalHours = new System.Windows.Forms.TextBox();
            this.textExamType = new System.Windows.Forms.TextBox();
            this.textLabHours = new System.Windows.Forms.TextBox();
            this.textPracticeHours = new System.Windows.Forms.TextBox();
            this.textLectureHours = new System.Windows.Forms.TextBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.textDepartment = new System.Windows.Forms.TextBox();
            this.textCredits = new System.Windows.Forms.TextBox();
            this.textSemester = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1184, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textGroupName
            // 
            this.textGroupName.Location = new System.Drawing.Point(88, 76);
            this.textGroupName.Name = "textGroupName";
            this.textGroupName.Size = new System.Drawing.Size(100, 26);
            this.textGroupName.TabIndex = 1;
            // 
            // textSubjectName
            // 
            this.textSubjectName.Location = new System.Drawing.Point(88, 157);
            this.textSubjectName.Name = "textSubjectName";
            this.textSubjectName.Size = new System.Drawing.Size(100, 26);
            this.textSubjectName.TabIndex = 2;
            // 
            // textTeacherName
            // 
            this.textTeacherName.Location = new System.Drawing.Point(88, 265);
            this.textTeacherName.Name = "textTeacherName";
            this.textTeacherName.Size = new System.Drawing.Size(100, 26);
            this.textTeacherName.TabIndex = 3;
            // 
            // textTotalHours
            // 
            this.textTotalHours.Location = new System.Drawing.Point(88, 365);
            this.textTotalHours.Name = "textTotalHours";
            this.textTotalHours.Size = new System.Drawing.Size(100, 26);
            this.textTotalHours.TabIndex = 4;
            // 
            // textExamType
            // 
            this.textExamType.Location = new System.Drawing.Point(289, 365);
            this.textExamType.Name = "textExamType";
            this.textExamType.Size = new System.Drawing.Size(100, 26);
            this.textExamType.TabIndex = 8;
            // 
            // textLabHours
            // 
            this.textLabHours.Location = new System.Drawing.Point(289, 265);
            this.textLabHours.Name = "textLabHours";
            this.textLabHours.Size = new System.Drawing.Size(100, 26);
            this.textLabHours.TabIndex = 7;
            // 
            // textPracticeHours
            // 
            this.textPracticeHours.Location = new System.Drawing.Point(289, 157);
            this.textPracticeHours.Name = "textPracticeHours";
            this.textPracticeHours.Size = new System.Drawing.Size(100, 26);
            this.textPracticeHours.TabIndex = 6;
            // 
            // textLectureHours
            // 
            this.textLectureHours.Location = new System.Drawing.Point(289, 76);
            this.textLectureHours.Name = "textLectureHours";
            this.textLectureHours.Size = new System.Drawing.Size(100, 26);
            this.textLectureHours.TabIndex = 5;
            // 
            // textYear
            // 
            this.textYear.Location = new System.Drawing.Point(529, 365);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(100, 26);
            this.textYear.TabIndex = 12;
            // 
            // textDepartment
            // 
            this.textDepartment.Location = new System.Drawing.Point(529, 265);
            this.textDepartment.Name = "textDepartment";
            this.textDepartment.Size = new System.Drawing.Size(100, 26);
            this.textDepartment.TabIndex = 11;
            // 
            // textCredits
            // 
            this.textCredits.Location = new System.Drawing.Point(529, 157);
            this.textCredits.Name = "textCredits";
            this.textCredits.Size = new System.Drawing.Size(100, 26);
            this.textCredits.TabIndex = 10;
            // 
            // textSemester
            // 
            this.textSemester.Location = new System.Drawing.Point(529, 76);
            this.textSemester.Name = "textSemester";
            this.textSemester.Size = new System.Drawing.Size(100, 26);
            this.textSemester.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(65, 690);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 39);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(480, 690);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(115, 39);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "Создать дб";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 818);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textYear);
            this.Controls.Add(this.textDepartment);
            this.Controls.Add(this.textCredits);
            this.Controls.Add(this.textSemester);
            this.Controls.Add(this.textExamType);
            this.Controls.Add(this.textLabHours);
            this.Controls.Add(this.textPracticeHours);
            this.Controls.Add(this.textLectureHours);
            this.Controls.Add(this.textTotalHours);
            this.Controls.Add(this.textTeacherName);
            this.Controls.Add(this.textSubjectName);
            this.Controls.Add(this.textGroupName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textGroupName;
        private System.Windows.Forms.TextBox textSubjectName;
        private System.Windows.Forms.TextBox textTeacherName;
        private System.Windows.Forms.TextBox textTotalHours;
        private System.Windows.Forms.TextBox textExamType;
        private System.Windows.Forms.TextBox textLabHours;
        private System.Windows.Forms.TextBox textPracticeHours;
        private System.Windows.Forms.TextBox textLectureHours;
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.TextBox textDepartment;
        private System.Windows.Forms.TextBox textCredits;
        private System.Windows.Forms.TextBox textSemester;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCreate;
    }
}

