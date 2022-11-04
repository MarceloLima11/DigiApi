using Digi.Core.Abstractions;

namespace Digi.Core.Entities
{
    public sealed class Digimon : EntityBase
    {
        public ICollection<Digimon> Evolutions { get; private protected set; }

        public Digimon(string name, string descr, ICollection<Digimon> evolutions) : base(name, descr)
        {
            Evolutions = evolutions;
        }
    }
}
