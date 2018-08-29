using System;

namespace WebApp.DAL.Entities.Base
{
    [Serializable]
    public class TransportId : EntityBase
    {
        public string Code { get; set; }
    }

    [Serializable]
    public class TransportTag : EntityBase
    {
        public string Tag { get; set; }
    }
}
