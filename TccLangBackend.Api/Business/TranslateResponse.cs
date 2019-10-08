using System.Collections.Generic;

namespace TccLangBackend.Api.Business
{
    public class TranslateResponse
    {
        public IEnumerable<Translation> Translations { get; set; }
    }
}