namespace _20240829_PilotControlSystem
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

        public override double SendValue()
        {
            if (_engine.GetRPM() < MIN_RPM) return 0;
            return Math.Round(((_engine.GetRPM() - MIN_RPM) / (MAX_RPM - MIN_RPM)) * MAX_SPEED);
        }

        public override string ToString()
        {
            return $"The speed of the airplane: {SendValue()}";
        }

        #endregion
    }
}