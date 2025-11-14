using DDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public interface IPodFeedRepository : IRepository<PodFeed>
    {
        Task AddAsync(PodFeed pf);
        Task<PodFeed?> GetAsync(string id);
        Task<List<PodFeed>> GetAllAsync();
        Task<bool> UpdateAsync(PodFeed pf);
        Task DeleteAsync(string id);
    }
}
