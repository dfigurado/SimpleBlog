using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Persistence.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SimpleBlogContext context) : base(context)
        {

        }

        public SimpleBlogContext SimpleBlogContext
        {
            get { return Context as SimpleBlogContext; }
        }

        public IEnumerable<UserRole> GetUserRoleWithWorkFlow(int id)
        {
            return SimpleBlogContext.UserRoles.Include(u => u.WorkFlowSteps).Where(u => u.Id == id);
        }
    }
}