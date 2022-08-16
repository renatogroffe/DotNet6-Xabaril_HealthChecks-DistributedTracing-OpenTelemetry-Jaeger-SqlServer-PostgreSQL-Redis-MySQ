using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppConsumoAPIs.Documents;
using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;

namespace ConsoleAppConsumoAPIs.Data;

public static class ContagemRepository
{
    public static void Save(ContagemDocument document)
    {
        var clientSettings = MongoClientSettings.FromUrl(
            new MongoUrl("mongodb://root:MongoDB2022!@localhost:27017"));
        clientSettings.ClusterConfigurator = cb => cb.Subscribe(new DiagnosticsActivityEventSubscriber());

        var client = new MongoClient(clientSettings);
        var db = client.GetDatabase("DBContagem");
        var historico = db.GetCollection<ContagemDocument>("HistoricoContagem");

        historico.InsertOne(document);
    }
}