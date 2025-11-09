using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BoxBreathing
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer breathTimer;
        private int currentPhase = 0;

        private readonly double[] opacities = { 1.0, 0.4, 1.0, 0.4 };
        private readonly string[] colors = { "#40E0D0", "#FFCC99", "#40E0D0", "#FFCC99" };

        public MainWindow()
        {
            InitializeComponent();

            Left = 0;
            Top = SystemParameters.PrimaryScreenHeight - Height;

            breathTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            breathTimer.Tick += AnimateBreath;
        }

        private void AnimateBreath(object sender, EventArgs e)
        {
            int i = currentPhase % 4;

            GlowStrip.Fill = (Brush)new BrushConverter().ConvertFromString(colors[i]);

            var fade = new DoubleAnimation
            {
                To = opacities[i],
                Duration = TimeSpan.FromSeconds(3),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            GlowStrip.BeginAnimation(OpacityProperty, fade);
            currentPhase++;
        }

        public void StartBreathing()
        {
            breathTimer.Start();
        }

        public void StopBreathing()
        {
            breathTimer.Stop();
        }
    }
}
