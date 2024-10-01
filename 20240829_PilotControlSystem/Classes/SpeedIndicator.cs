namespace _20240829_PilotControlSystem.Classes
{
    internal class SpeedIndicator(Engine engine) : Indicator
    {
        #region ---=== Fields ===---

        private const int MaxRpm = 6101;
        private const int MinRpm = 3701;
        private const int MaxSpeed = 900;

        #endregion

        #region ---=== Methods ===---

        public override double GetValue()
        {
            var speed = engine.EngineRpm <=MinRpm 
                ? 0 
                : Math.Round((double)(engine.EngineRpm - MinRpm) / (MaxRpm - MinRpm) * MaxSpeed);
            return speed;
        }

        #endregion
    }
}