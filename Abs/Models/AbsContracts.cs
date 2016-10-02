using System.Collections.Generic;

namespace Logos.Abs.Models
{

    public class Link
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class VersionLink
    {
        public Link Version { get; set; }
    }
    public class BookLink
    {
        public Link Book { get; set; }
    }
    public class ChapterLink
    {
        public Link Chapter { get; set; }
    }

    public class VerseLink
    {
        public Link Verse { get; set; }
    }

    public class Verse
    {
        public ChapterLink Parent { get; set; }
        public string Reference { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Auditid { get; set; }
        public string Copyright { get; set; }
        public string Osis_end { get; set; }
        public VerseLink Next { get; set; }
        public string Id { get; set; }
        public string LastVerse { get; set; }
        public VerseLink Previous { get; set; }
    }

    public class Chapter
    {
        public string Name { get; set; }
        public string Copyright { get; set; }
        public BookLink parent { get; set; }
        public string Label { get; set; }
        public string Auditid { get; set; }
        public string Osis_end { get; set; }
        public ChapterLink Next { get; set; }
        public string Id { get; set; }
        public ChapterLink Previous { get; set; }
    }

    public class Book
    {
        public string name { get; set; }
        public VersionLink parent { get; set; }
        public string version_id { get; set; }
        public BookLink next { get; set; }
        public string book_group_id { get; set; }
        public string osis_end { get; set; }
        public string abbr { get; set; }
        public string testament { get; set; }
        public string ord { get; set; }
        public string copyright { get; set; }
        public string id { get; set; }
        public BookLink previous { get; set; }
    }

    public class Meta
    {
        public string Fums_js_include { get; set; }
        public string Fums_noscript { get; set; }
        public string Fums_js { get; set; }
        public string Fums_tid { get; set; }
        public string Fums { get; set; }
    }

    public class Books
    {
        public List<Book> books { get; set; } = new List<Book>();
        public Meta Meta { get; set; }
    }

    public class Chapters
    {
        public List<Chapter> chapters { get; set; }
        public Meta Meta { get; set; }
    }
    public class Verses
    {
        public List<Verse> verses { get; set; }
        public Meta Meta { get; set; }
    }

    public class AbsResponse<T> where T : class, new()
    {
        public T response { get; set; } = new T();
    }
}