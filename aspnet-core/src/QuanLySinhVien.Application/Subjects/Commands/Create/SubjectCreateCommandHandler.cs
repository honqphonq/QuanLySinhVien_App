using Abp.Domain.Repositories;
using Abp.UI;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Subjects.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Commands.Create;

public class SubjectCreateCommandHandler : IRequestHandler<SubjectCreateCommand>
{
    private readonly IRepository<Subject, Guid> _subjectRepository;

    public SubjectCreateCommandHandler(IRepository<Subject, Guid> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task Handle(SubjectCreateCommand request, CancellationToken cancellationToken)
    {
        await CheckValidateName(request.Name);

        var subject = Subject.Create(request.Name, request.Description);

        await _subjectRepository.InsertAsync(subject);
    }

    private async Task CheckValidateName(string name)
    {
        var isExist = await _subjectRepository
            .GetAll()
            .AnyAsync(x => x.Name == name);

        if (isExist)
        {
            throw new UserFriendlyException("Subject has been existed!");
        }
    }
}
