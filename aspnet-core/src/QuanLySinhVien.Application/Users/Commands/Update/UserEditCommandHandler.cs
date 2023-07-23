using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.ObjectMapping;
using Abp.UI;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.Update;

public record UserEditCommandHandler : IRequestHandler<UserEditCommand>
{
    private readonly IObjectMapper _mapper;
    private readonly ILocalizationManager _localizationManager;
    private readonly UserManager _userManager;
    private readonly IRepository<User, long> _userRepository;
    private readonly IRepository<Role, int> _roleRepository;

    public UserEditCommandHandler(
        IObjectMapper mapper,
        ILocalizationManager localizationManager,
        UserManager userManager,
        IRepository<User, long> userRepository,
        IRepository<Role, int> roleRepository)
    {
        _mapper = mapper;
        _localizationManager = localizationManager;
        _userManager = userManager;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task Handle(UserEditCommand request, CancellationToken cancellationToken)
    {
        await ValidateEditUserAsync(request.Id, request.UserName, request.Email);

        var user = await _userManager.GetUserByIdAsync(request.Id);

        user.UserName = request.UserName;
        user.Name = request.FirstName;
        user.Surname = request.LastName;
        user.EmailAddress = request.Email;
        user.IsActive = request.IsActive;

        await _userManager.UpdateNormalizedEmailAsync(user);

        await _userManager.UpdateNormalizedUserNameAsync(user);

        var role = await _roleRepository.GetAsync(request.RoleId);

        CheckErrors(await _userManager.SetRolesAsync(user, new[] { role.Name }));
    }

    private void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(_localizationManager);
    }

    private async Task ValidateEditUserAsync(long userId, string username, string email)
    {
        var isUsernameTaken = await _userRepository
            .GetAll()
            .Where(e => e.Id != userId)
            .AnyAsync(e => e.UserName == username);

        if (isUsernameTaken)
        {
            throw new UserFriendlyException("Username has been taken.");
        }

        var isEmailTaken = await _userRepository
            .GetAll()
            .Where(e => e.Id != userId)
            .AnyAsync(e => e.EmailAddress == email);

        if (isEmailTaken)
        {
            throw new UserFriendlyException("Email has been taken.");
        }
    }
}
