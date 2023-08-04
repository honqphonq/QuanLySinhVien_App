using MediatR;
using QuanLySinhVien.Subjects.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Queries.GetAll;

public class SubjectGetAllQueryHandler : IRequestHandler<SubjectGetAllQuery, List<SubjectGetAllResponse>>
{
    public Task<List<SubjectGetAllResponse>> Handle(SubjectGetAllQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
