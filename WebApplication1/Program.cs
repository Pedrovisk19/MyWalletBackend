using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWallet.Models.Repository;
using MyWallet.Services;
using NHibernate.Mapping;
using System.Reflection;
using WebApplication1; // Importar isso para usar o `typeof(Program).Assembly`

var builder = WebApplication.CreateBuilder(args);

// String de conex�o do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin() // Permite qualquer origem
               .AllowAnyMethod() // Permite qualquer m�todo (GET, POST, etc.)
               .AllowAnyHeader(); // Permite qualquer cabe�alho
    });
});

builder.Services.AddControllers();

builder.Services.AddScoped<UsersService>(); // Adicione esta linha


builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar o FluentMigrator para escanear a pasta `Database/Migrations`
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(runner => runner
        .AddSqlServer() // Troque conforme o banco de dados que voc� est� utilizando
        .WithGlobalConnectionString(connectionString)
        .ScanIn(Assembly.GetExecutingAssembly()) // Scaneia o assembly atual
    .ScanIn(typeof(MyWallet.Database.Migrations.M20240923174100).Assembly).For.Migrations()) // Scaneia o assembly onde est�o as migra��es
    .AddLogging(logging => logging.AddFluentMigratorConsole());

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

// Executar as migra��es automaticamente
using (var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp(); // Executa todas as migra��es pendentes
}

app.Run();
