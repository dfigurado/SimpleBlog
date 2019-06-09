using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Persistence.Repositories
{
    public class UserRepository : Repository<BlogUser>, IUserRepository
    {
        public UserRepository(SimpleBlogContext context) : base(context)
        {

        }

        public BlogUser GetUserWithBlogs(int id)
        {
            return SimpleBlogContext.BlogUsers.Include(a => a.BlogPosts).SingleOrDefault(a => a.Id == id);
        }

        public BlogUser GetUserByEmail(string email)
        {
            return SimpleBlogContext.BlogUsers
                .Where(a => a.Email == email)
                .SingleOrDefault();
        }

        public BlogUser GetUserByEmailAndPassword(string email, string password)
        {
            return SimpleBlogContext.BlogUsers
                .Where(a => a.Email == email)
                .Where(a => a.Password == password)
                .SingleOrDefault();
        }

        public SimpleBlogContext SimpleBlogContext
        {
            get { return Context as SimpleBlogContext; }
        }
    }
}