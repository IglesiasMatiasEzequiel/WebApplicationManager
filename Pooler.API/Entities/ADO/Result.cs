using System.Runtime.Serialization;

namespace Pooler.API.Entities.ADO
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public int ResultNonQuery { get; set; }

        [DataMember]
        public SQLDataReader DataReader { get; set; }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}