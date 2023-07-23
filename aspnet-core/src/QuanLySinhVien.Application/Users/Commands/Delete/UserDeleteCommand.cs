using MediatR;

namespace QuanLySinhVien.Users.Commands.Delete;

public record UserDeleteCommand(long Id) : IRequest;

