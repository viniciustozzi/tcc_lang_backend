using System;

namespace TccLangBackend.Core
{
    public class InvalidParamException : Exception
    {
        public string ParamName { get; }

        public InvalidParamException(string paramName, string message) : base(message)
        {
            ParamName = paramName;
        }
    }
}