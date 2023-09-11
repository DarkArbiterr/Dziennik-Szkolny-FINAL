using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BackendLibrary.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    public class MarkData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich ocen danego ucznia </summary>
        public static ObservableCollection<MarkModel> GetAllForStudent(int student_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.mark WHERE mark.Student_idStudent = '" + student_id + "'";
                var data = connection.Query<MarkModel>(sql).ToList();

                ObservableCollection<MarkModel> data2 = new ObservableCollection<MarkModel>(data);

                return data2;
            }
        }

        /// <summary> Zwraca listę wszystkich ocen wystawionych przez danego nauczyciela danemu uczniowi </summary>
        public static ObservableCollection<MarkModel> GetAllForTeacher(int teacher_id, int student_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.mark WHERE mark.Teacher_idTeacher = '" + teacher_id + "' AND mark.Student_idStudent = '" + student_id + "'";
                var data = connection.Query<MarkModel>(sql).ToList();

                foreach (var d in data)
                {
                    d.Text = d.Value + " " + d.Date.Substring(0,10) + " " + d.Description;
                }

                ObservableCollection<MarkModel> data2 = new ObservableCollection<MarkModel>(data);

                return data2;
            }
        }

        /// <summary> Zwraca id ostatniego inserta </summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idMark) from mydb.mark";
                int id = connection.Query<int>(sql).First();
                
                return id;
            }
        }

        /// <summary> Usuwa daną ocenę </summary>
        public static int DeleteMark(int mark_id)
        {
            using(IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM mydb.mark WHERE mark.idMark = {mark_id}";

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }

        /// <summary> Dodaje ocenę </summary>
        public static void InsertMark(MarkModel newMark)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO mark (Value, Date, Description, Teacher_idTeacher, Student_idStudent, Subject_idSubject) VALUES " +
                    "('" + newMark.Value + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + newMark.Description + "', '" + newMark.Teacher_idTeacher + "', '" + newMark.Student_idStudent + "', '" + newMark.Subject_idSubject + "')";

                connection.Execute(sql, newMark);
            }
        }

        /// <summary> Aktualizuje ocenę </summary>
        public static void UpdateMark(MarkModel updatedMark)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"UPDATE mydb.mark SET Value = @Value, Date = @Date WHERE idMark = @IdMark";

                connection.Execute(sql, updatedMark);
            }
        }
    }
}
