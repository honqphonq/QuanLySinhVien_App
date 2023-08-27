using MediatR;
using QuanLySinhVien.Subjects.Commands.Create;
using QuanLySinhVien.Subjects.Commands.Delete;
using QuanLySinhVien.Subjects.Commands.Edit;
using QuanLySinhVien.Subjects.Dtos;
using QuanLySinhVien.Subjects.Queries.Get;
using QuanLySinhVien.Subjects.Queries.GetAll;
using System;
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

    public async Task<SubjectGetResponse> Get(SubjectGetRequest request)
    {
        return await _sender.Send(new SubjectGetQuery(request.Id));
    }

    public async Task Create(SubjectCreateRequest request)
    {
        var command = new SubjectCreateCommand(request.Name, request.Description);

        await _sender.Send(command);    
    }

   public async Task Edit(SubjectEditDto input)
    {
        var command = new SubjectEditCommand(input.Id, input.Name, input.Description);

        await _sender.Send(command);
    }

    public async Task Delete(Guid Id)
    {
        var command = new SubjectDeleteCommand(Id);

        await _sender.Send(command);
    }
}
