using System.Collections.Generic;

namespace Logos.Services
{
    public class Mapper
    {
        public static Logos.Models.Book MapBook(Logos.Abs.Models.Book book)
        {
            return new Logos.Models.Book(){
                Name = book.name,
                Chapters = new List<Logos.Models.Chapter>(),
                Next = book.next.Book.Name,
                Previous = book.previous.Book.Name,
            };
        }
    }
}