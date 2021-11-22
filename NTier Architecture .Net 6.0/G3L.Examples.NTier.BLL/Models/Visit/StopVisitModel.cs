using System;

namespace G3L.Examples.NTier.BLL.Models.Visit;

public record StopVisitModel
{
    public string VisitorEmail { get; set; }
    public DateTime Stop { get; set; }
}
