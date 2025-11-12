namespace DDModels
{
    public class Pod : PodFeed
    {
        public string EpisodeId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int Duration { get; set; }

        public Pod(string id, string pName, string[] participants, string description, string category,
            string eId, string title,string info, int duration)
            : base(id, pName, participants, description, category)
        {
            EpisodeId = id;
            Title = title;
            Info = info;
            Duration = duration;
        }



    }
}
