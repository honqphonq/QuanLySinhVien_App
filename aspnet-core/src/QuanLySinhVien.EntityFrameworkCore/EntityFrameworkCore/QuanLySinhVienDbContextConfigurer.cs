using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.EntityFrameworkCore
{
    public static class QuanLySinhVienDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QuanLySinhVienDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QuanLySinhVienDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
