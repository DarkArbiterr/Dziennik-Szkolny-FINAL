using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using BackendLibrary.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    public class TeacherData : SqlConnector
    {
        /// <summary> Zwraca dane zalogowanego nauczyciela </summary>
        public static TeacherModel GetTeacher(string username, string password)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.teacher WHERE teacher.username = '" + username + "' AND teacher.password = '" + password + "'";

                try
                {
                    var data = connection.Query<TeacherModel>(sql).First();
                    return data;
                }
                catch
                {
                    TeacherModel errorTeacher = new TeacherModel(-1);
                    return errorTeacher;
                }
            }
        }

        /// <summary> Zwraca nauczyciela o danym subject_id </summary>
        public static TeacherModel GetTeacherBySubjectId(string subject_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.teacher WHERE teacher.Subject_idSubject = '" + subject_id + "'";
                var data = connection.Query<TeacherModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca nauczyciela o danym teacher_id </summary>
        public static TeacherModel GetTeacherByTeacherId(int teacher_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.teacher WHERE teacher.idTeacher = '" + teacher_id + "'";
                var data = connection.Query<TeacherModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca id ostatniego inserta </summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idTeacher) from mydb.teacher";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }
    }
}
