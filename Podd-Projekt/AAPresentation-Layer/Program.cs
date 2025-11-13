using BBBusiness_Layer;
using DDModels;
using CCData_Access_Layer;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //ändrat igen 2
            IServicePodFeedRepo podfeedService = new ServicePodFeedRepo(new PodFeedRepository());
        }
    }
}