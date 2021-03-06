﻿/// <summary>
/// Models to match with External Api
/// </summary>
/// 

using System;

namespace Insurance.IApiProviders.Models
{
    public class PolicyDTO
    {
        public string Id { get; set; }

        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public DateTimeOffset InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }
    }
}