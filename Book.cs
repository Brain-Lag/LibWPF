using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWPF
{
    public class Book
    {
        public string? Author { get; set; }
        public int VendorCode { get; set; }
        public DateOnly Year { get; set; }
        public int Amount { get; set; }
        public Book(string author, int vendorCode, DateOnly year, int amount) 
        {
            Author = author;
            VendorCode = vendorCode;
            Year = year;
            Amount = amount;
        }
    }
}
