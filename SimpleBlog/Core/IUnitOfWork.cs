using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository BlogPosts { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRole { get; }
        IWorkFlowStepRepository WorkFlowStep { get; }
        int Complete();
    }
}
