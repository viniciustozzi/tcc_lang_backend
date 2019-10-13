using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TccLangBackend.Framework.Translation
{
    public class TranslationBusiness
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TranslationBusiness(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Translation> Translate(string text)
        {
            var httpClient = _httpClientFactory.CreateClient("cognitive");

            var httpResponseMessage =
                await httpClient.PostAsJsonAsync("", new List<Translatee> {new Translatee {Text = text}});

            var translations = await httpResponseMessage.Content.ReadAsAsync<IEnumerable<TranslateResponse>>();

            return translations.First().Translations.FirstOrDefault();
        }
    }
}