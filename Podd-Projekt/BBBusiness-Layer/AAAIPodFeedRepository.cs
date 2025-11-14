using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using BBBusiness_Layer;

namespace BBBusiness_Layer
{
    public interface AAAIPodFeedRepository
    {
        Task AddAsync(Pod p);

        Task<List<Pod>> GetAllAsync();

        Task<bool> UpdateAsync(Pod p);

        Task DeleteAsync(string id);
        Task<Pod?> GetOneAsync(string id);
    }
}
