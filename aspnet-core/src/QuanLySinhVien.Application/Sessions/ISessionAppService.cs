using System.Threading.Tasks;
using Abp.Application.Services;
using QuanLySinhVien.Sessions.Dto;

namespace QuanLySinhVien.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
