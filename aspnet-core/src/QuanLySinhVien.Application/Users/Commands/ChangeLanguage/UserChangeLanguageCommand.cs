using MediatR;

namespace QuanLySinhVien.Users.Commands.ChangeLanguage;

public record UserChangeLanguageCommand(string LanguageName) : IRequest;
