using System.Threading.Tasks;
using Insurance.Services.Models;

namespace Insurance.Services.Policies
{
    public interface IPolicyService
    {
        PolicyCollection GetByUsername(string userName);
        Task<PolicyCollection> GetAllAsync();
    }
}