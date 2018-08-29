using System.Collections.Generic;
using System.Linq;
using Pooler.API.Entities.ADO;
using WebApp.DAL.Entities;

namespace WebApp.DAL.DataServices
{
    public class UserService
    {
        public User GetUser(string userName)
        {
            SQLDataReader dataReader = Run.RunQuery(QueriesConst.QueryGetTableUserRoles, new List<SQLParam>{ new SQLParam("USERNAME", userName) });
            return new User(dataReader.Rows.FirstOrDefault());
        }
    }
}