using BookWayApi.Models;
using MongoDB.Driver;

namespace BookWayApi.Repositories
{
    public class GenreRepository
    {
        private const string databaseName = "dbBookshop";
        private const string collectionName = "Genre";
        private readonly IMongoCollection<Genre> genresCollection;

        public GenreRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            genresCollection = database.GetCollection<Genre>(collectionName);
        }
    }
}
