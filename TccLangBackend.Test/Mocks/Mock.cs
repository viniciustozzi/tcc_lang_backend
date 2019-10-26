using Moq;

namespace TccLangBackend.Test.Mocks
{
    public static class Mock
    {
        public static T Resolve<T>(this Mock<T> source) where T : class
        {
            return source.Object;
        }
    }
}