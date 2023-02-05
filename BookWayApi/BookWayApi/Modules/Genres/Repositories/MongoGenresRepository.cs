using BookWayApi.Modules.Genres.Models;
using MongoDB.Driver;

namespace BookWayApi.Modules.Genres.Repositories
{
    public class MongoGenresRepository : IGenresRepository
    {
        private const string databaseName = "dbBookshop";
        private const string collectionName = "Genre";
        private readonly IMongoCollection<Genre> genresCollection;
        private readonly FilterDefinitionBuilder<Genre> filterBuilder = Builders<Genre>.Filter;

        public MongoGenresRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            genresCollection = database.GetCollection<Genre>(collectionName);
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await genresCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            var filter = filterBuilder.Eq(genre => genre.Id, id);
            return await genresCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await genresCollection.InsertOneAsync(genre);
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            var filter = filterBuilder.Eq(existingGenre => existingGenre.Id, genre.Id);
            await genresCollection.ReplaceOneAsync(filter, genre);
        }

        public async Task DeleteGenreAsync(Guid id)
        {
            var filter = filterBuilder.Eq(genre => genre.Id, id);
            await genresCollection.DeleteOneAsync(filter);
        }
    }
}
