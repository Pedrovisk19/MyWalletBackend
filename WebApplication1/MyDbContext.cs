using Microsoft.EntityFrameworkCore;
using MyWallet.Models;

namespace WebApplication1
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
