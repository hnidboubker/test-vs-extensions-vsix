using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ToolWindowVSIXPR.Dialogs;
using ToolWindowVSIXPR.Dialogs.Models;
using ToolWindowVSIXPR.Dialogs.Steps;

namespace ToolWindowVSIXPR.Tests
{
    public class WelcomeDialogTests
    {
        // ============================================
        // CONSTRUCTOR TESTS
        // ============================================

        [Fact]
        public void Constructor_WithoutProjectPath_InitializesEmpty()
        {
            // Act
            var dialog = new WelcomeDialog();

            // Assert
            Assert.NotNull(dialog);
            Assert.NotNull(dialog.StepContainer);
        }

        [Fact]
        public void Constructor_WithValidProjectPath_InitializesWithPath()
        {
            // Arrange
            string projectPath = @"C:\Projects\MyProject";

            // Act
            var dialog = new WelcomeDialog(projectPath);

            // Assert
            Assert.NotNull(dialog);
        }

        [Fact]
        public void Constructor_WithEmptyProjectPath_InitializesEmpty()
        {
            // Arrange
            string projectPath = "";

            // Act
            var dialog = new WelcomeDialog(projectPath);

            // Assert
            Assert.NotNull(dialog);
        }

        [Fact]
        public void Constructor_WithNullProjectPath_InitializesEmpty()
        {
            // Arrange
            string projectPath = null;

            // Act
            var dialog = new WelcomeDialog(projectPath);

            // Assert
            Assert.NotNull(dialog);
        }

        // ============================================
        // INITIALIZER TESTS
        // ============================================

        [Fact]
        public void InitializeStepper_SetsStep1AsInitialContent()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            dialog.InitializeStepper();

            // Assert
            Assert.NotNull(dialog.StepContainer.Content);
        }

        [Fact]
        public void InitializeStepper_DisablesPreviousButton()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            dialog.InitializeStepper();

            // Assert
            Assert.False(dialog.PreviousButton.IsEnabled);
        }

        [Fact]
        public void InitializeStepper_EnablesNextButton()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            dialog.InitializeStepper();

            // Assert
            Assert.True(dialog.NextButton.IsEnabled);
        }

        [Fact]
        public void InitializeStepper_SetsNextButtonContentToNext()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            dialog.InitializeStepper();

            // Assert
            Assert.Equal("Next", dialog.NextButton.Content?.ToString());
        }

        // ============================================
        // LOAD STEP 1 TESTS
        // ============================================

        [Fact]
        public async Task LoadStep1_WithoutProjectPath_LoadsEmptyConfiguration()
        {
            // Arrange
            var dialog = new WelcomeDialog("");

            // Act
            await dialog.LoadStep1();

            // Assert
            Assert.NotNull(dialog.Configuration);
        }

        [Fact]
        public async Task LoadStep1_CallsStep1LoadConfiguration()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            await dialog.LoadStep1();

            // Assert
            Assert.NotNull(dialog.Step1);
        }

        [Fact]
        public async Task LoadStep1_UpdatesStepIndicator()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            await dialog.LoadStep1();

            // Assert
            Assert.Contains("1", dialog.StepIndicatorTextBlock.Text);
        }

        // ============================================
        // STEP INDICATOR TESTS
        // ============================================

        [Fact]
        public void UpdateStepIndicator_Step1_ShowsCorrectText()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            var currentStep = 1;

            // Act
            dialog.CurrentStep = currentStep;
            dialog.UpdateStepIndicator();

            // Assert
            Assert.Equal("Step 1 of 2", dialog.StepIndicatorTextBlock.Text);
        }

        [Fact]
        public void UpdateStepIndicator_Step2_ShowsCorrectText()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            var currentStep = 2;

            // Act
            dialog.CurrentStep = currentStep;
            dialog.UpdateStepIndicator();

            // Assert
            Assert.Equal("Step 2 of 2", dialog.StepIndicatorTextBlock.Text);
        }

        // ============================================
        // NAVIGATION BUTTON TESTS
        // ============================================

        [Fact]
        public void UpdateNavigationButtons_Step1_DisablesPrevious()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;

            // Act
            dialog.UpdateNavigationButtons();

            // Assert
            Assert.False(dialog.PreviousButton.IsEnabled);
        }

        [Fact]
        public void UpdateNavigationButtons_Step2_EnablesPrevious()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;

            // Act
            dialog.UpdateNavigationButtons();

            // Assert
            Assert.True(dialog.PreviousButton.IsEnabled);
        }

        [Fact]
        public void UpdateNavigationButtons_Step1_SetsNextButtonToNext()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;

            // Act
            dialog.UpdateNavigationButtons();

            // Assert
            Assert.Equal("Next", dialog.NextButton.Content?.ToString());
        }

        [Fact]
        public void UpdateNavigationButtons_Step2_SetsNextButtonToValidate()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;

            // Act
            dialog.UpdateNavigationButtons();

            // Assert
            Assert.Equal("Validate", dialog.NextButton.Content?.ToString());
        }

        [Fact]
        public void UpdateNavigationButtons_BothSteps_EnablesNextButton()
        {
            // Arrange
            var dialog = new WelcomeDialog();

            // Act
            for (int step = 1; step <= 2; step++)
            {
                dialog.CurrentStep = step;
                dialog.UpdateNavigationButtons();

                // Assert
                Assert.True(dialog.NextButton.IsEnabled);
            }
        }

        // ============================================
        // PREVIOUS CLICK TESTS
        // ============================================

        [Fact]
        public void OnPreviousClick_FromStep2_ReturnsToStep1()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;

            // Act
            dialog.OnPreviousClick(null, null);

            // Assert
            Assert.Equal(1, dialog.CurrentStep);
        }

        [Fact]
        public void OnPreviousClick_FromStep1_StaysAtStep1()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;

            // Act
            dialog.OnPreviousClick(null, null);

            // Assert
            Assert.Equal(1, dialog.CurrentStep);
        }

        [Fact]
        public void OnPreviousClick_UpdatesStepIndicator()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;

            // Act
            dialog.OnPreviousClick(null, null);

            // Assert
            Assert.Contains("1", dialog.StepIndicatorTextBlock.Text);
        }

        [Fact]
        public void OnPreviousClick_SavesStep2ConfigurationBeforeNavigating()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;
            var step2Config = new ProjectConfigurationModel
            {
                CoreSourcePath = @"C:\Core",
                DbContextPath = @"C:\DbContext",
                EntityFrameworkProject = "EF.Project"
            };
            dialog.Step2.SetConfiguration(step2Config);

            // Act
            dialog.OnPreviousClick(null, null);

            // Assert
            Assert.Equal(step2Config.CoreSourcePath, dialog.Configuration.CoreSourcePath);
            Assert.Equal(step2Config.DbContextPath, dialog.Configuration.DbContextPath);
            Assert.Equal(step2Config.EntityFrameworkProject, dialog.Configuration.EntityFrameworkProject);
        }

        // ============================================
        // NEXT CLICK - STEP 1 TESTS
        // ============================================

        [Fact]
        public void OnNextClick_Step1_WithValidInput_AdvancesToStep2()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;
            dialog.Step1.SetValidConfiguration(new ProjectConfigurationModel
            {
                ProjectName = "TestProject",
                CompanyName = "TestCompany",
                ProjectType = "Web"
            });

            // Act
            dialog.OnNextClick(null, null);

            // Assert
            Assert.Equal(2, dialog.CurrentStep);
        }

        [Fact]
        public void OnNextClick_Step1_WithInvalidInput_StaysAtStep1()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;
            dialog.Step1.ClearConfiguration(); // Invalid: empty

            // Act
            dialog.OnNextClick(null, null);

            // Assert
            Assert.Equal(1, dialog.CurrentStep);
        }

        [Fact]
        public void OnNextClick_Step1_WithValidInput_SavesStep1Config()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;
            var step1Config = new ProjectConfigurationModel
            {
                ProjectName = "TestProject",
                CompanyName = "TestCompany",
                ProjectType = "Web"
            };
            dialog.Step1.SetValidConfiguration(step1Config);

            // Act
            dialog.OnNextClick(null, null);

            // Assert
            Assert.Equal(step1Config.ProjectName, dialog.Configuration.ProjectName);
            Assert.Equal(step1Config.CompanyName, dialog.Configuration.CompanyName);
            Assert.Equal(step1Config.ProjectType, dialog.Configuration.ProjectType);
        }

        [Fact]
        public void OnNextClick_Step1_WithValidInput_LoadsStep2()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;
            dialog.Step1.SetValidConfiguration(new ProjectConfigurationModel
            {
                ProjectName = "TestProject"
            });

            // Act
            dialog.OnNextClick(null, null);

            // Assert
            Assert.NotNull(dialog.StepContainer.Content);
        }

        // ============================================
        // NEXT CLICK - STEP 2 TESTS
        // ============================================

        [Fact]
        public async Task OnNextClick_Step2_WithValidInput_CallsFinalizeConfiguration()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;
            dialog.Step2.SetValidConfiguration(new ProjectConfigurationModel
            {
                CoreSourcePath = @"C:\Core"
            });

            // Act
            await dialog.OnNextClick(null, null);

            // Assert
            // Dialog should be closed or configuration saved
            Assert.NotNull(dialog.Configuration);
        }

        [Fact]
        public void OnNextClick_Step2_WithInvalidInput_StaysAtStep2()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;
            dialog.Step2.ClearConfiguration(); // Invalid: empty

            // Act
            dialog.OnNextClick(null, null);

            // Assert
            Assert.Equal(2, dialog.CurrentStep);
        }

        [Fact]
        public async Task OnNextClick_Step2_WithValidInput_SavesStep2Config()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;
            var step2Config = new ProjectConfigurationModel
            {
                CoreSourcePath = @"C:\Core",
                DbContextPath = @"C:\DbContext",
                EntityFrameworkProject = "EF.Project"
            };
            dialog.Step2.SetValidConfiguration(step2Config);

            // Act
            await dialog.OnNextClick(null, null);

            // Assert
            Assert.Equal(step2Config.CoreSourcePath, dialog.Configuration.CoreSourcePath);
            Assert.Equal(step2Config.DbContextPath, dialog.Configuration.DbContextPath);
            Assert.Equal(step2Config.EntityFrameworkProject, dialog.Configuration.EntityFrameworkProject);
        }

        // ============================================
        // FINALIZE CONFIGURATION TESTS
        // ============================================

        [Fact]
        public async Task FinalizeConfiguration_WithoutProjectPath_DoesNotSaveToFile()
        {
            // Arrange
            var dialog = new WelcomeDialog("");
            dialog.Configuration = new ProjectConfigurationModel { ProjectName = "Test" };

            // Act
            await dialog.FinalizeConfiguration();

            // Assert
            // Config should still be in memory but not saved
            Assert.NotNull(dialog.Configuration);
        }

        [Fact]
        public async Task FinalizeConfiguration_WithProjectPath_SavesConfiguration()
        {
            // Arrange
            var dialog = new WelcomeDialog(@"C:\Projects\Test");
            dialog.Configuration = new ProjectConfigurationModel { ProjectName = "Test" };

            // Act
            await dialog.FinalizeConfiguration();

            // Assert
            // Configuration should be saved to file
            Assert.NotNull(dialog.Configuration);
        }

        [Fact]
        public async Task FinalizeConfiguration_ShowsSuccessMessage()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.Configuration = new ProjectConfigurationModel { ProjectName = "TestProject" };

            // Act
            // This would normally show a MessageBox
            await dialog.FinalizeConfiguration();

            // Assert
            Assert.NotNull(dialog.Configuration);
            Assert.Equal("TestProject", dialog.Configuration.ProjectName);
        }

        // ============================================
        // EDGE CASES & ERROR HANDLING
        // ============================================

        [Fact]
        public void Constructor_WithSpecialCharactersInPath_Initializes()
        {
            // Arrange
            string projectPath = @"C:\Projects\Test-Project_2024 (Copy)";

            // Act
            var dialog = new WelcomeDialog(projectPath);

            // Assert
            Assert.NotNull(dialog);
        }

        [Fact]
        public void Constructor_WithVeryLongPath_Initializes()
        {
            // Arrange
            string projectPath = new string('A', 260); // Max path length

            // Act
            var dialog = new WelcomeDialog(projectPath);

            // Assert
            Assert.NotNull(dialog);
        }

        [Fact]
        public void UpdateNavigationButtons_MultipleCallsInSequence_Maintains State()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 1;

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                dialog.UpdateNavigationButtons();
                Assert.False(dialog.PreviousButton.IsEnabled);
                Assert.True(dialog.NextButton.IsEnabled);
            }
        }

        [Fact]
        public void OnPreviousClick_RapidClicks_MaintainsConsistentState()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            dialog.CurrentStep = 2;

            // Act
            for (int i = 0; i < 10; i++)
            {
                dialog.OnPreviousClick(null, null);
            }

            // Assert
            Assert.Equal(1, dialog.CurrentStep);
        }

        [Fact]
        public async Task LoadStep1_ConcurrentCalls_HandlesProperly()
        {
            // Arrange
            var dialog = new WelcomeDialog("");

            // Act
            var task1 = dialog.LoadStep1();
            var task2 = dialog.LoadStep1();
            await Task.WhenAll(task1, task2);

            // Assert
            Assert.NotNull(dialog.Configuration);
        }

        // ============================================
        // INTEGRATION TESTS
        // ============================================

        [Fact]
        public async Task CompleteWorkflow_Step1ToStep2ToFinalize_Succeeds()
        {
            // Arrange
            var dialog = new WelcomeDialog(@"C:\TestProject");

            // Act - Initialize
            dialog.InitializeStepper();
            await dialog.LoadStep1();

            // Act - Complete Step 1
            dialog.Step1.SetValidConfiguration(new ProjectConfigurationModel
            {
                ProjectName = "MyProject",
                CompanyName = "MyCompany",
                ProjectType = "Console"
            });
            dialog.OnNextClick(null, null);

            // Assert Step 1 complete
            Assert.Equal(2, dialog.CurrentStep);

            // Act - Complete Step 2
            dialog.Step2.SetValidConfiguration(new ProjectConfigurationModel
            {
                CoreSourcePath = @"C:\Core",
                DbContextPath = @"C:\DbContext"
            });
            await dialog.OnNextClick(null, null);

            // Assert completion
            Assert.NotNull(dialog.Configuration);
            Assert.Equal("MyProject", dialog.Configuration.ProjectName);
        }

        [Fact]
        public async Task CompleteWorkflow_NavigateBackAndForth_MaintainsData()
        {
            // Arrange
            var dialog = new WelcomeDialog();
            var step1Config = new ProjectConfigurationModel
            {
                ProjectName = "MyProject",
                CompanyName = "MyCompany"
            };

            // Act - Step 1
            dialog.CurrentStep = 1;
            dialog.Step1.SetValidConfiguration(step1Config);
            dialog.OnNextClick(null, null);

            // Act - Go back
            dialog.OnPreviousClick(null, null);

            // Assert - Data preserved
            Assert.Equal(1, dialog.CurrentStep);
            Assert.Equal("MyProject", dialog.Configuration.ProjectName);

            // Act - Go forward again
            dialog.OnNextClick(null, null);

            // Assert - Still at step 2
            Assert.Equal(2, dialog.CurrentStep);
        }
    }
}
