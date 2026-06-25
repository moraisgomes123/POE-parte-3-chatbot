using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CybersecurityChatbot.Database
{
    public class DatabaseHelper
    {
        private string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=CyberSecurityBotDB;Trusted_Connection=True;";

        // =========================
        // ADD TASK
        // =========================
        public bool AddTask(TaskModel task)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = @"
                INSERT INTO Tasks (Title, Description, ReminderDate)
                VALUES (@Title, @Description, @ReminderDate)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", task.Title);

                cmd.Parameters.AddWithValue("@Description",
                    task.Description == null ? "" : task.Description);

                if (task.ReminderDate.HasValue)
                    cmd.Parameters.AddWithValue("@ReminderDate", task.ReminderDate.Value);
                else
                    cmd.Parameters.AddWithValue("@ReminderDate", DBNull.Value);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                conn.Close();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // GET TASKS
        // =========================
        public List<TaskModel> GetTasks()
        {
            List<TaskModel> list = new List<TaskModel>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = "SELECT * FROM Tasks ORDER BY TaskId DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskModel task = new TaskModel();

                    task.TaskId = Convert.ToInt32(reader["TaskId"]);
                    task.Title = reader["Title"].ToString();
                    task.Description = reader["Description"].ToString();

                    if (reader["ReminderDate"] == DBNull.Value)
                        task.ReminderDate = null;
                    else
                        task.ReminderDate = Convert.ToDateTime(reader["ReminderDate"]);

                    task.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    task.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);

                    list.Add(task);
                }

                reader.Close();
                conn.Close();
            }
            catch
            {
            }

            return list;
        }

        // =========================
        // MARK COMPLETE
        // =========================
        public bool MarkCompleted(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = "UPDATE Tasks SET IsCompleted = 1 WHERE TaskId = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                conn.Close();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // DELETE TASK
        // =========================
        public bool DeleteTask(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = "DELETE FROM Tasks WHERE TaskId = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                conn.Close();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // ACTIVITY LOG
        // =========================
        public void AddActivity(string type, string description)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = @"
                INSERT INTO ActivityLog (ActivityType, Description)
                VALUES (@Type, @Desc)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Desc", description);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
            }
        }

        public List<string> GetRecentActivity(int limit)
        {
            List<string> logs = new List<string>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = @"
                SELECT TOP (@Limit)
                ActivityType + ': ' + Description AS LogEntry
                FROM ActivityLog
                ORDER BY CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Limit", limit);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    logs.Add(reader["LogEntry"].ToString());
                }

                reader.Close();
                conn.Close();
            }
            catch
            {
            }

            return logs;
        }

        // =========================
        // QUIZ RESULT
        // =========================
        public void SaveQuizResult(int score, int total)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                string query = @"
                INSERT INTO QuizHistory (Score, TotalQuestions)
                VALUES (@Score, @Total)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@Total", total);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
            }
        }
    }
}