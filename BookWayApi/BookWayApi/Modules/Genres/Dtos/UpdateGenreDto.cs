using System.ComponentModel.DataAnnotations;

namespace BookWayApi.Modules.Genres.Dtos
{
    public class UpdateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
