using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240829_PilotControlSystem
{
    internal class Aircraft
    {
        private readonly string _namePlane;
        private readonly string _modelPlane;
        private readonly string _bortNumber;

        private readonly Engine _engine = new();
        private ControlSystem _controlSystem;

        private List<Indicator> _indicators = [];
        public Aircraft()
        {
            _namePlane = "null";
            _modelPlane = "null";
            _bortNumber = "null";
            _indicators = new List<Indicator>
            {
                new SpeedIndicator(_engine)
            };
        }
        public Aircraft(string namePlane, string modelPlane, string bortNumber)
        {
            _namePlane = namePlane;
            _modelPlane = modelPlane;
            _bortNumber = bortNumber;
            _indicators = new List<Indicator>
            {
                new SpeedIndicator(_engine),
                new FuelIndicator(_engine)
            };
        }

        public void StartEngine()
        {
            _engine.Start();
        }
        public void StopEngine()
        {
            _engine.Stop();
        }
        public void Gas(int procentGas)
        {
            _engine.Gas(procentGas);
        }

        public double GetEngineRPM()
        {
            return _engine.GetRPM();
        }
        public string GetSpeedInString()
        {
            return _indicators[0].SendValue().ToString();
        }
        public double GetSpeedInDouble()
        {
            return _indicators[0].SendValue();
        }
        public double GetFuelInDouble()
        {
            return _indicators[1].SendValue();
        }
        public string GetFuelInString()
        {
            return _indicators[1].SendValue().ToString();
        }
    }
}
