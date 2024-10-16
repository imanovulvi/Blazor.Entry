using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Commands.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dictionary.Common.AppClasses
{
    public class TokenGenerate
    {
        public string CreateAccessToken(User user, DateTime expires, IConfiguration _configuration)
        {

            List<Claim> claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Name, user.Name),


            };

            //foreach (var item in user.AppUsersAppRoles)
            //    claims.Add(new Claim(ClaimTypes.Role, item.AppRole.Role));

            //Application.DTOs.Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenSecurty:securityKey"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                expires: expires,
                notBefore: DateTime.UtcNow,
                issuer: _configuration["TokenSecurty:issuer"],
                audience: _configuration["TokenSecurty:audience"],
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);


        }
    }
}
