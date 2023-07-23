namespace QuanLySinhVien.Users.Dto;

public class CreateUserDto
{
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; }

    public int RoleId { get; set; }
}
