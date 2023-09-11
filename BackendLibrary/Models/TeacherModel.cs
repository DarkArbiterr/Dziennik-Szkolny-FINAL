using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class TeacherModel
    {
        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Subject_idSubject { get; set; }

        public TeacherModel(int idTeacher, string name, string surname, string username, string password, string subject_idSubject)
        {
            IdTeacher = idTeacher;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Subject_idSubject = subject_idSubject;
        }

        public TeacherModel(int idTeacher)
        {
            IdTeacher = idTeacher;
        }

        public TeacherModel()
        {

        }
    }
}
