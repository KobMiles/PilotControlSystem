namespace _20240829_PilotControlSystem.Classes
{
    internal class HeightIndicator(ControlSystem controlSystem) : Indicator
    {
        public override double GetValue()
        {
            return controlSystem.GetHeight();
        }
    }
}
