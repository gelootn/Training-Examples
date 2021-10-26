namespace G3L.Examples.NTier.Framework.Models
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Description { get; set; }
        public string Property { get; set; }
    }

    public enum MessageType
    {
        Info,
        Warning,
        Validation,
        Error
    }
}