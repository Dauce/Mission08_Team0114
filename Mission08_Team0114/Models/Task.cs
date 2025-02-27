using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0114.Models
{
    public class Task
    {
        [Key]
        public int taskId { get; set; }

        [Required]
        public string taskName { get; set; }

        public string? dueDate { get; set; }

        [Required]
        public int quadrant { get; set; }

        [ForeignKey(name:"categoryId")]
        public int? categoryId { get; set; }
        public Category Categories { get; set; }

        public int? completed { get; set; }

    }
}
