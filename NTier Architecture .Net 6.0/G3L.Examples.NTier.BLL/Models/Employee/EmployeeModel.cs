namespace G3L.Examples.NTier.BLL.Models.Employee;

public record EmployeeModel : ModelBase
{
    public string Name { get; init; }
    public string Email { get; init; }
    public int CompanyId { get; init; }
}
