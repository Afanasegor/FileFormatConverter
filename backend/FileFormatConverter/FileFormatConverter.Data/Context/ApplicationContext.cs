using FileFormatConverter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FileFormatConverter.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
