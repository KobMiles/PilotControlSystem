namespace _20240829_PilotControlSystem.Classes
{
    internal class Engine
    {
        #region ---=== Fields ===---

        private const int MaxRpm = 6101;
        private const int DelayTimeMilliseconds = 400;
        private const int MotorStepIncrement = 90;
        private const double GasMultiplier = 0.01;

        private int _percentGas;
        private int _rpm;

        private bool _isRunning;

        private CancellationTokenSource _cancellationTokenSource = new();

        private readonly FuelSystem _fuelSystem;

        #endregion

        #region ---=== Constructions ===---

        public Engine()
        {
            _isRunning = false;
            _rpm = 0;
            _fuelSystem = new FuelSystem(this);
        }

        #endregion

        #region ---=== Methods ===---

        public int GetRpm()
        {
            return _rpm;
        }

        public void Start()
        {
            _isRunning = true;
            Gas(50);
        }

        public void Stop()
        {
            _isRunning = false;
            Gas(0);
        }

        public void Gas(int percentGasBase)
        {
            _percentGas = percentGasBase;
            _ = UpdateRpmAsync(MaxRpm * (_percentGas * GasMultiplier));
        }

        public double GetFuel()
        {
            return _fuelSystem.Fuel;
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        private async Task UpdateRpmAsync(double newRpm)
        {
            _ = _cancellationTokenSource.CancelAsync();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            if (newRpm == 0)
            {
                _ = FullEngineStop(newRpm, token);
            }

            if (newRpm > _rpm && _isRunning)
            {
                _ = IncreaseEngineSpeed(newRpm, token);
            }
            else
            {
                _ = DecreaseEngineSpeed(newRpm, token);
            }
        }

        private async Task DecreaseEngineSpeed(double newRpm, CancellationToken token)
        {
            while (_rpm > newRpm)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(DelayTimeMilliseconds, token);
                _rpm -= MotorStepIncrement;
            }

            if (_rpm < 0)
            {
                _rpm = 0;
                _isRunning = false;
            }
        }

        private async Task IncreaseEngineSpeed(double newRpm, CancellationToken token)
        {
            while (_rpm <= newRpm)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(DelayTimeMilliseconds, token);
                _rpm += MotorStepIncrement;
            }
        }

        private async Task FullEngineStop(double newRpm, CancellationToken token)
        {
            while (_rpm > 0)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(DelayTimeMilliseconds, token);
                _rpm -= MotorStepIncrement;

                if (_rpm < 0)
                {
                    _rpm = 0;
                }
            }
            _isRunning = false;
            return;
        }

        #endregion
    }
}
