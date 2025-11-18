using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DDModels
{
    public class PodFeed //Motsarigheten till en serie typ
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; }
        public string Link { set; get; }//Källa inte content
        public List<Pod> podList { set; get; }//Content, annars inte ögonblicks bild
        public string? Name { set; get; }
        public string CategoryId { set; get; }

        public PodFeed() { }
    }
}
