using Microsoft.EntityFrameworkCore;
using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
