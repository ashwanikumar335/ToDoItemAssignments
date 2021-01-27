using Microsoft.EntityFrameworkCore;
using Todo.Core.Models.Sql;
using ToDoItems.Entities;

namespace ToDoItem.Data
{
    /// <summary>
    /// EF Core database context for the application
    /// </summary>
    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
        {
        }
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

       public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Label> Labels { get; set; }

        /// <summary>
        /// Apply explicit configurations on model creations.
        /// Also contains database seeding (should not be used for production applications)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // should not allow duplicate usernames in the database
            modelBuilder.Entity<User>().HasIndex(x => new { x.UserName }).IsUnique();

           // cascade deletion for TodoItems => Labels
            modelBuilder.Entity<Label>()
                .HasOne<TodoItem>()
                .WithMany(t => t.Labels)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem
                    {
                        Id = 1,
                        Description = "Buy IPhone 11"

                    });
            // cannot apply cascade delete on both items and list due to multiple cascade paths
            // if a list is deleted, the labels for the list must be deleted first by code
        }
    }
}
