using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BBBusiness_Layer;
using DDModels;
using MongoDB.Driver;

namespace CCData_Access_Layer
{
    public class PodFeedRepository : AAAIPodFeedRepository //IRepository<Pod>
    {
        public readonly IMongoCollection<Pod> podRepo;
        public PodFeedRepository()
        {
            var client = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var database = client.GetDatabase("PoddersDB");
            podRepo = database.GetCollection<Pod>("podders");
        }

        //C
        public async Task AddAsync(Pod p) => await podRepo.InsertOneAsync(p);

        //R
        public async Task<List<Pod>> GetAllAsync() => await podRepo.Find(FilterDefinition<Pod>.Empty).ToListAsync();
        //U
        public async Task<bool> UpdateAsync(Pod p)
        {
            var filter = Builders<Pod>.Filter.Eq(pod => pod.Id, p.Id);
            var update = await podRepo.ReplaceOneAsync(filter, p);
            return update.MatchedCount == 1 & update.ModifiedCount == 1;
        }
        //D
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Pod>.Filter.Eq(p => p.Id, id);
            await podRepo.DeleteOneAsync(filter);
        }
        //R
        public async Task<Pod?> GetOneAsync(string id)
        {
            var filter = Builders<Pod>.Filter.Eq(p => p.Id, id);
            return await podRepo.Find(filter).FirstOrDefaultAsync();
        }

        //För Deserialisering av XML

        //public async Task<List<Pod>> Deserialisera()
        //{
        //    XmlSerializer xmlSerializer = new(typeof(List<Pod>));
        //    using (FileStream fs = new("C:\\PodXml\\MyCurrent.xml", FileMode.Open, FileAccess.Read))
        //    {

        //    }
        //}

    }
}
