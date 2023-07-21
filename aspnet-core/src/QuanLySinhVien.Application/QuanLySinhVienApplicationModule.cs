using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuanLySinhVien.Authorization;

namespace QuanLySinhVien
{
    [DependsOn(
        typeof(QuanLySinhVienCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QuanLySinhVienApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QuanLySinhVienAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QuanLySinhVienApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
