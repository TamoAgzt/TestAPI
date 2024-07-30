using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbOptions): base(dbOptions)
        {
            
        }

        public DbSet<Profile> tb_Profiles => Set<Profile>();
    }
}
