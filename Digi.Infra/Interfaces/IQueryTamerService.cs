using Digi.Core.Entities;
using Digi.Infra.Records;

namespace Digi.Infra.Interfaces
{
    public interface IQueryTamerService
    {
        Task<IEnumerable<TamerRecord>> GetAllAsync();

        void Add(TamerRecord tamer);
    }
}