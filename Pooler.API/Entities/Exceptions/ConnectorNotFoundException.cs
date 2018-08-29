using System;

namespace Pooler.API.Entities.Exceptions
{
    public class ConnectorNotFoundException : Exception
    {
        public ConnectorNotFoundException(string message) : base(message)
        {
        }

        public ConnectorNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
