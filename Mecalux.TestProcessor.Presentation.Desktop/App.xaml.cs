using Mecalux.TestProcessor.Business.Logic;
using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Mappers;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;
using Mecalux.TestProcessor.Services;
using Mecalux.TestProcessor.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using System.Windows;

namespace Mecalux.TestProcessor.Presentation.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Main Window
            services.AddTransient(typeof(MainWindow));

            //TextService
            services.AddTransient<ITextService, TextService>();
            services.AddTransient<ITextLogic, TextLogic>();
            services.AddTransient<ITextRepository, TextRepository>();
            services.AddTransient<ITextMapper, TextMapper>();

            //TextSortService
            services.AddTransient<ITextSortService, TextSortService>();
            services.AddTransient<ITextSortLogic, TextSortLogic>();
            services.AddTransient<ITextSortRepository, TextSortRepository>();
            services.AddTransient<ITextSortMapper, TextSortMapper>();
        }
    }
}