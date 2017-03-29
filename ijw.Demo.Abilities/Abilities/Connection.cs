using System;

namespace ijw.Demo.Abilities {
    class Connection : IConnection {
        public Sendable From {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public Recievable To {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public double Value {
            get {
                throw new NotImplementedException();
            }
        }

        public void ConnectNodes(Sendable ni, Recievable nh) {
            throw new NotImplementedException();
        }
    }
}
