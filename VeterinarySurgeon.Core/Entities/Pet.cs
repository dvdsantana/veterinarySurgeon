namespace VeterinarySurgeon.Core.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; private set; }

        public int OwnerId { get; private set; } // Not required, but recommended.

        public Employee Owner { get; private set; }

        public int AnimalId { get; private set; } // Not required, but recommended.

        public Animal Animal { get; private set; }

        private Pet()
        {
        }

        public Pet(string name, Animal animal, Employee owner) : this()
        {
            Name = name;
            Animal = animal;
            Owner = owner;
        }

        public Pet(string name, int animalId, int ownerId) : this()
        {
            Name = name;
            AnimalId = animalId;
            OwnerId = ownerId;
        }

        public override string ToString() => $"The {Animal.Name} {Name} belongs to {Owner.FullName}.";
    }
}