using MongoDB.Bson;

namespace BookWayApi.Models
{
    public class Genre
    {
        public ObjectId Id { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
