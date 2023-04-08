using Dapper;
using DBLOG;
using FluentAssertions.Execution;
using System.Data.SqlClient;
using TechTalk.SpecFlow;
using Tests.Contexts;

namespace Tests.StepDefinitions;


[Binding]
public class StepDefinitions
{
    private readonly MyTestContext context;
    private DatabaseLogAnalyzer analyzer;

    private int recordsCount = 0;

    public StepDefinitions(MyTestContext context)
    {
        this.context = context;
    }

    [BeforeFeature]
    public static async Task BeforeFeature(MyTestContext context)
    {
        context.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "DatabaseSources");
        context.DBPassword = "P@ssw0rd";
        context.SourceDBName = "test_db";

        await context.CreateDatabaseAsync(1443);
    }

    [Given(@"I created the default database")]
    public async Task GivenICreatedTheDefaultDatabaseAsync()
    {
        analyzer = new DatabaseLogAnalyzer(context.ConnectionString);
    }
    
    [AfterFeature()]
    public static async Task AfterFeature(MyTestContext context)
    {    
        await context.DropDatabaseAsync();
     
    }
    
    [AfterScenario]
    public async Task AfterScenario(MyTestContext context)
    {     
        var fromTime = DateTime.Now.AddMinutes(-10);
        var toTime = DateTime.Now.AddMinutes(1);
        var tableName = "";

        var logs = analyzer.ReadLog(fromTime, toTime, tableName);

        using var connection = new SqlConnection(context.ConnectionString);   
        logs = logs.Skip(context.SkipLogs).ToArray();
        foreach (var log in logs.Reverse())
        {
             
            var results = await connection.QueryAsync(log.UndoSQL);
        }

        context.SkipLogs += logs.Length*2;
    }

    [When(@"I execute ""([^""]*)""")]
    public async Task WhenIExecuteAsync(string sql)
    {
        using var connection = new SqlConnection(context.ConnectionString);
        var results = await connection.QueryAsync(sql);

        recordsCount = results.Count();
    }
    [Given(@"the '([^']*)' has '([^']*)' rows")]
    [Then(@"the '([^']*)' has '([^']*)' rows")]
    public async Task ThenTheHasRowsAsync(string tableName, int expectedRows)
    {
        using var connection = new SqlConnection(context.ConnectionString);
        var count = await connection.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM {tableName}");

        count.Should().Be(expectedRows);
    }

    [Then(@"Transaction logs in the last (.*) min should be")]
    public void ThenTransactionLogsInTheLastMinShouldBe(int lastMinutes, Table table)
    {
        var fromTime = DateTime.Now.AddMinutes(-lastMinutes);
        var toTime = DateTime.Now.AddMinutes(1);
        var tableName = "";

        var logs = analyzer.ReadLog(fromTime, toTime, tableName);
        logs = logs.Skip(context.SkipLogs).ToArray();
        
        using (new AssertionScope())
        {
            logs.Length.Should().Be(table.RowCount);

            var rowIndex = 0;
            foreach (var row in table.Rows)
            {
                var log = logs[rowIndex];

                foreach (var header in table.Header)
                {
                    var val = row[header].Trim();

                    switch (header)
                    {
                        case "TransactionID":
                            log.TransactionID.Should().Be(val);
                            break;
                        case "ObjectName":
                            log.ObjectName.Should().Be(val);
                            break;
                        case "Operation":
                            log.Operation.Should().Be(val);
                            break;
                        case "Type":
                            log.Type.Should().Be(val);
                            break;
                        case "RedoSQL":
                            log.RedoSQL.Should().Be(val);
                            break;
                        case "UndoSQL":
                            log.UndoSQL.Should().Be(val);
                            break;
                        default:
                            break;
                    }
                }

                rowIndex++;
            }
        }
    }
}
