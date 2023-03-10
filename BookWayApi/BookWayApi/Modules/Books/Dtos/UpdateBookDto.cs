using System.ComponentModel.DataAnnotations;

namespace BookWayApi.Modules.Books.Dtos
{
    public class UpdateBookDto
    {
        [Required]
        public string Title { get; set; }

        [Required] 
        public string Genre { get; set; }
    }
}
