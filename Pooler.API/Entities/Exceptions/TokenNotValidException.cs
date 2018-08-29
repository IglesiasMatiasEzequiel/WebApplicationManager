using System;

namespace Pooler.API.Entities.Exceptions
{
    public class TokenNotValidException : Exception
    {
        public TokenNotValidException(string message) : base(message)
        {
        }

        public TokenNotValidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
