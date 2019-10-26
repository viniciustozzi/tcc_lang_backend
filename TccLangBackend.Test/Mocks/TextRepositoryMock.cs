using System.Threading.Tasks;
using Moq;
using TccLangBackend.Core.Text;

namespace TccLangBackend.Test.Mocks
{
    public static class TextRepositoryMock
    {
        public static Mock<ITextRepository> CreateTextRepositoryMock()
        {
            return new Mock<ITextRepository>();
        }

        public static Mock<ITextRepository> MockCreateBookmarkAsync(this Mock<ITextRepository> source,
            CreateBookmark createBookmark)
        {
            source
                .Setup(x => x.CreateBookmarkAsync(createBookmark))
                .Returns(Task.CompletedTask)
                .Verifiable();

            return source;
        }

        public static Mock<ITextRepository> MockExistByTileAsync(this Mock<ITextRepository> source, string textTitle,
            bool result)
        {
            source
                .Setup(x => x.ExistByTileAsync(textTitle))
                .ReturnsAsync(result)
                .Verifiable();

            return source;
        }

        public static Mock<ITextRepository> MockExist(this Mock<ITextRepository> source, int textId, bool result)
        {
            source
                .Setup(x => x.ExistAsync(textId))
                .ReturnsAsync(result)
                .Verifiable();

            return source;
        }
    }
}