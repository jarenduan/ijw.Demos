using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ijw.Demo.Abilities {
    public interface IConnection {
        Sendable From { get; set; }
        Recievable To { get; set; }
        double Value { get; }

        void ConnectNodes(Sendable ni, Recievable nh);
    }
}