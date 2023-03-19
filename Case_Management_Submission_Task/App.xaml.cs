using Case_Management_Submission_Task.Contexts;
using Case_Management_Submission_Task.MVVM.Models.Entities;
using Case_Management_Submission_Task.MVVM.ViewModels;
using Case_Management_Submission_Task.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Case_Management_Submission_Task
{
    public partial class App : Application
    {
        public static IHost app { get; private set; } = null!;
        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<DatabaseService>();
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = app!.Services.GetRequiredService<NavigationStore>();
            var databaseService = app!.Services.GetRequiredService<DatabaseService>();

            navigationStore.CurrentViewModel = new CustomersViewModel(navigationStore, databaseService);

            app.Start();

            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.DataContext = new MainViewModel(navigationStore, databaseService);
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
