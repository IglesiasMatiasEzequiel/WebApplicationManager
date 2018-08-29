using System;

namespace WebApp.DAL.Exceptions
{
    public class ObjectLoadException : ObjectCustomException
    {
        public ObjectLoadException() : base(GetMessage())
        {
        }

        public ObjectLoadException(string message) : base(GetMessage(message))
        {
        }

        public ObjectLoadException(string objName, string id) : base(GetMessage(objName, id))
        {
        }

        public ObjectLoadException(string objName, string id, string message, Exception inner) : base(GetMessage(objName, id, message), inner)
        {
        }
    }
}