using DDModels;
using CCData_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public interface IPodFeedService
    {
        Task AddPodFeedAsync(PodFeed pf);
        Task AddTempPodFeedAsync(PodFeed pf);
        Task<PodFeed?> GetPodFeedAsync(string id);
        Task<PodFeed?> GetTempPodFeedAsync();
        Task<List<PodFeed>> GetAllAsync();
        Task<List<PodFeed>> GetAllFilteredAsync(string category);
        Task<bool> UpdatePodFeedAsync(PodFeed pf, string newCategory);
        Task<bool> UpdatePodFeedAsync(PodFeed pf);
        Task UpdateRecentlySearchedAsync(PodFeed tempPf);
        Task DeletePodFeedAsync(string id);
        Task DeleteTempPodFeedAsync(string id);
        Task InsertDeleteTempAsync(PodFeed pfNew, PodFeed pfOld);
        string ValidateList(List<Pod> enlist);
    }
}
