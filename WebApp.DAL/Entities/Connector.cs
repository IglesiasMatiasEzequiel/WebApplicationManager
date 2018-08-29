using System;
using System.Collections.Generic;
using System.Linq;
using AppCommon.Functions;
using Pooler.API.Entities.ADO;
using WebApp.DAL.Entities.Base;

namespace WebApp.DAL.Entities
{
    [Serializable]
    public class Connector : EntityBase
    {
        public static int QUERY_GET = 1891;
        public static int QUERY_INSERT = 1888;
        public static int QUERY_UPDATE = 1889;
        public static int QUERY_DELETE = 1907;

        public bool IsActive { get; set; }
        public int IdType { get; set; }
        public int TimeOut { get; set; }
        public string ConnectionString { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UserUpdate { get; set; }

        public Connector()
        {
        }

        public Connector(long id)
        {
            Load(id);
        }

        public Connector(SQLRow row)
        {
            Load(row);
        }

        public void Load(SQLRow row)
        {
            Id = row.GetValueLong("Id");
            Name = row.GetValue("Name");
            IsActive = row.GetValueBool("IsActive");
            IdType = row.GetValueInt("IdType");
            ConnectionString = Encrypter.DecryptNotNullOrEmpty(row.GetValue("ConnectionString"));
            TimeOut = row.GetValueInt("TimeOut");
            LastUpdate = row.GetValueDateTime("LastUpdate");
            UserUpdate = row.GetValue("UserUpdate");
        }

        public void Load(long id)
        {
            SQLRow row = Run.RunQuery(QUERY_GET, new List<SQLParam>
            {
                new SQLParam {Name = "ID", Value = id.ToString()}
            }).Rows.FirstOrDefault();

            if (row != null)
                Load(row);
        }

        public void Save()
        {
            Run.RunNonQuery((Id != -1) ? QUERY_UPDATE : QUERY_INSERT, new List<SQLParam>
                {
                    new SQLParam {Name = "ID", Value = Id.ToString()},
                    new SQLParam {Name = "NAME", Value = Name},
                    new SQLParam {Name = "ISACTIVE", Value = IsActive? "1" : "0"},
                    new SQLParam {Name = "IDTYPE", Value = IdType.ToString()},
                    new SQLParam {Name = "CONNECTIONSTRING", Value = Encrypter.EncryptNotNullOrEmpty(ConnectionString)},
                    new SQLParam {Name = "TIMEOUT", Value = TimeOut.ToString()},
                    new SQLParam {Name = "USERUPDATE", Value = UserUpdate}
                });
        }

        public void Delete()
        {
            Run.RunNonQuery(QUERY_DELETE, new List<SQLParam>
            {
                new SQLParam { Name = "ID", Value = Id.ToString() }
            });
        }
    }
}