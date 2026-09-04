using System;
using System.Collections.Generic;

namespace ToolWindowVSIXPR.Dialogs.Models
{
    public class ProjectConfigurationModel
    {
        public string CompanyName { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectType { get; set; } = string.Empty;
        public string ProjectVersion { get; set; } = "1.0.0";
        public string ApplicationArea { get; set; } = string.Empty;

        public string CoreSourcePath { get; set; } = string.Empty;
        public string DbContextPath { get; set; } = string.Empty;
        public string EntityFrameworkProject { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public static List<string> GetAvailableProjectTypes()
        {
            return new List<string>
            {
                "Console Application",
                "Class Library",
                "Web API",
                "Windows Forms",
                "WPF Application",
                "ASP.NET Core Web Application",
                "Blazor Server",
                "Blazor WebAssembly",
                "Service/Daemon",
                "Other"
            };
        }
    }
}
