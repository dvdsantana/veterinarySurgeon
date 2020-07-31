using System;
using System.Collections.Generic;
using System.Text;
using VeterinarySurgeon.SharedKernel;

namespace VeterinarySurgeon.Core.Entities
{
    public class Animal: BaseEntity
    {
        public string Name { get; private set; }

        public ICollection<Pet> Pets { get; set; }

        private Animal()
        {

        }
        public Animal(string name):this()
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
