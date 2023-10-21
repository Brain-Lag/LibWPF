using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibWPF
{
    public class Applications : Notify
    {
        private User? _selectedUser;
        public User? SelectedUser
        {
            get { return _selectedUser; } 
            set { _selectedUser = value; OnPropertyChanged("SelectedUser"); }
        }

        private Book? _selectedBook;
        public Book? SelectedBook
        {
            get { return _selectedBook; }
            set { _selectedBook = value; OnPropertyChanged("SelectedBook"); }
        }

        private User? _searchReader;
        public User? SearchReader 
        { 
            get { return _searchReader; } 
            set { _searchReader = value; OnPropertyChanged("SearchReader"); } 
        }
        private RelayCommand? _addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ??
                    (_addUserCommand = new RelayCommand(obj =>
                    {
                        User? user = new User();
                        Users.Add(user);
                        SelectedUser = user;
                    }));
            }
        }
        
        private RelayCommand? _removeUserCommand;
        public RelayCommand RemoveUserCommand
        {
            get
            {
                return _removeUserCommand ??
                    (_removeUserCommand = new RelayCommand(obj =>
                    {
                        User? user = obj as User;
                        if (user != null)
                        {
                            Users.Remove(user);
                            MessageBox.Show("Пользователь " + user.Name + " " + user.Surname + " удалён.");
                        }
                    },
                    (obj) => Users.Count > 0));
            }
        }

        private RelayCommand? _addBookCommand;
        public RelayCommand? AddBookCommand
        {
            get
            {
                return _addBookCommand ??
                    (_addBookCommand = new RelayCommand(obj =>
                    {
                        Book book = new Book();
                        Books.Add(book);
                        SelectedBook = book;
                    }));
            }
        }

        private RelayCommand? _removeBookCommand;

        public RelayCommand? RemoveBookCommand
        {
            get
            {
                return _removeBookCommand ??
                    (_removeBookCommand = new RelayCommand(obj =>
                    {
                        Book? book = obj as Book;
                        if (book != null)
                        {
                            Books.Remove(book);
                            MessageBox.Show("Книга " + book.Author + " удалена.");
                        }
                    },
                    (obj) => Books.Count > 0));
            }
        }
        public RelayCommand AddBookToUserCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedUser != null && SelectedBook != null)
                    {
                        if (SelectedBook.Amount > 0)
                        {
                            SelectedBook.Amount--;
                            Book addedBook = new Book
                            {
                                Author = SelectedBook.Author,
                                VendorCode = SelectedBook.VendorCode,
                                Year = SelectedBook.Year,
                                Amount = 1
                            };
                            SelectedUser.UserBooks.Add(addedBook);
                            MessageBox.Show("Книга успешно выдана.");
                            if (SelectedBook.Amount == 0)
                            {
                                MessageBox.Show("Нет доступных экземпляров книги");
                            }
                        }
                    }
                });
            }
        }
        public ObservableCollection<User>? Users { get; set; }
        public ObservableCollection<Book>? Books { get; set; }
        public Applications()
        {
            Users = new ObservableCollection<User>()
            {
                new User {Id = 1, Name = "Прав", Surname = "Левов", UserBooks = new List<Book>() },
                new User {Id = 2, Name = "Лев", Surname = "Правов", UserBooks= new List<Book>() },
                new User {Id = 3, Name = "Владимир", Surname = "Скопин", UserBooks = new List<Book>()}
            };
            Books = new ObservableCollection<Book>()
            {
                new Book {Author = "Лев Толстой - 'Война и Мир'", VendorCode = 123, Year = new DateOnly(1867,1,1), Amount = 100},
                new Book {Author = "Олдос Хаксли - 'О дивный новый мир'", VendorCode = 123321, Year = new DateOnly(1932,1,1), Amount = 50}
            };
        }
    }
}
