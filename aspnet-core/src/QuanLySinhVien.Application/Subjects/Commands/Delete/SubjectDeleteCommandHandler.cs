using Abp.Domain.Repositories;
using MediatR;
using QuanLySinhVien.Subjects.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Commands.Delete;

public class SubjectDeleteCommandHandler : IRequestHandler<SubjectDeleteCommand>
{
    private readonly IRepository<Subject, Guid> _deleteRepository;

    public SubjectDeleteCommandHandler(IRepository<Subject, Guid> deleteRepository)
    {
        _deleteRepository = deleteRepository;
    }

    public async Task Handle(SubjectDeleteCommand request, CancellationToken cancellationToken)
    {
        var deleteSubject = await _deleteRepository.GetAsync(request.Id);

        await _deleteRepository.DeleteAsync(request.Id);
    }
}
