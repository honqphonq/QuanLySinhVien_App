using Abp.Configuration;
using Abp.Localization;
using Abp.Runtime.Session;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.ChangeLanguage;

public class UserChangeLanguageCommandHandler : IRequestHandler<UserChangeLanguageCommand>
{
    private readonly IAbpSession _session;
    private readonly ISettingManager _settingManager;

    public UserChangeLanguageCommandHandler(
        IAbpSession session,
        ISettingManager settingManager)
    {
        _session = session;
        _settingManager = settingManager;
    }

    public async Task Handle(UserChangeLanguageCommand request, CancellationToken cancellationToken)
    {
        await _settingManager.ChangeSettingForUserAsync(
             _session.ToUserIdentifier(),
             LocalizationSettingNames.DefaultLanguage,
             request.LanguageName
          );
    }
}
