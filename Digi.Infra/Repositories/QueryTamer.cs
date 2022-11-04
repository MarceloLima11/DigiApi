using Digi.Core.Entities;
using Digi.Core.Intefaces;
using Digi.Infra.Persistence;
using Digi.Infra.Records;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Digi.Infra.Repositories
{
    public class QueryTamer : IQueryTamer
    {
        private readonly IMongoCollection<Tamer> _tamerColletion;

        public QueryTamer(IOptions<DigiDbSettings> sett)
        {

            var client = new MongoClient(sett.Value.ConnectionURI);
            var database = client.GetDatabase(sett.Value.DatabaseName);

            _tamerColletion = database.GetCollection<Tamer>(sett.Value.CollectionName);
        }

        public async Task<IEnumerable<Tamer>> GetAllAsync() => await _tamerColletion.Find(_ => true).ToListAsync();

        public void Add(Tamer tamer)
        {
            _tamerColletion.InsertOne(tamer);
        }

        public long Count() => _tamerColletion.CountDocuments(_ => true);
    }
}