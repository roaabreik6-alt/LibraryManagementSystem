using System;
using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface ILibraryService
    {
        void AddBook(Book book);
        void RegisterUser(User user);
        bool BorrowBook(int userId, string isbn);
        bool ReturnBook(int userId, string isbn);

        List<Book> FindBooks(Func<Book, bool> filter);
    }
}
