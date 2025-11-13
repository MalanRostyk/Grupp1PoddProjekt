using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;

namespace BBBusiness_Layer
{
    public class PodFeedService : IPodFeedService
    {
        public readonly IRepository<Pod> podRepo;

        public PodFeedService(IRepository<Pod> podRepo)
        {
            this.podRepo = podRepo;
        }

        public async Task AddPodAsync(Pod p) => await podRepo.AddAsync(p);
        //R
        public async Task<Pod?> GetPodAsync(string id) => await podRepo.GetOneAsync(id);
        //R
        public async Task<List<Pod>> GetPodsAsync() => await podRepo.GetAllAsync();
        //U
        public async Task<bool> UpdatePodAsync(Pod p) => await podRepo.UpdateAsync(p);
        //D
        public async Task DeletePodAsync(string id) => await podRepo.DeleteAsync(id);
    }
}
