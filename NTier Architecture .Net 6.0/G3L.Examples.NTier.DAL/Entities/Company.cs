namespace G3L.Examples.NTier.DAL.Entities;

public class Company : Entity
{
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
