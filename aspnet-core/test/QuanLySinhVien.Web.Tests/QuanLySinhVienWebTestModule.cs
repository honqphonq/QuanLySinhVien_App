using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuanLySinhVien.EntityFrameworkCore;
using QuanLySinhVien.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace QuanLySinhVien.Web.Tests
{
    [DependsOn(
        typeof(QuanLySinhVienWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class QuanLySinhVienWebTestModule : AbpModule
    {
        public QuanLySinhVienWebTestModule(QuanLySinhVienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuanLySinhVienWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(QuanLySinhVienWebMvcModule).Assembly);
        }
    }
}