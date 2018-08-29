using System;

namespace WebApp.DAL.Entities.Base
{
    [Serializable]
    public abstract class Base
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}