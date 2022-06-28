using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Application
{
    class BookstoreBook : Book,IBorrowBuy
    {
        private double BookValue;

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
        protected void SetBookValue(float bookBookValue)
        {
            this.BookValue = bookBookValue;
        }

        public BookstoreBook(string bookName, string bookAuthor, int bookBookIdentificationNumber, double bookBookValue)
        {
            this.Name = bookName;
            this.Author = bookAuthor;
            this.BookIdentificationNumber = bookBookIdentificationNumber;
            this.BookValue = bookBookValue;
        }

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
        public double GetBookValue()
        {
            return this.BookValue;
        }

        public void BorrowABook()
        {
            Console.WriteLine("You can't borrow a book in a bookstore!");
        }
        public void BuyABook()
        {
            Console.WriteLine("The book " + this.Name + " will cost you " + this.BookValue + "HRK.");
        }


    }
}
