using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();*/
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbcontext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
