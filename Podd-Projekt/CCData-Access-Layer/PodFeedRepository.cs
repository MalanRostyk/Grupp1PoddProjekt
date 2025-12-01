using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using MongoDB.Driver;

namespace CCData_Access_Layer
{
    public class PodFeedRepository : IRepository<PodFeed>
    {
        public IMongoClient dbClient;
        public readonly IMongoCollection<PodFeed> pfCollection;
        public readonly IMongoCollection<PodFeed> tempColl;

        public PodFeedRepository()
        {
            dbClient = new MongoClient("mongodb+srv://OruMongoDBAdmin:qwe123@orumongodb.88ybr1l.mongodb.net/?appName=OruMongoDB");
            var db = dbClient.GetDatabase("Opponering");
            pfCollection = db.GetCollection<PodFeed>("PodFeed");
            this.tempColl = db.GetCollection<PodFeed>("Temp");

        }
        public async Task AddAsync(PodFeed pf)// Använder transaktion
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    await pfCollection.InsertOneAsync(session, pf);
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
                }catch(NullReferenceException e)//Kan bli null? för dirty read, kom tillbaka tänk igenom.
                {
                    session.AbortTransaction();
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
                    await pfCollection.DeleteOneAsync(session, filter);
                    session.CommitTransaction();
                }catch(Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public async Task AddTempAsync(PodFeed dummyPf)
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    await tempColl.InsertOneAsync(dummyPf);
                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public async Task<PodFeed?> GetTempAsync()
        {
            var filter = FilterDefinition<PodFeed>.Empty;
            return await tempColl.Find(filter).FirstOrDefaultAsync();
        }

        public async Task DeleteTempAsync(string id)
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    await tempColl.DeleteOneAsync(Builders<PodFeed>.Filter.Eq(p => p.Id, id));
                    session.CommitTransaction();
                }catch(Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public async Task TempInsertOneDeleteOtherAsync(PodFeed pfNew, PodFeed pfOld)
        {
            using (var session = dbClient.StartSession())
            {
                session.StartTransaction();
                try
                {
                    if (pfOld == null)
                        return;

                    //Ta bort gamla
                    await tempColl.DeleteOneAsync(
                        Builders<PodFeed>.Filter.Eq(p => p.Id, pfOld.Id));

                    //Lägg till nya
                    await tempColl.InsertOneAsync(pfNew);

                    session.CommitTransaction();
                }
                catch (Exception e)
                {
                    session.AbortTransaction();
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
