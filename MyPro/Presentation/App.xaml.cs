namespace MyPro
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            MainPage = new AppShell(_serviceProvider);
        }
    }
}
