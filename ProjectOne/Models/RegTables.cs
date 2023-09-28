using Microsoft.EntityFrameworkCore;

namespace ProjectOne.Models
{
    public class RegTables:DbContext
    {
        public RegTables() 
        {

        }
        public RegTables(DbContextOptions<RegTables> options) : base(options) { }
        public virtual DbSet<logtable> LogTables { get; set; }

    }
}
