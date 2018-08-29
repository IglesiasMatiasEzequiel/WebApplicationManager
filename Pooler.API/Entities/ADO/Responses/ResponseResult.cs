using System.Collections.Generic;
using System.Runtime.Serialization;
using Pooler.API.Entities.ADO.Base;

namespace Pooler.API.Entities.ADO.Responses
{
    [DataContract]
    public class ResponseResult : ResponseBase
    {
        [DataMember]
        public IList<Result> Results { get; set; }
    }
}