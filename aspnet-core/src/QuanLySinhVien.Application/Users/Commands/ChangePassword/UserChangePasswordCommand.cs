using MediatR;

namespace QuanLySinhVien.Users.Commands.ChangePassword;

public record UserChangePasswordCommand(
    string CurrentPassword,
    string NewPassword,
    int TenantId,
    long UserId) : IRequest;
