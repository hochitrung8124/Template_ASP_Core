using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions options) : base(options) { }
        #region Dbset
        public DbSet<SinhVien> sinhViens { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>(e =>
            {
                e.ToTable("SinhVien");
                e.HasKey(dh => dh.id);
                e.Property(e => e.id)
                .ValueGeneratedOnAdd();
                e.Property(dh => dh.name).IsRequired().HasMaxLength(100);
            });
        }

    }
}