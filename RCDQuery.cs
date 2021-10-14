using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvin
{
    public delegate void QueryCallBack(DataTable dataTable, Boolean queryResult);

    public class RCDQuery
    {
        private SqlConnection connectionRCD;
        private SqlCommand sqlQueryRCD;
        private SqlCommand sqlQueryServerTime;
        private SqlDataAdapter sqlDataAdapterRCD;
        private SqlDataReader sqlDataReaderRCD;
        private QueryCallBack queryCallBack;
        private Exception exceptionCode;
        private DataTable dataTable;
        private DateTime serverQueryTime;

        public RCDQuery(String queryString)
        {
            connectionRCD = new SqlConnection(Properties.Resources.RyDConn);
            sqlQueryRCD = new SqlCommand(queryString, connectionRCD);
            sqlQueryServerTime = new SqlCommand("SELECT CURRENT_TIMESTAMP", connectionRCD);
        }

        public bool setQueryCallBack(QueryCallBack callbackDelegate)
        {
            queryCallBack = callbackDelegate;
            return true;
        }

        public void getDataTableThread()
        {
            Boolean queryResult;
            if (!(queryResult = fillDataTable()))
                dataTable = null;
            if (queryCallBack != null)
                queryCallBack(dataTable, queryResult);
        }

        public DataTable getDataTable()
        {
            if (fillDataTable())
                return dataTable;
            else
                return null;
        }

        private Boolean fillDataTable()
        {
            Boolean returnValue = true;
            try
            {
                if (returnValue = openConnection())
                {
                    dataTable = new DataTable();
                    sqlDataAdapterRCD = new SqlDataAdapter(sqlQueryRCD);
                    sqlDataAdapterRCD.Fill(dataTable);
                    if (openDataReader())
                        serverQueryTime = (DateTime)getDataReaderRecord(0);
                    closeDataReader();
                }
            }
            catch (Exception ex)
            {
                exceptionCode = ex;
                returnValue = false;
            }
            return returnValue;
        }

        private Boolean openConnection()
        {
            bool returnValue = true;
            if (connectionRCD.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connectionRCD.Open();
                }
                catch (Exception ex)
                {
                    exceptionCode = ex;
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private Boolean closeConnection()
        {
            Boolean returnValue = true;
            if (connectionRCD.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connectionRCD.Close();
                }
                catch (Exception ex)
                {
                    exceptionCode = ex;
                    returnValue = false;
                }
            }
            return returnValue;
        }

        public Boolean openDataReader()
        {
            Boolean returnValue = true;
            if (openConnection()) 
                try
                {
                    sqlDataReaderRCD = sqlQueryServerTime.ExecuteReader();
                }
                catch (Exception ex)
                {
                    exceptionCode = ex;
                    returnValue = false;
                }
            return returnValue;
        }

        public Boolean closeDataReader()
        {
            Boolean returnValue = true;
            try
            {
                if (sqlDataReaderRCD != null && (!sqlDataReaderRCD.IsClosed))
                    sqlDataReaderRCD.Close();
                sqlDataReaderRCD = null;
                closeConnection();
            }
            catch (Exception ex)
            {
                exceptionCode = ex;
                returnValue = false;
            }
            return returnValue;
        }

        public Object getDataReaderRecord(int fieldNumber)
        {
            if (!sqlDataReaderRCD.IsClosed)
                sqlDataReaderRCD.Read();
            return sqlDataReaderRCD[fieldNumber];
        }

        public DateTime getServerTime()
        {
            return serverQueryTime;
        }
    }
}
