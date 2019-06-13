using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                //Test List All Users
                //---------------------
                //var users = unitOfWork.Users.GetAll().ToList();
                //foreach(var u in users)
                //{
                //    Console.WriteLine(u.Name);
                //}
                //Console.ReadLine();


                //Test : Login
                //-----------------------------------

                //var userName = "admin@localhost.com";
                //var pwd = "pass123@";

                var userName = "editor@localhost.com";
                var pwd = "pass123@";


                var authUser = unitOfWork.Users.GetUserByEmailAndPassword(userName, pwd);
                var userAttr = unitOfWork.UserRole.Get(authUser.RoleId);
                var userWF = unitOfWork.UserRole.GetUserRoleWithWorkFlow(authUser.RoleId).ToList();
                if (authUser != null && userAttr != null)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Login successfull");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("User's Name :" + authUser.Name);
                    Console.WriteLine("Email Address :" + authUser.Email);
                    Console.WriteLine("User Role: " + userAttr.RoleName);
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Work Flow");
                    Console.WriteLine("---------------------------------");
                    foreach (var w in userWF)
                    {
                        foreach (var i in w.WorkFlowSteps)
                        {
                            Console.WriteLine(i.Id + " " + i.WorkFlow);
                        }
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Login unsuccessfull");
                    Console.ReadLine();
                }

                //Test : Blog Post CRUD
                //-----------------------------------
                BlogPost blogPost = new BlogPost
                {
                    Title = "Test Title",
                    BannerImage = "0.jpg",
                    Content = "<p>Test</p>",
                    UserId = authUser.Id,
                    WorkFlowId = 1,
                    CreateDate = DateTime.Now,
                    PublishedToDate = DateTime.Now.AddDays(10),
                    IsArchived = false
                };

                try
                {
                    unitOfWork.BlogPosts.Add(blogPost);
                    unitOfWork.Complete();
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace.ToString());
                }
            } 
        }
    }
}
