using SQLite;
using MauiBase.Data.Entities.AppUserSettings;

namespace MauiBase.Data;

public class AppDatabase
{
    public SQLiteAsyncConnection Connection { get; }

    public AppDatabase(string dbPath)
    {
        Connection = new SQLiteAsyncConnection(dbPath);
    }

    public async Task InitAsync()
    {
        await Connection.CreateTableAsync<AppUserSetting>();
    }
}