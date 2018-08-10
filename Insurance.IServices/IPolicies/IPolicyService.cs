﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.IServices.ViewModels;

namespace Insurance.IServices.IPolicies
{
    public interface IPolicyService
    {
        Task<List<PolicyViewModel>> GetAllAsync();
        Task<List<PolicyViewModel>> GetByUsernameAsync(string userName);
    }
}