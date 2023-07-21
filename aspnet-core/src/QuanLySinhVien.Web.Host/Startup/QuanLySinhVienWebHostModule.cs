using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuanLySinhVien.Configuration;

namespace QuanLySinhVien.Web.Host.Startup
{
    [DependsOn(
       typeof(QuanLySinhVienWebCoreModule))]
    public class QuanLySinhVienWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QuanLySinhVienWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuanLySinhVienWebHostModule).GetAssembly());
        }
    }
}
