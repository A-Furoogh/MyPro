using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.Presentation;

public partial class AddProjectPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private int _userId;
    public AddProjectPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        LoadUserId();
    }
    private async void OnSaveProjectClicked(object sender, EventArgs e)
    {
        var projectProvider = _serviceProvider.GetRequiredService<IProjectRepository>();
        async Task<int> GenerateProjectId()
        {
            var projects = await projectProvider.GetAllProjectsAsync();
            Random random = new Random();
            int projectId = random.Next(1000, 9999);
            while (projects.Any(u => u.Id == projectId))
            {
                projectId = random.Next(1000, 9999);
            }
            return projectId;
        }
        try
            {
            var project = new Project
            {
                Id = await GenerateProjectId(),
                Name = ProjectNameEntry.Text,
                Description = ProjectDescriptionEntry.Text,
                UsersIds = new List<int> { _userId },
                StartDate = StartDatePicker.Date,
                EndDate = EndDatePicker.Date
            };
            var projectService = _serviceProvider.GetRequiredService<IProjectService>();
            await projectService.AddProjectAsync(project);
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
    private void LoadUserId()
    {
        var authenticationService = _serviceProvider.GetRequiredService<IAuthenticationService>();
        _userId = authenticationService.GetUserIdAsync();
    }
    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        var userListPage = _serviceProvider.GetRequiredService<UserListPage>();
        await Navigation.PushAsync(userListPage);
    }

    private async void OnMemberSelected(object sender, EventArgs e)
    {
    }


}