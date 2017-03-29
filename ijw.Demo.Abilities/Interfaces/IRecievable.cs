using System.Collections.Generic;

namespace ijw.Demo.Abilities.Interfaces {

    //把接受连接的一系列操作抽象出来形成recieve接口
    internal interface IRecievable {
        IEnumerable<IConnection> InConnections { get; }
        void AddInConnection(IConnection connection);
        void RemoveInConnection(IConnection connection);
        double GetValueByInConnection(IConnection connection);
    }
}