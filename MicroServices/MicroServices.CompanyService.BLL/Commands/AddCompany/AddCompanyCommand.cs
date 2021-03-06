namespace MicroServices.CompanyService.BLL.Commands.AddCompany
{
    public record AddCompanyCommand : IRequest<AddCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VatNumber { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
    }
}


