using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core.Domain;

namespace SimpleBlog.Core.Repositories
{
    public interface IUserRepository : IRepository<BlogUser>
    {
        BlogUser GetUserWithBlogs(int id);
        BlogUser GetUserByEmail(string email);
        BlogUser GetUserByEmailAndPassword(string email, string password);
    }
}
