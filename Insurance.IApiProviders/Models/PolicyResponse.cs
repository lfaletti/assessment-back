using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.IApiProviders.Models
{
    public class PolicyResponse<T>
    {
        public List<T> Policies { get; set; }
    }
}
