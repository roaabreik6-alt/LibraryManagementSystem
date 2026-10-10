using System;
using System.Collections.Generic;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.Interfaces;
namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ILibraryService library = new LibraryService();
            library.AddBook(new Book("111", "C# Programming", "Ameen Al-Shalabi"));
            library.AddBook(new Book("222", "Clean Architecture", "Robert Martin"));
            library.AddBook(new Book("333", "Design Patterns", "Gang of Four"));
            library.RegisterUser(new User(1, "Ahmad"));
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("    PRIME ACADEMY - LIBRARY SYSTEM       ");
                Console.WriteLine("=========================================");
                Console.ResetColor();
                Console.WriteLine("1. Add a New Book");
                Console.WriteLine("2. Register a New User");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. Search/Filter Books (Demonstrating Delegate)");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option (1-6): ");

                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                       library.AddBook(new Book(isbn, title, author));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔️ Book added successfully!");
                        Console.ResetColor();
                        break;

                    case "2":
                        Console.Write("Enter User ID (Number): ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Write("Enter User Name: ");
                            string name = Console.ReadLine();
                            library.RegisterUser(new User(id, name));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✔️ User registered successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Invalid ID format.");
                        }
                        Console.ResetColor();
                        break;

                    case "3":
                        Console.Write("Enter User ID: ");
                        int.TryParse(Console.ReadLine(), out int bUserId);
                        Console.Write("Enter Book ISBN to borrow: ");
                        string bIsbn = Console.ReadLine();

                        if (library.BorrowBook(bUserId, bIsbn))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✔️ Book borrowed successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Borrowing failed. Check User ID or Book availability.");
                        }
                        Console.ResetColor();
                        break;

                    case "4":
                        Console.Write("Enter User ID: ");
                        int.TryParse(Console.ReadLine(), out int rUserId);
                        Console.Write("Enter Book ISBN to return: ");
                        string rIsbn = Console.ReadLine();

                        if (library.ReturnBook(rUserId, rIsbn))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✔️ Book returned successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Return failed. Verify details.");
                        }
                        Console.ResetColor();
                        break;

                    case "5":
                        
                        Console.WriteLine("How do you want to filter books?");
                        Console.WriteLine("A. Show only AVAILABLE books");
                        Console.WriteLine("B. Show books by author 'Ameen Al-Shalabi'");
                        Console.Write("Choice (A or B): ");
                        string filterChoice = Console.ReadLine().ToUpper();

                        List<Book> result = new List<Book>();

                        if (filterChoice == "A")
                        {
                            
                            result = library.FindBooks(b => !b.IsBorrowed);
                        }
                        else if (filterChoice == "B")
                        {
                            
                            result = library.FindBooks(b => b.Author.Equals("Ameen Al-Shalabi", StringComparison.OrdinalIgnoreCase));
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n--- Search Results ---");
                        foreach (var b in result)
                        {
                            Console.WriteLine($"[ISBN: {b.Isbn}] {b.Title} by {b.Author} - (Borrowed: {b.IsBorrowed})");
                        }
                        Console.ResetColor();
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using Prime Academy Library System. Goodbye!");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Invalid choice, please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
