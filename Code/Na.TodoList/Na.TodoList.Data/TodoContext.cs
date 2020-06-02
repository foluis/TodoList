using Microsoft.EntityFrameworkCore;
using Na.TodoList.Domain;

namespace Na.TodoList.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
         : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
