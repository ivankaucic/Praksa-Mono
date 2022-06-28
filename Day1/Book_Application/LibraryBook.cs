using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Application
{
    class LibraryBook : Book,IBorrowBuy
    {
        private bool IsBorrowed;

        //setters
        protected override void SetName(string bookName)
        {
            this.SetName(bookName);
        }
        protected override void SetAuthor(string bookAuthor)
        {
            this.SetAuthor(bookAuthor);
        }
        protected override void SetBookIdentificationNumber(int bookBookIdentificationNumber)
        {
            this.SetBookIdentificationNumber(bookBookIdentificationNumber);
        }


        //Constructor
        public LibraryBook(string bookName, string bookAuthor, int bookBookIdentificationNumber)
        {
            this.Name = bookName;
            this.Author = bookAuthor;
            this.BookIdentificationNumber = bookBookIdentificationNumber;
            this.IsBorrowed = false;
        }

        //getters
        public override string GetName()
        {
            return this.Name;
        }
        public override string GetAuthor()
        {
            return this.Author;
        }
        public override int GetBookIdentificationNumber()
        {
            return this.BookIdentificationNumber;
        }       
        public bool GetIsBorrowed()
        {
            if (IsBorrowed == true) { return true; }
            else return false;
        }
       

        //interface functions
        public void BorrowABook()
        {
            if (IsBorrowed == true) { Console.WriteLine("The " + this.GetName() + " book you wanted is borrowed!"); }
            else { Console.WriteLine("The " + this.GetName() + " book you wanted is available for borrowing!");
                this.IsBorrowed = true;
            }
        }
        public void BuyABook()
        {
        Console.WriteLine("You can't buy a book in a Library!");
        }

        public void ReturnABook()
        {
            Console.WriteLine("You have returened the book " + this.GetName());
            this.IsBorrowed = false;
        }
        public void CompareAuthors(LibraryBook otherBook)
        {
            if(this.GetAuthor() == otherBook.GetAuthor())
            {
                Console.WriteLine(this.GetName() + " has the same author as " + otherBook.GetAuthor() + " and authors name is " + this.GetAuthor() + "!");
            }

            else Console.WriteLine(this.GetName() + " doesn't have the same author as " + otherBook.GetName() + ".");
        }
        public void CompareAuthors(BookstoreBook otherBook)
        {
            if (this.GetAuthor() == otherBook.GetAuthor())
            {
                Console.WriteLine(this.GetName() + " has the same author as " + otherBook.GetAuthor() + " and authors name is " + this.GetAuthor() + "!");
            }

            else Console.WriteLine(this.GetName() + " doesn't have the same author as " + otherBook.GetName() + ".");
        }
    }
}
