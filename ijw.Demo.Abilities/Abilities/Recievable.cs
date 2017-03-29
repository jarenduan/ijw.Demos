using System;
using System.Collections.Generic;

namespace ijw.Demo.Abilities {
    //这种实现方式固定的接口，就可以采用“能力”模式
    //以接口方法声明一种能力
    public interface Recievable {
    }

    //使用扩展方法进行能力的实现
    [Serializable]
    public static class RecievableImpl {
        ////”能力“的方法，类似于接口中的方法
        //public static void AddRecieve(this Recievable recieve, IConnection connection) {
        //    recieve.getInConnections().Add(connection);
        //}

        //public static void RemoveRecieve(this Recievable recieve, IConnection connection) {
        //    recieve.getInConnections().Remove(connection);
        //}

        ////“能力”的属性
        //public static IEnumerable<IConnection> GetInConnections(this Recievable recieve) {
        //    return recieve.getInConnections();
        //}

        ////"能力"的字段
        //private static List<IConnection> getInConnections(this Recievable recieve) {
        //    List<IConnection> value;
        //    if (!recieveAbility_InConnection.TryGetValue(recieve, out value)) {
        //        recieveAbility_InConnection.Add(recieve, new List<IConnection>());
        //    }
        //    return value;
        //}

        ////“能力”的全局字段，存储对象和属性的对应关系
        //private static Dictionary<Recievable, List<IConnection>> recieveAbility_InConnection = new Dictionary<Recievable, List<IConnection>>();

        ////涉及一定数据成员存储的”能力“需要进行”注册“，注册后的对象才具有这样的能力，仅对需要数据成员、属性等能力
        //public static void RegisterRecieve(this Recievable recieve) {
        //    recieveAbility_InConnection.Add(recieve, new List<IConnection>());
        //}

        ////对象被GC回收时，已经调用此方法，从存储中删除数据成员
        //public static void UnregisterRecieve(this Recievable recieve) {
        //    if (recieveAbility_InConnection.ContainsKey(recieve)) {
        //        recieveAbility_InConnection.Remove(recieve);
        //    }
        //}
        ////但是问题是，即使客户代码不再使用对象，对象一直在字典中引用，所以程序运行期间对象一直不会被回收，从而内存泄露。

        //--------------解决方法：使用弱引用-------------------------------
        //”能力“的方法，类似于接口中的方法，调用形式没有变化
        public static void AddRecieveConnection(this Recievable recieve, IConnection connection) {
            recieve.getInConnections().Add(connection);
        }

        public static void RemoveRecieveConnection(this Recievable recieve, IConnection connection) {
            recieve.getInConnections().Remove(connection);
        }

        //“能力”的属性
        public static IEnumerable<IConnection> GetInConnections(this Recievable recieve) {
            return recieve.getInConnections();
        }

        //"能力"的字段
        private static List<IConnection> getInConnections(this Recievable recieve) {
           return RecieveAbility_InConnection.GetMember(recieve);
        }
        
        private static ClassToMember<Recievable, List<IConnection>> RecieveAbility_InConnection = new ClassToMember<Recievable, List<IConnection>>();

        //"能力"需要注册
        public static void RegisterRecieveAbility(this Recievable recieve) {
            RecieveAbility_InConnection.Register(recieve);
        }
    }
}