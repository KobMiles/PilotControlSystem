namespace _20240829_PilotControlSystem
{
    class HeightIndicator : Indicator
    {
        ControlSystem _controlSystem;
        public HeightIndicator(ControlSystem controlSystem)
        {
            _controlSystem = controlSystem;
        }
        public override double SendValue()
        {
            return _controlSystem.GetHeight();
        }

        public override string ToString()
        {
            return _controlSystem.GetHeight().ToString();
        }
    }
}
