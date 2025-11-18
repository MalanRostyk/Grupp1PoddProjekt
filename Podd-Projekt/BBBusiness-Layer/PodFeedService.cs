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
        private readonly IRepository<PodFeed> pfRepo;

        public PodFeedService(IRepository<PodFeed> pfRepository)
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
        //public async Task<bool> UpdateNameAsync(PodFeed pf, string newName)
        //{
        //    bool wasUpdated = false;
        //    PodFeed p = await pfRepo.GetAsync(pf.Id); //Hämta dok som PodFeed
        //    p.Name = newName;//Ändra det som ska ändras
        //    wasUpdated = await pfRepo.UpdateAsync(p);//Skicka tillbaks PodFeed och gör uppdatering
        //    return wasUpdated;
        //}
        //public async Task<bool> UpdateCategoryAsync(PodFeed pf, string newCategory)
        //{
        //    bool wasUpdated = false;
        //    PodFeed p = await pfRepo.GetAsync(pf.Id); //Hämta dok som PodFeed
        //    p.Name = newCategory;//Ändra det som ska ändras
        //    wasUpdated = await pfRepo.UpdateAsync(p);//Skicka tillbaks PodFeed och gör uppdatering
        //    return wasUpdated;
        //}

        public async Task<bool> UpdatePodFeedAsync(PodFeed pf, string newName, string newCategory)
        {
            bool wasUpdated = false;
            try
            {
                PodFeed p = await pfRepo.GetAsync(pf.Id);
                p.Name = newName;
                p.CategoryId = newCategory;

                wasUpdated = await pfRepo.UpdateAsync(p);
            }catch(NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return wasUpdated;
        }
        public async Task<bool> UpdatePodFeedAsync(PodFeed pf, string newCategory)
        {
            bool wasUpdated = false;
            try
            {
                PodFeed p = await pfRepo.GetAsync(pf.Id);
                p.CategoryId = newCategory;

                wasUpdated = await pfRepo.UpdateAsync(p);
            }catch(NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return wasUpdated;
        }
        public async Task DeletePodFeedAsync(string id) => await pfRepo.DeleteAsync(id);

    }
}
