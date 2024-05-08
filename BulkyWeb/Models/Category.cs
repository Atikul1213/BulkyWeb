using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Diplay Order")]
        [Range(1,100,ErrorMessage ="Value Must be 1 to 100")]
        public string DisplayOrder { get; set; }

    }
}
