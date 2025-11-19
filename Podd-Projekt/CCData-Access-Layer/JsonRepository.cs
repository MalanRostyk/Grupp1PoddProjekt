using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DDModels;

namespace CCData_Access_Layer
{
    public class JsonRepository : IJsonRepository
    {
        private readonly string Path = @"..\..\..\..\CCData-Access-Layer\podfeed.xml";
        public JsonRepository() { }
        public async Task SerializePodFeedJson(PodFeed pf)
        {
            await using FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.Write);
            await JsonSerializer.SerializeAsync(fs, pf);
        }
        public async Task<PodFeed> DeserializePodFeedJson()
        {
            await using FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<PodFeed>(fs);
        }
    }
}
