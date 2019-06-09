using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Persistence.Repositories
{
    public class PostRepository : Repository<BlogPost>, IPostRepository
    {
        public PostRepository(SimpleBlogContext context) : base(context)
        {

        }

        public SimpleBlogContext SimpleBlogContext
        {
            get { return Context as SimpleBlogContext; }
        }

        public IEnumerable<BlogPost> GetBlogPostsWithUsers(int pageIndex, int pageSize)
        {
            return SimpleBlogContext.BlogPosts
                .Include(p => p.BlogUser)
                .OrderBy(p => p.CreateDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}