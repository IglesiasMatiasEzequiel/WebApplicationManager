using System;
using System.Collections.Generic;
using RequestQuery = Pooler.API.Entities.ADO.Requests.RequestQuery;
using ResponseQuery = Pooler.API.Entities.ADO.Responses.ResponseQuery;
using ResponseResult = Pooler.API.Entities.ADO.Responses.ResponseResult;
using Result = Pooler.API.Entities.ADO.Result;

namespace Pooler.API
{
    public class ExternalPooler : IDisposable
    {
        public ResponseResult ExecuteQueries(RequestQuery request)
        {
            ResponseResult response = new ResponseResult
                                                {
                                                    HasError = false,
                                                    ErrorCode = string.Empty,
                                                    ErrorMessage = string.Empty,
                                                    Results = new List<Result>()
                                                };

            try
            {
                IList<ResponseQuery> responseQueries = DAL.GetQueries(request.idApp, request);

                foreach (ResponseQuery responseQuery in responseQueries)
                    response.Results.Add(Execute(responseQuery));

            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorCode = "PLRx201303071818";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public Result Execute(ResponseQuery responseQuery)
        {
            if (responseQuery == null || responseQuery.HasError)
            {
                return new Result
                {
                    DataReader = null,
                    ErrorMessage = responseQuery.ErrorMessage,
                    HasError = true,
                    Key = responseQuery.Query.Key
                };
            }

            Result result = new Result { Key = responseQuery.Query.Key, DataReader = null };

            try
            {
                if (responseQuery.Query.IsNonQuery)
                {
                    result.ResultNonQuery = DAL.RunNonQuery(responseQuery.QueryText, Connectors.Get(responseQuery.Query.Connector));
                    return result;
                }
                
                result.DataReader = DAL.RunQuery(responseQuery.QueryText, Connectors.Get(responseQuery.Query.Connector));
                return result;

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }

            return result;
        }

        public void Dispose()
        {
        }
    }
}