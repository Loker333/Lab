using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<bool> ValidateCustomer(CustomerForAuthenticationDto customerForAuth);
        Task<string> CreateToken();
        Task<string> CreateTokenCustomer();
    }
}
