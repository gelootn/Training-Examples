namespace MicroServices.CompanyService.DAL.Models;

public class Company : Entity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string VatNumber { get; set; }
    public string Building { get; set; }
    public int Floor { get; set; }
    public IEnumerable<Employee> Employees { get; set; }

}

