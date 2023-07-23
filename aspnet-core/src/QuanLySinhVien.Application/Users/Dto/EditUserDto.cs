using Abp.Application.Services.Dto;

namespace QuanLySinhVien.Users.Dto;

//public class EditUserDto : EntityDto<long>
//{
//    public string UserName { get; set; }

//    public string FirstName { get; set; }

//    public string LastName { get; set; }

//    public string Email { get; set; }

//    public bool IsActive { get; set; }

//    public int RoleId { get; set; }
//}

public record EditUserDto(
    long Id,
    string Username,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive,
    int RoleId);
