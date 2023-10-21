using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWPF
{
    public class User : Notify
    {
        private int _id;
        public int Id 
        {
            get { return _id; } 
            set { _id = value; OnPropertyChanged("Id"); }
        }
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private string? _surname;
        public string? Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }
        private List<Book>? _userBooks;
        public List<Book>? UserBooks
        {
            get { return _userBooks; }
            set { _userBooks = value; OnPropertyChanged("UserBooks"); }
        }
    }
}
