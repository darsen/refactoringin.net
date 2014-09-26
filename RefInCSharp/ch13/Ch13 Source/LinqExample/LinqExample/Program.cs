using System;
using System.Linq;

namespace Linq
{
    class Author
    {
        public string FirstName;
        public string LastName;
        public Book[] Books;
    }

    class Book
    {
        public string Name;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Author[] authors = { 
                new Author { FirstName = "Leo" , 
                    LastName = "Tolstoy", 
                    Books = new Book[]{
                        new Book{Name = "War and Peace"},
                        new Book{Name = "Anna Karenina"},
                        new Book{Name = "Resurrection"}
                    }                    
                },
                new Author { FirstName = "Homer" , 
                    LastName = "", 
                    Books = new Book[]{
                        new Book{Name = "The Iliad"},                        
                        new Book{Name = "Odyssey"}
                    }                    
                },
                new Author { FirstName = "Miguel" , 
                    LastName = "Cervantes", 
                    Books = new Book[]{                        
                        new Book{Name = "“Don Quixote"}
                    }                    
                }
            };

            var prolificAuthor = (
                    from author in authors
                    orderby author.Books.Count() descending
                    select author
                    ).First();

            Console.WriteLine("Author with most books: " +
                prolificAuthor.FirstName + " " +
                prolificAuthor.LastName);

            Console.ReadKey();
        }       
    }
}
