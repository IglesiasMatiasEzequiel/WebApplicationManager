using System.Configuration;
using System.Linq;
using AppCommon.Functions;
using Pooler.API.Entities.ADO;
using Pooler.API.Entities.Exceptions;

namespace Pooler.API
{
    public static class Connectors
    {
        public static readonly string ConnRepository = Encrypter.Decrypt(ConfigurationManager.AppSettings["ConnRepository"]);

        public static string Get(int connector)
        {
            //asd
            string query = "SELECT Id, EncryptedConnString FROM Connectors WHERE Id = " + connector;

            SQLDataReader dr = DAL.RunQuery(query, ConnRepository);

            if (dr == null)
                throw new NullResponseException("La respuesta fue nula");

            if (dr.Rows.Count <= 0)
                throw new ConnectorNotFoundException("No se encontró el conector parametrizado.");

            return Encrypter.Decrypt(dr.Rows.First().GetValue("EncryptedConnString"));
        }
    }
}