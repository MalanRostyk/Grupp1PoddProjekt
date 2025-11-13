using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace DDModels
{
    [BsonKnownTypes(typeof(Pod))]
    public class PodFeed
    {
        [BsonId]
        public string Id { get; set; }
        public string PodName { get; set; }
        public List<string> Participants { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public PodFeed(string id, string pName, List<string> participants, string description, string category)
        {
            Id = id;
            PodName = pName;
            Participants = participants;
            Description = description;
            Category = category;
        }
    }
}
