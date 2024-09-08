namespace _20240829_PilotControlSystem.Classes
{
    internal class SpeedIndicator : Indicator
    {
        #region ---=== Fields ===---

        private Engine _engine;

        private const int MAX_RPM = 6101;
        private const int MIN_RPM = 3701;
        private const int MAX_SPEED = 900;

        #endregion

        #region ---=== Constructions ===---

        public SpeedIndicator(Engine engine)
        {
            _engine = engine;
        }

        #endregion

        #region ---=== Methods ===---

        public override double GetValue()
        {
            var speed = Math.Round((_engine.GetRpm() - MIN_RPM) / (MAX_RPM - MIN_RPM) * MAX_SPEED);
            return _engine.GetRpm() < MIN_RPM ? 0.0 : _engine.GetRpm();

        }

        #endregion
    }
}