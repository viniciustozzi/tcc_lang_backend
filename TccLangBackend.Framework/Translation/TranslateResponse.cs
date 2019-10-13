using System.Collections.Generic;

namespace TccLangBackend.Framework.Translation
{
    public class TranslateResponse
    {
        public IEnumerable<Translation> Translations { get; set; }
    }
}