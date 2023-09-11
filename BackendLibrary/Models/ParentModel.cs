using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class ParentModel
    {
        public int IdParent { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ParentModel(int idParent, string name, string surname, string username, string password)
        {
            IdParent = idParent;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }

        public ParentModel(int idParent)
        {
            IdParent = idParent;
        }

        public ParentModel()
        {

        }
    }
}
