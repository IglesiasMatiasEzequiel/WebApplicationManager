using System.ServiceModel;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.ADO.Requests;
using Pooler.API.Entities.ADO.Responses;

namespace Pooler.SVC
{
    [ServiceContract]
    public interface IPooler
    {
        [OperationContract]
        ResponseResult ExecuteQueries(RequestQuery request);

        [OperationContract]
        ResponseQuery GetQuery(int idApp, Query query);
    }
}
