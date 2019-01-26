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

### Connection String
```C#
  <connectionStrings>
    <add name="SourceSQLDBConn" connectionString="Server=DESKTOP-3KU7CQB\MSSQLSERVER2014; Database=DevTemp; User ID=devproject;Password=dev123456" />
    <add name="DestinationSQLDBConn" connectionString="Server=DESKTOP-3KU7CQB\MSSQLSERVER2014; Database=Destination; User ID=devproject;Password=dev123456" />
  </connectionStrings> 
```
