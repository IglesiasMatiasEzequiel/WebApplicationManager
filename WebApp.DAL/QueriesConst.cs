namespace WebApp.DAL
{
    public static class QueriesConst
    {
        #region Queries

        #region Common

        public const int QueryGetUserRol = 1881;
        public const int QueryRun = 2110;

        #endregion

        #region Structures

        public const int QueryGetTableConnectors = 1882;
        public const int QueryGetTableDLLInvokers = 1884;
        public const int QueryGetTableSenders = 1885;
        public const int QueryGetTableTransfers = 1886;

        #endregion

        #region Monitoring

        public const int QueryGetTableLoggerStepsServices = 1926;
        public const int QueryGetTableLoggerServices = 1927;
        public const int QueryGetTableLoggerServicesResume = 1928;
        public const int QueryMonitorServerDataBase = 2043;
        

        #endregion

        #region Configuration

        public const int QueryGetSystemParameters = 1939;
        public const int QueryGetTableUserRoles = 1944;
        public const int QueryGetTableGroups = 1952;
        public const int QueryDeleteGroups = 1955;
        public const int QueryInsertGroup = 1954;

        #endregion

        #region ControlPanel

        public const int QueryGetTableProcessTray = 1957;
        public const int QueryGetTableDLLProcessTray = 1968;
        public const int QueryGetTableDailyReport = 1978;
        public const int QueryGetProcessTrayById = 1959;
        public const int QueryGetDLLProcessTrayById = 11111111;
        public const int QueryGetComboRules = 1956;
        public const int QueryGetComboDLLRules = 1967;
        public const int QuerySuspendProcessTray = 1963;
        public const int QuerySuspendDLLProcessTray = 1973;

        #endregion

        #region Programming

        public const int QueryGetTableRules = 1979;
        public const int QueryGetTableDLLRules = 2048;
        public const int QueryGetProcessActions = 2091;
        public const int QueryGetTableQueries = 2121;
        public const int QueryGetTableListenerMasks = 2124;
        public const int QueryGetTableListeners = 2126;

        #endregion

        #region Parameters

        public const int QueryGetTableVariables = 1980;
        public const int QueryGetTableViews = 2058;
        public const int QueryGetTableSchedulers = 2052;
        public const int QueryGetTableFilters = 2057;
        public const int QueryGetAllSchedulers = 2053;
        public const int QueryGetTableReprocesses = 2055;
        public const int QueryGetOccasions = 2056;
        public const int QueryGetComboGroups = 1982;
        public const int QueryGetComboViews = 2059;
        public const int QueryGetComboFilters = 2106;
        public const int QueryGetComboSchedulers = 2107;
        public const int QueryGetComboReprocesses = 2108;
        public const int QueryGetFilterVariables = 2060;
        public const int QueryGetRuleValues = 2092;
        public const int QueryGetFilterValues = 2109;
        public const int QueryGetTableEmailParameter = 2080;
        public const int QueryGetTableEmailMasks = 2112;
        public const int QueryGetTableNonWorkingCalendar = 2086;

        #endregion

        #endregion
    }
}