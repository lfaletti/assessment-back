using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.IServices.Policies
{
    public interface IPolicyService
    {
        Task<List<PolicyViewModel>> GetAllAsync();
        Task<List<PolicyViewModel>> GetByUsernameAsync(string userName);
    }
}