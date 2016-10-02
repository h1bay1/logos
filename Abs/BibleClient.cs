namespace Logos.Abs
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Abs.Models;
    using Newtonsoft.Json;

    public class BibleClient
    {
        private readonly HttpClient _client;

        public BibleClient()
        {
            var credentials = new NetworkCredential("7ONLU1OEoeE9dP2KWcsFJBISPWheNRsJEtEkKuEB", string.Empty);
            var handler = new HttpClientHandler { Credentials = credentials };
            _client = new HttpClient(handler){BaseAddress = new System.Uri("https://bibles.org/v2/")};
        }

        public async Task<IList<Book>> GetBooks()
        {
            var result = await _client.GetAsync($"/versions/eng-GNTD/books.js");
            return JsonConvert.DeserializeObject<AbsResponse<Books>>(await result.Content.ReadAsStringAsync())?.response?.books;
        }

        public async Task<IList<Chapter>> GetChapters(string book)
        {
            var result = await _client.GetAsync($"books/eng-GNTD:{book}/chapters.js");
            return JsonConvert.DeserializeObject<AbsResponse<Chapters>>(await result.Content.ReadAsStringAsync()).response.chapters;
        }

        public async Task<IList<Verse>> GetVerses(string book, int chapter)
        {
            var result = await _client.GetAsync($"chapters/eng-GNTD:{book}.{chapter}/verses.js");
            return JsonConvert.DeserializeObject<AbsResponse<Verses>>(await result.Content.ReadAsStringAsync()).response.verses;
        }
    }
}