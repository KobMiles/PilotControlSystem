using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240829_PilotControlSystem
{
    internal abstract class Indicator
    {
        public abstract double SendValue();
        public abstract override string ToString();
    }
}
