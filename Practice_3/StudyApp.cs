using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_3
{
    public partial class StudyApp : Form
    {
        public StudyApp()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFilters();
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
            btnLoad_Click(null, null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=practice_3.db";
            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                string sql = @"SELECT * FROM Practice_3";

                using (var adapter = new SQLiteDataAdapter(sql, connectionString))
                {
                    DataTable table = new DataTable();

                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void LoadFilters()
        {
            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                // ГОДЫ
                var yearsCmd = new SQLiteCommand("SELECT DISTINCT Year FROM Practice_3", db);
                var reader1 = yearsCmd.ExecuteReader();

                cbYear.Items.Clear();
                cbYear1.Items.Clear();
                cbYear2.Items.Clear();

                while (reader1.Read())
                {
                    var year = reader1["Year"].ToString();
                    cbYear.Items.Add(year);
                    cbYear1.Items.Add(year);
                    cbYear2.Items.Add(year);
                }

                // ГРУППЫ
                var groupCmd = new SQLiteCommand("SELECT DISTINCT GroupName FROM Practice_3", db);
                var reader2 = groupCmd.ExecuteReader();

                cbGroup.Items.Clear();

                while (reader2.Read())
                {
                    cbGroup.Items.Add(reader2["GroupName"].ToString());
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                string sql = @"
        SELECT * FROM Practice_3
        WHERE Year = @Year AND GroupName = @Group";

                using (var cmd = new SQLiteCommand(sql, db))
                {
                    cmd.Parameters.AddWithValue("@Year", cbYear.Text);
                    cmd.Parameters.AddWithValue("@Group", cbGroup.Text);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }


        }


        private void HighlightDifferences(List<StudyPlan> list1, List<StudyPlan> list2)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["SubjectName"].Value == null) continue;

                string subject = row.Cells["SubjectName"].Value.ToString();
                string group = row.Cells["GroupName"].Value.ToString();

                var oldItem = list1.FirstOrDefault(x => x.SubjectName == subject && x.GroupName == group);
                var newItem = list2.FirstOrDefault(x => x.SubjectName == subject && x.GroupName == group);

                if (oldItem == null)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen; // добавлено
                }
                else if (newItem == null)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral; // удалено
                }
                else if (oldItem.TotalHours != newItem.TotalHours)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow; // изменено
                }
            }
        }


        private void btnCompare_Click(object sender, EventArgs e)
        {
            var year1 = cbYear1.Text;
            var year2 = cbYear2.Text;

            var list1 = GetPlansByYear(year1);
            var list2 = GetPlansByYear(year2);

            // Показываем новый план
            dataGridView1.DataSource = list2;

            HighlightDifferences(list1, list2);
        }

        public List<StudyPlan> GetPlansByYear(string year)
        {
            var list = new List<StudyPlan>();
            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                string sql = "SELECT * FROM Practice_3 WHERE Year = @Year";

                using (var cmd = new SQLiteCommand(sql, db))
                {
                    cmd.Parameters.AddWithValue("@Year", year);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new StudyPlan
                            {
                                SubjectName = reader["SubjectName"].ToString(),
                                GroupName = reader["GroupName"].ToString(),
                                TotalHours = Convert.ToInt32(reader["TotalHours"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                var cmd = new SQLiteCommand("DELETE FROM Practice_3 WHERE Id = @Id", db);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Удалено");
            btnLoad_Click(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            string connectionString = "Data Source=practice_3.db;";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.Open();

                string sql = @"
        UPDATE Practice_3 SET
            SubjectName = @Subject,
            TotalHours = @Hours
        WHERE Id = @Id";

                var cmd = new SQLiteCommand(sql, db);

                cmd.Parameters.AddWithValue("@Subject", textSubjectName.Text);
                cmd.Parameters.AddWithValue("@Hours", int.Parse(textTotalHours.Text));
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Обновлено");
            btnLoad_Click(null, null);
        }
    }
}
