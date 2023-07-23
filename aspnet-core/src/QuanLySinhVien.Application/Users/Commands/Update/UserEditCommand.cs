using MediatR;

namespace QuanLySinhVien.Users.Commands.Update;

public record UserEditCommand(
    long Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive,
    int RoleId) : IRequest;

