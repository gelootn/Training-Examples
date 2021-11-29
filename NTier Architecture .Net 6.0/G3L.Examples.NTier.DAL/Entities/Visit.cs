namespace G3L.Examples.NTier.DAL.Entities;

public class Visit : Entity
{
    public Visitor Visitor { get; set; }
    public Company Company { get; set; }
    public Employee Employee { get; set; }

    public DateTime Start { get; set; }
    public DateTime? Stop { get; set; }
}
