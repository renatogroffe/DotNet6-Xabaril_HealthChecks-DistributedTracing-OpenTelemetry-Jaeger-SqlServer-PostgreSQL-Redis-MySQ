using MongoDB.Bson;

namespace ConsoleAppConsumoAPIs.Documents;

public class ContagemDocument
{
    public ObjectId _id { get; set; }
    public string? DataReferencia { get; set; }
    public object? SqlServerData { get; set; }
    public object? PostgreSqlData { get; set; }
    public object? RedisData { get; set; }
    public object? MySqlData { get; set; }
}