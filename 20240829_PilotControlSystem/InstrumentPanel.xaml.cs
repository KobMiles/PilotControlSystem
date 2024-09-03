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
        #region ---=== Fields ===---

        private DispatcherTimer _timer;
        internal Aircraft Plane = new Aircraft("a", "a", "a");

        #endregion

        #region ---=== Constructions ===---

        public InstrumentPanel()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(400);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        #endregion

        #region ---=== Methods ===---

            #region ||| UI Methods |||
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            EngineRPM_TextBox.Text = Plane.GetEngineRPM().ToString();
            Speed_TextBox.Text = Plane.GetSpeedInString();
            TotalFuel_TextBox.Text = Plane.GetFuelInString();
            HeightInFeet.Text = Plane.GetHeightInString();
        }
        #endregion

        #region ||| Elements Methods |||

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Plane.StartEngine();
        //    SliderGas.Value = 50;
        //    ButtonStartEngine.IsEnabled = false;
        //}

        ////private void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        ////{
        ////    Plane.Gas((int)SliderGas.Value);
        ////}

        //private void SliderGas_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    Plane.Gas((int)SliderGas.Value);
        //}

        private void SliderGas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Plane.Gas((int)SliderGas.Value);
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Plane.SetPitchAngle(30);
        //}

        #endregion

        #endregion
    }

}
