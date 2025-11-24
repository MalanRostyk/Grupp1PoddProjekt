using BBBusiness_Layer.Validation;
using CCData_Access_Layer;
using DDModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<PodFeed>> GetAllFilteredAsync(string category)
        {
            List<PodFeed> pfLista = await pfRepo.GetAllAsync();
            List<PodFeed> filteredList = new();
            if (category.Equals("None"))
            {
                return pfLista;
            }
            if (!category.Equals(""))
            {
                filteredList = GetFilteredList(pfLista, category);
            }
            return filteredList;
        }
        private List<PodFeed> GetFilteredList(List<PodFeed> allPf, string category)
        {
            List<PodFeed> filteredList = new();
            var query = allPf.Where(p => p.CategoryId == category).OrderByDescending(p => p.Name);
            foreach (var pf in query)
                filteredList.Add(pf);
            return filteredList;
        }

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
                PodFeed newPf = new();
                newPf.Id = pf.Id;
                newPf.Link = pf.Link;
                newPf.podList = pf.podList;
                newPf.Name = pf.Name;
                newPf.CategoryId = newCategory;

                wasUpdated = await pfRepo.UpdateAsync(newPf);
            }catch(NullReferenceException e)
            {
                Debug.WriteLine(e.Message);

            }
            return wasUpdated;
        }

        public async Task<bool> UpdatePodFeedAsync(PodFeed pf)
        {
            bool wasUpdated = false;
            try
            {
                wasUpdated = await pfRepo.UpdateAsync(pf);
                
            }catch(Exception e) { Debug.WriteLine(e.Message); }
            return wasUpdated;
        }

        public async Task DeletePodFeedAsync(string id) => await pfRepo.DeleteAsync(id);


        public async Task AddTempPodFeedAsync(PodFeed dummyPf) => await pfRepo.AddTempAsync(dummyPf);
        public async Task<PodFeed?> GetTempPodFeedAsync() => await pfRepo.GetTempAsync();
        public string ValidateList(List<Pod> enlist)
        {
            string emptyList = "";
            var validationResult = FeedValidator.ValidateList(enlist);
            if (!validationResult.IsValid)
            {
                emptyList = validationResult.GetErrorString();
            }
            return emptyList;
        }

        public async Task DeleteTempPodFeedAsync(string id) => await pfRepo.DeleteTempAsync(id);
        public async Task InsertDeleteTempAsync(PodFeed pfNew, PodFeed pfOld) => await pfRepo.TempInsertOneDeleteOtherAsync(pfNew, pfOld);
    }
}
