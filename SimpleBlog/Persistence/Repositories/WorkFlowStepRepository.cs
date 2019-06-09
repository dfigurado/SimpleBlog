using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Persistence.Repositories
{
    public class WorkFlowStepRepository : Repository<WorkFlowStep>, IWorkFlowStepRepository
    {
        public WorkFlowStepRepository(SimpleBlogContext context) : base(context)
        {

        }

        public SimpleBlogContext SimpleBlogContext
        {
            get { return Context as SimpleBlogContext; }
        }
    }
}