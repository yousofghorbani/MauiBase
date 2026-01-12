namespace MauiBase.Data.Repositories.BaseRepository;

public interface IBaseRepository<T> where T : new()
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}