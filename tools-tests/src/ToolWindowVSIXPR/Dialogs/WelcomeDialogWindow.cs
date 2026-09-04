using System.Windows;

namespace ToolWindowVSIXPR.Dialogs
{
    public class WelcomeDialogWindow : Window
    {
        public WelcomeDialogWindow(string projectPath = "")
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Power Tool Clever - Project Configuration";
            this.Width = 550;
            this.Height = 600;
            this.ResizeMode = ResizeMode.NoResize;
            this.Content = new WelcomeDialog(projectPath);
        }
    }
}
