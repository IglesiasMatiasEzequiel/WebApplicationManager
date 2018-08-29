using System;

namespace WebApp.DAL.Exceptions
{
    public abstract class ObjectCustomException : Exception
    {
        protected ObjectCustomException()
        {
        }

        protected ObjectCustomException(string message) : base(message)
        {
        }

        protected ObjectCustomException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected static string GetMessage()
        {
            return GetMessage(null, null, null);
        }

        protected static string GetMessage(string message)
        {
            return GetMessage(null, null, message);
        }

        protected static string GetMessage(string objName, string id)
        {
            return GetMessage(objName, id, null);
        }

        protected static string GetMessage(string objName, string id, string message)
        {
            return "An error occurred in object"
                + (!string.IsNullOrEmpty(objName) ? " " + objName.ToUpper() : "")
                + (!string.IsNullOrEmpty(id) ? " with ID " + id : "")
                + "."
                + (!string.IsNullOrEmpty(message)? message : "");
        }
    }
}