using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuanLySinhVien.Configuration;
using QuanLySinhVien.EntityFrameworkCore;
using QuanLySinhVien.Migrator.DependencyInjection;

namespace QuanLySinhVien.Migrator
{
    [DependsOn(typeof(QuanLySinhVienEntityFrameworkModule))]
    public class QuanLySinhVienMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QuanLySinhVienMigratorModule(QuanLySinhVienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(QuanLySinhVienMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                QuanLySinhVienConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuanLySinhVienMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
