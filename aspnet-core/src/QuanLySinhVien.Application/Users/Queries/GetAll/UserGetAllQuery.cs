using MediatR;
using QuanLySinhVien.Users.Dto;
using System.Collections.Generic;

namespace QuanLySinhVien.Users.Queries.GetAll;

public record UserGetAllQuery(string SearchTerm) : IRequest<List<UserDto>>;

