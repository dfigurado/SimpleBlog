using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core.Domain;

namespace SimpleBlog.Core.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IEnumerable<UserRole> GetUserRoleWithWorkFlow(int id); 
    }
}
