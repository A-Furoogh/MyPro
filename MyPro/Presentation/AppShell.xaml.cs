using MyPro.Application.Interfaces;
using MyPro.Presentation;

namespace MyPro
{
    public partial class AppShell : Shell
    {
        private readonly IServiceProvider _serviceProvider;
        public AppShell(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            CheckAuthentication();
        }

        private void CheckAuthentication()
        {
            var authenticationService = _serviceProvider.GetRequiredService<IAuthenticationService>();

            if (!authenticationService.IsUserAuthenticated())
            {
                CurrentItem = new ShellContent
                {
                    Content = _serviceProvider.GetRequiredService<LoginPage>()
                };
            }
            else
            {
                CurrentItem = new ShellContent
                {
                    //Use PushModalAsync to show the MainPage as a modal page
                    Content = _serviceProvider.GetRequiredService<MainPage>()
                };
            }
        }
    }
}
