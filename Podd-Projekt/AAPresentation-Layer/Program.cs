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
            //HttpClient client = new();
            //var rssClient = new RssPodClient(client);
            //PodFeedRepository pfRepo = new();

            IService service = new Service(new RssPodClient(new HttpClient()));//Dependency Injection
            IPodFeedService pfService = new PodFeedService(new PodFeedRepository());//Dependency Injection
            ICategoryService catService = new CategoryService(new CategoryRepository());

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service, pfService,catService));
        }
    }
}