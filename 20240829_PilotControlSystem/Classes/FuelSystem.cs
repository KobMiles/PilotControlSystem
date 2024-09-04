namespace _20240829_PilotControlSystem
{
    internal class FuelSystem
    {
        #region ---=== Fields ===---

        private double _fuel;
        private Engine _engine;

        #endregion

        #region ---=== Constructions ===---

        public FuelSystem(Engine engine)
        {
            _engine = engine;
            _fuel = 500.0;
            _ = FuelComsumptionAsync();
        }

        public FuelSystem(double fuel, Engine engine)
        {
            _fuel = fuel;
            _engine = engine;
            _ = FuelComsumptionAsync();
        }

        #endregion

        #region ---=== Methods ===---
        public double GetFuel()
        {
            return _fuel;
        }
        public async Task FuelComsumptionAsync()
        {
            while (_fuel != 0)
            {
                await Task.Delay(400);
                _fuel -= _engine.GetRPM() * 0.00001;
            }
        }
        #endregion

    }
}