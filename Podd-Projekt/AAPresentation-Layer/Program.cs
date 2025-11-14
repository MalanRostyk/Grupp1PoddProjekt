using BBBusiness_Layer;
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
            HttpClient client = new();
            var rssClient = new RssPodClient(client);
            Service service = new(rssClient);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service));

            //ändrat igen 2
        }
    }
}