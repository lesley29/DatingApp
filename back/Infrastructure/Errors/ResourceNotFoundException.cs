using System.Net;

namespace Infrastructure.Errors
{
    public class ResourceNotFoundException : ApiException
    {
        public ResourceNotFoundException()
            : base((int)HttpStatusCode.NotFound, "Requested resource was not found")
        {
        }
    }
}
