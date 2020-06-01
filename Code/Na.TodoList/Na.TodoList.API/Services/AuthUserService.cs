using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.API.Services
{
    public class AuthUserService : IAuthUserServices
    {
        private readonly IConfiguration _config;

        public AuthUserService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void CreateToken(AppUser userInfo)
        {   
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim("id", userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.GivenName, string.Format("{0} {1}", userInfo.FirstName, userInfo.LastName)),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),                
                //new Claim("role", string.Join(",",userInfo.UserRoles.Select(x=>x.RoleId).ToArray())),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:ExpirationTimeMinutes"])),
                signingCredentials: credentials);

            userInfo.Token = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
