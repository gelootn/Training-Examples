namespace MicroServices.CompanyService.DAL.Models;

public class Employee : Entity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Company Company { get; set; }

}

