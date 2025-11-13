using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesLayer;
using DDModels;
using System.Xml;
using System.ServiceModel.Syndication;

namespace BBBusiness_Layer
{
    public class PodFeedService :IPodFeedService
    {
        private readonly IPodFeedRepository podRepo;

        public PodFeedService(IPodFeedRepository podRepo)
        {
            this.podRepo = podRepo;
        }

        public async Task<List<PodFeed>> GetAllFeedsAsync() =>
            await podRepo.GetAllAsync();

        public async Task AddFeedFromUrlAsync(string rssUrl, string category)
        {
            using var reader = XmlReader.Create(rssUrl);
            var feed = SyndicationFeed.Load(reader);

            var newFeed = new PodFeed
            {
                Title = feed.Title.Text,
                Url = rssUrl,
                Category = category,
                Episodes = feed.Items.Select(item => new PodEpisode
                {
                    Title = item.Title.Text,
                    PublishDate = item.PublishDate.DateTime
                }).ToList()
            };
            await podRepo.AddAsync(newFeed);
        }

        public async Task UpdateFeedasync(string oldTitle, string newtitle)
        {
            var feeds = await podRepo.GetAllAsync();
            var feedToUpdate = feeds.FirstOrDefault(f => f.Title == oldTitle);
            if (feedToUpdate != null)
            {
                feedToUpdate.Title = newtitle;
                await podRepo.UpdateAsync(feedToUpdate);
            }
        }


    }
}
