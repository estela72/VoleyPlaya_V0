using Ejemplo.EFWebAPI.Model;

using Microsoft.EntityFrameworkCore;

namespace Ejemplo.EFWebAPI.Data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
        public DbSet<Dummy> Dummies { get; set; }
    }
}
