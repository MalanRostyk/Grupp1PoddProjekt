using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;

namespace CCData_Access_Layer
{
    public class PodFeedRepository
    {
        public IMongoClient dbClient;
        public readonly IMongoCollection<PodFeed> pfCollection;

        public PodFeedRepository()
        {
            dbClient = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var db = dbClient.GetDatabase("PodderDB");
            pfCollection = db.GetCollection<PodFeed>("Podders");
        }
        public async Task AddAsync(PodFeed pf)// Använder transaktion
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    await pfCollection.InsertOneAsync(pf);
                    session.CommitTransaction();

                }catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    session.AbortTransaction();
                }
            }
        }
        public async Task<PodFeed?> GetAsync(string id)
        {
            var filter = Builders<PodFeed>.Filter.Eq(pf => pf.Id, id);
            return await pfCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<PodFeed>> GetAllAsync() => await pfCollection.Find(FilterDefinition<PodFeed>.Empty).ToListAsync();
        public async Task<bool> UpdateAsync(PodFeed pf)//Använder transaktion
        {
            bool isUpdated = false;
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, pf.Id);
                    var update = await pfCollection.ReplaceOneAsync(filter, pf);
                    isUpdated = update.MatchedCount == 1 && update.ModifiedCount == 1;
                    session.CommitTransaction();
                }catch(Exception e)
                {
                    session.AbortTransaction();
                }
            }
            return isUpdated;
        }
        public async Task DeleteAsync(string id)//Använder transaktion
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<PodFeed>.Filter.Eq(p => p.Id, id);
                    await pfCollection.DeleteOneAsync(filter);
                    session.CommitTransaction();
                }catch(Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
