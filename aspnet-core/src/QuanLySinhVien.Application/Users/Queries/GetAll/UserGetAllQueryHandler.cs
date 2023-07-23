using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;
using QuanLySinhVien.Users.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Queries.GetAll;

public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserDto>>
{
    private readonly IRepository<User, long> _userRepository;
    private readonly IRepository<Role, int> _roleRepository;
    private readonly IObjectMapper _mapper;

    public UserGetAllQueryHandler(
        IRepository<User, long> userRepository,
        IRepository<Role, int> roleRepository,
        IObjectMapper mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository
            .GetAllIncluding(e => e.Roles)
            .WhereIf(!request.SearchTerm.IsNullOrEmpty(), x => x.UserName.Contains(request.SearchTerm) 
                                                                || x.Name.Contains(request.SearchTerm) 
                                                                || x.Surname.Contains(request.SearchTerm) 
                                                                || x.PhoneNumber.Contains(request.SearchTerm) 
                                                                || x.EmailAddress.Contains(request.SearchTerm
            ))
            .AsNoTracking()
            .ToListAsync();

        var result = _mapper.Map<List<UserDto>>(users);

        var roles = await _roleRepository.GetAllListAsync();
        var roleDictionary = roles.ToDictionary(e => e.Id, e => e.DisplayName);

        foreach (var user in result)
        {
            user.Role = roleDictionary.GetValueOrDefault(user.RoleId);
        }

        return result;
    }
}
