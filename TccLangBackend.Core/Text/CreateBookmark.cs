namespace TccLangBackend.Core.Text
{
    public class CreateBookmark
    {
        public CreateBookmark(int userId, int textId)
        {
            UserId = userId;
            TextId = textId;
        }

        public int UserId { get; }
        public int TextId { get; }
    }
}