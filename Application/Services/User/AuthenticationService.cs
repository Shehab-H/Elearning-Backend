using Application.Services.User.Commands;
using Core.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class AuthenticationService : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<ElearningUser> _userManager;
        private readonly IPasswordHasher<ElearningUser> _passwordHasher;

        public AuthenticationService(UserManager<ElearningUser> userManager, IPasswordHasher<ElearningUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ElearningUser()
            {
                Email = request.Email,
                UserName = request.UserName,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            var result = await _userManager.CreateAsync(user);

            if(result.Succeeded)
            {
                var claims = new List<Claim>()
                {
                   new Claim(ClaimTypes.Role, request.UserType.ToString())
                };
                await _userManager.AddClaimsAsync(user, claims);
            }
            return result;
        }
    }
}
