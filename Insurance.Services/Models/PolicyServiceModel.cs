using System;

namespace Insurance.ApiProviders.Models
{
    public class PolicyServiceModel
    {
        public string Id { get; set; }

        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public DateTimeOffset InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }
    }
}