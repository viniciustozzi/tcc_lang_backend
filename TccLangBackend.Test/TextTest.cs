using System.Threading.Tasks;
using Moq;
using TccLangBackend.Core;
using TccLangBackend.Core.Text;
using TccLangBackend.Test.Mocks;
using Xunit;
using static TccLangBackend.Test.Mocks.TextRepositoryMock;
using static TccLangBackend.Test.Mocks.UserRepositoryMock;
using static Xunit.Assert;

namespace TccLangBackend.Test
{
    public class TextTest
    {
        [Fact]
        public async Task CreateAsync_Ok()
        {
            var createText = new CreateText("words", "title", "lang");

            var textRepository = CreateTextRepositoryMock()
                .MockExistByTileAsync("title", false)
                .Resolve();


            var text = new TextBusiness(textRepository, EmptyUserRepository);

            await text.CreateAsync(createText);
        }

        [Fact]
        public async Task CreateAsync_InvalidTitle()
        {
            var textRepository = CreateTextRepositoryMock()
                .MockExistByTileAsync("title", true)
                .Resolve();

            var text = new TextBusiness(textRepository, EmptyUserRepository);

            var invalidParamException =
                await ThrowsAsync<InvalidParamException>(() =>
                    text.CreateAsync(new CreateText("words", "title", "lang")));

            Equal("Title", invalidParamException.ParamName);
            Equal("A text with this title is already stored", invalidParamException.Message);
        }


        [Fact]
        public async Task CreateBookmarkAsync_Ok()
        {
            var createBookmark = new CreateBookmark(1, 1);

            var textRepository = CreateTextRepositoryMock()
                .MockExist(1, true)
                .MockCreateBookmarkAsync(createBookmark)
                .Resolve();

            var userRepository = CreateUserRepositoryMock()
                .MockExistAsync(1, true)
                .Resolve();

            var text = new TextBusiness(textRepository, userRepository);
            await text.CreateBookmarkAsync(createBookmark);
        }


        [Fact]
        public async Task CreateBookmarkAsync_UserIdNotFound()
        {
            var textRepository = CreateTextRepositoryMock()
                .MockExist(1, true)
                .Resolve();

            var userRepository = CreateUserRepositoryMock()
                .MockExistAsync(1, false)
                .Resolve();

            var text = new TextBusiness(textRepository, userRepository);

            var notFoundException =
                await ThrowsAsync<NotFoundException>(() => text.CreateBookmarkAsync(new CreateBookmark(1, 1)));

            Equal("UserId not found", notFoundException.Message);
        }

        [Fact]
        public async Task CreateBookmarkASync_TextIdNotFound()
        {
            var createBookmark = new CreateBookmark(1, 1);

            var textRepository = CreateTextRepositoryMock()
                .MockExist(1, false)
                .Resolve();

            var userRepository = CreateUserRepositoryMock()
                .MockExistAsync(1, true)
                .Resolve();

            var text = new TextBusiness(textRepository, userRepository);

            var notFoundException =
                await ThrowsAsync<NotFoundException>(() => text.CreateBookmarkAsync(createBookmark));

            Equal("TextId not found", notFoundException.Message);
        }
    }
}