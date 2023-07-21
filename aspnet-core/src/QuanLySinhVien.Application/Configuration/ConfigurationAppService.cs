using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using QuanLySinhVien.Configuration.Dto;

namespace QuanLySinhVien.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QuanLySinhVienAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
