using System.Collections.Generic;

namespace VeterinarySurgeon.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string FullName => $"{Name} {LastName}";

        public bool IsEmployee { get; private set; } = true;

        public ICollection<FamilyMember> FamilyMembers { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public int PetsCount { 
            get {
                int petsCount = 0;

                if (Pets != null)
                    petsCount = Pets.Count;

                if (FamilyMembers == null)
                    return petsCount;
 
                foreach (var member in FamilyMembers)
                {
                    petsCount += member.PetsCount;
                }
                
                return petsCount;
            }
        }

        // We need this constructor in the child class FamilyMember,
        // so it should be at least protected.
        protected Employee() { }

        public Employee(string name, string lastName, bool isEmployee = true) : this()
        {
            Name = name;
            LastName = lastName;
            IsEmployee = isEmployee;
        }

        public Employee AddPets(ICollection<Pet> pets)
        {
            Pets = pets;
            return this;
        }

        public Employee AddFamilyMembers(ICollection<FamilyMember> familyMembers)
        {
            FamilyMembers = familyMembers;
            return this;
        }

        public override string ToString()
        {
            string status = IsEmployee ? "Employee" : "Not Employee";
            return $"({status}) {LastName}, {Name} has {Pets.Count} pet(s) and {FamilyMembers.Count} family Members(s).";
        }
    }
}