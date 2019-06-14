using AdminPanelCore.ENTITIES.Concrete;
using System.Data.Entity;

namespace AdminPanelCore.DAL.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(null);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Rols { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
