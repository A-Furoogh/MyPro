using MyPro.Application.Interfaces;

namespace MyPro.Presentation;

public partial class UserListPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    public UserListPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;

        LoadUsers();
    }

    private async void LoadUsers()
    {
        var userService = _serviceProvider.GetRequiredService<IUserService>();
        var users = await userService.GetAllUsersAsync();
        UserListView.ItemsSource = users;
    }

    private async void OnUserSelected(object sender, EventArgs e)
    {
    }
}