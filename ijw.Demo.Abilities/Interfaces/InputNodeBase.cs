using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.Abilities.Interfaces {
    //输入型节点，只能向外发出连接
    public abstract class InputNodeBase : NodeBase, ISendable {
        public IEnumerable<IConnection> OutConnections {
            get {
                throw new NotImplementedException();
            }
        }

        //实现了ISendable接口（重复代码）
        #region Send接口的实现

        public void AddOutConnection(IConnection connection) {
            throw new NotImplementedException();
        }

        public double GetValueByOutConnection(IConnection connection) {
            throw new NotImplementedException();
        }

        public void RemoveOutConnection(IConnection connection) {
            throw new NotImplementedException();
        } 
        #endregion
    }
}