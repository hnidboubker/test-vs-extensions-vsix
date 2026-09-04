using System.Windows;

namespace ToolWindowVSIXPR.Dialogs
{
    public class WelcomeDialogWindow : Window
    {
        public WelcomeDialogWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Power Tool Clever";
            this.Width = 400;
            this.Height = 250;
            this.ResizeMode = ResizeMode.NoResize;
            this.Content = new WelcomeDialog();
        }
    }
}
