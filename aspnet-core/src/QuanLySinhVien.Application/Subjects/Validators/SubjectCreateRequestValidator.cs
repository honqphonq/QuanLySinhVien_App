using FluentValidation;
using QuanLySinhVien.Subjects.Consts;
using QuanLySinhVien.Subjects.Dtos;

namespace QuanLySinhVien.Subjects.Validators;

public class SubjectCreateRequestValidator : AbstractValidator<SubjectCreateRequest>
{
    public SubjectCreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(SubjectConsts.NameMaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(SubjectConsts.DescriptionMaxLength);
    }
}
