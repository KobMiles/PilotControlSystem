using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    internal class SpeedIndicator : Indicator
    {
        private double _speed;

        private Engine _engine;

        private const int MAX_RPM = 6101;
        private const int MIN_RPM = 3701;
        private const int MAX_SPEED = 900;

        public SpeedIndicator(Engine engine)
        {
            _engine = engine;
        }
        
        public override double SendValue()
        {
            if (_engine.GetRPM() < MIN_RPM) return 0;
            return Math.Round(((_engine.GetRPM() - MIN_RPM) / (MAX_RPM - MIN_RPM)) * MAX_SPEED);
        }
    }
}