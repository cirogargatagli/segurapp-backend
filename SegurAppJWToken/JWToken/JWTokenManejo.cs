using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SegurAppJWToken.JWToken.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SegurAppJWToken.JWToken
{
    public class JWTokenManejo : IJWTokenManejo
    {
        //private readonly IConfiguration _configuration;

        public JWTokenManejo()
        {
        }

        public string GenerateToken(string mail)
        {
            var header = new JwtHeader(
            new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("25bf7728-f388-4276-aedb-81549186d8ee")
                    ),
                    SecurityAlgorithms.HmacSha256)
            );

            var claims = new Claim[]
            {
                new Claim("Email", mail),
                new Claim("Name", "leandro"),
            };
            var payload = new JwtPayload(
                 issuer: "algoasda",
                audience: "algoasda",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(6)
                );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
