namespace G3L.Examples.DDD.Domain.Companies.Factories.Employee
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private string _employeeName = default;
        private string _employeeEmail = default;
        
        public Models.Employee Build()
        {
            return new Models.Employee(_employeeName, _employeeEmail);
        }

        public IEmployeeFactory WithName(string name)
        {
            _employeeName = name;
            return this;
        }

        public IEmployeeFactory WithEmail(string email)
        {
            _employeeEmail = email;
            return this;
        }
    }
}