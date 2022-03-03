namespace MicroServices.Common.BLL.Infrastructure.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(int id) : base($"The item with id: {id} was not found")
        {
            Id = id;
        }

        public ItemNotFoundException(int id, Type type) : base($"The {nameof(type)} with id: {id} was not found")
        {
           
        }
        public int Id { get; }
    }
}
