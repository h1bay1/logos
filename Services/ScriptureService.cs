
using System.Linq;
using System.Threading.Tasks;
using Logos.Abs;

namespace Logos.Services
{
    public class ScriptureService
    {
        private readonly BibleClient _absClient;
        public ScriptureService()
        {
            _absClient = new BibleClient();
        }

        public async Task<string> LoadBooks()
        {
            var response = await _absClient.GetBooks();
            var books = response.Select(Mapper.MapBook);
            return books.First().Name;
        }
    }
}