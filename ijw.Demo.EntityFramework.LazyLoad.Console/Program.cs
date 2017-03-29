using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ijw.Demo.EntityFramework.LazyLoad.Console {
    public class Program {
        static void Main(string[] args) {
            UserServices services = new UserServices();
            var ifadded = services.AddUserIfNecessary();
            if (ifadded) {
                System.Console.WriteLine("2 User and 2 ContactInfo added to database. One of ContactInfo remove by EF for testing.");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("User count in database: " + services.QueryUserCount());
            System.Console.WriteLine();

            IList<User> users = services.GetUsersWithContactLazy();
            DisplayUsersNameAndMails(users);

            IList<User> notlazyusers = services.GetUsersWithContactWithInclude();
            DisplayUsersNameAndMails(notlazyusers);

            System.Console.ReadLine();
        }

        private static void DisplayUsersNameAndMails(IList<User> users) {
            System.Console.WriteLine("Get user's contact with lazyload...got users, connection closed.");
            foreach (var u in users) {
                System.Console.WriteLine(" User name: " + u.Name + ".");
                try {
                    System.Console.Write("  Try to check if mail is null...");
                    if (u.Contact == null) {
                        System.Console.WriteLine("   Yes, it is.");
                    }
                    else {
                        System.Console.WriteLine("   NO, it is not.");
                        System.Console.WriteLine("   Mail: " + u.Contact.Mail + ".");
                    }

                }
                catch (Exception ex) {
                    System.Console.WriteLine();
                    System.Console.WriteLine("   Mail have value, null-checking causing lazyload.");
                    System.Console.WriteLine("   Lazyload failed: " + ex.GetType().ToString() + ".");
                }
            }
            System.Console.WriteLine();
        }
    }
}
