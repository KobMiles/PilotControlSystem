using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    public class SpeedIndicator : Indicator
    {
        private double _speed;

        private Engine _engine;

        private const int MAX_RPM = 6000;
        private const int MIN_RPM = 3000;
        private const int MAX_SPEED = 900;

        public SpeedIndicator(Engine engine)
        {
            _engine = engine;
        }
        
        public override int SendValue()
        {
            return (int)Math.Round(Math.Abs(_engine.RPM - MIN_RPM / (MAX_RPM - MIN_RPM) * MAX_SPEED));
        }
    }
}