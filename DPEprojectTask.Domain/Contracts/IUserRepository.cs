using DPEprojectTask.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Contracts
{
    public interface IUserRepository
    {
        Task Save(CustomIdentityUser user);
        Task<CustomIdentityUser> Get(int id);
    }
}
