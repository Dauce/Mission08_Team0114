using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0114.Models
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)  // Constructor
        { 
        
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
