using Abp.Domain.Repositories;
using MediatR;
using QuanLySinhVien.Authorization.Users;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.Suspend;

public class UserSuspendCommandHandler : IRequestHandler<UserSuspendCommand>
{
    private readonly IRepository<User, long> _userRepository;

    public UserSuspendCommandHandler(IRepository<User, long> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UserSuspendCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        user.Suspend();

        await _userRepository.UpdateAsync(user);    
    }
}
