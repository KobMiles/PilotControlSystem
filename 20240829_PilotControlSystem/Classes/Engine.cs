using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    internal class Engine
    {
        private const int NORMAL_MINIMUM_RPM_AFTER_START = 3000;
        private const int NORMAL_MAXIMUM_RPM_AFTER_START = 3100;
        private const int MAX_RPM = 6101;

        private int _procentGas;
        private double _rpm;

        private bool _isRunning;

        private FuelSystem _fuelSystem;
        private Random _randomRPM = new Random();

        public Engine()
        {
            _isRunning = false;
            _rpm = 0;
            _fuelSystem = new(this);
        }

        public double GetRPM()
        {
            return _rpm;
        }

        public void Start()
        {
            _isRunning = true;
            _procentGas = 50;
            UpdateRPMAsync(_randomRPM.Next(NORMAL_MINIMUM_RPM_AFTER_START,
                NORMAL_MAXIMUM_RPM_AFTER_START));
        }
        public void Stop()
        {
            _isRunning = false;
            UpdateRPMAsync(0);
        }
        public void Gas(int procentGasBase)
        {
            _procentGas = procentGasBase;
            UpdateRPMAsync(MAX_RPM * (_procentGas * 0.01));
        }
        public double GetFuel()
        {
            return _fuelSystem.GetFuel();
        }
        private async void UpdateRPMAsync(double newRPM)
        {
            if (newRPM > _rpm)
            {
                while (_rpm <= newRPM)
                {
                    await Task.Delay(400);
                    _rpm += _randomRPM.Next(26, 29);
                }
            }
            else
            {
                while (_rpm > newRPM)
                {
                    await Task.Delay(400);
                    _rpm -= _randomRPM.Next(26, 29);
                    if (_rpm < 0)
                    {
                        _rpm = 0;
                        _isRunning = false;
                    }
                }
            }
        }
    }
}