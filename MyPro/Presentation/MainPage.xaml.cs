using Firebase.Database;
using MyPro.Domain.Entities;
using MyPro.Presentation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyPro.Application.Interfaces;

namespace MyPro
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
        int userId;
        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void LoadUserId()
        {
            var authenticationService = _serviceProvider.GetRequiredService<IAuthenticationService>();
            userId = authenticationService.GetUserIdAsync();
        }
        protected override async void OnNavigatedTo(NavigatedToEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadUserId();
            await LoadProjects();
        }

        [Obsolete]
        private async Task LoadProjects()
        {
            var projectService = _serviceProvider.GetRequiredService<IProjectService>();
            var projects = await projectService.GetAllProjectsByUserIdAsync(userId);
            Projects.Clear();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        // Event handler stubs for navigation and other actions
        private async void OnProjectSelected(object sender, EventArgs e)
        {
            // Navigate to ProjectPage
            var projectPage = _serviceProvider.GetRequiredService<ProjectPage>();
            await Navigation.PushAsync(projectPage);
        }

        private async void OnViewUsersClicked(object sender, EventArgs e)
        {
            var userListPage = _serviceProvider.GetRequiredService<UserListPage>();
            await Navigation.PushAsync(userListPage);
        }

        private async void OnGotoLoginPageClicked(object sender, EventArgs e)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(loginPage);
        }

        private async void OnAddProjectClicked(object sender, EventArgs e)
        {
            var addProjectPage = _serviceProvider.GetRequiredService<AddProjectPage>();
            await Navigation.PushAsync(addProjectPage);
        }

        private async void OnGotoProjectListClicked(object sender, EventArgs e)
        {
            // var projectListPage = _serviceProvider.GetRequiredService<ProjectListPage>();
            // await Navigation.PushAsync(projectListPage);
        }

        private async void OnGotoSignupClicked(object sender, EventArgs e)
        {
            var signupPage = _serviceProvider.GetRequiredService<SignupPage>();
            await Navigation.PushAsync(signupPage);
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(loginPage);
        }
    }
}
