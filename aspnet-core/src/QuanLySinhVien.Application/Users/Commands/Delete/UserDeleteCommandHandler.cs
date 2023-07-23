using Abp.Domain.Repositories;
using MediatR;
using QuanLySinhVien.Authorization.Users;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLySinhVien.Users.Commands.Delete;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
{
    private readonly IRepository<User, long> _userRepository;

    public UserDeleteCommandHandler(IRepository<User, long> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        await _userRepository.DeleteAsync(user);
    }
}
