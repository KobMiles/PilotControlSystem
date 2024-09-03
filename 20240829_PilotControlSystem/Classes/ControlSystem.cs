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
        private const int MAX_ANGLE_TO_UP = 30;
        private int _heightInFeet;

        private int _pitchAngle;

        private Engine _engine;
        private Indicator _speedIndicator;
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
            _pitchAngle = pitchAngle;
            IncreaseAltitude();
        }
        public int GetPitchAngle()
        {
            return _heightInFeet;
        }
        public int GetHeight()
        {
            return _heightInFeet;
        }
        public async void IncreaseAltitude()
        {
            if (_speedIndicator.SendValue() > MIN_SPEED_TO_UP)
            {

                while (true)
                {
                    _heightInFeet += 60 * (_pitchAngle / 10);
                    if (_heightInFeet > MAX_HEIGHT)
                    {

                        _heightInFeet = MAX_HEIGHT;
                        _pitchAngle = 0;
                    }
                    await Task.Delay(200);
                }
            }
        }
        #endregion
    }
}