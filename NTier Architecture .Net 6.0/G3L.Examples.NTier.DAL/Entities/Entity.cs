namespace G3L.Examples.NTier.DAL.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public bool Deleted { get; set; }
}
