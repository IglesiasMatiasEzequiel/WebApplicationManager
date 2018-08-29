using System;

namespace WebApp.DAL.Exceptions
{
    public class ObjectDeleteException : ObjectCustomException
    {
        public ObjectDeleteException()
        {
        }

        public ObjectDeleteException(string message): base(GetMessage(message))
        {
        }

        public ObjectDeleteException(string objName, string id) : base(GetMessage(objName, id))
        {
        }

        public ObjectDeleteException(string objName, string id, string message, Exception inner) : base(GetMessage(objName, id, message), inner)
        {
        }
    }
}