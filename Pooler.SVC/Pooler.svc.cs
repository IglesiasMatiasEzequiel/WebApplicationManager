using AppCommon.Functions;
using Pooler.API;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.ADO.Requests;
using Pooler.API.Entities.ADO.Responses;
using Pooler.API.Entities.Exceptions;

namespace Pooler.SVC
{
    public class Pooler : IPooler
    {
        public ResponseResult ExecuteQueries(RequestQuery request)
        {
            if (!Token.ValidatePoolerToken(request.Token))
                throw new TokenNotValidException("El token no es válido.");

            return new ExternalPooler().ExecuteQueries(request);
        }

        public ResponseQuery GetQuery(int idApp, Query query)
        {
            return DAL.GetQuery(idApp, query);
        }
    }
}
