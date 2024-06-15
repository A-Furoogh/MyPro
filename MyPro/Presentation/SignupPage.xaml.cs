using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.Presentation;

public partial class SignupPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    public SignupPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private async void OnSignupClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Fehlgeschlagen", "Benutzername oder Passwort leer", "OK");
            return;
        }
        else if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Fehlergeschlagen", "Passwörter stimmen nicht", "OK");
            return;
        }
        var userServiceProvider = _serviceProvider.GetRequiredService<IUserRepository>();

        string email = EmailEntry.Text;
        if (string.IsNullOrEmpty(email))
        {
            email = " ";
        }
        User user = new User
        {
            Name = UsernameEntry.Text,
            Password = PasswordEntry.Text,
            Email = email,
            Id = await GenerateUserId(),
            ProjectsIds = new List<int>()
        };
        try
        {
            await userServiceProvider.AddUserAsync(user);
            await DisplayAlert("Erfolgreich", "Benutzer erfolgreich angelegt", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Anmeldefehler", ex.Message, "OK");
            //await Navigation.PopAsync();
        }

        async Task<int> GenerateUserId()
        {
            var users = await userServiceProvider.GetAllUsersAsync();
            Random random = new Random();
            int userId = random.Next(1000, 9999);
            while (users.Any(u => u.Id == userId))
            {
                userId = random.Next(1000, 9999);
            }
            return userId;
        }

    }
    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.RequestAsync<Permissions.Photos>();

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Zugriff verweigert", "nicht möglich Bild zu wählen.", "OK");
                return;
            }

            // Pick a photo
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "wähle ein Bild aus",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                //ProfileImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Fehler aufgetreten: {ex.Message}", "OK");
        }
    }
}