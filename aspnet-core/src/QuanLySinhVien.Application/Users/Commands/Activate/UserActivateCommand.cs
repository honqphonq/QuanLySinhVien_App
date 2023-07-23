using MediatR;

namespace QuanLySinhVien.Users.Commands.Activate;

public record UserActivateCommand(long Id) : IRequest;

