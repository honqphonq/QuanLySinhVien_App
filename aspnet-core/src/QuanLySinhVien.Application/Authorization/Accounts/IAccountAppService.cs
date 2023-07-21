using System.Threading.Tasks;
using Abp.Application.Services;
using QuanLySinhVien.Authorization.Accounts.Dto;

namespace QuanLySinhVien.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
