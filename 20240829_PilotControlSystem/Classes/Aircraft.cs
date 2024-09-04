namespace _20240829_PilotControlSystem
{
    internal class Aircraft
    {
        #region ---=== Fields ===---
        private readonly string _namePlane;
        private readonly string _modelPlane;
        private readonly string _bortNumber;

        private bool _pitchAngleTooHighWarning = false;

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
            _controlSystem.AngleTooHigh += AngleTooHighWarning;
            _controlSystem.AngleIsNormal += AngleIsNormal;
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
            //return _controlSystem.GetHeight().ToString();
        }

        public bool GetEngineStatus()
        {
            return IsEngineRunning();
        }

        #endregion

        #region ||| ControlSystem Methods |||

        public void SetPitchAngle(int pitchAngle)
        {
            _controlSystem.SetPitchAngle(pitchAngle);
        }
        public double GetPitchAngleInDouble()
        {
            return _controlSystem.GetPitchAngle();
        }
        public string GetPitchAngleInString()
        {
            return _controlSystem.GetPitchAngle().ToString();
        }
        #endregion

        #region ||| Warning Methods |||

        private void AngleTooHighWarning(object? sender, EventArgs e)
        {
            _pitchAngleTooHighWarning = true;
        }
        private void AngleIsNormal(object? sender, EventArgs e)
        {
            _pitchAngleTooHighWarning = false;
        }
        public bool GetAngleTooHighWarning()
        {
            return _pitchAngleTooHighWarning;
        }

        #endregion

        #endregion
    }
}
