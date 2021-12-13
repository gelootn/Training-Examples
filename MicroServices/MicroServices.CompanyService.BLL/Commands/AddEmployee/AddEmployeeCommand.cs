namespace MicroServices.CompanyService.BLL.Commands.AddEmployee;

public class AddEmployeeCommand : IRequest<AddEmployeeCommandResponse>
{
    public int CompanyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}