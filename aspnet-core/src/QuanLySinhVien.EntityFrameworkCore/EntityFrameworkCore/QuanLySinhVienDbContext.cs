using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;
using QuanLySinhVien.MultiTenancy;
using QuanLySinhVien.Subjects.Entities;

namespace QuanLySinhVien.EntityFrameworkCore
{
    public class QuanLySinhVienDbContext : AbpZeroDbContext<Tenant, Role, User, QuanLySinhVienDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Subject> Subjects { get; set; }
        
        public QuanLySinhVienDbContext(DbContextOptions<QuanLySinhVienDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuanLySinhVienDbContext).Assembly);
        }
    }
}
