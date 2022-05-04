using AutoMapper;
using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.IntegrationEvents.Events;
using DDD.UserAccess.IntegrationEvents.Events.Command;
using DDD.UserAccess.IntegrationEvents.Model;
using MediatR;

namespace DDD.UserAccess.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, LoginDto>
    {
        readonly IUserRepository _userRepo;
        readonly IMapper _mapper;
        readonly IJwtServices _jwtService;

        public AddUserCommandHandler(IUserRepository userRepo, IMapper mapper, IJwtServices jwtService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<LoginDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Domain.Users.User>(request);
            await _userRepo.Insert(model);
            var token = _jwtService.Generate(model);
            return new LoginDto(token, model.UserName);
        }
    }
}
