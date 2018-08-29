using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pooler.API.Entities.ADO.Requests
{
    [DataContract]
    public class RequestQuery
    {
        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public int idApp { get; set; }

        [DataMember]
        public IList<Query> Queries { get; set; }
    }
}