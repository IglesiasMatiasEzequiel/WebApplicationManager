using System;

namespace Pooler.API.Entities.Exceptions
{
    public class QueryNotFoundException : Exception
    {
        public QueryNotFoundException(string message) : base(message)
        {
        }

        public QueryNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
