using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Subjects.Dtos;
using QuanLySinhVien.Subjects.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Queries.GetAll;

public class SubjectGetAllQueryHandler : IRequestHandler<SubjectGetAllQuery, List<SubjectGetAllResponse>>
{
    private readonly IRepository<Subject, Guid> _subjectRepository;

    public SubjectGetAllQueryHandler(IRepository<Subject, Guid> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<List<SubjectGetAllResponse>> Handle(SubjectGetAllQuery request, CancellationToken cancellationToken)
    {
        var subjects = await _subjectRepository
            .GetAll()
            .WhereIf(!request.SearchTerm.IsNullOrEmpty(), e => e.Name.Contains(request.SearchTerm))
            .ToListAsync();

        return subjects.ConvertAll(e => new SubjectGetAllResponse(e.Id, e.Name, e.Description));
    }
}
