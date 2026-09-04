using System.Windows.Controls;
using System.Windows.Forms;
using WpfUserControl = System.Windows.Controls.UserControl;
using WinFormsFolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using ToolWindowVSIXPR.Dialogs.Models;

namespace ToolWindowVSIXPR.Dialogs.Steps
{
    public partial class Step2_ProjectLocation : WpfUserControl
    {
        public Step2_ProjectLocation()
        {
            InitializeComponent();
        }

        public void LoadConfiguration(ProjectConfigurationModel config)
        {
            CoreSourcePathTextBox.Text = config.CoreSourcePath;
            DbContextPathTextBox.Text = config.DbContextPath;
            EntityFrameworkProjectTextBox.Text = config.EntityFrameworkProject;
        }

        public ProjectConfigurationModel GetConfiguration()
        {
            return new ProjectConfigurationModel
            {
                CoreSourcePath = CoreSourcePathTextBox.Text,
                DbContextPath = DbContextPathTextBox.Text,
                EntityFrameworkProject = EntityFrameworkProjectTextBox.Text
            };
        }

        public bool ValidateInput()
        {
            return !string.IsNullOrWhiteSpace(CoreSourcePathTextBox.Text);
        }

        private void OnBrowseCoreSourcePath(object sender, System.Windows.RoutedEventArgs e)
        {
            string selectedPath = BrowseFolder("Select Core Source Path");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                CoreSourcePathTextBox.Text = selectedPath;
            }
        }

        private void OnBrowseDbContextPath(object sender, System.Windows.RoutedEventArgs e)
        {
            string selectedPath = BrowseFolder("Select DB Context Path");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                DbContextPathTextBox.Text = selectedPath;
            }
        }

        private string BrowseFolder(string title)
        {
            using (WinFormsFolderBrowserDialog dialog = new WinFormsFolderBrowserDialog())
            {
                dialog.Description = title;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
                return null;
            }
        }
    }
}
