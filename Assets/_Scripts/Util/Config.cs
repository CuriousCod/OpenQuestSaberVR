using System.IO;
using UnityEngine;

namespace _Scripts
{
    public class Config
    {
        private const string ConfigFolder = "Configs";
        private const string ConfigFileName = "Config.json";
        
        public ConfigData Data;
        
        public Config()
        {
            Data = LoadConfig();
        }
        
        private static string GetConfig()
        {
            return Path.Combine(ConfigFolder, ConfigFileName);
        }
        
        private void SaveConfig(ConfigData configData)
        {
            var json = JsonUtility.ToJson(configData);
            
            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
            }

            File.WriteAllText(GetConfig(), json);
        }
        
        private ConfigData LoadConfig()
        {
            var config = GetConfig();

            if (!File.Exists(config))
                SaveConfig(new ConfigData());

            var json = File.ReadAllText(config);
            return JsonUtility.FromJson<ConfigData>(json);
        }
        
    }

    public class ConfigData
    {
        public string SongFolder = Application.dataPath + "/Playlists";
    }
}