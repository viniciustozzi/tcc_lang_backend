namespace TccLangBackend.Api.Controllers.Requests
{
    public class CreateFlashcardRequest
    {
        public string OriginalWord { get; set; }
        public string TranslatedWord { get; set; }
    }
}