using PRSLib;
using PRSLib.Controllers;
using PRSLib.Models;
using System;

namespace PRSCapstoneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var prsconn = new PrsConnection("localhost", "PRS");
            prsconn.Connect();

            var user = new User()
            {
                Id = 0,
                Username = "zz",
                Password = "zz",
                Firstname = "zz",
                Lastname = "zz",
                Phone = "zz",
                Email = "zz",
                IsAdmin = true,
                IsReviewer = true,
            };
            var usersCtrl = new UsersController(prsconn);
            //var recsAffected = usersCtrl.Insert(user);
            var users = usersCtrl.GetUsers();
            var user1 = usersCtrl.GetUser(7);
            user1.Firstname = "Noah";
            user1.Lastname = "Phence";
            var recsAffected = usersCtrl.Update(user1);

            prsconn.Disconnect();
        }
    }
}
