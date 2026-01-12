using MauiBase.Pages.Auth.ViewModels;

namespace MauiBase.Pages.Auth.Services
{
    public class AuthService
    {
        public async Task<bool> LoginAsync(LoginRequest request)
        {
            await Task.Delay(1500);

            
            if (request.Username == "admin" && request.Password == "1234")
                return true;

            return false;
        }
    }
}