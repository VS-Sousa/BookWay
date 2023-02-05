using BookWayApi.Modules.Genres.Models;

namespace BookWayApi.Modules.Genres.Repositories
{
    public interface IGenresRepository
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(Guid id);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(Guid id);
    }
}
