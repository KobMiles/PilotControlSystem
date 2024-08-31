using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    internal class FuelSystem
    {
        private double _fuel;
        private Engine _engine;

        public FuelSystem(Engine engine)
        {
            _engine = engine;
            _fuel = 500.0;
            FuelComsumptionAsync();
        }

        public FuelSystem(double fuel, Engine engine)
        {
            _fuel = fuel;
            _engine = engine;
            FuelComsumptionAsync();
        }
        public double GetFuel()
        {
            return _fuel;
        }
        public async void FuelComsumptionAsync()
        {
            while (_fuel != 0)
            {
                await Task.Delay(400);
                _fuel -= _engine.GetRPM() * 0.00001;
            }
        }

    }
}