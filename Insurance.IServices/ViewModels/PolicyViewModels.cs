using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.IServices.ViewModels
{
    public class PolicyViewModel
    {
        public string Id { get; set; }
        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public System.DateTimeOffset InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }
    }
}
