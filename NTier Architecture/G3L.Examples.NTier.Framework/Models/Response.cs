using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace G3L.Examples.NTier.Framework.Models
{
    public class Response<T>
    {
        private readonly ICollection<T> _values = new List<T>();

        public Response(T response)
        {
            _values.Add(response);
        }

        public Response(ICollection<T> values)
        {
            _values = values;
        }


        public T Value => _values.FirstOrDefault();
        public ICollection<T> Values => _values;
        public bool IsSuccess => Messages.All(x => x.Type != MessageType.Error);
        public ICollection<Message> Messages { get; set; }
    }
}