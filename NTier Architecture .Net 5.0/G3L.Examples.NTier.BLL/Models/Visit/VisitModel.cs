using System;

namespace G3L.Examples.NTier.BLL.Models.Visit
{
    public class VisitModel
    {
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorCompany { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }
        public string Employee { get; set; }
        public string Company { get; set; }
    }
}