using MediatR;

namespace QuanLySinhVien.Users.Commands.Create;

public record UserCreateCommand(
    string Username,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive,
    int RoleId) : IRequest;
