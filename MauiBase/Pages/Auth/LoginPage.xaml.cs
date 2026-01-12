using MauiBase.Pages.Auth.ViewModels;

namespace MauiBase.Pages.Auth
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}