using System.Collections.Generic;

namespace Logos.Models
{
    public class Book
    {
        public string Name;
        public IList<Chapter> Chapters;
        public string Next;
        public string Previous;
    }
}