using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class PresenceModel
    {
        public int IdPresence { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public int Hour { get; set; }
        public int Teacher_idTeacher { get; set; }
        public int Student_idStudent { get; set; }
        public string Subject_idSubject { get; set; }
        public string Text { get; set; }
        public bool Check { get; set; }
        public PresenceModel(int idPresence, string value, string date, int hour, int teacher_idTeacher, int student_idStudent, string subject_idSubject)
        {
            IdPresence = idPresence;
            Value = value;
            Date = date;
            Hour = hour;
            Teacher_idTeacher = teacher_idTeacher;
            Student_idStudent = student_idStudent;
            Subject_idSubject = subject_idSubject;
            Check = false;
        }

        public PresenceModel(string value, string date, int hour, int teacher_idTeacher, int student_idStudent, string subject_idSubject)
        {
            Value = value;
            Date = date;
            Hour = hour;
            Teacher_idTeacher = teacher_idTeacher;
            Student_idStudent = student_idStudent;
            Subject_idSubject = subject_idSubject;
            Check = false;
        }

        public PresenceModel()
        {

        }
    }
}
