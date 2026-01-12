using MauiBase.Data.Entities.AppUserSettings;
using MauiBase.Data.Repositories.BaseRepository;
using SQLite;
namespace MauiBase.Data.Repositories.AppUserSettings
{
    public class AppUserSettingRepository : BaseRepository<AppUserSetting>, IAppUserSettingRepository
    {
        public AppUserSettingRepository(SQLiteAsyncConnection db) : base(db)
        {
        }

        public async Task SetAsync(string name, string value)
        {
            var existing = await _db
                .Table<AppUserSetting>()
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (existing == null)
            {
                await _db.InsertAsync(new AppUserSetting
                {
                    Name = name,
                    Value = value
                });
            }
            else
            {
                existing.Value = value;
                await _db.UpdateAsync(existing);
            }
        }

        public async Task<string?> GetAsync(string name)
        {
            var item = await _db
                .Table<AppUserSetting>()
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            return item?.Value;
        }

        public async Task DeleteAsync(string name)
        {
            await _db.ExecuteAsync(
                "DELETE FROM AppUserSetting WHERE Name = ?", name);
        }
    }
}