using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Author Name")]
        public string Author { get; set; }
        [Required]
        [DisplayName("Book Price")]
        [Range(1,1000,ErrorMessage ="Price must be 1 to 1000")]
        public int Price { get; set; }
        [DisplayName("Book Title")]
        public string Title { get; set; }

        public int catId { get; set; }
        [ForeignKey("catId")]
        public virtual Category? Category { get; set; }

    }
}
