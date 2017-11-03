using MSSQLBulkCopy.Configarations;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLBulkCopy
{
    public class BulkOperations
    {
        public DataTable GetDataFromSource(string strTableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection SQLconnSource = MSSQLConn.GetSourceMSSQLConn())
                {
                    SQLconnSource.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from " + strTableName + "", SQLconnSource))
                    {
                        sqlCommand.CommandTimeout = 0;
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        sqlDataAdapter.SelectCommand = sqlCommand;

                        dt.Clear();
                        sqlDataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }


        public string BulkCopyToDestinationsServer(DataTable dt, string strTableName)
        {
            try
            {
                //Clean table data before data inser: Delete All
                DeleteTblAllData(strTableName);

                using (SqlConnection SQLconnDestination = MSSQLConn.GetDestinationMSSQLConn())
                {
                    SQLconnDestination.Open();
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(SQLconnDestination))
                    {
                        sqlBulkCopy.BulkCopyTimeout = 0;
                        sqlBulkCopy.DestinationTableName = strTableName;

                        sqlBulkCopy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Bulk Operation success";
        }


        public static void DeleteTblAllData(string strTableName)
        {
            try
            {
                using (SqlConnection SQLconnDestination = MSSQLConn.GetDestinationMSSQLConn())
                {
                    SQLconnDestination.Open();
                    using (SqlCommand command = new SqlCommand("IF EXISTS(select * from sys.databases where name='" + strTableName + "') truncate table " + strTableName + "", SQLconnDestination))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
