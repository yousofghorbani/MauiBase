using MauiBase.Data.Entities.AppUserSettings;
using MauiBase.Data.Repositories.BaseRepository;
namespace MauiBase.Data.Repositories.AppUserSettings
{
    public interface IAppUserSettingRepository : IBaseRepository<AppUserSetting>
    {
        Task SetAsync(string name, string value);
        Task<string?> GetAsync(string name);
        Task DeleteAsync(string name);
    }
}