using System;
using System.Collections.Generic;
using System.Linq;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.ADO.Requests;
using Pooler.API.Entities.ADO.Responses;
using Pooler.API.Entities.Exceptions;

namespace Pooler.API
{
    public static class DAL
    {
        public static SQLDataReader RunQuery(string query, string connString)
        {
            SQLDataReader dataReader;
            using (SQLAccess sqlAccess = new SQLAccess(connString))
            {
                dataReader = sqlAccess.ExecuteSQLReader(query);
            }
            return dataReader;

        }

        public static int RunNonQuery(string query, string connString)
        {
            int value;

            using (SQLAccess sqlAccess = new SQLAccess(connString))
            {
                value = sqlAccess.ExecuteSQLNonQuery(query);
            }

            return value;
        }

        public static void RunNonQuery(IList<string> queries, string connString)
        {
            using (SQLAccess sqlAccess = new SQLAccess(connString))
            {
                sqlAccess.ExecuteSQLNonQuery(queries);
            }
        }

        public static IList<ResponseQuery> GetQueries(int idApp, RequestQuery request)
        {
            IList<ResponseQuery> response = new List<ResponseQuery>();

            ExistApp(idApp);

            foreach (Query query in request.Queries)
                response.Add(GetQuery(idApp, query));

            return response;
        }

        public static ResponseQuery GetQuery(int idApp, Query query)
        {
            string getQuery = "SELECT Nombre, QueryText FROM Queries " +
                              "WHERE Id = " + query.IdQuery + " AND IdApp = " + idApp;
            try
            {
                SQLDataReader dr = RunQuery(getQuery, Connectors.ConnRepository);

                if (dr == null)
                    throw new NullResponseException("La respuesta fue nula");

                if (dr.Rows.Count > 0)
                {
                    string queryText = dr.Rows.First().GetValue("QueryText");

                    if(query.Parameters != null)
                        foreach (SQLParam parameter in query.Parameters)
                            queryText = queryText.Replace(":" + parameter.Name.Trim() + "@", parameter.Value);

                    return new ResponseQuery
                    {
                        Query = query,
                        QueryText = queryText,
                        HasError = false
                    };
                }

                throw new QueryNotFoundException("No se encontró el query");

            }
            catch (Exception ex)
            {
                return new ResponseQuery
                {
                    Query = query,
                    HasError = true,
                    ErrorCode = "RPx201802131315",
                    ErrorMessage = "Ocurrió un error obteniendo el query (" + query.IdQuery + "). - " + ex.Message
                };
            }
        }

        /*public static ResponseQuery GetQueries(int idApp, string nombre, int idQuery)
        {
            string getQuery = "SELECT Nombre, QueryText FROM Queries " +
                              "WHERE Id = " + query.IdQuery + " AND IdApp = " + idApp;
            try
            {
                SQLDataReader dr = RunQuery(getQuery, Connectors.ConnRepository);

                if (dr == null)
                    throw new NullResponseException("La respuesta fue nula");

                if (dr.Rows.Count > 0)
                {
                    string queryText = dr.Rows.First().GetValue("QueryText");

                    if (query.Parameters != null)
                        foreach (SQLParam parameter in query.Parameters)
                            queryText = queryText.Replace(":" + parameter.Name.Trim() + "@", parameter.Value);

                    return new ResponseQuery
                    {
                        Query = query,
                        QueryText = queryText,
                        HasError = false
                    };
                }

                throw new QueryNotFoundException("No se encontró el query");

            }
            catch (Exception ex)
            {
                return new ResponseQuery
                {
                    Query = query,
                    HasError = true,
                    ErrorCode = "RPx201802131315",
                    ErrorMessage = "Ocurrió un error obteniendo el query (" + query.IdQuery + "). - " + ex.Message
                };
            }
        }*/

        public static void ExistApp(int idApp)
        {
            string getApp = "SELECT Nombre AS App FROM Apps WHERE Id = " + idApp;

            SQLDataReader dr = RunQuery(getApp, Connectors.ConnRepository);

            if (dr == null)
                throw new NullResponseException("La respuesta fue nula");

            if (dr.Rows.Count == 0)
                throw new AppNotFoundException("La aplicación con id '" + idApp + "' no se encuentra parametrizada.");
        }

    }
}