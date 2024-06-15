using Firebase.Database;
using Microsoft.Extensions.Logging;
using MyPro.Application.Interfaces;
using MyPro.Application.Services;
using MyPro.Infrastructure.Repositories;
using MyPro.Presentation;

namespace MyPro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            ConfigureServices(builder.Services);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var firebaseUrl = "https://mytaskapp-26179-default-rtdb.europe-west1.firebasedatabase.app/";
            services.AddSingleton(new FirebaseClient(firebaseUrl));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<AddProjectPage>();
            services.AddTransient<MainPage>();
            services.AddTransient<UserListPage>();
            services.AddTransient<LoginPage>();
            services.AddTransient<SignupPage>();
        }
    }
}
