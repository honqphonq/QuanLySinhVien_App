using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QuanLySinhVien.Controllers
{
    public abstract class QuanLySinhVienControllerBase: AbpController
    {
        protected QuanLySinhVienControllerBase()
        {
            LocalizationSourceName = QuanLySinhVienConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
