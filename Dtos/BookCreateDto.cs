using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dtos
{
    public class BookCreateDto
    {

        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
    }
}
