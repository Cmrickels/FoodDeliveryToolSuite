using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using ApiGateway.Services.Interfaces;
using ApiGateway.Models.Entities;
using ApiGateway.Models.Dto;
using ApiGateway.Presenters;
using ApiGateway.Models.Requests;
using ApiGateway.Models.Responses;


namespace ApiGateway.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        private readonly UserManager<User> _userManager;

        public AuthenticationService(IConfiguration configuration, UserManager<User> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task Register(RegisterRequest request, RegisterPresenter outputPort)
        {
            
        }

        public async Task FetchAndAuthenticate(LoginRequest request, LoginPresenter outputPort)
        {
            User user = await _userManager.FindByNameAsync(request.Username);
            bool authenticated = await _userManager.CheckPasswordAsync(user, request.Password);

            if(user != null && authenticated) {
                JwtToken jwt = await this.PerformAuthProtocol(user);
                outputPort.Handle(new LoginResponse(200, "Successful Authentication", jwt.token));
                return;
            } else if(user == null) {
                outputPort.Handle(new LoginResponse(401, "User not found"));
                return;
            } else if(user != null && !authenticated) {
                outputPort.Handle(new LoginResponse(401, "Incorrect Credentials"));
                return;
            }
        }

        public async Task<JwtToken> PerformAuthProtocol(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims, // public claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)// security signature
            );

            return new JwtToken(token);
        }


    }
}