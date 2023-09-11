using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class StudentModel
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Clas { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Parent_idParent { get; set; }
        public string Text { get; set; }
        public bool Check { get; set; }

        public StudentModel(int idStudent, string name, string surname, string clas, string username, string password, int parent_idParent)
        {
            IdStudent = idStudent;
            Name = name;
            Surname = surname;
            Clas = clas;
            Username = username;
            Password = password;
            Parent_idParent = parent_idParent;
            Check = false;
        }

        public StudentModel(int idStudent)
        {
            IdStudent = idStudent;
        }

        public StudentModel()
        {

        }
    }
}
