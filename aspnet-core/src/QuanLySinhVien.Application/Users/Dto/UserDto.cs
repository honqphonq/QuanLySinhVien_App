using Abp.Application.Services.Dto;

namespace QuanLySinhVien.Users.Dto
{
    public class UserDto : EntityDto<long>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
    }
}
