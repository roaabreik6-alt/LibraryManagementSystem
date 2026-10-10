using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> BorrowedBooks { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }
    }
}
