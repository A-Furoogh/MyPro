using MyPro.Application.Interfaces;

namespace MyPro.Presentation;

public partial class LoginPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    public LoginPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            await DisplayAlert("Einloggen Fehlgeschlagen", "Bitte geben Sie Benutername und Passwordt ein", "OK");
            return;
        }

        var authenticationService = _serviceProvider.GetRequiredService<IAuthenticationService>();

        bool authenticated = await authenticationService.AuthenticateUserAsync(UsernameEntry.Text, PasswordEntry.Text);

        if (authenticated)
        {
            int userId = authenticationService.GetUserIdAsync();
            if (userId > 0)
            {
                var mainPage = _serviceProvider.GetRequiredService<MainPage>();
                await Navigation.PushModalAsync(new NavigationPage(mainPage));
            }
        }
        else
        {
            await DisplayAlert("Einloggen Fehlgeschlagen", "Benutername oder Passwordt ist falsch", "OK");
        }
    }
    private async void OnGotoSignupClicked(object sender, EventArgs e)
    {
        var signupPage = _serviceProvider.GetRequiredService<SignupPage>();
        await Navigation.PushAsync(signupPage);
    }
}