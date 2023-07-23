using Abp.Application.Services;
using QuanLySinhVien.Users.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<List<UserDto>> GetAll(GetAllUserInput input);

        Task Suspend(long id);

        Task Activate(long id);

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task ChangePassword(ChangePasswordDto input);

        Task Create(CreateUserDto input);

        Task Edit(EditUserDto input);

        Task<EditUserDto> Get(long id);

        Task Delete(long id);
    }
}
