using Microsoft.EntityFrameworkCore;
using StundenplanApp.Models;

namespace StundenplanApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext() { }

        public DbSet<Days> Tag {  get; set; }
        public DbSet<Subjects> Faecher { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAP0019\SQLEXPRESS;Database=StundenplanApp;Integrated Security=true;TrustServerCertificate=True;Trusted_Connection=True;User Id=IIS-APPPOOL\StundenplanApp");
        }
    }
}
