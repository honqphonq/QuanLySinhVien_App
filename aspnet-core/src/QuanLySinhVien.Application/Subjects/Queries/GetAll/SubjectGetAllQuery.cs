using MediatR;
using QuanLySinhVien.Subjects.Dtos;
using System.Collections.Generic;

namespace QuanLySinhVien.Subjects.Queries.GetAll;

public record SubjectGetAllQuery(string SearchTerm) : IRequest<List<SubjectGetAllResponse>>;

