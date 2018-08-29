using System;

namespace WebApp.DAL.Exceptions
{
    public class ObjectSaveException : ObjectCustomException
    {
        public ObjectSaveException()
        {
        }

        public ObjectSaveException(string message): base(GetMessage(message))
        {
        }

        public ObjectSaveException(string objName, string id) : base(GetMessage(objName, id))
        {
        }

        public ObjectSaveException(string objName, string id, string message, Exception inner) : base(GetMessage(objName, id, message), inner)
        {
        }
    }
}