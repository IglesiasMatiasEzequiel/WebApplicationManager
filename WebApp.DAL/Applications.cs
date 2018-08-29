using System;
using System.Configuration;

namespace WebApp.DAL
{
    public static class Applications
    {
        #region  Internal 

        public static readonly int IdWebApplication = Convert.ToInt32(ConfigurationManager.AppSettings["WebAppId"]);

        #endregion
    }
}