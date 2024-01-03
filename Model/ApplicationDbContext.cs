using Microsoft.EntityFrameworkCore;

namespace CRUDWithSP.Model
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        #region Table
        public DbSet<CRUDInfo> CRUDInfo { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
