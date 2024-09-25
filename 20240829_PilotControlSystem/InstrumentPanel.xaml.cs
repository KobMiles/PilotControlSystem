using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using _20240829_PilotControlSystem.Classes;

namespace _20240829_PilotControlSystem
{
    public partial class InstrumentPanel : Window
    {
        #region ---=== Fields ===---

        private readonly DispatcherTimer _timer;
        internal Aircraft Plane = new ("SkyUP", "Boeing 737-800", "UR-SQC");

        #endregion

        #region ---=== Constructions ===---

        public InstrumentPanel()
        {
            InitializeComponent();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        #endregion

        #region ---=== Methods ===---

        #region ||| UI Methods ||| 
        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateUi();
        }

        private void UpdateUi()
        {
            EngineRPM_TextBox.Text = Plane.GetEngineRpm().ToString(CultureInfo.InvariantCulture);
            Speed_TextBox.Text = Plane.GetSpeed().ToString(CultureInfo.InvariantCulture);
            TotalFuel_TextBox.Text = Plane.GetFuel().ToString(CultureInfo.InvariantCulture);
            HeightInFeet.Text = Plane.GetHeight().ToString(CultureInfo.InvariantCulture);
            PitchAngle_TextBox.Text = Plane.GetPitchAngle().ToString(CultureInfo.InvariantCulture);

            EngineOn_CheckBox.IsChecked = Plane.GetEngineStatus();

            TheAngleTooHigh_TextBlock.Visibility = Plane.GetAngleTooHighWarning() ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region ||| Elements Methods |||

        private void SliderGas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Plane.Gas((int)SliderGas.Value);
        }

        private void StartEngine_Button_Click(object sender, RoutedEventArgs e)
        {
            Plane.StartEngine();
            SliderGas.Value = 50;
            StartEngine_Button.IsEnabled = false;
            StopEngine_Button.IsEnabled = true;
        }

        private void StopEngine_Button_Click(object sender, RoutedEventArgs e)
        {
            Plane.StopEngine();
            SliderGas.Value = 0;
            StartEngine_Button.IsEnabled = true;
            StopEngine_Button.IsEnabled = false;
        }

        private void UpPitch_Button_Click(object sender, RoutedEventArgs e)
        {
            Plane.SetPitchAngle(5);
        }

        private void DownPitch_Button_Click(object sender, RoutedEventArgs e)
        {
            Plane.SetPitchAngle(-5);
        }

        #endregion

        #endregion
    }

}
