using System.Collections.Generic;

namespace Pooler.API.Entities.ADO
{
    public class SQLDataReader
    {
        public IList<SQLRow> Rows { get; set; }
    }
}