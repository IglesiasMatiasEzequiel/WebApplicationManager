using System;

namespace Pooler.API.Entities.Exceptions
{
    public class AppNotFoundException : Exception
    {
        public AppNotFoundException(string message) : base(message)
        {
        }

        public AppNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
