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
    public class ScheduleData : SqlConnector
    {
        /// <summary> Zwraca plan zajęć danej klasy </summary>
        public static ObservableCollection<ScheduleModel> GetAllSchedule(string clas)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM mydb.schedule " +
                    "WHERE schedule.Class = '" + clas + "'";
                var data = connection.Query<ScheduleModel>(sql).ToList();
                ObservableCollection<ScheduleModel> data2 = new ObservableCollection<ScheduleModel>(data);

                return data2;
            }
        }
    }
}
