using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _20240829_PilotControlSystem
{
    public partial class InstrumentPanel : Window
    {
        private DispatcherTimer _timer;
        internal Aircraft Plane = new Aircraft("a", "a", "a");

        private int valueChangedCount = 0;
        public InstrumentPanel()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(400);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            EngineRPM.Text = Plane.GetEngineRPM().ToString();
            Speed.Text = Plane.GetSpeedInString();
            Fuel.Text = Plane.GetFuelInString();
            Plane.Gas((int)SliderGas.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Plane.StartEngine();
            SliderGas.Value = 50;
            ButtonStartEngine.IsEnabled = false;
        }

        private void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Plane.Gas((int)SliderGas.Value);
        }

        private void SliderGas_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Plane.Gas((int)SliderGas.Value);
        }
    }

}
