using System.Windows;
using System.Windows.Controls;

namespace ToolWindowVSIXPR.Dialogs
{
    public partial class WelcomeDialog : UserControl
    {
        public WelcomeDialog()
        {
            InitializeComponent();
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
