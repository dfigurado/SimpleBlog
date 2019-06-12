using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core;
using SimpleBlog.Core.Domain;
using SimpleBlog.Persistence;

namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new SimpleBlogContext()))
            {
                var users = unitOfWork.Users.GetAll().ToList();
                foreach(var u in users)
                {
                    Console.WriteLine(u.Name);
                }
                Console.ReadLine();
            }
        }
    }
}
