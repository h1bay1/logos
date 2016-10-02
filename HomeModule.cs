namespace logos
{
    using Nancy;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Logos.Services;

    public class HomeModule : NancyModule
    {
        private readonly ScriptureService _scriptureService;

        public HomeModule()
        {
            _scriptureService = new ScriptureService();
            Get("/{version}/", async parameters => await _scriptureService.LoadBooks());
            Get("/{book}/{chapter}/{verse}", async parameters => await GetBibleContentV2(parameters.book, parameters.chapter, parameters.verse));
        }

        public async Task<string> GetBook(dynamic parameters)
        {
            return await GetBibleContentV2(parameters.book, parameters.chapter, parameters.verse);
        }

        public async Task<string> GetBibleContentV2(string book, int chapter, int verse)
        {
            var client = new HttpClient(){BaseAddress = new Url("http://labs.bible.org/api/")};
            var result = await client.GetAsync($"?passage={book}%20{chapter}:{verse}&type=json");
            return await result.Content.ReadAsStringAsync();
        }
    }
}
