namespace TccLangBackend.Api.Controllers.Requests
{
    public class CreateDeckRequest
    {
        public string Title { get; set; }

        public int? TextId { get; set; }
    }
}