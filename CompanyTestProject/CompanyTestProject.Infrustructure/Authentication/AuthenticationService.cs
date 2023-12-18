using CompanyTestProject.Application.Models;
using CompanyTestProject.Application.Models.Authentication;
using CompanyTestProject.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyTestProject.Infrustructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly JwtSettings _JwtSettings;

        public AuthenticationService(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _JwtSettings = jwtSettings.Value;
        }
        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            var user = await _UserManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception($"User with {request.Email} not found.");

            var result = await _SignInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (!result.Succeeded)
                throw new Exception($"Credentials for {request.Email} are not valid.");

            var jwtSecurityToken = await GenerateJwtToken(user);

            AuthenticationResponse response = new()
            {
                //Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;
        }

        public async Task<AuthenticationResponse> Registeration(AuthenticationRequest request)
        {
            User user = new()
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _UserManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new Exception($"{result.Errors.FirstOrDefault().Description}");

            var jwtSecurityToken = await GenerateJwtToken(user);
            AuthenticationResponse response = new AuthenticationResponse
            {
                //Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;
        }

        public async Task<JwtSecurityToken> GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey
                (Encoding.ASCII.GetBytes(_JwtSettings.Key));

            var signingCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _JwtSettings.Issuer,
                audience: _JwtSettings.Audience,
                claims: new[] { new Claim("Guid", user.Id) },
                expires: DateTime.Now.AddMinutes(_JwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );
            return jwtSecurityToken;
        }
    }
}
