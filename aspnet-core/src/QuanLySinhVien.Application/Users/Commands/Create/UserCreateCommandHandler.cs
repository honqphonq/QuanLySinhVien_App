using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.UI;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Authorization.Roles;
using QuanLySinhVien.Authorization.Users;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.Create;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand>
{
    private readonly ILocalizationManager _localizationManager;
    private readonly UserManager _userManager;
    private readonly IRepository<User, long> _userRepository;
    private readonly IRepository<Role, int> _roleRepository;
    private readonly IAbpSession _session;

    public UserCreateCommandHandler(
        ILocalizationManager localizationManager,
        UserManager userManager,
        IRepository<User, long> userRepository,
        IRepository<Role, int> roleRepository,
        IAbpSession session)
    {
        _localizationManager = localizationManager;
        _userManager = userManager;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _session = session;
    }

    public async Task Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        await ValidateCreateUser(request.Username, request.Email);

        var role = await _roleRepository.GetAsync(request.RoleId);

        var user = new User
        {
            UserName = request.Username,
            Name = request.FirstName,
            Surname = request.LastName,
            EmailAddress = request.Email,
            IsEmailConfirmed = true,
            IsActive = request.IsActive,
            TenantId = _session.TenantId,
            IsLockoutEnabled = true,
        };

        await _userManager.InitializeOptionsAsync(_session.TenantId);

        var password = User.CreateRandomPassword();

        CheckErrors(await _userManager.CreateAsync(user, password));

        CheckErrors(await _userManager.SetRolesAsync(user, new[] { role.Name }));
    }


    private void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(_localizationManager);
    }

    private async Task ValidateCreateUser(string username, string email)
    {
        var isUsernameTaken = await _userRepository.GetAll().AnyAsync(x => x.UserName == username);

        if (isUsernameTaken)
        {
            throw new UserFriendlyException("Username has been taken.");
        }

        var isEmailTaken = await _userRepository.GetAll().AnyAsync(x => x.EmailAddress == email);

        if (isEmailTaken)
        {
            throw new UserFriendlyException("Email has been taken");
        }
    }
}
