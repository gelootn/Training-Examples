namespace G3L.Examples.NTier.DAL.Entities;

public class Employee : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
