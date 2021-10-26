using System;
using System.Threading.Tasks;
using G3L.Examples.NTier.Framework.Models;

namespace G3L.Examples.NTier.Framework.Infrastructure.Extensions
{
    public static class ExtensionsForResponse
    {
        public static Response<T> AddMessage<T>(this Response<T> response, string message, MessageType type)
        {
            response.Messages.Add(
                new Message
                {
                    Description = message,
                    Type = type
                }
                );
            return response;
        }
        public static Response<T> AddError<T>(this Response<T> response, string message)
        {
            return response.AddMessage(message, MessageType.Error);
        }

        public static Response<T> AddError<T>(this Response<T> response, Exception ex)
        {
            response.AddError(ex.Message);
            if (ex.InnerException != null)
            {
                response.AddError(ex.InnerException);
            }
            return response;
        }

    }
}