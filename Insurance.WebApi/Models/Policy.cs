namespace Insurance.WebApi.Models
{
    public class Policy
    {
        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public System.DateTimeOffset InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }
    }
}
