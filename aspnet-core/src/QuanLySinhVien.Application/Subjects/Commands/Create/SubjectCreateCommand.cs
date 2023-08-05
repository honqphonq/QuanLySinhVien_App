using MediatR;

namespace QuanLySinhVien.Subjects.Commands.Create;

public record SubjectCreateCommand(string Name, string Description) : IRequest;

