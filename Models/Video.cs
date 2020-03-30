namespace blockbuster_api.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public bool IsAvailable { get; set; }
    }
}