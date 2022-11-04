using AutoMapper;
using Digi.Core.Entities;
using Digi.Core.Intefaces;
using Digi.Infra.Interfaces;
using Digi.Infra.Records;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Digi.Infra.Services
{
    public class QueryTamerService : IQueryTamerService
    {
        private readonly IQueryTamer _queryT;
        private readonly IMapper _map;

        public QueryTamerService(IMapper map, IQueryTamer queryT)
        {
            _queryT = queryT;
            _map = map;
        }

        public async Task<IEnumerable<TamerRecord>> GetAllAsync()
        {
            var tamers = await _queryT.GetAllAsync();

            return _map.Map<IEnumerable<TamerRecord>>(tamers);
        }

        public void Add(TamerRecord tamerR)
        {
            var tamer = _map.Map<Tamer>(tamerR);
            _queryT.Add(tamer);
        }
    }
}