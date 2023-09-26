using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SegurAppJWToken
{
    public static class Authentication
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration Authentication
            //string valor = configuration.GetSection("Autenticacion:SecretKey").Value;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
                    {
                        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(
                                //Encoding.UTF8.GetBytes("25bf7728-f388-4276-aedb-81549186d8ee")
                                Encoding.UTF8.GetBytes(configuration.GetSection("Autenticacion:SecretKey").Value)
                                ),

                            ValidateIssuer = false,
                            ValidateAudience = false,
                            RequireExpirationTime = false
                        };
                    });
            return services;
        }
    }
}