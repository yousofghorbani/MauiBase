using SQLite;

namespace MauiBase.Data.Entities.AppUserSettings;

[Table("AppUserSetting")]
public class AppUserSetting
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed(Name = "IX_Setting_Name", Unique = true)]
    public string Name { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}