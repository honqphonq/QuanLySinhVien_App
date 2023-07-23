using Abp.Authorization;
using MediatR;
using QuanLySinhVien.Authorization;
using QuanLySinhVien.Roles.Dto;
using QuanLySinhVien.Roles.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleAppService : QuanLySinhVienAppServiceBase, IRoleAppService
    {
        private readonly ISender _sender;

        public RoleAppService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<List<RoleListDto>> GetAll(GetRolesInput input)
        {
            return await _sender.Send(new RoleGetAllQuery(input.Permission));
        }
    }
}

