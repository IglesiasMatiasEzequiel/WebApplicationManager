using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pooler.API.Entities.ADO
{
    public class SQLAccess : IDisposable
    {
        private SqlConnection SqlConnection;

        public SQLAccess(string connString)
        {
            SqlConnection = new SqlConnection { ConnectionString = connString };

            if (SqlConnection.State != ConnectionState.Open)
                SqlConnection.Open();
        }

        public SqlTransaction BeginTran()
        {
            return SqlConnection.BeginTransaction();
        }

        public void ExecuteSQLNonQuery(IList<string> sqlQueries)
        {
            SqlTransaction beginTrans = SqlConnection.BeginTransaction();

            try
            {
                foreach (string sqlQuery in sqlQueries)
                    ExecuteSQLNonQuery(sqlQuery, beginTrans);

                beginTrans.Commit();
            }
            catch (Exception)
            {
                beginTrans.Rollback();
                throw;
            }
        }

        public int ExecuteSQLNonQuery(string query, SqlTransaction sqlTransaction = null)
        {
            return new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = SqlConnection,
                Transaction = sqlTransaction
            }.ExecuteNonQuery();
        }

        public SQLDataReader ExecuteSQLReader(string query, SqlTransaction sqlTransaction = null)
        {
            SqlCommand comm = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = SqlConnection,
                Transaction = sqlTransaction
            };

            return ToDataReader(comm.ExecuteReader());
        }

        #region Private methods

        private SQLDataReader ToDataReader(IDataReader result)
        {
            SQLDataReader dataReader = new SQLDataReader {Rows = new List<SQLRow>()};

            DataTable schemaTable = result.GetSchemaTable();

            while (result.Read())
            {
                SQLRow row = new SQLRow {Columns = new List<SQLColumn>()};

                foreach (DataRow dataRow in schemaTable.Rows)
                {
                    string columnName = dataRow["ColumnName"].ToString();
                    SQLColumn register = new SQLColumn {Name = columnName, Value = result[columnName].ToString()};

                    row.Columns.Add(register);
                }

                dataReader.Rows.Add(row);
            }

            return dataReader;
        }

        #endregion

        public void Dispose()
        {
            SqlConnection.Close();
            SqlConnection = null;
        }
    }
}