using System.Threading.Tasks;
using QuanLySinhVien.Configuration.Dto;

namespace QuanLySinhVien.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
