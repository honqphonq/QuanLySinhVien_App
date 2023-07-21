using Abp.Authorization;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;

namespace QuanLySinhVien.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
