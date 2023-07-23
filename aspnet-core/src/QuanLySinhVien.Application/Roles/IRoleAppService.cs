using Abp.Application.Services;
using QuanLySinhVien.Roles.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task<List<RoleListDto>> GetAll(GetRolesInput input);
    }
}
