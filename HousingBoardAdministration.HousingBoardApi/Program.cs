using HousingBoardApi.Application;
using HousingBoardApi.Domain.Mail;
using HousingBoardApi.Infrastructure;
using HousingBoardApi.SqlServerContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

//builder.Services.AddControllersWithViews()
//    .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);


// Add-Migration init -Context HousingBoardApi.SqlServerContext.HousingBoardDbContext -Project HousingBoardApi.SqlServerContextMigrations
// Update-Database -Context HousingBoardApi.SqlServerContext.HousingBoardDbContext
builder.Services.AddDbContext<HousingBoardDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("HousingBoardDbContextConnection"),
    x => x.MigrationsAssembly("HousingBoardApi.SqlServerContextMigrations")));

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

app.Run();
