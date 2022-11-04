using System.Collections.Generic;
using System.Threading.Tasks;
using Digi.Core.Entities;

namespace Digi.Core.Intefaces
{
    public interface IQueryTamer
    {
        Task<IEnumerable<Tamer>> GetAllAsync();

        void Add(Tamer tamer);

        long Count();
    }
}