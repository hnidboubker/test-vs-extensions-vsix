using System.Windows;
using ToolWindowVSIXPR.Dialogs;

namespace ToolWindowVSIXPR
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyToolWindowCommand : BaseCommand<MyToolWindowCommand>
    {
        protected override Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var welcomeDialog = new WelcomeDialogWindow();
            welcomeDialog.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
