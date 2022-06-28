using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Application
{
    abstract class Book
    {
        protected string Name;
        protected string Author;
        protected int BookIdentificationNumber;


        public abstract string GetName();
        public abstract string GetAuthor();
        public abstract int GetBookIdentificationNumber();

        protected abstract void SetName(string bookName);
        protected abstract void SetAuthor(string bookAuthor);
        protected abstract void SetBookIdentificationNumber(int bookBookIdentificationNumber);

    }
}
