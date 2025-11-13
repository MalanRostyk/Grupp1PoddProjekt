namespace DDModels
{
    public class Pod : PodFeed
    {
        public string EpisodeId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int Duration { get; set; }

        public Pod(string id, string pName, List<string> participants, string description, string category,
            string eId, string title,string info, int duration)
            : base(id, pName, participants, description, category)
        {
            EpisodeId = id;
            Title = title;
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
                $"Description: {Description}| " +
                $"Category: {EpisodeId}| " +
                $"Title: {Title}| " +
                $"Info: {Info}| " +
                $"Duration: {Duration}";
        }

    }
}
