using System.Collections.Generic;

namespace Insurance.IApiProviders.Models
{
    public class PolicyResponse<T>
    {
        public List<T> Policies { get; set; }
    }
}