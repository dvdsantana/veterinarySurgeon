namespace VeterinarySurgeon.Core.Entities
{
    public class FamilyMember : Employee
    {
        public Employee Employee { get; set; }

        public FamilyMember() : base()
        {
        }

        public FamilyMember(string name, string lastName, Employee employee) : base(name, lastName, false)
        {
            Employee = employee;
        }
    }
}