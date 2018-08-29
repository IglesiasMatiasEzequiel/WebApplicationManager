using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pooler.API.Entities.ADO
{
    [DataContract]
    public class Query
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public int IdQuery { get; set; }

        [DataMember]
        public int Connector { get; set; }

        [DataMember]
        public bool IsNonQuery { get; set; }

        [DataMember]
        public IList<SQLParam> Parameters { get; set; }
    }
}