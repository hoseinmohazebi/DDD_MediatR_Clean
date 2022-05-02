using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.IntegrationEvents.Events;
using DDD.UserAccess.IntegrationEvents.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Application.Features.User.Query
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginDto>
    {
        readonly IUserRepository _userRepo;
        readonly IJwtServices _jwtService;
        readonly UserManager<Domain.Users.User> _userManager;

        public LoginUserQueryHandler(IUserRepository userRepo, UserManager<Domain.Users.User> userManager, IJwtServices jwtService)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<LoginDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new Exception("user notFound");

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("incorrect pass");
            }
            var token = _jwtService.Generate(user);
            return new LoginDto("t", token);
        }
    }
}
