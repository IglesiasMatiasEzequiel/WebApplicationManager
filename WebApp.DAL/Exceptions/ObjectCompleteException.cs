using System;

namespace WebApp.DAL.Exceptions
{
    public class ObjectCompleteException : ObjectCustomException
    {
        public ObjectCompleteException()
        {
        }

        public ObjectCompleteException(string message) : base(GetMessage(message))
        {
        }

        public ObjectCompleteException(string objName, string id) : base(GetMessage(objName, id))
        {
        }

        public ObjectCompleteException(string objName, string id, string message, Exception inner) : base(GetMessage(objName, id, message), inner)
        {
        }
    }
}