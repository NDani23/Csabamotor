using Microsoft.EntityFrameworkCore;

namespace Csabamotor.Web.Models
{
    public class CsabamotorDBContext : DbContext
    {
        public DbSet<List> Lists { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;

        public CsabamotorDBContext(DbContextOptions<CsabamotorDBContext> options)
            : base(options)
        {
        }
    }
}
