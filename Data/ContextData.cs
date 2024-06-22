using Microsoft.EntityFrameworkCore;
using administradorUsuarios.models;
namespace administradorUsuarios.Data
{
    public class ContextData : DbContext
    {
        public ContextData(DbContextOptions<ContextData>options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
