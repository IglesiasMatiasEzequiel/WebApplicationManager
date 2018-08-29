using System.Runtime.Serialization;

namespace Pooler.API.Entities.ADO.Base
{
    [DataContract]
    public abstract class ResponseBase
    {
        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}