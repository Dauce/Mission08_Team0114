using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0114.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        public string categoryName { get; set; }
    }
}