using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DDModels;
using CCData_Access_Layer;

namespace BBBusiness_Layer
{
    public class JsonService : IJsonService
    {
        private IJsonRepository jsonRepo;

        public JsonService(IJsonRepository jsonRepo)
        {
            this.jsonRepo = jsonRepo;
        }


        public async Task SavePodFeedToJson(PodFeed pf)
        {
            await jsonRepo.SerializePodFeedJson(pf);
        }

        public async Task<PodFeed> LoadPodFeedFromJson()
        {
            return await jsonRepo.DeserializePodFeedJson();
        }


    }
}
