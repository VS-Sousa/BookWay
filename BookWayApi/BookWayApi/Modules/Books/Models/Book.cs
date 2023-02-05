using MongoDB.Bson;

namespace BookWayApi.Modules.Books.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
