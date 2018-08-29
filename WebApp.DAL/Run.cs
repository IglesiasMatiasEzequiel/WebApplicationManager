using System;
using System.Collections.Generic;
using System.Linq;
using AppCommon.Functions;
using Pooler.API;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.ADO.Requests;
using Pooler.API.Entities.ADO.Responses;

namespace WebApp.DAL
{
    public static class Run
    {
        public static ResponseResult RunQueries(int idApp, List<Query> queries)
        {
            ResponseResult response;

            using (ExternalPooler pooler = new ExternalPooler())
            {
                response = pooler.ExecuteQueries(new RequestQuery
                {
                    Queries = queries,
                    Token = Token.GeneratePoolerToken(),
                    idApp = idApp
                });
            }

            if (response == null)
                throw new Exception("ERRx201807211204 No se pudo obtener la respuesta.");

            return response;
        }

        public static SQLDataReader RunQuery(int idQuery, List<SQLParam> parameters)
        {
            return RunQuery(idQuery, Applications.IdWebApplication, parameters);
        }

        public static SQLDataReader RunQuery(int idQuery, int idApp, List<SQLParam> parameters)
        {
            return RunQuery(idQuery, idApp, parameters, Connectors.ConnWebApplication);
        }

        public static SQLDataReader RunQuery(int idQuery, int idApp, List<SQLParam> parameters, int connector)
        {
            List<Query> queries = new List<Query>
            {
                new Query
                {
                    Key = string.Empty,
                    IdQuery = idQuery,
                    Parameters = parameters,
                    IsNonQuery = false,
                    Connector = connector
                }
            };

            ResponseResult response = RunQueries(idApp, queries);

            Result result = response.Results.First();

            if (response.HasError || result.HasError)
                throw new Exception("ERRx201807211204 Ocurrió un error en la ejecución del query - Response: " + response.ErrorMessage + "/ Result: " + result.ErrorMessage);

            return response.Results.First().DataReader;
        }

        public static SQLDataReader RunNonQuery(int idQuery, List<SQLParam> parameters)
        {
            return RunNonQuery(idQuery, Applications.IdWebApplication, parameters);
        }

        public static SQLDataReader RunNonQuery(int idQuery, int idApp, List<SQLParam> parameters)
        {
            return RunNonQuery(idQuery, idApp, parameters, Connectors.ConnWebApplication);
        }

        public static SQLDataReader RunNonQuery(int idQuery, int idApp, List<SQLParam> parameters, int connector)
        {
            List<Query> queries = new List<Query>
            {
                new Query
                {
                    Key = string.Empty,
                    IdQuery = idQuery,
                    Parameters = parameters,
                    IsNonQuery = false,
                    Connector = connector
                }
            };

            ResponseResult response = RunQueries(idApp, queries);

            Result result = response.Results.First();

            if (response.HasError || result.HasError)
                throw new Exception("ERRx201807211204 Ocurrió un error en la ejecución del query - Response: " + response.ErrorMessage + "/ Result:" + result.ErrorMessage);

            return response.Results.First().DataReader;
        }
    }
}