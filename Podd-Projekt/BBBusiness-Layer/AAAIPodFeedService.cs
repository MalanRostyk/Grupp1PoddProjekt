using DDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public interface AAAIPodFeedService
    {
        Task AddPodAsync(string rssUrl);

        Task<Pod?> GetPodAsync(string id);

        Task<List<Pod>> GetPodsAsync();

        Task<bool> UpdatePodAsync(string oldTitle, string newTitle);

        Task DeletePodAsync(string id);
        

    }
}
