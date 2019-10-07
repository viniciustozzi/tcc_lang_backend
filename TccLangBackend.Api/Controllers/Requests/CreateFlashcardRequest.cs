namespace TccLangBackend.Api.Controllers.Requests
{
    public class CreateFlashcardRequest
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
    }
}