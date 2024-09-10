using Microsoft.EntityFrameworkCore;
using Ecf.Vgames.Models;

namespace Ecf.Vgames.Database
{
    public class GizmondosDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder _options)
        {
            _options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_gizmondos_ecf");
        }
        public DbSet<Gizmondo> Gizmondo { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
    }
}
