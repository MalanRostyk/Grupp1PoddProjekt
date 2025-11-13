using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace InterfacesLayer
{
    public interface IPodFeedRepository
    {
        Task<List<PodFeed>> GetAllAsync();
        Task AddAsync(PodFeed feed);
        Task UpdateAsync(PodFeed feed);
        Task DeleteAsync(string feedId);

    }
}
