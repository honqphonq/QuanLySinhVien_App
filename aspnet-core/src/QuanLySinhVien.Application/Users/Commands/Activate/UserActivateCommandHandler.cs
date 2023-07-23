using Abp.Domain.Repositories;
using MediatR;
using QuanLySinhVien.Authorization.Users;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.Activate;

public class UserActivateCommandHandler : IRequestHandler<UserActivateCommand>
{
    private readonly IRepository<User, long> _userRepository;

    public UserActivateCommandHandler(IRepository<User, long> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UserActivateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        user.Activate();

        await _userRepository.UpdateAsync(user);
    }
}
