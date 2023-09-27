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
        public string GenerateToken(string usuario,string name ,string rol)
        {
            string? secretKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Autenticacion")["SecretKey"];

            var header = new JwtHeader(
            new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey ?? string.Empty)
                    ),
                    SecurityAlgorithms.HmacSha256)
            );

            var claims = new Claim[]
            {
                new Claim("IdUsuario", usuario),
                new Claim("Name", name),
                new Claim("Rol", rol),
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
