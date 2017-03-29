using System.Collections.Generic;

namespace ijw.Demo.Abilities.Interfaces {
    //把发出连接的一系列操作抽象出来形成send接口
    internal interface ISendable {
        IEnumerable<IConnection> OutConnections { get; }
        void AddOutConnection(IConnection connection);
        void RemoveOutConnection(IConnection connection);
        double GetValueByOutConnection(IConnection connection);
    }
}