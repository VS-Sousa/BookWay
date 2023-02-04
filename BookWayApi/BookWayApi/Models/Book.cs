using MongoDB.Bson;

namespace BookWayApi.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string CoverFileName { get; set; }
    }
}
