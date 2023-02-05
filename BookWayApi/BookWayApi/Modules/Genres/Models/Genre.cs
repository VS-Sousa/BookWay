using MongoDB.Bson;

namespace BookWayApi.Modules.Genres.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
