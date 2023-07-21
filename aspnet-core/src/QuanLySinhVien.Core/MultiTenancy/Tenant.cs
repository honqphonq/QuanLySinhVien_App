using Abp.MultiTenancy;
using QuanLySinhVien.Authorization.Users;

namespace QuanLySinhVien.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
