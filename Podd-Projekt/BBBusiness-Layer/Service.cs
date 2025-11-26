using System;
using System.Collections.Generic;
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
            var validateLink = FeedValidator.ValidateLink(link);
            List<Pod> podList = new();
            if(validateLink.IsValid)
            {
                podList = await podClient.GetAllPodsAsync(link);
            }
            return podList;
        }
    }
}
