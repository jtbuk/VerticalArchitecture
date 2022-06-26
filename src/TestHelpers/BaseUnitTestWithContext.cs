using Microsoft.Data.Sqlite;

namespace Jtbuk.VerticalArchitecture.TestHelpers;

public abstract class BaseUnitTestWithContext<TContext> : BaseUnitTest where TContext : BaseContext
{
    public TContext GetContext()
    {
        var connection = new SqliteConnection($"DataSource=Capp_CoreInMemory_{Guid.NewGuid()};mode=memory;cache=shared");
        connection.Open();
        var options = new DbContextOptionsBuilder<TContext>().UseSqlite(connection).Options;
        var instance = (Activator.CreateInstance(typeof(TContext), new object[] { options }) as TContext)!;

        instance.Database.EnsureCreated();

        return instance;
    }
}

