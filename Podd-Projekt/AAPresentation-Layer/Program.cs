using BBBusiness_Layer;
using InterfacesLayer;
using CCData_Access_Layer;
using Microsoft.Extensions.DependencyInjection;

namespace AAPresentation_Layer
    
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddScoped<IPodFeedRepository, PodFeedRepository>();
            services.AddScoped<IPodFeedService, PodFeedService>();

            var provider = services.BuildServiceProvider();

            var form = ActivatorUtilities.CreateInstance< Form1 > (provider);



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(form);

       }
    }
}