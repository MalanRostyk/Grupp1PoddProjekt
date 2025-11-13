using MongoDB.Bson.Serialization.Attributes;

namespace DDModels
{
    public class Pod
    {
        [BsonId]
        public string Id { get; set; }
        public string PodName { get; set; }
        public List<string> Participants { get; set; }
        public string Category { get; set; }
        public string Info { get; set; }
        public double Duration { get; set; }

        public Pod(string id, string pName, List<string> participants, string category, string info, double duration)
        {
            Id = id;
            PodName = pName;
            Participants = participants;
            Category = category;
            Info = info;
            Duration = duration;
        }

        public List<string> GetParticipants() => Participants;

        public string GetParticipantsString()
        {
            List<string> participants = GetParticipants();
            string medverkande = "";
            for(int i = 0; i < participants.Count; i++)
            {
                medverkande += "|" + participants[i];
            }
            return medverkande;
        }
        public string GetAllPodInfo()
        {
            return $"Id: {Id}| " +
                $"PodName: {PodName}| " +
                $"{GetParticipantsString()}| " +
                $"Info: {Info}| " +
                $"Duration: {Duration}" +
                $"Category: {Category}";
        }

    }
}
