using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using MyWallet.Mappings;
using WebApplication1;
using MyWallet.BaseCollections;
using MyWallet.Configurations;
using NHibernate.Driver;
using MyWallet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Permite qualquer origem
               .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
               .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

builder.Services.AddControllers();

// Configura o appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Se for necessário acessar alguma seção do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var sessionFactory = NHibernateConfig.CreateSessionFactory(connectionString);

builder.Services.AddSingleton(sessionFactory);
builder.Services.AddScoped<NHibernate.ISession>(provider => sessionFactory.OpenSession());

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(runner => runner
        .AddSqlServer() // Troque conforme o banco de dados que você está utilizando
        .WithGlobalConnectionString(connectionString)
        .ScanIn(Assembly.GetExecutingAssembly()) // Scaneia o assembly atual
        .ScanIn(typeof(MyWallet.Database.Migrations.M20240923174100).Assembly).For.Migrations()) // Scaneia o assembly onde estão as migrações
    .AddLogging(logging => logging.AddFluentMigratorConsole());

// Configura o serviço de banco de dados (exemplo com Entity Framework)
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Configuração de roteamento global para controllers
    endpoints.MapControllers(); // Isso automaticamente aplica as rotas para os controllers
});

app.MapControllers();

builder.Services.AddDynamicServices(typeof(BaseService<>).Assembly);

using (var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp(); // Executa todas as migrações pendentes
}

app.Run();
