using Moq;
using TccLangBackend.Core.User;

namespace TccLangBackend.Test.Mocks
{
    public static class UserRepositoryMock
    {
        public static IUserRepository EmptyUserRepository => CreateUserRepositoryMock().Resolve();

        public static Mock<IUserRepository> CreateUserRepositoryMock()
        {
            return new Mock<IUserRepository>();
        }

        public static Mock<IUserRepository> MockExistAsync(this Mock<IUserRepository> source, int userId, bool result)

        {
            source
                .Setup(x => x.ExistAsync(userId))
                .ReturnsAsync(result)
                .Verifiable();

            return source;
        }
    }
}