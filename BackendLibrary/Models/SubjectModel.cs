using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class SubjectModel
    {
        public string IdSubject { get; set; }
        public string Name { get; set; }
        public string Classroom { get; set; }

        public SubjectModel(string idSubject, string name, string classroom)
        {
            IdSubject = idSubject;
            Name = name;
            Classroom = classroom;
        }

        public SubjectModel()
        {

        }
    }
}
