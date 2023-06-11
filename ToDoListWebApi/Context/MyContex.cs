using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Models.Orms;

namespace ToDoListWebApi.Context
{
    public class MyContex :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=ToDolistDb; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserMessage> Messages { get; set; }


    }
}
