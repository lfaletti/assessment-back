using System.Threading.Tasks;
using Insurance.IServices.Models;

namespace Insurance.Services.Policies
{
    public interface IPolicyService
    {
        PolicyCollection GetByUsername(string userName);
        Task<PolicyCollection> GetAllAsync();
    }
}