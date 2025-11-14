using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DDModels;
using CCData_Access_Layer;
using MongoDB.Driver;
using System.ServiceModel.Syndication;

namespace BBBusiness_Layer
{
    public class PodFeedService : AAAIPodFeedService //IPodFeedService
    {
        public readonly AAAIPodFeedRepository podRepo;

        public PodFeedService(AAAIPodFeedRepository podRepo)
        {
            this.podRepo = podRepo;
        }
        //C
        public async Task AddPodAsync(string rssUrl)
        {
            using var reader = XmlReader.Create(rssUrl);
            var feed = SyndicationFeed.Load(reader);

            var newPod = new Pod();
            await podRepo.AddAsync(newPod);
        }
        //R
        public async Task<List<Pod>> GetPodsAsync() => await podRepo.GetAllAsync();
        //U
        public async Task<bool> UpdatePodAsync(string oldTitle, string newTitle)
        {
            var feeds = await podRepo.GetAllAsync();
            var podToUpdate = feeds.FirstOrDefault(p => p.PodName == oldTitle);
            if(podToUpdate != null)
            {
                podToUpdate.PodName = newTitle;
                return await podRepo.UpdateAsync(podToUpdate);
            }
            return false;
        } 
        //D
        public async Task DeletePodAsync(string id) => await podRepo.DeleteAsync(id);

        //R
        public async Task<Pod?> GetPodAsync(string id) => await podRepo.GetOneAsync(id);
    }
}
