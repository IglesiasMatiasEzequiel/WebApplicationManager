using System.Collections.Generic;
using AppCommon.Functions;
using Pooler.API;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.ADO.Requests;
using Pooler.API.Entities.ADO.Responses;

namespace PoolerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ResponseResult result = new ExternalPooler().ExecuteQueries(new RequestQuery
            {
                idApp = 1,
                Token = Token.GeneratePoolerToken(),
                Queries = new List<Query>
                {
                    new Query
                    {
                        Connector = 3,
                        IsNonQuery = false,
                        IdQuery = 1, //ObtenerUsuario
                        Parameters = new List<SQLParam>
                        {
                            new SQLParam {Name = "EMAIL", Value = "YANINAMAGARINOS@YAHOO.COM.AR"}
                        }    
                    }
                }
            });

            SQLDataReader dataReader = result.Results[0].DataReader;

        }
    }
}
