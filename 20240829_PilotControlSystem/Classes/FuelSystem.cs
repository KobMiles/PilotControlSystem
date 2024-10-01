namespace _20240829_PilotControlSystem.Classes
{
    internal class FuelSystem
    {
        #region ---=== Fields ===---
        private const int DelayTimeMilliseconds = 400;
        private const double FuelConsumptionRate = 0.00001;

        public double Fuel { get; private set; }
        private readonly Engine _engine;

        #endregion


        #region ---=== Constructions ===---

        public FuelSystem(Engine engine)
        {
            _engine = engine;
            Fuel = 500.0;
            _ = FuelConsumptionAsync();
        }

        #endregion

        #region ---=== Methods ===---

        public async Task FuelConsumptionAsync()
        {
            while (Fuel > 0)
            {
                await Task.Delay(DelayTimeMilliseconds);
                Fuel -= _engine.EngineRpm * FuelConsumptionRate;
            }
        }

        #endregion
    }
}