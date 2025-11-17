using CCData_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;
using System.Diagnostics;

namespace BBBusiness_Layer
{
    public class PodFeedService : IPodFeedService
    {
        private readonly PodFeedRepository pfRepo;

        public PodFeedService(PodFeedRepository pfRepository)
        {
            pfRepo = pfRepository;
        }

        public async Task AddPodFeedAsync(PodFeed pf) => await pfRepo.AddAsync(pf);
        public async Task<PodFeed?> GetPodFeedAsync(string id)
        {
            PodFeed? p = null;
            try
            {
                p = await pfRepo.GetAsync(id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return p;
        }

        public async Task<List<PodFeed>> GetAllAsync() => await pfRepo.GetAllAsync();
        public async Task<bool> UpdatePodFeedAsync(PodFeed pf, string newName, string newCategoryId)
        {
            bool wasUpdated = false;
            try
            {
                PodFeed p = await pfRepo.GetAsync(pf.Id);
                p.Name = newName;
                p.CategoryId = newCategoryId;

                wasUpdated = await pfRepo.UpdateAsync(p);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return wasUpdated;
        }

        public async Task DeletePodFeedAsync(string id) => await pfRepo.DeleteAsync(id);

        public async Task<List<PodFeed>> GetByCategoryAsync(string categoryId)
        {
            var filter = Builders<PodFeed>.Filter.Eq(pf => pf.CategoryId, categoryId);
            return await pfRepo.pfCollection.Find(filter).ToListAsync();
        }
        public async Task<bool> UpdateCategoryAsync(string podFeedId, string newCategoryId)
        {
            bool isUpdated = false;
            using (var session = pfRepo.dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, podFeedId);
                    var update = Builders<PodFeed>.Update.Set(p => p.CategoryId, newCategoryId);
                    var result = await pfRepo.pfCollection.UpdateOneAsync(filter, update);
                    isUpdated = result.ModifiedCount == 1;

                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
            return isUpdated;
        }
        public async Task<List<PodFeed>> GetUncategorizedAsync()
        {
            var filter = Builders<PodFeed>.Filter.Eq(pf => pf.CategoryId, null) |
                         Builders<PodFeed>.Filter.Eq(pf => pf.CategoryId, "");
            return await pfRepo.pfCollection.Find(filter).ToListAsync();
        }
        public async Task<bool> UpdateNameAsync(string podFeedId, string newName)
        {
            bool isUpdated = false;
            using (var session = pfRepo.dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, podFeedId);
                    var update = Builders<PodFeed>.Update.Set(p => p.Name, newName);
                    var result = await pfRepo.pfCollection.UpdateOneAsync(filter, update);
                    isUpdated = result.ModifiedCount == 1;
                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
            return isUpdated;
        }
    }
}