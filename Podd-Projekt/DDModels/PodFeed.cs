namespace DDModels
{
    public class PodFeed
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Info { get; set; }
        public int Duration { get; set; }
        public string Category { get; set; }
        public List<PodEpisode> Episodes { get; set; }

    }

}
