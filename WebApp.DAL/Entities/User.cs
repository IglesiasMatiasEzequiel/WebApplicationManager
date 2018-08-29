using System;
using System.Configuration;
using Pooler.API.Entities.ADO;

namespace WebApp.DAL.Entities
{
    public class User : Base.Base
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LastActivityTime { get; set; }

        public User(SQLRow row)
        {
            Load(row);
        }

        public bool HasLoginActivity {
            get 
            { 
                int endTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["EndTimeout"]);
                return (LoginTime.AddMinutes(endTimeout).CompareTo(DateTime.Now)) < 0 ;
            }
        }

        public bool HasSessionActive
        {
            get
            {
                int sessionTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeout"]);
                return (LastActivityTime.AddMinutes(sessionTimeout).CompareTo(DateTime.Now)) < 0;
            }
        }

        public void Load(SQLRow row)
        {
            Id = row.GetValueInt("ID");
            Nombre = row.GetValue("NOMBRE");
        }
    }
}