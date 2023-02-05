using System.ComponentModel.DataAnnotations;

namespace BookWayApi.Modules.Genres.Dtos
{
    public class AddGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
