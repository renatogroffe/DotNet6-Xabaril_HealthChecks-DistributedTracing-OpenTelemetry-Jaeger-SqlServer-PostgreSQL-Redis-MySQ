using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Configurando a verificação de disponibilidade de diferentes
// serviços através de Health Checks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("BaseContagemSqlServer"),
        name: "sqlserver", tags: new string[] { "db", "data", "sql" })
    .AddNpgSql(builder.Configuration.GetConnectionString("BaseContagemPostgreSql"),
        name: "postgresql", tags: new string[] { "db", "data", "sql" })
    .AddMySql(builder.Configuration.GetConnectionString("BaseContagemMySql"),
        name: "mysql", tags: new string[] { "db", "data", "sql" })
    .AddRedis(builder.Configuration.GetConnectionString("BaseContagemRedis"),
        name: "redis", tags: new string[] { "db", "data", "nosql" })
    .AddMongoDb(builder.Configuration.GetConnectionString("BaseContagemMongoDB"),
        name: "mongodb", tags: new string[] { "db", "data", "nosql" })
    .AddUrlGroup(new System.Uri("http://localhost:14269"),
        name: "jaeger", tags: new string[] { "url", "rest", "tracing", "microservices" });
builder.Services.AddHealthChecksUI()
    .AddSqlServerStorage(
        builder.Configuration.GetConnectionString("BaseHealthChecks"));

var app = builder.Build();

// Gera o endpoint que retornará os dados utilizados no dashboard
app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// Ativa o dashboard para a visualização da situação de cada Health Check
app.UseHealthChecksUI(options =>
{
    options.UIPath = "/monitor";
});

app.Run();