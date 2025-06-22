using kolokwium_code_first_1.Data;
using kolokwium_code_first_1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbService, DbService>();


//uczelniane dla appsettings.json z ćwiczeń
//"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
//z githuba z rozwiazania kolokwium
//"Default": "Data Source=localhost, 1433; User=SA; Password=yourStrong(!)Password; Initial Catalog=test2; Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False"

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();

