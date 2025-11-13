using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace BBBusiness_Layer
{
    public interface IPodFeedService
    {
        //C
        Task AddPodAsync(Pod p);
        //R
        Task<Pod?> GetPodAsync(string id);
        //R
        Task<List<Pod>> GetPodsAsync();
        //U
        Task<bool> UpdatePodAsync(Pod p);
        //D
        Task DeletePodAsync(string id);
    }
}
