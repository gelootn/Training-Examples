namespace G3L.Examples.DDD.Domain.Visiting.Factories.Visitor
{
    public class VisitorFactory : IVisitorFactory
    {
        private string _name = default;
        private string _email = default;
        private string _companyName = default;
        
        public Models.Visitor Build()
        {
            return new Models.Visitor(_name, _email, _companyName);
        }

        public IVisitorFactory WithName(string name)
        {
            _name = name;
            return this;
        }

        public IVisitorFactory WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public IVisitorFactory WithCompanyName(string companyName)
        {
            _companyName = companyName;
            return this;
        }
    }
}