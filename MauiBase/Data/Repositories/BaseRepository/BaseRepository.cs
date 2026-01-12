using SQLite;
namespace MauiBase.Data.Repositories.BaseRepository;

public class BaseRepository<T> : IBaseRepository<T> where T : new()
{
    protected readonly SQLiteAsyncConnection _db;

    public BaseRepository(SQLiteAsyncConnection db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAllAsync() =>
        await _db.Table<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _db.Table<T>()
                  .Where(x => (int)x.GetType().GetProperty("Id")!.GetValue(x)! == id)
                  .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(T entity) =>
        await _db.InsertAsync(entity);

    public async Task<int> UpdateAsync(T entity) =>
        await _db.UpdateAsync(entity);

    public async Task<int> DeleteAsync(T entity) =>
        await _db.DeleteAsync(entity);
}