using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;
using QuanLySinhVien.MultiTenancy;

namespace QuanLySinhVien.EntityFrameworkCore
{
    public class QuanLySinhVienDbContext : AbpZeroDbContext<Tenant, Role, User, QuanLySinhVienDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public QuanLySinhVienDbContext(DbContextOptions<QuanLySinhVienDbContext> options)
            : base(options)
        {
        }
    }
}
