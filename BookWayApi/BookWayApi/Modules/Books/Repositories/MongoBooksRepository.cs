using BookWayApi.Modules.Books.Models;
using MongoDB.Driver;

namespace BookWayApi.Modules.Books.Repositories
{
    public class MongoBooksRepository : IBooksRepository
    {
        private const string databaseName = "dbBookshop";
        private const string collectionName = "Book";
        private readonly IMongoCollection<Book> booksCollection;
        private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;

        public MongoBooksRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(databaseName);
            booksCollection = database.GetCollection<Book>(collectionName);
        }
        public async Task CreateBookAsync(Book book)
        {
            await booksCollection.InsertOneAsync(book);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            await booksCollection.DeleteOneAsync(filter);
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            return await booksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await booksCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            var filter = filterBuilder.Eq(book => book.Id, book.Id);
            await booksCollection.ReplaceOneAsync(filter, book);
        }
    }
}
