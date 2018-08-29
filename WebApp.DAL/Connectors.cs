using System;
using System.Configuration;

namespace WebApp.DAL
{
    public static class Connectors
    {
        #region  Internal 

        public static readonly int ConnWebApplication = Convert.ToInt32(ConfigurationManager.AppSettings["WebAppConnector"]);

        #endregion
    }
}