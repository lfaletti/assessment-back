using System.Collections.Generic;

namespace Insurance.IApiProviders.Models
{
    public class ClientResponse<T>
    {
        public List<T> Clients { get; set; }
    }
}