using Freela.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelaAPI.Data
{
    public class FreelaContext: DbContext
    {
        public FreelaContext(DbContextOptions<FreelaContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> Usersprojects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>()
                .HasKey(UP => new { UP.ProjectId, UP.UserId });
        }
    }
}
