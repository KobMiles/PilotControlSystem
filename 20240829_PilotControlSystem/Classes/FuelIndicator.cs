namespace _20240829_PilotControlSystem.Classes
{
    internal class FuelIndicator(Engine engine) : Indicator
    {
        #region ---=== Methods ===---

        public override double GetValue()
        {
            return Math.Round(engine.GetFuel(), 2, MidpointRounding.ToZero);
        }

        #endregion
    }
}
