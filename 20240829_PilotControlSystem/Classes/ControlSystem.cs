using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    internal class ControlSystem
    {
        #region ---=== Fields ===---
        private const int MIN_SPEED_TO_UP = 300;
        private const int MAX_HEIGHT = 39370;
        private const int MAX_ANGLE_TO_UP = 35;
        private const int MAX_ANGLE_TO_DOWN = -35;

        private double _heightInFeet;
        private double _pitchAngle;

        private CancellationTokenSource _cancellationTokenSource = new();
        private Engine _engine;
        private Indicator _speedIndicator;

        public event EventHandler AngleTooHigh = delegate { };
        public event EventHandler AngleIsNormal = delegate { };

        #endregion

        #region ---=== Constructions ===---
        public ControlSystem(Engine engine, Indicator speedIndicator)
        {
            _heightInFeet = 0;
            _engine = engine;
            _speedIndicator = speedIndicator;
        }
        #endregion

        #region ---=== Methods ===---
        public void SetPitchAngle(int pitchAngle)
        {
            _pitchAngle += pitchAngle;
            CheckPitchAngle();
            _ = IncreaseAltitude();
        }
        public double GetPitchAngle()
        {
            return _pitchAngle;
        }
        public double GetHeight()
        {
            return _heightInFeet;
        }
        private void CheckPitchAngle()
        {
            if (_pitchAngle > MAX_ANGLE_TO_UP || _pitchAngle < MAX_ANGLE_TO_DOWN)
            {
                OnAngleTooHigh();
            }
            else if (_pitchAngle <= MAX_ANGLE_TO_UP)
            {
                OnAngleIsNormal();
            }
        }
        protected virtual void OnAngleTooHigh()
        {
            AngleTooHigh?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnAngleIsNormal()
        {
            AngleIsNormal?.Invoke(this, EventArgs.Empty);
        }
        public async Task IncreaseAltitude()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;
            while (true)
            {
                if (token.IsCancellationRequested)
                    break;
                if (_speedIndicator.SendValue() > MIN_SPEED_TO_UP)
                {

                    _heightInFeet += 30 * (_pitchAngle / 5);
                    if (_heightInFeet > MAX_HEIGHT)
                    {

                        _heightInFeet = MAX_HEIGHT;
                        _pitchAngle = 0;
                    }
                }
                await Task.Delay(200);
            }

        }
        #endregion
    }
}