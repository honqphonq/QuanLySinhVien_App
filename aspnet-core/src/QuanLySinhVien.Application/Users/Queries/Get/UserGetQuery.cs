using MediatR;
using QuanLySinhVien.Users.Dto;

namespace QuanLySinhVien.Users.Queries.Get;

public record UserGetQuery(long Id) : IRequest<EditUserDto>;
