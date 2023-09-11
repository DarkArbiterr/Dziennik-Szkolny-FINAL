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
    public class ParentData : SqlConnector
    {
        /// <summary> Zwraca dane zalogowanego rodzica </summary>
        public static ParentModel GetParent(string username, string password)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.parent WHERE parent.username = '" + username +"' AND parent.password = '" + password +"'";

                try
                {
                    var data = connection.Query<ParentModel>(sql).First();
                    return data;
                }
                catch
                {
                    ParentModel errorParent = new ParentModel(-1);
                    return errorParent;
                }

                
            }
            
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(idParent) from mydb.parent";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }
    }
}
