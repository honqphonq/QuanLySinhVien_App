using Abp.Application.Services;
using QuanLySinhVien.Subjects.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Services;

public interface ISubjectAppService : IApplicationService
{
    Task<List<SubjectGetAllResponse>> GetAll(SubjectGetAllRequest request);

    Task<SubjectGetResponse> Get(SubjectGetRequest request);

    Task Create(SubjectCreateRequest input);

    Task Edit(SubjectEditDto input);
}
