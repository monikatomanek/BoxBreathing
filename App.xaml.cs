using System.Windows;

namespace BoxBreathing
{
    public partial class App : Application
    {
        private MainWindow mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindow = new MainWindow();
            mainWindow.Hide(); // keep strip window invisible initially

            var setupWindow = new SetupWindow(mainWindow);
            setupWindow.Show();
        }
    }
}
