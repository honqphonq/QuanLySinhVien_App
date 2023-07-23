using MediatR;

namespace QuanLySinhVien.Users.Commands.Suspend;

public record UserSuspendCommand(long Id) : IRequest;
