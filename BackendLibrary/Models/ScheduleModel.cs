using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class ScheduleModel
    {
        public int IdSchedule { get; set; }
        public string Day { get; set; }
        public int Hour { get; set; }
        public string Clas { get; set; }
        public string Subject_idSubject { get; set; }

        public ScheduleModel(int idSchedule, string day, int hour, string clas, string subject_idSubject, string subject_name, string teacher_name, string teacher_surname, string classroom)
        {
            IdSchedule = idSchedule;
            Day = day;
            Hour = hour;
            Clas = clas;
            Subject_idSubject = subject_idSubject;
        }

        public ScheduleModel()
        {

        }
    }
}
