using System;
using System.Collections.Generic;

namespace ijw.Demo.Abilities.Interfaces {
    [Serializable]
    public abstract class OutputNodeBase : NodeBase, IRecievable {
        //IRecievable properties
        public IEnumerable<IConnection> InConnections {
            get { return this.inConnections; }
        }

        public void AddInConnection(IConnection connection) {
            this.inConnections.Add(connection);
        }

        public void RemoveInConnection(IConnection connection) {
            this.inConnections.Remove(connection);
        }

        public double GetValueByInConnection(IConnection connection) {
            throw new NotImplementedException();
        }

        //Field
        protected List<IConnection> inConnections = new List<IConnection>();
    }
}
