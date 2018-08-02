using System.Collections.Generic;

/// <summary>
/// Models to match with External Api
/// </summary>
/// 
namespace Insurance.Services.Models
{
    public class Policy
    {
        public string Id { get; set; }

        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public System.DateTimeOffset InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }

    }

    public class PolicyCollection
    {
        public List<Policy> Policies { get; set; }
    }
}