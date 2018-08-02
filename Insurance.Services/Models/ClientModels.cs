using System.Collections.Generic;

/// <summary>
/// Models to match with External Api
/// </summary>
namespace Insurance.Services.Models
{
    public class Client
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }

    public class ClientCollection { 

        public List<Client> Clients { get; set; }
    }
}