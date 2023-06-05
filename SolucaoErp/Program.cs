using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SolucaoErp.Business.Imp;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Configuration;
using SolucaoErp.Repository;
using SolucaoErp.Repository.Imp;
using SolucaoErp.Repository.Interfaces;
using SolucaoErpDomain.Auth;
using System.Text;

using SolucaoErpDomain.Configurations;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//InjectionConfiguration.AddInjectionDependency(builder.Services);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddDbContext<RepositoryContext>(options=>options.UseMySql(RepositoryContext.dadosDeAcesso(), ServerVersion.AutoDetect(RepositoryContext.dadosDeAcesso())));
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ActionHandlersAttribute));
});
builder.Services.AddCors();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(AuthConfigurations.jwtOptions);
builder.Services.AddAuthorization();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//builder.Services.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
//builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();



builder.Services.AddDependencieInjections();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

app.Run();
