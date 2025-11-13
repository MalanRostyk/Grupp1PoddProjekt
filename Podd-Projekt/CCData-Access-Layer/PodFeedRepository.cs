using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesLayer;
using DDModels;
using MongoDB.Driver;

namespace CCData_Access_Layer
{
    public class PodFeedRepository : IPodFeedRepository
    {
        public readonly IMongoCollection<PodFeed> podCollection;
        public PodFeedRepository()
        {
            var client = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var database = client.GetDatabase("PoddersDB");
            podCollection = database.GetCollection<PodFeed>("podders");
        }

        //C
        public async Task AddAsync(PodFeed p) => 
            await podCollection.InsertOneAsync(p);
        //R
        public async Task<List<PodFeed>> GetAllAsync() => 
            await podCollection.Find(_ => true).ToListAsync();
        //U
        public async Task UpdateAsync(PodFeed p) =>
            await podCollection.ReplaceOneAsync(pod => pod.Id == p.Id, p);

        //D
        public async Task DeleteAsync(string id) =>
            await podCollection.DeleteOneAsync(p => p.Id == id);
    }
}
