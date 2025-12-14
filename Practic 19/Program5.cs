using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_19_5
{
    class BookAlreadyTakenException : Exception
    {
        public BookAlreadyTakenException(string bookName, string reader)
            : base($"Книга \"{bookName}\" уже у {reader}!") { }
    }
    class Library
    {
        private string takenBook = null;
        private string currentReader = null;

        public void TakeBook(string bookName, string reader)
        {
            if (takenBook != null)
                throw new BookAlreadyTakenException(bookName, currentReader);

            takenBook = bookName;
            currentReader = reader;
            Console.WriteLine($"{reader} берёт \"{bookName}\"");
        }

        public void ReturnBook()
        {
            if (takenBook != null)
            {
                Console.WriteLine($"{currentReader} возвращает книгу");
                takenBook = null;
                currentReader = null;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library();


            library.TakeBook("Война и мир", "Анна");

            Console.WriteLine("Пётр пытается взять \"Война и мир\"");
            try
            {
                library.TakeBook("Война и мир", "Пётр");
            }
            catch (BookAlreadyTakenException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            library.ReturnBook();

            Console.WriteLine("Теперь можно брать");

            library.TakeBook("Война и мир", "Пётр");
        }
    }
}
