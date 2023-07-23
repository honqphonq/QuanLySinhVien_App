using Abp.Authorization;
using Abp.Runtime.Session;
using MediatR;
using QuanLySinhVien.Authorization;
using QuanLySinhVien.Users.Commands.Activate;
using QuanLySinhVien.Users.Commands.ChangeLanguage;
using QuanLySinhVien.Users.Commands.ChangePassword;
using QuanLySinhVien.Users.Commands.Create;
using QuanLySinhVien.Users.Commands.Delete;
using QuanLySinhVien.Users.Commands.Suspend;
using QuanLySinhVien.Users.Commands.Update;
using QuanLySinhVien.Users.Dto;
using QuanLySinhVien.Users.Queries.Get;
using QuanLySinhVien.Users.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : QuanLySinhVienAppServiceBase, IUserAppService
    {
        private readonly ISender _sender;

        public UserAppService(ISender sender)
        {
            _sender = sender;
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task Activate(long id)
        {
            var command = new UserActivateCommand(id);

            await _sender.Send(command);
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            var command = new UserChangeLanguageCommand(input.LanguageName);

            await _sender.Send(command);    
        }

        public async Task ChangePassword(ChangePasswordDto input)
        {
            var command = new UserChangePasswordCommand(
                input.CurrentPassword,
                input.NewPassword,
                AbpSession.GetTenantId(),
                AbpSession.GetUserId());

            await _sender.Send(command);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task Create(CreateUserDto input)
        {
            var command = new UserCreateCommand(
                input.UserName,
                input.FirstName,
                input.LastName,
                input.Email,
                input.IsActive,
                input.RoleId);

            await _sender.Send(command);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task Delete(long id)
        {
            var command = new UserDeleteCommand(id);

            await _sender.Send(command);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task Edit(EditUserDto input)
        {
            var command = new UserEditCommand(
                input.Id,
                input.Username,
                input.FirstName,
                input.LastName,
                input.Email,
                input.IsActive,
                input.RoleId);

            await _sender.Send(command);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<EditUserDto> Get(long id)
        {
            return await _sender.Send(new UserGetQuery(id));
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public Task<List<UserDto>> GetAll(GetAllUserInput input)
        {
            return _sender.Send(new UserGetAllQuery(input.SearchTerm));
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task Suspend(long id)
        {
            var command = new UserSuspendCommand(id);

            await _sender.Send(command);
        }
    }
}

