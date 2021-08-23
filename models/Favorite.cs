namespace api.models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}