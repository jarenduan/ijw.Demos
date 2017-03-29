using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ijw.Demo.Abilities {
    [Serializable]
    public abstract class MiddleNodeBase : OutputNodeBase, Recievable, Sendable {
        public IEnumerable<IConnection> OutConnections {
            get { return this.outConnections; }
        }

        public MiddleNodeBase() {
            this.outConnections = new List<IConnection>(); 
        }

        public void AddSend(IConnection connection) {
            this.outConnections.Add(connection);
        }
        public void RemoveSend(IConnection connection) {
            this.outConnections.Remove(connection);
        }
        public abstract double GetValueByConn(IConnection connection);

        protected List<IConnection> outConnections;
    }
}