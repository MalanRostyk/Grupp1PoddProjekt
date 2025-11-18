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
        Task<PodFeed?> GetPodFeedAsync(string id);
        Task<List<PodFeed>> GetAllAsync();
        //Task<bool> UpdateNameAsync(PodFeed pf, string newName);
        //Task<bool> UpdateCategoryAsync(PodFeed pf, string newCategory);
        Task<bool> UpdatePodFeedAsync(PodFeed pf, string newName, string newCategory);
        Task<bool> UpdatePodFeedAsync(PodFeed pf, string newCategory);
        Task DeletePodFeedAsync(string id);
    }
}
