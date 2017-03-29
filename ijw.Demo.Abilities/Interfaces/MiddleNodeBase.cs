using System;
using System.Collections.Generic;

namespace ijw.Demo.Abilities.Interfaces {

    //中间型节点，既能接受也能发出连接。从outputnodebase继承，同时自己实现Send接口。
    [Serializable]
    public abstract class MiddleNodeBase : OutputNodeBase, IRecievable, ISendable {
        public IEnumerable<IConnection> OutConnections {
            get { return this.outConnections; }
        }

        //实现Send接口（重复代码，inputnodebase中也有一套一样的代码，逻辑功能完全一样，不需要多种实现）
        #region Send接口的实现
        public void AddOutConnection(IConnection connection) {
            throw new NotImplementedException();
        }

        public void RemoveOutConnection(IConnection connection) {
            throw new NotImplementedException();
        }

        public double GetValueByOutConnection(IConnection connection) {
            throw new NotImplementedException();
        } 
        #endregion

        protected List<IConnection> outConnections = new List<IConnection>();
    }
}