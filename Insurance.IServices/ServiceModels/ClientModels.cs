using System.Collections.Generic;

/// <summary>
/// Models to match with External Api
/// </summary>
namespace Insurance.IServices.ServiceModels
{
    public class ClientServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}