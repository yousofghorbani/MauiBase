using MauiBase.Pages.Auth.Services;
using System.Windows.Input;

namespace MauiBase.Pages.Auth.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly AuthService _authService;

        string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            IsBusy = false;
            _authService = new AuthService();
            LoginCommand = new Command(async () => await LoginAsync());
        }

        async Task LoginAsync()
        {
            try
            {
                ErrorMessage = string.Empty;
                IsBusy = true;

                var result = await _authService.LoginAsync(new LoginRequest
                {
                    Username = Username,
                    Password = Password
                });

                IsBusy = false;

                if (!result)
                {
                    ErrorMessage = "❌ Username and password do not match";
                    return;
                }

                await Application.Current.MainPage.DisplayAlertAsync(
                    "Success", "Login successful 🎉", "OK");
            }
            catch
            {
                IsBusy = false;
                ErrorMessage = "An error occurd";
                return;
            }
            
        }
    }
}