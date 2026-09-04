using System.Windows;
using System.Windows.Controls;
using WpfMessageBox = System.Windows.MessageBox;
using ToolWindowVSIXPR.Dialogs.Models;
using ToolWindowVSIXPR.Dialogs.Steps;

namespace ToolWindowVSIXPR.Dialogs
{
    public partial class WelcomeDialog : UserControl
    {
        private int currentStep = 1;
        private Step1_ProjectInfo step1;
        private Step2_ProjectLocation step2;
        private ProjectConfigurationModel configuration;
        private string projectPath;

        public WelcomeDialog(string projectPath = "")
        {
            InitializeComponent();
            this.projectPath = projectPath;
            this.step1 = new Step1_ProjectInfo();
            this.step2 = new Step2_ProjectLocation();
            this.configuration = new ProjectConfigurationModel();

            InitializeStepper();
            _ = LoadStep1();
        }

        private void InitializeStepper()
        {
            StepContainer.Content = step1;
            UpdateNavigationButtons();
        }

        private async Task LoadStep1()
        {
            if (!string.IsNullOrEmpty(projectPath))
            {
                configuration = await ConfigurationManager.LoadConfigurationAsync(projectPath);
            }

            step1.LoadConfiguration(configuration);
            UpdateStepIndicator();
        }

        private void UpdateNavigationButtons()
        {
            PreviousButton.IsEnabled = currentStep > 1;
            NextButton.Content = currentStep == 2 ? "Validate" : "Next";
            NextButton.IsEnabled = true;
        }

        private void UpdateStepIndicator()
        {
            StepIndicatorTextBlock.Text = $"Step {currentStep} of 2";
        }

        private async void OnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (currentStep > 1)
            {
                if (currentStep == 2)
                {
                    var step2Config = step2.GetConfiguration();
                    configuration.CoreSourcePath = step2Config.CoreSourcePath;
                    configuration.DbContextPath = step2Config.DbContextPath;
                    configuration.EntityFrameworkProject = step2Config.EntityFrameworkProject;
                }

                currentStep--;
                StepContainer.Content = step1;
                step1.LoadConfiguration(configuration);
                UpdateNavigationButtons();
                UpdateStepIndicator();
            }
        }

        private async void OnNextClick(object sender, RoutedEventArgs e)
        {
            if (currentStep == 1)
            {
                if (!step1.ValidateInput())
                {
                    WpfMessageBox.Show("Please fill in the Project Name field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var step1Config = step1.GetConfiguration();
                configuration.CompanyName = step1Config.CompanyName;
                configuration.ProjectName = step1Config.ProjectName;
                configuration.ProjectType = step1Config.ProjectType;

                currentStep++;
                StepContainer.Content = step2;
                step2.LoadConfiguration(configuration);
                UpdateNavigationButtons();
                UpdateStepIndicator();
            }
            else if (currentStep == 2)
            {
                if (!step2.ValidateInput())
                {
                    WpfMessageBox.Show("Please fill in the Core Source Path field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var step2Config = step2.GetConfiguration();
                configuration.CoreSourcePath = step2Config.CoreSourcePath;
                configuration.DbContextPath = step2Config.DbContextPath;
                configuration.EntityFrameworkProject = step2Config.EntityFrameworkProject;

                await FinalizeConfiguration();
            }
        }

        private async Task FinalizeConfiguration()
        {
            if (!string.IsNullOrEmpty(projectPath))
            {
                await ConfigurationManager.SaveConfigurationAsync(projectPath, configuration);
            }

            WpfMessageBox.Show($"Configuration saved successfully!\n\nProject: {configuration.ProjectName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
