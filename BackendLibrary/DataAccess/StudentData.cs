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
    public class StudentData : SqlConnector
    {
        /// <summary> Zwraca liste studentow danej klasy </summary>
        public static ObservableCollection<StudentModel> GetAllClassStudents(string clas)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM student" +
                    " WHERE student.Class = '" + clas +
                    "' ORDER BY student.Surname";
                var data = connection.Query<StudentModel>(sql).ToList();

                foreach (var d in data)
                {
                    d.Text = d.IdStudent.ToString() + " " + d.Name + " " + d.Surname;
                }

                ObservableCollection<StudentModel> data2 = new ObservableCollection<StudentModel>(data);

                return data2;
            }
        }

        /// <summary> Zwraca id ostatniego inserta </summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idStudent) from mydb.student";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        /// <summary> Zwraca dane zalogowanego studenta </summary>
        public static StudentModel GetStudent(string username, string password)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.student WHERE student.username = '" + username + "' AND student.password = '" + password + "'";

                try
                {
                    var data = connection.Query<StudentModel>(sql).First();
                    return data;
                }
                catch
                {
                    StudentModel errorStudent = new StudentModel(-1);
                    return errorStudent;
                }
            }

        }

        public static StudentModel GetStudentByParentId(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.student WHERE student.Parent_idParent = '" + id + "'";
                try
                {
                    var data = connection.Query<StudentModel>(sql).First();
                    return data;
                }
                catch
                {
                    StudentModel errorStudent = new StudentModel(-1);
                    return errorStudent;
                }
            }

        }
    }
}
