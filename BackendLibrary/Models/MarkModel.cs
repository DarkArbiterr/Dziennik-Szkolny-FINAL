using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class MarkModel
    {
        public int IdMark { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Subject_idSubject { get; set; }
        public int Student_idStudent { get; set; }
        public int Teacher_idTeacher { get; set; }
        public string Text { get; set; }
        public bool Check{ get; set; }
        public MarkModel(string value, string date, string description, int teacher_idTeacher, int student_idStudent, string subject_idSubject)
        {
            Value = value;
            Date = date;
            Description = description;
            Teacher_idTeacher = teacher_idTeacher;
            Student_idStudent = student_idStudent;
            Subject_idSubject = subject_idSubject;
        }

        public MarkModel(int idMark, string value, string date, string description, int teacher_idTeacher, int student_idStudent, string subject_idSubject)
        {
            IdMark = idMark;
            Value = value;
            Date = date;
            Description = description;
            Teacher_idTeacher = teacher_idTeacher;
            Student_idStudent = student_idStudent;
            Subject_idSubject = subject_idSubject;
            Check = false;
        }

        public MarkModel()
        {

        }
    }

    
}
