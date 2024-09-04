using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240829_PilotControlSystem
{
    internal class Aircraft
    {
        #region ---=== Fields ===---
        private readonly string _namePlane;
        private readonly string _modelPlane;
        private readonly string _bortNumber;

        private readonly Engine _engine = new();
        private ControlSystem _controlSystem;

        private List<Indicator> _indicators = [];
        #endregion

        #region ---=== Constructions ===---
        public Aircraft()
        {
            _namePlane = "null";
            _modelPlane = "null";
            _bortNumber = "null";
            _indicators = new List<Indicator>
            {
                new SpeedIndicator(_engine),
                new FuelIndicator(_engine)
            };
            _controlSystem = new ControlSystem(_engine, _indicators[0]);
            _indicators.Add(new HeightIndicator(_controlSystem));
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
            _controlSystem = new ControlSystem(_engine, _indicators[0]);
            _indicators.Add(new HeightIndicator(_controlSystem));
        }
        #endregion

        #region ---=== Methods ===---

        #region ||| Engine Methods |||
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

        public bool IsEngineRunning()
        {
            return _engine.IsRunning();
        }
        public double GetEngineRPM()
        {
            return _engine.GetRPM();
        }
        #endregion

        #region ||| Indicators Methods |||
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

        public double GetHeightInDouble()
        {
            return _indicators[2].SendValue();
        }

        public string GetHeightInString()
        {
            return _indicators[2].SendValue().ToString();
        }

        #endregion

        #region ||| ControlSystem Methods |||

        public void SetPitchAngle(int pitchAngle)
        {
            _controlSystem.SetPitchAngle(pitchAngle);
        }
        public int GetPitchAngleInInt()
        {
            return _controlSystem.GetPitchAngle();
        }
        public string GetPitchAngleInString()
        {
            return _controlSystem.GetPitchAngle().ToString();
        }
        #endregion

        #endregion
    }
}
