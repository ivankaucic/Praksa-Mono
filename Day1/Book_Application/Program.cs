using System;
using System.Collections.Generic;

namespace Book_Application
{
    class Program
    {

        static void Main(string[] args)
        {
            #region LibraryBooks

            List<LibraryBook> library = new List<LibraryBook>();

            LibraryBook eastOfEden = new LibraryBook("East of Eden", "John Steinbeck", 100);
            LibraryBook ofMiceAndMen = new LibraryBook("Of mice and men", "John Steinbeck", 110);
            LibraryBook grapesOfWrath = new LibraryBook("Grapes of wrath", "John Steinbeck", 111);
            LibraryBook catch22 = new LibraryBook("Catch 22", "Joseph Heller", 200);
            LibraryBook hundreadYearsOfSolitude = new LibraryBook("100 years of solitude", "Gabriel Garcia Marquez", 300);

            library.Add(eastOfEden);
            library.Add(catch22);
            library.Add(hundreadYearsOfSolitude);
            library.Add(ofMiceAndMen);
            library.Add(grapesOfWrath);


            foreach (LibraryBook book in library)
            {
                Console.WriteLine("This book is called " + book.GetName() + " and it is written by: " + book.GetAuthor());
            }

            Console.WriteLine("\n");

            foreach(LibraryBook book in library)
            {
                book.BorrowABook();
            }

            Console.WriteLine("\n");

            foreach (LibraryBook book in library)
            {
                book.BorrowABook();
            }

            Console.WriteLine("\n");

            Console.WriteLine("There are " + library.Count + " books in this library.");

            Console.WriteLine("\n");

            int counter = 0;
            foreach(LibraryBook book in library)
            {
                if (book.GetIsBorrowed() == true) counter++;
            }
            Console.WriteLine("There are currently " + counter + " borrowed books, but " + (library.Count - counter) + " book(s) is(are) left to be borrowed!");

            Console.WriteLine("\n");
            grapesOfWrath.CompareAuthors(ofMiceAndMen);
            grapesOfWrath.CompareAuthors(catch22);
            #endregion LibraryBooks

            #region BookStoreBooks

            IList<BookstoreBook> bookstore = new List<BookstoreBook>();

            BookstoreBook oneFlewOverTheCuckoosNest = new BookstoreBook("One Flew Over The Cuckoo's Nest", "Ken Kesey", 100, 99.9);
            BookstoreBook animalFarm = new BookstoreBook("Animal Farm", "George Orwell", 200, 75.49);
            BookstoreBook aPassageToIndia = new BookstoreBook("A passage to India", "E. M. Forster", 300, 119.99);
            BookstoreBook theBookThief = new BookstoreBook("The book thief", "Ken Kesey", 400, 130.29);

            bookstore.Add(oneFlewOverTheCuckoosNest);
            bookstore.Add(animalFarm);
            bookstore.Add(aPassageToIndia);
            bookstore.Add(theBookThief);
            bookstore.Add(new BookstoreBook("Alice's Adventures in Wonderland", "Lewis Carroll", 500, 80.00));

            Console.WriteLine("");

            foreach(BookstoreBook book in bookstore)
            {
                Console.WriteLine("The book is called " + book.GetName() + ", it was written by: " + book.GetAuthor() + " and it costs: " + book.GetBookValue() + "HRK");
            }


            animalFarm.BuyABook();



            #endregion BookStoreBooks

            Console.WriteLine("");

            grapesOfWrath.CompareAuthors(oneFlewOverTheCuckoosNest);

        }
    }
}
