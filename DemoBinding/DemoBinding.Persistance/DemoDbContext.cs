using DemoBinding.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBinding.Persistance
{
    public class DemoDbContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }

        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }   
    }
}
