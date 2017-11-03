using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MSSQLBulkCopy.Configarations
{
    public static class MSSQLConn
    {
        public static SqlConnection GetSourceMSSQLConn()
        {
            SqlConnection connMSSQLDB = null;
            try
            {
                connMSSQLDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SourceSQLDBConn"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connMSSQLDB;
        }

        public static SqlConnection GetDestinationMSSQLConn()
        {
            SqlConnection connMSSQLDB = null;
            try
            {
                connMSSQLDB = new SqlConnection(ConfigurationManager.ConnectionStrings["DestinationSQLDBConn"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connMSSQLDB;
        }


    }
}
