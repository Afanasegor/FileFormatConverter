using Microsoft.EntityFrameworkCore;

namespace FileFormatConverter.Data.Context
{
    public class HangfireContext : DbContext
    {
        public HangfireContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
