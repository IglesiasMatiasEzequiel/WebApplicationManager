using System.Runtime.Serialization;
using Pooler.API.Entities.ADO.Base;

namespace Pooler.API.Entities.ADO.Responses
{
    [DataContract]
    public class ResponseQuery : ResponseBase
    {
        [DataMember]
        public Query Query { get; set; }

        [DataMember]
        public string QueryText { get; set; }
    }
}