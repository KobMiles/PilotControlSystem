namespace _20240829_PilotControlSystem.Classes
{
    internal class Aircraft
    {
        #region ---=== Fields ===---
        private readonly string _namePlane;
        private readonly string _modelPlane;
        private readonly string _boardNumber;

        private bool _pitchAngleTooHighWarning = false;

        private readonly Engine _engine = new();
        private readonly ControlSystem _controlSystem;

        private List<Indicator> _indicators = new List<Indicator>();
        #endregion

        #region ---=== Constructions ===---
        public Aircraft()
        {
            _namePlane = string.Empty;
            _modelPlane = string.Empty;
            _boardNumber = string.Empty;
            _indicators =
                [
                    new SpeedIndicator(_engine),
                    new FuelIndicator(_engine)
                ];
            _controlSystem = new ControlSystem(_engine, _indicators[0]);
            _indicators.Add(new HeightIndicator(_controlSystem));
        }
        public Aircraft(string namePlane, string modelPlane, string boardNumber)
        {
            _namePlane = namePlane;
            _modelPlane = modelPlane;
            _boardNumber = boardNumber;
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
            _ = _engine.StartAsync();
        }
        public void StopEngine()
        {
            _ = _engine.StopAsync();
        }
        public void AdjustThrottle(int percentGas)
        {
            _ = _engine.AdjustThrottleAsync(percentGas);
        }

        public bool IsEngineRunning()
        {
            return _engine.IsRunning;
        }
        public double GetEngineRpm()
        {
            return _engine.EngineRpm;
        }

        #endregion

        #region ||| Indicators Methods |||

        public double GetSpeed()
        {
            return _indicators[0].GetValue();
        }

        public double GetFuel()
        {
            return _indicators[1].GetValue();
        }

        public double GetHeight()
        {
            return _indicators[2].GetValue();
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
        public double GetPitchAngle()
        {
            return _controlSystem.GetPitchAngle();
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
