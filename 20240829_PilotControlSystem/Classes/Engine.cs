using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20240829_PilotControlSystem
{
    public class Engine
    {
        private const int NORMAL_MINIMUM_RPM_AFTER_START = 3000;
        private const int NORMAL_MAXIMUM_RPM_AFTER_START = 3100;
        private const double NORMAL_MAXIMUM_RPM = 6000;
        public double RPM { get; private set; }

        private bool _isRunning;

        private Random _randomRPM = new Random();

        public Engine()
        {
            _isRunning = false;
            RPM = 0;
        }

        public void Start()
        {
            _isRunning = true;
            UpdateRPM(_randomRPM.Next(NORMAL_MINIMUM_RPM_AFTER_START,
                NORMAL_MAXIMUM_RPM_AFTER_START));
        }
        public void Stop()
        {
            _isRunning = false;
            UpdateRPM(0);
        }
        public void Gas(double procentGas)
        {
            double multipleGas = procentGas * 2 / 100;
            UpdateRPM(RPM * multipleGas);
        }
        private async void UpdateRPM(double newRPM)
        {
            while(RPM <= newRPM)
            {
                await Task.Delay(400);
                RPM += _randomRPM.Next(36, 39);
            }
        }
    }
}