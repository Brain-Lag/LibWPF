using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWPF
{
    public class Book : Notify
    {
        private string? _author;
        public string? Author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged("Author"); }
        }
        private int _vendorCode;
        public int VendorCode
        {
            get { return _vendorCode; }
            set { _vendorCode = value; OnPropertyChanged("VendorCode"); }
        }
        private DateOnly _year;
        public DateOnly Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged("Year"); }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged("Amount"); }
        }
    }
}
