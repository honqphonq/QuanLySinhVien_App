using MediatR;
using System;

namespace QuanLySinhVien.Subjects.Commands.Edit;

public record SubjectEditCommand(Guid Id, string Name, string Description) : IRequest;
