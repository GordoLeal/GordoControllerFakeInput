using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GordoControllerFakeInput
{
    public class Config()
    {
        // In case i need to make changes to the config file in the future.
        // this can be used to check if the loaded config file is compatible with the current version of the program.
        // if is necessary, code to adapt old config files to the new format can be added in the future.
        public int SAVEFILE_VERSION { get; set; } = 1;
        public int AccelerationKey_index { get; set; } = 0;
        public int KeyboardToggleKey_index { get; set; } = 0;
        public bool PlayerSound_KeyToggle { get; set; } = true;
        public int ControllerToggleKey_index { get; set; } = 0;
        public bool PlayerSound_ControllerToggle { get; set; } = true;
    }
    public static class ConfigFileHandler
    {
        public const string CONFIG_FILENAME = "config.json";
        public const string CONFIG_FOLDER_PATH = "Config";
        public static void Save(Config config, string path, string filename)
        {
            CreateConfigFolderIfNotExists(path);
            string configAsJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true});
            string fullPAth = Path.Combine(path, filename);
            File.WriteAllText(fullPAth, configAsJson);
        }
        public static void CreateConfigFolderIfNotExists(string path)
        {
            if (path == null || path == "") { return;}

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string Load(string path, string filename)
        {
            string fullPAth = Path.Combine(path, filename);
            if (File.Exists(fullPAth))
            {
                return File.ReadAllText(fullPAth);
            }
            else
            {
                CreateConfigFolderIfNotExists(path);
                Config a = new Config();
                Save(a, path, filename);
                return JsonSerializer.Serialize(a, new JsonSerializerOptions { WriteIndented = true }); ;
            }
        }

        public static Config GetConfigFile(string path, string filename)
        {
            if (File.Exists(Path.Combine(path, filename)))
            {
                Config loadedConfig;
                try
                {
                    string configAsJson = Load(path, filename);
                    loadedConfig = JsonSerializer.Deserialize<Config>(configAsJson)!;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading config file: {ex.Message}");
                    loadedConfig = new Config();
                }
                return loadedConfig;
            }else
            {
                Config defaultConfig = new Config();
    
                Save(defaultConfig, path, filename);
                return defaultConfig;
            }
        }
    }
}
