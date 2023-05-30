using Hr.WebAPI.Dapper;
using HR.OvetimePolicies.data;
using HR.OvetimePolicies.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ashkan abdolahi Sample", Version = "v1" });
});

builder.Services.AddDbContext<EmployeeContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


builder.Services.AddTransient<ICalculatorsService, CalculatorsService>();



builder.Services
.AddMvc(options =>
{
    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));

});
builder.Services.AddControllers();
builder.Services.AddDbContext<Hr.WebAPI.Dapper.AppContext>(options =>
          options.UseSqlServer(
              builder.Configuration.GetConnectionString("DefaultConnection")));
//Register dapper in scope 

builder.Services.AddScoped<IDapper, Dapperr>();
var app = builder.Build();

app.MapGet("/", () => "Entekhab man Sample Project");

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{datatype}/{controller}/{action=Index}/{id?}");


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR Sample Project API V1");
});
app.MapControllers();
app.Run();
