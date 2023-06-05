using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SolucaoErpAuth.Data;
using SolucaoErpAuth.Services;
using SolucaoErpDomain.Auth;
using SolucaoErpDomain.Model;
using System.Text;
using SolucaoErpDomain.Configurations;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration["ConnectionStrings:UsuarioConnection"];

builder.Services.AddDbContext<UsuarioDbContext>
    (opts =>
    {
        opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });


builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(AuthConfigurations.jwtOptions);

builder.Services.AddAuthorization();

builder.Services.AddDependencieInjections();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

app.Run();
