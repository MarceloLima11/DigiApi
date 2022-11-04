using Digi.Core.CustomValidations;

namespace Digi.Core.Abstractions
{
    public abstract class EntityBase
    {
        public Guid Id { get; private protected set; }
        public string Name { get; private protected set; }
        public string Description { get; private protected set; }

        public EntityBase(string name, string descr)
        {
            IsValid(name, descr);
        }

        private void IsValid(string name, string descr)
        {
            // Name =>
            DomainException.When(string.IsNullOrEmpty(name), "Name não pode ser nulo");

            // Description =>
            DomainException.When(string.IsNullOrEmpty(descr), "Description não pode ser nula");

            Id = new Guid();
            Name = name;
            Description = descr;
        }
    }
}