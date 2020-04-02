using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> option) : base(option)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
