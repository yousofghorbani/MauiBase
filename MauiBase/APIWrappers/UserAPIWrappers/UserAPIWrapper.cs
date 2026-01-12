using MauiBase.Data.Repositories.AppUserSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiBase.APIWrappers.UserAPIWrappers
{
    public class UserAPIWrapper : BaseApiWrapper, IUserAPIWrapper
    {
        public UserAPIWrapper(IAppUserSettingRepository appUserSettingRepository) : base(appUserSettingRepository)
        {
        }
    }
}