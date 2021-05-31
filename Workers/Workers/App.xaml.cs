using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Workers.Service.Extensions;
using Workers.View;
using Workers.ViewModel;

namespace Workers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                }).Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWorkersServices()
                .AddSingleton<WorkerListView>()
                .AddSingleton<WorkerView>()
                .AddSingleton<WorkerListViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var workerListView = _host.Services.GetRequiredService<WorkerListView>();
            workerListView.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
