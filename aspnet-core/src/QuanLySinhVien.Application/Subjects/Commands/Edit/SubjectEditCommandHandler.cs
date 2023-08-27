using Abp.Domain.Repositories;
using Abp.UI;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Subjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Subjects.Commands.Edit;

public class SubjectEditCommandHandler : IRequestHandler<SubjectEditCommand>
{
    private readonly IRepository<Subject, Guid> _editRepository;

    public SubjectEditCommandHandler(IRepository<Subject, Guid> editRepository)
    {
        _editRepository = editRepository;
    }

    public async Task Handle(SubjectEditCommand request, CancellationToken cancellationToken)
    {
        await ValidatorEditAsync(request.Id, request.Name);
        
        var editSubject = await _editRepository.GetAsync(request.Id);

        editSubject.Update(request.Name, request.Description);

        await _editRepository.UpdateAsync(editSubject);
    }

    private async Task ValidatorEditAsync(Guid Id, string Name)
    {
        var isExist = await _editRepository.GetAll().Where(e => e.Id != Id).AnyAsync(e => e.Name == Name);

        if(isExist)
        {
            throw new UserFriendlyException("SubjectServiceAlreadyExist");
        }
    }
}