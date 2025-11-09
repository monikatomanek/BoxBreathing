using System.Windows;

namespace BoxBreathing
{
    public partial class SetupWindow : Window
    {
        private MainWindow breathingWindow;
        private bool isStripVisible = false;

        public SetupWindow(MainWindow window)
        {
            InitializeComponent();
            breathingWindow = window;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isStripVisible)
            {
                breathingWindow.Show();
                isStripVisible = true;
            }

            breathingWindow.StartBreathing();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            breathingWindow.StopBreathing();
        }
    }
}
