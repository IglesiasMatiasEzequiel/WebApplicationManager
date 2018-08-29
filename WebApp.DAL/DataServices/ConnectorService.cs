using System.Collections.Generic;
using System.Linq;
using Pooler.API.Entities.ADO;
using WebApp.DAL.Entities;

namespace WebApp.DAL.DataServices
{
    public class ConnectorService
    {
        public IList<Connector> GetConnectors()
        {
            SQLDataReader dataReader = Run.RunQuery(QueriesConst.QueryGetTableConnectors, new List<SQLParam>());

            return dataReader.Rows.Select(row => new Connector(row)).ToList();
        }
    }
}