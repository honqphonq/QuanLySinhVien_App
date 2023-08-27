using MediatR;
using QuanLySinhVien.Subjects.Dtos;
using System;

namespace QuanLySinhVien.Subjects.Queries.Get;

public record SubjectGetQuery(Guid Id) : IRequest<SubjectGetResponse>;