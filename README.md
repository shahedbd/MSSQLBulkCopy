# MSSQL Bulk Data Copy
* Using C# Bulk data copy from one source table to destination table.

```C#
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
```
