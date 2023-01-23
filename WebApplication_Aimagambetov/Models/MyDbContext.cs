using Microsoft.EntityFrameworkCore;

namespace WebApplication_Aimagambetov.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CalculationData> CalculationDatas { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
}
