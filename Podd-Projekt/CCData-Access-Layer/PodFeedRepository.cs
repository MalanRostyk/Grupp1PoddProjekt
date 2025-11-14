using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;

namespace CCData_Access_Layer
{
    public class PodFeedRepository
    {
        public readonly IMongoCollection<PodFeed> pfCollection;

        public PodFeedRepository()
        {
            var dbClient = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var db = dbClient.GetDatabase("PodderDB");
            pfCollection = db.GetCollection<PodFeed>("Podders");
        }
        public async Task AddAsync(PodFeed pf) => await pfCollection.InsertOneAsync(pf);
        public async Task<PodFeed?> GetAsync(string id)
        {
            var filter = Builders<PodFeed>.Filter.Eq(pf => pf.Id, id);
            return await pfCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<PodFeed>> GetAllAsync() => await pfCollection.Find(FilterDefinition<PodFeed>.Empty).ToListAsync();
        public async Task<bool> UpdateAsync(PodFeed pf)
        {
            var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, pf.Id);
            var update = await pfCollection.ReplaceOneAsync(filter, pf);
            return update.MatchedCount == 1 && update.ModifiedCount == 1;
        }
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, id);
            await pfCollection.DeleteOneAsync(filter);
        }
    }
}
