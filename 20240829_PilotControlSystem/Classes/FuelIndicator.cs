namespace _20240829_PilotControlSystem
{
    internal class FuelIndicator : Indicator
    {
        #region ---=== Fields ===---

        Engine _engine;

        #endregion

        #region ---=== Constructions ===---

        public FuelIndicator(Engine engine)
        {
            _engine = engine;
        }

        #endregion

        #region ---=== Methods ===---
        public override double SendValue()
        {
            return Math.Round(_engine.GetFuel(), 2, MidpointRounding.ToZero);
        }

        public override string ToString()
        {
            return $"Fuel in the tank: {SendValue()}";
        }
        #endregion
    }
}
