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
        public Aircraft Plane = new Aircraft("a", "a", "a");
        public InstrumentPanel()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(400);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            Plane.Engine.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            EngineRPM.Text = Plane.Engine.RPM.ToString();
            EngineRPM.Text = Plane.Engine.RPM.ToString();
        }
    }

}
