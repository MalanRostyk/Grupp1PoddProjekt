using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBBusiness_Layer.Validation;
using CCData_Access_Layer;
using DDModels;

namespace BBBusiness_Layer
{
    public class Service : IService
    {
        private RssPodClient podClient;

        public Service(RssPodClient client)
        {
            podClient = client;
        }
        public async Task<List<Pod>> ReadAllPodAsync(string link) 
        {
            List<Pod> podList = await podClient.GetAllPodsAsync(link);
            var valLink = FeedValidator.ValidateTextBox(link);
            var validator = FeedValidator.ValidateList(podList);
            if (!valLink.IsValid)
            {
                if (!validator.IsValid)
                {
                    
                    Debug.WriteLine("This is not an RSS link");
                }
                Debug.WriteLine("Must enter a RSS link first.");
            }
            return podList;
        }
    }
}
