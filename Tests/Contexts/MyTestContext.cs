using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Tests.Contexts;

public sealed class MyTestContext
{
    public string DBPassword { get; set; } = string.Empty;
    public string DBName { get; private set; } = "test_db";
    public int DBPort { get; private set; }

    public string SourcePath { get; set; } = string.Empty;
    public string SourceDBName { get; set; } = string.Empty;
    private string TempFolderPath => Path.Combine(SourcePath, "temp");

    public string ConnectionString { get => $"Server={dbContainer.Hostname},{DBPort};Database={DBName};User Id=sa;Password={DBPassword};TrustServerCertificate=True;"; }

    public IContainer dbContainer = default!;

    public int SkipLogs { get; set; } = 0;
    
    public async Task CreateDatabaseAsync(int? port = null)
    {
        try
        {
            DBPort = port ?? new Random().Next(10000, 12000);

            CopyFile($"{SourceDBName}.mdf", $"{DBPort}.mdf");
            CopyFile($"{SourceDBName}_log.ldf", $"log_{DBPort}.ldf");

            dbContainer = new ContainerBuilder()
                .WithImage("octopusdeploy/mssql-server-windows-express")
                .WithAutoRemove(true)
                .WithEnvironment("sa_password", DBPassword)
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("attach_dbs", $"[{{'dbName': '{DBName}', 'dbFiles': ['C:\\\\temp\\\\{DBPort}.mdf', 'C:\\\\temp\\\\log_{DBPort}.ldf'] }}]")
                .WithPortBinding(DBPort, 1433)
                .WithBindMount(TempFolderPath, @"C:\temp\")
                .WithWaitStrategy(Wait.ForWindowsContainer().UntilPortIsAvailable(1433))
                .Build();

            await dbContainer.StartAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task DropDatabaseAsync()
    {
        await dbContainer.StopAsync();

        DeleteFile($"{DBPort}.mdf");
        DeleteFile($"log_{DBPort}.ldf");
    }


    private void CopyFile(string originalFileName, string newFileName)
    {
        if (Directory.Exists(TempFolderPath) == false)
            Directory.CreateDirectory(TempFolderPath);

        File.Copy(Path.Combine(SourcePath, originalFileName),
            Path.Combine(TempFolderPath, newFileName), true);
    }

    private void DeleteFile(string newFileName)
    {
        File.Delete(Path.Combine(TempFolderPath, newFileName));
    }
}
