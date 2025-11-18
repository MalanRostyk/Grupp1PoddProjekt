using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;
using System.Diagnostics;

namespace CCData_Access_Layer
{
    public class CategoryRepository
    {
        public IMongoClient dbClient;
        public readonly IMongoCollection<Category> categoryCollection;

        public CategoryRepository()
        {
            dbClient = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var db = dbClient.GetDatabase("PodderDB");
            categoryCollection = db.GetCollection<Category>("Categories");
        }

        public async Task AddAsync(Category category)
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    await categoryCollection.InsertOneAsync(category);
                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    session.AbortTransaction();
                }
            }
        }
        public async Task<Category?> GetAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            return await categoryCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<Category>> GetAllAsync() => await categoryCollection.Find(FilterDefinition<Category>.Empty).ToListAsync();

        public async Task<bool> UpdateAsync(Category category)
        {
            bool isUpdated = false;
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<Category>.Filter.Eq(c => c.Id, category.Id);
                    var update = await categoryCollection.ReplaceOneAsync(filter, category);
                    isUpdated = update.MatchedCount > 0 && update.ModifiedCount > 0;
                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    session.AbortTransaction();
                }
            }
            return isUpdated;
        }

        public async Task DeleteAsync(string id)
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
                    await categoryCollection.DeleteOneAsync(filter);
                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    session.AbortTransaction();
                }
            }
        }
    }
}
