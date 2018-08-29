using System;

namespace Pooler.API.Entities.Exceptions
{
    public class NullResponseException : Exception
    {
        public NullResponseException(string message) : base(message)
        {
        }

        public NullResponseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
