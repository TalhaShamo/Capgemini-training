using System;
using System.Collections.Immutable;
using System.Net;
namespace Practice_Q3
{
    class Book
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public bool BookAvailability = true;
        public Book(string t, string a)
        {
            Title = t;
            Author = a;
        }
    }
    
    class Library
    {
        List<Book> myBook = new List<Book>();
        public void AddBook(Book newBook)
        {
            myBook.Add(newBook);
            Console.WriteLine($"{newBook} added to Library!");
        }
        public void ViewLibrary()
        {
            Console.WriteLine("Books in the library - ");
            foreach(Book b in myBook){
                Console.WriteLine("Books in the library - ");
                Console.WriteLine($"{b.Title} ");
            }
        }
        public void BorrowBook(string searchBook)
        {
            foreach(Book b in myBook)
            {
                if(b.Title == searchBook)
                {
                    if (b.BookAvailability) 
                    {
                        Console.WriteLine($"You successfully borrowed the book {b.Title}");
                        b.BookAvailability = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, this book is already taken");
                        return;
                    }
                }
            }
            Console.WriteLine("Book not found");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book harrypotter = new Book("Harry Potter", "Hanks");
            Book lordoftherings = new Book("Lord of the Rings", "Mbuembo");
            Book thehobbit = new Book("The Hobbit", "Zaha");

            Library books = new Library();
            books.AddBook(harrypotter);
            books.AddBook(lordoftherings);
            books.AddBook(thehobbit);

            books.ViewLibrary();
            books.BorrowBook("Harry Potter");
            books.BorrowBook("Harry Potter");
            books.BorrowBook("Star Wars");

        }
    }
}