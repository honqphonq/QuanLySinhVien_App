using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Users;
using QuanLySinhVien.Users.Dto;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Queries.Get;

public class UserGetQueryHandler : IRequestHandler<UserGetQuery, EditUserDto>
{
    private readonly IRepository<User, long> _userRepository;

    public UserGetQueryHandler(IRepository<User, long> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<EditUserDto> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == request.Id);

        if(user is null)
        {
            throw new EntityNotFoundException(typeof(User), request.Id);
        }

        return new EditUserDto(
            user.Id,
            user.UserName,
            user.Name,
            user.Surname,
            user.EmailAddress,
            user.IsActive,
            user.Roles.Select(x => x.RoleId).First());
    }
}
