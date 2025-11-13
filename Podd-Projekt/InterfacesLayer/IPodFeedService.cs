using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace InterfacesLayer
{
    public interface IPodFeedService
    {
        Task<List<PodFeed>> GetAllFeedsAsync();
        Task AddFeedFromUrlAsync(string rssUrl, string category);
        Task UpdateFeedasync(string oldTitle, string newtitle);
    }
}
