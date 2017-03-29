using System;
using System.Collections.Generic;

namespace ijw.Demo.Abilities {
    [Serializable]
    public abstract class OutputNodeBase : Recievable {
        public abstract double Input { get; }
        public abstract double Output { get; }
        public IEnumerable<IConnection> InConnections {
            get { return this.inConnections; }
        }

        public OutputNodeBase() {
            this.inConnections = new List<IConnection>();
        }

        public void AddRecieve(IConnection connection) {
            this.inConnections.Add(connection);
        }
        public void RemoveRecieve(IConnection connection) {
            this.inConnections.Remove(connection);
        }
        protected List<IConnection> inConnections;
    }
}
