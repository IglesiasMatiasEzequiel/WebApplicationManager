using System;

namespace WebApp.DAL.Entities.Base
{
    [Serializable]
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        protected EntityBase()
        {
            Id = -1;
            Name = string.Empty;
            Group = string.Empty;
        }
    }
}