using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToolWindowVSIXPR.Dialogs.Models
{
    public class ConfigurationManager
    {
        private const string ConfigFileName = ".power-tools-config.json";

        public static async Task<ProjectConfigurationModel> LoadConfigurationAsync(string projectPath)
        {
            try
            {
                string configPath = Path.Combine(projectPath, ConfigFileName);

                if (File.Exists(configPath))
                {
                    string json = await File.ReadAllTextAsync(configPath);
                    var config = JsonConvert.DeserializeObject<ProjectConfigurationModel>(json);
                    return config ?? new ProjectConfigurationModel();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading configuration: {ex.Message}");
            }

            return new ProjectConfigurationModel();
        }

        public static async Task SaveConfigurationAsync(string projectPath, ProjectConfigurationModel config)
        {
            try
            {
                string configPath = Path.Combine(projectPath, ConfigFileName);
                config.LastUpdated = DateTime.Now;

                var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
                string json = JsonConvert.SerializeObject(config, settings);

                await File.WriteAllTextAsync(configPath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        public static bool HasExistingConfiguration(string projectPath)
        {
            string configPath = Path.Combine(projectPath, ConfigFileName);
            return File.Exists(configPath);
        }
    }
}
