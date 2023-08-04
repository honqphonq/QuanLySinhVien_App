using MediatR;
using QuanLySinhVien.Subjects.Dtos;
using QuanLySinhVien.Subjects.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Services;

public class SubjectAppService : QuanLySinhVienAppServiceBase, ISubjectAppService
{
    private readonly ISender _sender;

    public SubjectAppService(ISender sender)
    {
        _sender = sender;
    }

    public async Task<List<SubjectGetAllResponse>> GetAll(SubjectGetAllRequest request)
    {
        return await _sender.Send(new SubjectGetAllQuery(request.SearchTerm));
    }
}
