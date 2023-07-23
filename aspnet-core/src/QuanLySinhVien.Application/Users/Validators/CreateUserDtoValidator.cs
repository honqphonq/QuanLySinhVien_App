using Abp.Authorization.Users;
using FluentValidation;
using QuanLySinhVien.Users.Dto;

namespace QuanLySinhVien.Users.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.UserName)
           .NotEmpty()
           .MaximumLength(AbpUserBase.MaxUserNameLength)
           .Matches("^[a-zA-Z0-9_.-]*$").WithMessage("Username must contain letters, digits, hyphen, underscore or period only.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(AbpUserBase.MaxNameLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(AbpUserBase.MaxSurnameLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(AbpUserBase.MaxEmailAddressLength);

        RuleFor(x => x.RoleId).NotEmpty();
    }
}
