namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Create
{
    public class CreateCompanyOutputModel
    {
        public CreateCompanyOutputModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}