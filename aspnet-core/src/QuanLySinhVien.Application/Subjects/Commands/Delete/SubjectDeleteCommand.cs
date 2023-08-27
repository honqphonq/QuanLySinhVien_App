using MediatR;
using System;

namespace QuanLySinhVien.Subjects.Commands.Delete;

public record SubjectDeleteCommand(Guid Id) : IRequest;