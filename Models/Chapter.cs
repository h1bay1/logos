using System.Collections.Generic;

namespace Logos.Models
{
    public class Chapter
    {
        public int Number;
        public IList<Verse> Verses;
        public int? Next;
        public int? Previous;
    }
}