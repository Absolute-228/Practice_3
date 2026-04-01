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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var year1 = cbYear1.Text;
            var year2 = cbYear2.Text;

            var list1 = GetPlansByYear(year1);
            var list2 = GetPlansByYear(year2);

            List<string> differences = new List<string>();

            foreach (var oldItem in list1)
            {
                var newItem = list2.FirstOrDefault(x =>
                    x.SubjectName == oldItem.SubjectName &&
                    x.GroupName == oldItem.GroupName);

                if (newItem == null)
                {
                    differences.Add($"❌ Убрана: {oldItem.SubjectName}");
                    continue;
                }

                if (oldItem.TotalHours != newItem.TotalHours)
                {
                    differences.Add($"⚠ {oldItem.SubjectName}: {oldItem.TotalHours} → {newItem.TotalHours}");
                }
            }

            foreach (var newItem in list2)
            {
                var oldItem = list1.FirstOrDefault(x =>
                    x.SubjectName == newItem.SubjectName &&
                    x.GroupName == newItem.GroupName);

                if (oldItem == null)
                {
                    differences.Add($"🆕 Добавлена: {newItem.SubjectName}");
                }
            }

            MessageBox.Show(string.Join("\n", differences));
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
    }
}
