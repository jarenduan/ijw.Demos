﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.MEF {
    public interface IPlugin {
        string Name { get; set; }
        void SayHello();
    }
}
