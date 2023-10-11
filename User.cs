using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWPF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book>? Books { get; set; }
        public User (int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Books = new List<Book>();
        }
    }
}
