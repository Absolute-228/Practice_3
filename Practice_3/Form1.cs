using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();
                MessageBox.Show("База подключена");
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=practice_3.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @" 
                  CREATE TABLE IF NOT EXISTS Practice_3(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Year INTEGER,
                    GroupName TEXT,
                 SubjectName TEXT,
                 TeacherName TEXT,
                 TotalHours INTEGER,
                 LectureHours INTEGER,
                 PracticeHours INTEGER,
                 LabHours INTEGER,
                 ExamType TEXT,
                 Semester INTEGER,
                 Credits INTEGER,
                 Department TEXT
                )";

                using (var cmd = new  SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Таблица создана");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                string sql = @"
        INSERT INTO Practice_3 
        (Year, GroupName, SubjectName, TeacherName, TotalHours,
         LectureHours, PracticeHours, LabHours, ExamType,
         Semester, Credits, Department)
        VALUES
        (@Year, @GroupName, @SubjectName, @TeacherName, @TotalHours,
         @LectureHours, @PracticeHours, @LabHours, @ExamType,
         @Semester, @Credits, @Department);";

                using (var cmd = new SQLiteCommand(sql, db))
                {
                    cmd.Parameters.AddWithValue("@Year", int.Parse(textYear.Text));
                    cmd.Parameters.AddWithValue("@GroupName", textGroupName.Text);
                    cmd.Parameters.AddWithValue("@SubjectName", textSubjectName.Text);
                    cmd.Parameters.AddWithValue("@TeacherName", textTeacherName.Text);
                    cmd.Parameters.AddWithValue("@TotalHours", int.Parse(textTotalHours.Text));

                    cmd.Parameters.AddWithValue("@LectureHours", int.Parse(textLectureHours.Text));
                    cmd.Parameters.AddWithValue("@PracticeHours", int.Parse(textPracticeHours.Text));
                    cmd.Parameters.AddWithValue("@LabHours", int.Parse(textLabHours.Text));

                    cmd.Parameters.AddWithValue("@ExamType", textExamType.Text);
                    cmd.Parameters.AddWithValue("@Semester", int.Parse(textSemester.Text));
                    cmd.Parameters.AddWithValue("@Credits", int.Parse(textCredits.Text));
                    cmd.Parameters.AddWithValue("@Department", textDepartment.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Добавлено!");
            }
        }
    }
}
