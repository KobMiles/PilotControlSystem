using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240829_PilotControlSystem
{
    internal class FuelIndicator : Indicator
    {
        Engine _engine;

        public FuelIndicator(Engine engine)
        {
            _engine = engine;
        }
        public override double SendValue()
        {
            return Math.Round(_engine.GetFuel(), 2, MidpointRounding.ToZero);
        }
    }
}
