using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroDePreco.Repository;
using SolucaoErpDomain.Auth;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Configurations.Errors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddDbContext<RegistroPrecoContext>(options => options.UseMySql(RegistroPrecoContext.dadosDeAcesso(), ServerVersion.AutoDetect(RegistroPrecoContext.dadosDeAcesso())));

builder.Services.AddAuthentication(AuthConfigurations.authOptions).AddJwtBearer(AuthConfigurations.jwtOptions);
builder.Services.AddAuthorization();
builder.Services.AddDependencieInjections();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ActionHandlersAttribute));
});

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
