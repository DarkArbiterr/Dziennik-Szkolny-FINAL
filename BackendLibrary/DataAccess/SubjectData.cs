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
    public class SubjectData : SqlConnector
    {
        /// <summary> Zwraca przedmiot o danym id </summary>
        public static SubjectModel GetSubjectById(string subject_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.subject WHERE subject.idSubject = '" + subject_id + "'";
                var data = connection.Query<SubjectModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca przedmiot o najwiekszym id </summary>
        public static string GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idSubject) from mydb.subject";
                string id = connection.Query<string>(sql).First();

                return id;
            }
        }
    }
}
