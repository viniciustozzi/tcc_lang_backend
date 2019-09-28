namespace TccLangBackend.Api.Controllers.Requests
{
    public class CreateDeckRequest
    {
        public string Name { get; set; }

        public int? TextId { get; set; }
    }
}