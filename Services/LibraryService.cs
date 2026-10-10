using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Models;
using LibraryManagement.Interfaces;

namespace LibraryManagement.Services
{
    public class LibraryService : ILibraryService
    {
        
        private readonly List<Book> _books = new List<Book>();
        private readonly List<User> _users = new List<User>();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        
        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        
        public bool BorrowBook(int userId, string isbn)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            var book = _books.FirstOrDefault(b => b.Isbn == isbn && !b.IsBorrowed);

            if (user != null && book != null)
            {
                book.IsBorrowed = true; 
                user.BorrowedBooks.Add(book); 
                return true; 
            }
            return false; 
        }

        
        public bool ReturnBook(int userId, string isbn)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;

            var book = user.BorrowedBooks.FirstOrDefault(b => b.Isbn == isbn);

            if (book != null)
            {
                book.IsBorrowed = false; 
                user.BorrowedBooks.Remove(book); 
                return true;
            }
            return false;
        }

        
        public List<Book> FindBooks(Func<Book, bool> filter)
        {
            
            return _books.Where(filter).ToList();
        }
    }
}
