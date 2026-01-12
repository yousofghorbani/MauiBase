using MauiBase.APIWrappers;
using MauiBase.APIWrappers.UserAPIWrappers;
using MauiBase.Data;
using MauiBase.Data.Repositories.AppUserSettings;
using MauiBase.Data.Repositories.BaseRepository;
using Microsoft.Extensions.Logging;

namespace MauiBase
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AppDatabase>(sp =>
            {
                var dbPath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "mesghal.db3");

                var db = new AppDatabase(dbPath);
                db.InitAsync().Wait();
                return db;
            });

            // ----------------------------  IOC Database Repositories  ----------------------------
            builder.Services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddSingleton<IAppUserSettingRepository, AppUserSettingRepository>();
            // ----------------------------  END IOC Database Repositories  ------------------------


            // ----------------------------  IOC API Wrappers  -------------------------------------
            builder.Services.AddSingleton<IBaseApiWrapper, BaseApiWrapper>();
            builder.Services.AddSingleton<IUserAPIWrapper, UserAPIWrapper>();
            // ----------------------------  END IOC API Wrappers  ---------------------------------

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}