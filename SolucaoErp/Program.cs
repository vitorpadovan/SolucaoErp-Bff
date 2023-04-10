using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolucaoErp.Configuration;
using SolucaoErp.Repository;

var builder = WebApplication.CreateBuilder(args);

InjectionConfiguration.AddInjectionDependency(builder.Services);
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
