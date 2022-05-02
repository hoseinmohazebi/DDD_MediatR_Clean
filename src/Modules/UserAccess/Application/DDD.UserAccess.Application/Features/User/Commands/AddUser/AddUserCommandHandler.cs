using AutoMapper;
using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.IntegrationEvents.Events;
using DDD.UserAccess.IntegrationEvents.Response;
using MediatR;

namespace DDD.UserAccess.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, LoginDto>
    {
        readonly IUserRepository _userRepo;
        readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<LoginDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Domain.Users.User>(request);
            await _userRepo.Insert(model);
            return new LoginDto("a","aaa");
        }
    }
}
