using Abp.IdentityFramework;
using Abp.Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QuanLySinhVien.Authorization.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.ChangePassword;

public class UserChangePasswordCommandHandler : IRequestHandler<UserChangePasswordCommand>
{
    private readonly ILocalizationManager _localizationManager;
    private readonly UserManager _userManager;

    public UserChangePasswordCommandHandler(
        ILocalizationManager localizationManager,
        UserManager userManager)
    {
        _localizationManager = localizationManager;
        _userManager = userManager;
    }

    public async Task Handle(UserChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await _userManager.InitializeOptionsAsync(request.TenantId);

        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            throw new Exception("There is no current user!");
        }

        if (await _userManager.CheckPasswordAsync(user, request.CurrentPassword))
        {
            CheckErrors(await _userManager.ChangePasswordAsync(user, request.NewPassword));
        }
        else
        {
            CheckErrors(IdentityResult.Failed(new IdentityError
            {
                Description = "Incorrect password."
            }));
        }
    }

    private void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(_localizationManager);
    }
}
