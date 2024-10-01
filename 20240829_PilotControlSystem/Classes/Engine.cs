namespace _20240829_PilotControlSystem.Classes
{
    internal class Engine
    {
        private const int MaxRpm = 6101;
        private const int DelayTimeMilliseconds = 400;
        private const int MotorStepIncrement = 90;
        private const double GasMultiplier = 0.01;

        public int EngineRpm { get; private set; }

        public bool IsRunning { get; private set; }

        private CancellationTokenSource _cancellationTokenSource = new();

        private readonly FuelSystem _fuelSystem;

        public Engine()
        {
            IsRunning = false;
            EngineRpm = 0;
            _fuelSystem = new FuelSystem(this);
        }

        public double Fuel => _fuelSystem.Fuel;

        public async Task StartAsync()
        {
            IsRunning = true;
            await AdjustThrottleAsync(50);
        }

        public async Task StopAsync()
        {
            IsRunning = false;
            await AdjustThrottleAsync(0);
        }

        public async Task AdjustThrottleAsync(int throttlePercentage)
        {
            await UpdateRpmAsync(MaxRpm * (throttlePercentage * GasMultiplier));
        }

        private async Task UpdateRpmAsync(double targetEngineRpm)
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                await _cancellationTokenSource.CancelAsync();
            }
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            var engineCancellationToken = _cancellationTokenSource.Token;

            await AdjustEngineSpeedAsync(
                targetEngineRpm,
                (targetEngineRpm > EngineRpm) && IsRunning,
                engineCancellationToken);

            if (EngineRpm <= 0)
            {
                EngineRpm = 0;
                IsRunning = false;
            }
        }

        private async Task AdjustEngineSpeedAsync(
            double targetEngineRpm,
            bool increase,
            CancellationToken engineCancellationToken)
        {
            while ((increase && EngineRpm < targetEngineRpm) || (!increase && EngineRpm > targetEngineRpm))
            {
                if (engineCancellationToken.IsCancellationRequested)
                {
                    return;
                }

                await Task.Delay(DelayTimeMilliseconds, engineCancellationToken);
                EngineRpm += increase ? MotorStepIncrement : -MotorStepIncrement;
            }
        }
    }
}