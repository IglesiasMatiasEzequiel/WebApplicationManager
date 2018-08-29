using System.Runtime.Serialization;

namespace Pooler.API.Entities.ADO.Base
{
    [DataContract]
    public abstract class RequestBase
    {
        [DataMember]
        public string Key { get; set; }
    }
}