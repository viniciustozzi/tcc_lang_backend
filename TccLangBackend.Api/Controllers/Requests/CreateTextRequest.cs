namespace TccLangBackend.Api.Controllers.Requests
{
    public class CreateTextRequest
    {
        public string Title { get; set; }
        public string Words { get; set; }

        public string Language { get; set; }
    }
}