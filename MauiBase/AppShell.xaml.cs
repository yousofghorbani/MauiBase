using MauiBase.Pages.Auth;

namespace MauiBase;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("Login", typeof(LoginPage));
        //Routing.RegisterRoute("Chat", typeof(ChatPage));
        //Routing.RegisterRoute("Profile", typeof(ProfilePage));
    }
}