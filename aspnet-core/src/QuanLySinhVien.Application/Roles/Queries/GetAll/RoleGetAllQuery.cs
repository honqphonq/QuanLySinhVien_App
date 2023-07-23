using MediatR;
using QuanLySinhVien.Roles.Dto;
using System.Collections.Generic;

namespace QuanLySinhVien.Roles.Get;

public record RoleGetAllQuery(string Permission) : IRequest<List<RoleListDto>>;

