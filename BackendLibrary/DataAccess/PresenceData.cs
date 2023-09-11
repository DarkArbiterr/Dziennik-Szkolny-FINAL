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
    public class PresenceData : SqlConnector
    {
        /// <summary> Wyswietla wszystkie nieobecnosci danego ucznia </summary>
        public static ObservableCollection<PresenceModel> GetAllStudentPresence(int student_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.presence WHERE presence.Student_idStudent = '" + student_id + "'";
                var data = connection.Query<PresenceModel>(sql).ToList();

                ObservableCollection<PresenceModel> data2 = new ObservableCollection<PresenceModel>(data);

                return data2;
            }
        }

        /// <summary> Wyswietla wszystkie nieobecnosci z danego przedmiotu </summary>
        public static ObservableCollection<PresenceModel> GetAllSubjectPresence(string subject_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.presence WHERE presence.Subject_idSubject = '" + subject_id + "' ORDER BY presence.date";
                var data = connection.Query<PresenceModel>(sql).ToList();
                string sql2 = "SELECT student.name, student.surname FROM mydb.presence JOIN student ON student.idStudent = presence.Student_idStudent WHERE presence.Subject_idSubject = '" + subject_id + "' ORDER BY presence.date";
                var data2 = connection.Query<StudentModel>(sql2).ToList();

                for (int i = 0; i < data.Count; i++)
                {
                    data[i].Text = data[i].Date.Substring(0, 10) + "     " + data[i].Hour.ToString() + ":00    " + data2[i].Name + " " + data2[i].Surname;
                }

                ObservableCollection<PresenceModel> data3 = new ObservableCollection<PresenceModel>(data);

                return data3;
            }
        }

        /// <summary> Usuwa daną nieobecnosc </summary>
        public static int DeletePresence(int idPresence)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM mydb.presence WHERE presence.idPresence = {idPresence}";

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }

        /// <summary> Dodaje nieobecnosc </summary>
        public static void InsertPresence(PresenceModel newPresence)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO presence (Value, Date, Hour, Teacher_idTeacher, Student_idStudent, Subject_idSubject) VALUES " +
                        "('" + "NIE" + "', '" + newPresence.Date + "', '" + newPresence.Hour + "', '" + newPresence.Teacher_idTeacher + "', '" + newPresence.Student_idStudent + "', '" + newPresence.Subject_idSubject + "')";

                connection.Execute(sql, newPresence);
            }
        }

        /// <summary> Sprawdza czy dana nieobecnosc juz istnieje w bazie danych </summary>
        public static bool CheckPresence(int idStudent, string date, int hour)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(presence.idPresence) FROM mydb.presence WHERE Student_idStudent = '" + idStudent + "' AND Date = '" + date + "' AND Hour = '" + hour + "' ";
                int count = connection.Query<int>(sql).First();

                if (count == 1)
                    return true;
                else
                    return false;
            }
        }

        /// <summary> Zwraca ostatnio wykonany insert </summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idPresence) from mydb.presence";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }
    }
}
