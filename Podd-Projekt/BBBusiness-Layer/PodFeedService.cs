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

        public PodFeedService(IRepository<PodFeed> pfRepository)=> pfRepo = pfRepository;

        public async Task AddPodFeedAsync(PodFeed pf)
        {
            if (pf == null)
                throw new NullReferenceException("The feed being added does not exist");

            await pfRepo.AddAsync(pf);
                
        }
        public async Task<PodFeed?> GetPodFeedAsync(string id)
        {
            return await pfRepo.GetAsync(id);
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

        public async Task<bool> UpdatePodFeedAsync(PodFeed pf, string newCategory)
        {
            if (string.IsNullOrWhiteSpace(pf.Name) && string.IsNullOrWhiteSpace(pf.CategoryId))
                throw new FormatException("The selected RSS feed does not coontain valid values");
            PodFeed newPf = new();
            newPf.Id = pf.Id;
            newPf.Link = pf.Link;
            newPf.podList = pf.podList;
            newPf.Name = pf.Name;
            newPf.CategoryId = newCategory;

            return await pfRepo.UpdateAsync(newPf);
        }

        public async Task<bool> UpdatePodFeedAsync(PodFeed pf)
        {
            if (string.IsNullOrWhiteSpace(pf.Name) && string.IsNullOrWhiteSpace(pf.CategoryId))
                throw new FormatException("The selected RSS feed does not coontain valid values");
            return await pfRepo.UpdateAsync(pf);
        }

        public async Task DeletePodFeedAsync(string id)
        {
            await pfRepo.DeleteAsync(id);
        }

        public async Task AddTempPodFeedAsync(PodFeed dummyPf) => await pfRepo.AddTempAsync(dummyPf);
        public async Task<PodFeed?> GetTempPodFeedAsync() => await pfRepo.GetTempAsync();
        public string ValidateList(List<Pod> enList)
        {
            string emptyList = "";
            var validationResult = FeedValidator.ValidateList(enList);
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
