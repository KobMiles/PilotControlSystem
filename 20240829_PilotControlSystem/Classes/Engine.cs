using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    internal class Engine
    {
        #region ---=== Fields ===---

        private const int NORMAL_MINIMUM_RPM_AFTER_START = 3000;
        private const int NORMAL_MAXIMUM_RPM_AFTER_START = 3101;
        private const int MAX_RPM = 6101;

        private int _procentGas;
        private int _rpm;

        private bool _isRunning;

        private CancellationTokenSource _cancellationTokenSource = new();
        private FuelSystem _fuelSystem;
        private Random _randomRPM = new Random();

        #endregion

        #region ---=== Constructions ===---

        public Engine()
        {
            _isRunning = false;
            _rpm = 0;
            _fuelSystem = new(this);
        }

        #endregion

        #region ---=== Methods ===---
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
        public bool IsRunning()
        {
            return _isRunning;
        }

        private async void UpdateRPMAsync(double newRPM)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            if (newRPM == 0)
            {
                while (_rpm > 0)
                {
                    if (token.IsCancellationRequested)
                        break;

                    await Task.Delay(400);
                    _rpm -= 90;

                    if (_rpm < 0)
                    {
                        _rpm = 0;
                    }
                }
                _isRunning = false;
                return;
            }

            if (newRPM > _rpm && _isRunning)
            {
                while (_rpm <= newRPM)
                {
                    if (token.IsCancellationRequested)
                        break;

                    await Task.Delay(200);
                    _rpm += 60;
                }
            }
            else
            {
                while (_rpm > newRPM)
                {
                    if (token.IsCancellationRequested)
                        break;

                    await Task.Delay(400);
                    _rpm -= 90;
                }
                if (_rpm < 0)
                {
                    _rpm = 0;
                    _isRunning = false;
                }
            }
        }
        #endregion
    }
}