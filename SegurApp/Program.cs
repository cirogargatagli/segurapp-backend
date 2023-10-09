using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SegurApp.Infraestructure;
using SegurApp.Repository;
using SegurApp.Repository.Interfaces;
using SegurApp.Services;
using SegurApp.Services.Hubs;
using SegurApp.Services.Interfaces;
using SegurAppJWToken;
using SegurAppJWToken.JWToken;
using SegurAppJWToken.JWToken.Interfaces;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR().AddHubOptions<SendMessageHub>(options =>
{
    options.EnableDetailedErrors = true; // Otras opciones que puedas necesitar
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
}); ;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Inyecciones
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IMessageUserRepository, MessageUsersRepository>();
builder.Services.AddTransient<IMessageUserService, MessageUserService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IJWTokenManejo, JWTokenManejo>();

//Autenticacion jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(
                        //Encoding.UTF8.GetBytes("25bf7728-f388-4276-aedb-81549186d8ee")
                            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Autenticacion:SecretKey").Value)
                            ),

                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false
                    };
                });

//CORS

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:8081", "http://localhost:5554")
//                   .AllowAnyMethod()
//                   .AllowAnyHeader()
//                   .AllowCredentials();
//        });
//});

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SendMessageHub>("/sendMessageHub");

//app.UseCors("AllowAll");


app.Run();



