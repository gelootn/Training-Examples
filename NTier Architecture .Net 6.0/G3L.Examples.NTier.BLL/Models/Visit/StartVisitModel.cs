using System;

namespace G3L.Examples.NTier.BLL.Models.Visit;

public class StartVisitModel
{
    public string VisitorName { get; set; }
    public string VisitorEmail { get; set; }
    public string VisitorCompany { get; set; }
    public DateTime Start { get; set; }
    public int EmployeeId { get; set; }
    public int CompanyId { get; set; }
}
