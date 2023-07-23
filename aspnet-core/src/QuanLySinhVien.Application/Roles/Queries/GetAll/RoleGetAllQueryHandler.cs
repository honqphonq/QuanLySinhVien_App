using Abp.Application.Services.Dto;
using Abp.ObjectMapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Roles.Dto;
using QuanLySinhVien.Roles.Get;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Roles.Queries.GetAll;

public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQuery, List<RoleListDto>>
{
    private readonly RoleManager _roleManager;
    private readonly IObjectMapper _mapper;

    public RoleGetAllQueryHandler(RoleManager roleManager, IObjectMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<List<RoleListDto>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleManager
               .Roles
               .ToListAsync();

        return new List<RoleListDto>(_mapper.Map<List<RoleListDto>>(roles));
    }
}
