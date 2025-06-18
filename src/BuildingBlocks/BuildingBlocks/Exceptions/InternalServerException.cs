

using System.Runtime.InteropServices.Marshalling;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerException:Exception 
    {
        public InternalServerException(string message) : base(message)
        {
        }
        public InternalServerException(string message, string details) : base(message )
        {
            Details = details;  
        }
        public InternalServerException(string name, object key) : base($"Entity \"{name}\" ({key}) encountered an internal server error.")
        {
        }

        public string? Details { get; }
    }
}
