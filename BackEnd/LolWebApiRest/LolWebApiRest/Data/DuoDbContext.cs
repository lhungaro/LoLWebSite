using LolWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LolWebApiRest.Data
{
    public class DuoDbContext : DbContext
    {
        public DuoDbContext(DbContextOptions<DuoDbContext> opts) : base(opts) { }
        public DbSet<Duo> Duos { get; set; }

    }

}
