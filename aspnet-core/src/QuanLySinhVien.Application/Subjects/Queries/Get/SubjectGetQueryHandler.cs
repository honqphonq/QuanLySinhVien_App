using Abp.Domain.Repositories;
using MediatR;
using QuanLySinhVien.Subjects.Dtos;
using QuanLySinhVien.Subjects.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Queries.Get;

public class SubjectGetQueryHandler : IRequestHandler<SubjectGetQuery, SubjectGetResponse>
{
    private readonly IRepository<Subject, Guid> _subjectRepository;

    public SubjectGetQueryHandler(IRepository<Subject, Guid> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<SubjectGetResponse> Handle(SubjectGetQuery request, CancellationToken cancellationToken)
    {
        var subject = await _subjectRepository.GetAsync(request.Id);

        return new SubjectGetResponse(
            subject.Id,
            subject.Name,
            subject.Description);
    }
}
