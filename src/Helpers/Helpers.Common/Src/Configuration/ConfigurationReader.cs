using Newtonsoft.Json;
using System.IO;

namespace Helpers.Common.Src.Configuration
{
    public static class ConfigurationReader
    {
        public static T ReadConfig<T>(string fileName = "config.json") where T : new()
        {
            if (File.Exists(fileName))
            {
                var text = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<T>(text);
            }
            else
            {
                var defaultJson = JsonConvert.SerializeObject(new T(), Formatting.Indented);
                File.WriteAllText(fileName, defaultJson);
                var defaultConfig = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<T>(defaultConfig);
            }
        }
    }
}
