using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.EntityFramework.LazyLoad {
    public class UserServices {
        //没有下面这行语句的显式类型使用, 调用者build后, 项目输出文件夹中EF.SqlServer Dll的引用会被自动优化掉, 导致运行时缺少相应引用
        static private Type _tempType1_ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

        public bool AddUserIfNecessary() {
            using (var context = new EntityContext()) {
                var count = context.Users.Count();
                if (count != 0) return false;

                User u = new User();
                u.Name = "TestUser";
                u.Age = 21;

                ContactInfo ci = new ContactInfo();
                ci.Mail = "test@123.com";
                ci.PostCode = "100001";

                u.Contact = ci;

                context.Users.Add(u);
                context.SaveChanges();
            }

            using (var context  = new EntityContext()) {
                User u = new User();
                u.Name = "TestUser2";
                u.Age = 22;

                ContactInfo ci = new ContactInfo();
                ci.Mail = "test2@123.com";
                ci.PostCode = "100002";

                u.Contact = ci;

                context.Users.Add(u);
                context.SaveChanges();

                context.ContactInfos.Remove(ci);
                context.SaveChanges();
            }

            return true;
        }

        public int QueryUserCount() {
            using (var context = new EntityContext()) {
                return context.Users.Count();
            }
        }

        public IList<User> GetUsersWithContactLazy() {
            using (var context = new EntityContext()) {
                return context.Users.OrderBy(u => u.Name).ToList();
            }
        }

        public IList<User> GetUsersWithContactWithInclude() {
            using (var context = new EntityContext()) {
                return context.Users.Include(u => u.Contact).OrderBy(u => u.Name).ToList();
            }
        }
    }
}
