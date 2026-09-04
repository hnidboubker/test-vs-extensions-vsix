using System.Windows.Controls;
using ToolWindowVSIXPR.Dialogs.Models;

namespace ToolWindowVSIXPR.Dialogs.Steps
{
    public partial class Step1_ProjectInfo : UserControl
    {
        public Step1_ProjectInfo()
        {
            InitializeComponent();
            InitializeProjectTypes();
        }

        private void InitializeProjectTypes()
        {
            ProjectTypeComboBox.ItemsSource = ProjectConfigurationModel.GetAvailableProjectTypes();
            ProjectTypeComboBox.SelectedIndex = 0;
        }

        public void LoadConfiguration(ProjectConfigurationModel config)
        {
            CompanyNameTextBox.Text = config.CompanyName;
            ProjectNameTextBox.Text = config.ProjectName;
            ProjectTypeComboBox.SelectedItem = config.ProjectType;
        }

        public ProjectConfigurationModel GetConfiguration()
        {
            return new ProjectConfigurationModel
            {
                CompanyName = CompanyNameTextBox.Text,
                ProjectName = ProjectNameTextBox.Text,
                ProjectType = ProjectTypeComboBox.SelectedItem?.ToString() ?? string.Empty
            };
        }

        public bool ValidateInput()
        {
            return !string.IsNullOrWhiteSpace(ProjectNameTextBox.Text);
        }
    }
}
