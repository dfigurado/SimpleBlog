using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Core;
using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;
using SimpleBlog.Persistence.Repositories;

namespace SimpleBlog.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleBlogContext _context;

        public UnitOfWork(SimpleBlogContext context)
        {
            _context = context;
            BlogPosts = new PostRepository(_context);
            Users = new UserRepository(_context);
            UserRole = new UserRoleRepository(_context);
            WorkFlowStep = new WorkFlowStepRepository(_context);
        }

        public IPostRepository BlogPosts { get; private set; }
        public IUserRepository Users { get; private set; }
        public IUserRoleRepository UserRole { get; private set; }
        public IWorkFlowStepRepository WorkFlowStep { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}