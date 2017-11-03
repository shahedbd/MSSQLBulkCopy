using System;
using System.Data;
using System.Diagnostics;

namespace MSSQLBulkCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started....");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();



            string strDBTableName = "Customers";
            BulkOperations _BulkOperations = new BulkOperations();
            DataTable dt = _BulkOperations.GetDataFromSource(strDBTableName);

            var result = _BulkOperations.BulkCopyToDestinationsServer(dt, strDBTableName);

            Console.WriteLine(result);

            Console.WriteLine("Total number of row transfer: " + dt.Rows.Count);
            Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("The End....");
            Console.ReadLine();

        }
    }
}
