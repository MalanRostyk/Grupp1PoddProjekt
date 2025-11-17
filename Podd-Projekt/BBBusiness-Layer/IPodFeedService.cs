using DDModels;
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
        Task<PodFeed?> GetPodFeedAsync(string id);
        Task<List<PodFeed>> GetAllAsync();
        Task<bool> UpdatePodFeedAsync(PodFeed pf, string newName, string newCategoryId);
        Task DeletePodFeedAsync(string id);
        Task<List<PodFeed>> GetByCategoryAsync(string categoryId);
        Task<bool> UpdateCategoryAsync(string podFeedId, string newCategoryId);
        Task<List<PodFeed>> GetUncategorizedAsync();
        Task<bool> UpdateNameAsync(string podFeedId, string newName);
    }
}